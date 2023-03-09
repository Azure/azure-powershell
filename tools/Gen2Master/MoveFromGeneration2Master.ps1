Function Move-Generation2Master {
    Param(
        [string]
        ${SourcePath},
        [string]
        ${DestPath}
    )

    process {
        #Region Handle the hybrid module whoes folder is a subfolder of the module folder.
        $ModuleName = $SourcePath.Replace('/', '\').Split('\src\')[1].Split('\')[0]
        $SourcePsd1Path = Get-ChildItem -path $SourcePath -filter Az.$ModuleName.psd1 -Recurse
        $FolderPathRelativeToSrc = $SourcePsd1Path.Directory.FullName.Replace('/', '\').Split('\src\')[1]
        if ($FolderPathRelativeToSrc -eq $ModuleName) {
            $IsHybridModule = $False
        }
        else {
            $IsHybridModule = $True
        }
        $SourcePath = $SourcePsd1Path.Directory.FullName
        If (-not ($DestPath.Trim("\").Split("\")[-1] -eq $ModuleName)) {
            $DestPath = Join-Path -Path $DestPath -ChildPath $FolderPathRelativeToSrc
        }
        
        $DestParentPath = $DestPath
        While ("" -ne $DestParentPath) {
            $DestAccountsPath = Join-Path -Path $DestParentPath -ChildPath Accounts
            if (-not (Test-Path -Path $DestAccountsPath)) {
                $DestParentPath = Split-Path -path $DestParentPath -Parent
            }
            else {
                Break
            }
        }
        #EndRegion
        If (-not (Test-Path $DestPath)) {
            New-Item -ItemType Directory -Path $DestPath -Force
        }
        $Dir2Copy = @('custom', 'examples', 'exports', 'generated', 'internal', 'test', 'utils', 'UX')
        Foreach ($Dir in $Dir2Copy) {
            $SourceItem = Join-Path -Path $SourcePath -ChildPath $Dir
            $DestItem = Join-Path -Path $DestPath -ChildPath $Dir
            If (Test-Path $DestItem) {
                Remove-Item -Path $DestItem -Recurse
            }
            Write-Host "Copying folder: $SourceItem." -ForegroundColor Yellow
            if (Test-Path -Path $SourceItem) {
                Copy-Item -Recurse -Path $SourceItem -Destination $DestItem
            }
        }
        #Region Clean Local Modules
        $LocalModulesPath = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'generated') -ChildPath 'modules'
        If (Test-Path $LocalModulesPath) {
            Write-Host "Removing local modules: $LocalModulesPath." -ForegroundColor Yellow
            Remove-Item -Path $LocalModulesPath -Recurse -Force
        }
        #EndRegion
        #Region copy docs
        $SourceItem = Join-Path -Path $SourcePath -ChildPath 'docs'
        $DestItem = Join-Path -Path $DestPath -ChildPath 'help'
        If (Test-Path $DestItem) {
            Remove-Item -Path $DestItem -Recurse
        }
        Write-Host "Copying docs: $SourceItem." -ForegroundColor Yellow
        Copy-Item -Recurse -Path $SourceItem -Destination $DestItem
        #EndRegion
        $File2Copy = @('*.ps1', 'how-to.md', 'readme.md', 'README.md', '*.psm1', '*.ps1xml')
        Foreach ($File in $File2Copy) {
            $SourceItem = Join-Path -Path $SourcePath -ChildPath $File
            $DestItem = Join-Path -Path $DestPath -ChildPath $File
            If (Test-Path $DestItem) {
                Remove-Item -Path $DestItem
            }
            Write-Host "Copying file: $SourceItem" -ForegroundColor Yellow
            Copy-Item -Path $SourceItem -Destination $DestPath
        }

        #Region verify psd1 file
        Write-Host "Copying Az.$ModuleName.psd1." -ForegroundColor Yellow
        $ModuleGuid = $Null
        $RequiredModule = $Null
        $DestPsd1Path = Join-Path -Path $DestPath -ChildPath "Az.$ModuleName.psd1"
        $SourcePsd1Path = Join-Path -Path $SourcePath -ChildPath "Az.$ModuleName.psd1"
        If (Test-Path $DestPsd1Path) {
            $Psd1Metadata = Import-LocalizedData -BaseDirectory $DestPath -FileName "Az.$ModuleName.psd1"
            $ModuleGuid = $Psd1Metadata.GUID
            $RequiredModule = $Psd1Metadata.RequiredModules
            $Psd1Version = $Psd1Metadata.ModuleVersion
        }
        $Psd1Metadata = Import-LocalizedData -BaseDirectory $SourcePath -FileName "Az.$ModuleName.psd1"
        If ($Null -ne $Psd1Version) {
            $Psd1Metadata.ModuleVersion = $Psd1Version
        }
        If ($Null -ne $ModuleGuid) {
            $Psd1Metadata.GUID = $ModuleGuid
        }
        If ($Null -eq $RequiredModule) {
            $AccountsModulePath = [System.IO.Path]::Combine($DestParentPath, 'Accounts', 'Accounts')
            $AccountsMetadata = Import-LocalizedData -BaseDirectory $AccountsModulePath -FileName "Az.Accounts.psd1"
            $RequiredModule = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = $AccountsMetadata.ModuleVersion; })
        }
        If ($Null -ne $RequiredModule) {
            $Psd1Metadata.RequiredModules = $RequiredModule
        }
        If ($Psd1Metadata.FunctionsToExport -Contains "*") {
            $Psd1Metadata.FunctionsToExport = ($Psd1Metadata.FunctionsToExport | Where-Object { $_ -ne "*" })
        }
        Update-ModuleManifest -Path $SourcePsd1Path @Psd1Metadata
        Copy-Item -Path $SourcePsd1Path -Destination $DestPsd1Path
        #EndRegion

        #Region Remove unnecessary readme.md
        $ModuleReadmeInHelp = Join-Path -Path (Join-Path -Path $DestPath -ChildPath 'help') -ChildPath "Az.$ModuleName.md"
        Get-ChildItem -Path (Join-Path -Path $DestPath -ChildPath 'help') -Recurse -Include 'readme.md' | Remove-Item -ErrorAction SilentlyContinue
        If ($Null -ne $ModuleGuid) {
            $ReadmeContent = Get-Content -Path $ModuleReadmeInHelp
            $ReadmeContent -replace "Module Guid: [0-9a-z\-]+", "Module Guid: $ModuleGuid" | Set-Content -Path $ModuleReadmeInHelp
        }
        Get-ChildItem -Path (Join-Path -Path $DestPath -ChildPath 'examples') -Recurse -Include 'readme.md' | Remove-Item -ErrorAction SilentlyContinue
        #EndRegion

        #Region generate-info.json Here have a issue that user may not use latest version to generate the code.
        $generateInfo = [ordered]@{}
        $content = Get-Content README.md
        $commitId = [System.Text.RegularExpressions.Regex]::New("(?i)\bbranch\b:[ \t]*([0-9a-zA-Z]+)").Matches($content) | % {$_.groups[1].Value}
        if ($commitId -eq $null -or $commitId -eq "main")
        {
            $repo = "https://github.com/Azure/azure-rest-api-specs"
            $commitId = git ls-remote $repo HEAD
        }
        $generateInfo.Add("swagger_commit", $commitId.Substring(0, 40))
        $generateInfo.Add("node", (node --version))
        $autorest_info = (npm ls -g @autorest/autorest).Split('@')
        $generateInfo.Add("autorest", ($autorest_info[$autorest_info.count - 2]).trim())
        $extensions = ls ~/.autorest
        ForEach ($ex in $extensions) {
            if ($Null -eq $ex.Name) {
                continue
            }
            $info = $ex.Name.Split('@')
            $packageName = $info[1]
            $version = $info[2]
            if ($generateInfo.Contains($packageName)) {
                $preVersion = $generateInfo[$packageName]
                $versionFields = $version.Split('.')
                $preVersionFields = $preVersion.Split('.')
                if (($versionFields[0] -lt $preVersionFields[0]) -or ($versionFields[1] -lt $preVersionFields[1]) -or ($versionFields[2] -lt $preVersionFields[2])) {
                    $generateInfo[$packageName] = $version
                }
            }
            else {
                $generateInfo.Add($packageName, $version)
            }
        }
        Set-Content -Path (Join-Path $DestPath generate-info.json) -Value (ConvertTo-Json $generateInfo)
        #EndRegion

        #Region update azure-powershell-modules.md
        
        #EndRegion

        #Region update GeneratedModuleList
        $GeneratedModuleListPath = [System.IO.Path]::Combine($PSScriptRoot, "..", "GeneratedModuleList.txt")
        $Modules = (Get-Content $GeneratedModuleListPath) + "Az.$ModuleName"
        $NewModules = $Modules | Sort-Object | Get-Unique
        Set-Content -Path $GeneratedModuleListPath -Value $NewModules
        #EndRegion

        if ($IsHybridModule) {
            Copy-Template -SourceName Az.ModuleName.hybrid.csproj -DestPath $DestPath -DestName "Az.$ModuleName.csproj" -ModuleName $ModuleName
        }
        else {
            Copy-Template -SourceName Az.ModuleName.csproj -DestPath $DestPath -DestName "Az.$ModuleName.csproj" -ModuleName $ModuleName
        }
        Copy-Template -SourceName Changelog.md -DestPath $DestPath -DestName Changelog.md -ModuleName $ModuleName
        #Region create a solution file for module and add the related csproj files to this solution.
        dotnet new sln -n $ModuleName -o $DestPath --force
        $SolutionPath = Join-Path -Path $DestPath -ChildPath $ModuleName.sln
        foreach ($DependenceCsproj in (Get-ChildItem -path $DestAccountsPath -Recurse -Filter *.csproj -Exclude *test*)) {
            dotnet sln $SolutionPath add $DependenceCsproj
        }
        dotnet sln $SolutionPath add (Join-Path -Path $DestPath -ChildPath Az.$ModuleName.csproj)
        #EndRegion

        $PropertiesPath = Join-Path -Path $DestPath -ChildPath "Properties"
        If (-not (Test-Path $PropertiesPath)) {
            New-Item -ItemType Directory -Path $PropertiesPath
        }
        Copy-Template -SourceName AssemblyInfo.cs -DestPath $PropertiesPath -DestName AssemblyInfo.cs -ModuleName $ModuleName
        Update-MappingJson -ModuleName $ModuleName
    }
}

Function Move-Generation2MasterHybrid {
    Param(
        [string]
        ${SourcePath},
        [string]
        ${DestPath}
    )

    process {
        #Region Handle the hybrid module whoes folder is a subfolder of the module folder.
        $ModuleName = $SourcePath.Replace('/', '\').Split('\src\')[1].Split('\')[0]

        $DestParentPath = $DestPath
        While ("" -ne $DestParentPath) {
            $DestAccountsPath = Join-Path -Path $DestParentPath -ChildPath Accounts
            if (-not (Test-Path -Path $DestAccountsPath)) {
                $DestParentPath = Split-Path -path $DestParentPath -Parent
            }
            else {
                Break
            }
        }
        #EndRegion
        If (-not (Test-Path $DestPath)) {
            New-Item -Type Directory -Path $DestPath -Force
        }
        $Dir2Copy = @('custom', 'examples', 'exports', 'generated', 'internal', 'test', 'utils', 'docs')
        $submoduleDirs = Get-ChildItem -Filter *.Autorest -Directory -Path $SourcePath
        foreach ($submoduleDir in $submoduleDirs) {
            $SolutionPath = Join-Path -Path $DestPath -ChildPath "$ModuleName.sln"

            if (-not (Test-Path -path $SolutionPath)) {
                # It means there is no handcraft module for this module, so we need to create the solution file and other related files
                Copy-Template -SourceName ModuleName.sln -DestPath $DestPath -DestName "$ModuleName.sln" -ModuleName $ModuleName
                Copy-Template -SourceName Changelog.md -DestPath $DestPath\$ModuleName -DestName Changelog.md -ModuleName $ModuleName
                Copy-Template -SourceName Module.psd1 -DestPath $DestPath\$ModuleName -DestName "Az.$ModuleName.psd1" -ModuleName $ModuleName
                Copy-Template -SourceName HandcraftedModule.csproj -DestPath $DestPath\$ModuleName -DestName "$ModuleName.csproj" -ModuleName $ModuleName
                Copy-Template -SourceName ModulePage.md -DestPath $DestPath\$ModuleName\help -DestName "Az.$ModuleName.md" -ModuleName $ModuleName
                Copy-Template -SourceName AssemblyInfo.cs -DestPath $DestPath\$ModuleName\Properties -DestName AssemblyInfo.cs -ModuleName $ModuleName
            }
            $psd1File = Get-ChildItem -Filter *.psd1 -File -Path $submoduleDir
            write-host ("psd1 file name {0}" -f $psd1File.Name)
            $submoduleName = $psd1File.Name.Split('.')[-2]
            Foreach ($Dir in $Dir2Copy) {
                $SourceItem = Join-Path -Path (Join-Path -Path $SourcePath -ChildPath $submoduleDir.Name) -ChildPath $Dir
                $DestItem = Join-Path -Path (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name) -ChildPath $Dir
                If (Test-Path $DestItem) {
                    Remove-Item -Path $DestItem -Recurse
                }
                Write-Host "Copying folder: $SourceItem." -ForegroundColor Yellow
                if (Test-Path -Path $SourceItem) {
                    Copy-Item -Recurse -Path $SourceItem -Destination $DestItem
                }
            }
            #Region Clean Local Modules
            $LocalModulesPath = Join-Path -Path (Join-Path -Path (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name) -ChildPath 'generated') -ChildPath 'modules'
            If (Test-Path $LocalModulesPath) {
                Write-Host "Removing local modules: $LocalModulesPath." -ForegroundColor Yellow
                Remove-Item -Path $LocalModulesPath -Recurse -Force
            }
            #EndRegion
            $File2Copy = @('*.ps1', 'how-to.md', 'readme.md', 'README.md', '*.psm1', '*.ps1xml')
            Foreach ($File in $File2Copy) {
                $SourceItem = Join-Path -Path (Join-Path -Path $SourcePath -ChildPath $submoduleDir.Name) -ChildPath $File
                $DestItem = Join-Path -Path (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name) -ChildPath $File
                If (Test-Path $DestItem) {
                    Remove-Item -Path $DestItem
                }
                Write-Host "Copying file: $SourceItem" -ForegroundColor Yellow
                Copy-Item -Path $SourceItem -Destination (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name)
            }

            #copy generated docs to help folder
            #Assume psd1 and help are in the same folder.
            $Psd1FolderPostfix = '';
            if (-not (Test-Path (Join-Path -Path (Join-Path -Path $DestPath -ChildPath $ModuleName) -ChildPath "Az.$ModuleName.psd1"))) {
                $Psd1FolderPostfix = '.Management'
            }
            Copy-Item -Path ("$SourcePath\{0}\docs\*" -f $submoduleDir.Name) -Destination "$DestPath\$ModuleName$Psd1FolderPostfix\help" -Filter *-*

            #Region generate-info.json Here have a issue that user may not use latest version to generate the code.
            $generateInfo = @{}
            $repo = "https://github.com/Azure/azure-rest-api-specs"
            $commit = git ls-remote $repo HEAD
            $generateInfo.Add("swagger_commit", $commit.Substring(0, 40))
            $generateInfo.Add("node", (node --version))
            $autorest_info = (npm ls -g @autorest/autorest).Split('@')
            $generateInfo.Add("autorest", ($autorest_info[$autorest_info.count - 2]).trim())
            $extensions = ls ~/.autorest
            ForEach ($ex in $extensions) {
                if ($Null -eq $ex.Name) {
                    continue
                }
                $info = $ex.Name.Split('@')
                $packageName = $info[1]
                $version = $info[2]
                if ($generateInfo.ContainsKey($packageName)) {
                    $preVersion = $generateInfo[$packageName]
                    $versionFields = $version.Split('.')
                    $preVersionFields = $preVersion.Split('.')
                    if (($versionFields[0] -lt $preVersionFields[0]) -or ($versionFields[1] -lt $preVersionFields[1]) -or ($versionFields[2] -lt $preVersionFields[2])) {
                        $generateInfo[$packageName] = $version
                    }
                }
                else {
                    $generateInfo.Add($packageName, $version)
                }
            }
            Set-Content -Path (Join-Path (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name) generate-info.json) -Value (ConvertTo-Json $generateInfo)
            #EndRegion

            # Generate csproj file and add the dependency in the solution file
            Copy-Template -SourceName Az.ModuleName.hybrid.csproj -DestPath (Join-Path $DestPath $submoduleDir.Name) -DestName "Az.$submoduleName.csproj" -RootModuleName $ModuleName -ModuleName $submoduleName -ModuleFolder $submoduleDir.Name


            dotnet sln $SolutionPath add (Join-Path -Path (Join-Path -Path $DestPath -ChildPath $submoduleDir.Name) -ChildPath Az.$submoduleName.csproj)

            # Update psd1
            $DestPsd1Path = Join-Path -Path (Join-Path -Path $DestPath -ChildPath $ModuleName$Psd1FolderPostfix) -ChildPath "Az.$ModuleName.psd1"
            $Psd1Metadata = Import-LocalizedData -BaseDirectory (Join-Path -Path $DestPath -ChildPath $ModuleName$Psd1FolderPostfix) -FileName "Az.$ModuleName.psd1"
            $SubModulePsd1MetaData = Import-LocalizedData -BaseDirectory (Join-Path -Path $SourcePath -ChildPath $submoduleDir.Name) -FileName "Az.$submoduleName.psd1"
            if (!@($Psd1Metadata.RequiredAssemblies).Contains(("{0}\bin\Az.${submoduleName}.private.dll" -f $submoduleDir.Name))) {
                $Psd1Metadata.RequiredAssemblies = @($Psd1Metadata.RequiredAssemblies) + ("{0}\bin\Az.${submoduleName}.private.dll" -f $submoduleDir.Name)
            }
            if (!@($Psd1Metadata.FormatsToProcess).Contains(("{0}\Az.${submoduleName}.format.ps1xml" -f $submoduleDir.Name))) {
                $Psd1Metadata.FormatsToProcess = @($Psd1Metadata.FormatsToProcess) + ("{0}\Az.${submoduleName}.format.ps1xml" -f $submoduleDir.Name)
            }
            if (!@($Psd1Metadata.NestedModules).Contains(("{0}\Az.${submoduleName}.psm1" -f $submoduleDir.Name))) {
                $Psd1Metadata.NestedModules = @($Psd1Metadata.NestedModules) + ("{0}\Az.${submoduleName}.psm1" -f $submoduleDir.Name)
            }
            foreach ($func in $SubModulePsd1MetaData.FunctionsToExport) {
                if (!@($Psd1Metadata.FunctionsToExport).Contains($func) -and ($func -ne '*')) {
                    $Psd1Metadata.FunctionsToExport = @($Psd1Metadata.FunctionsToExport) + $func
                }
            }
            foreach ($alias in $SubModulePsd1MetaData.AliasesToExport) {
                if (!@($Psd1Metadata.AliasesToExport).Contains($alias) -and ($alias -ne '*')) {
                    $Psd1Metadata.AliasesToExport = @($Psd1Metadata.AliasesToExport) + $alias
                }
            }
            if ($null -ne $Psd1Metadata.PrivateData) {
                foreach ($pKey in $Psd1Metadata.PrivateData.PSData.Keys) {
                    $Psd1Metadata.$pKey = $Psd1Metadata.PrivateData.PSData.$pKey
                }
                $Psd1Metadata.Remove("PrivateData")
            }
            New-ModuleManifest -Path $DestPsd1Path @Psd1Metadata
            
            # Copy the assemblyinfo file
            Copy-Template -SourceName AssemblyInfo.cs -DestPath (Join-Path (Join-Path $DestPath $submoduleDir.Name) "Properties") -DestName AssemblyInfo.cs -ModuleName $submoduleName
        }

        #update module page
        dotnet build "$DestPath\$ModuleName.sln"
        # start a job to update markdown help module, since we can not uninstall a module in the same process.
        $job = start-job {
            param(
                [string] $ModuleName,
                [string] $DestPath,
                [string] $Psd1FolderPostfix
            )
            Import-Module "$DestPath\..\..\artifacts\Debug\Az.$ModuleName\Az.$ModuleName.psd1"
            Update-MarkdownHelpModule -Path "$DestPath\$ModuleName$Psd1FolderPostfix\help" -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow         
        } -ArgumentList $ModuleName, $DestPath, $Psd1FolderPostfix

        $job | Wait-Job | Receive-Job
        # Import-Module "$DestPath\..\..\artifacts\Debug\Az.$ModuleName\Az.$ModuleName.psd1"
        # Update-MarkdownHelpModule -Path "$DestPath\$ModuleName\help" -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow
    }
}

Function Update-MappingJson {
    Param(
        [string]
        ${ModuleName}
    )
    process {
        Write-Host "Updating MappingJson: CreateMappings_rules.json." -ForegroundColor Yellow
        $MappingPath = Join-Path -Path (Join-Path -Path $PSScriptRoot -ChildPath '..') -ChildPath "CreateMappings_rules.json"
        $MappingObject = Get-Content -Path $MappingPath | ConvertFrom-Json
        Foreach ($Item in $MappingObject) {
            If ($ModuleName -eq $Item.regex -or $ModuleName -eq $Item.module) {
                return
            }
        }
        $MappingObject = $MappingObject + @{module = $ModuleName; alias = $ModuleName }
        ConvertTo-Json $MappingObject -Depth 1 | Set-Content -Path $MappingPath
    }
}

Function Copy-Template {
    Param(
        [string]
        $SourceName,
        [string]
        $DestPath,
        [string]
        $DestName,
        [string]
        $ModuleName,
        [string]
        $RootModuleName,
        [string]
        $ModuleFolder
    )
    process {
        $DestPath = Join-Path -Path $DestPath -ChildPath $DestName
        If (-not (Test-Path -Path $DestPath)) {
            Write-Host "Copying template: $SourceName." -ForegroundColor Yellow
            New-Item -Path $DestPath -Force
            $TemplatePath = Join-Path -Path (Join-Path -Path $PSScriptRoot -ChildPath "Templates") -ChildPath $SourceName
            $TemplateContent = Get-Content -Path $TemplatePath
            If ($TemplateContent -Match "{GUID}") {
                $TemplateContent = $TemplateContent -replace '{GUID}', (New-Guid).Guid
            }
            if ($null -eq $RootModuleName) {
                $RootModuleName = $ModuleName
            }
            if ($null -eq $ModuleFolder) {
                $ModuleFolder = $ModuleName + ".Autorest"
            }
            $TemplateContent = $TemplateContent -replace '{ModuleNamePlaceHolder}', $ModuleName
            $TemplateContent = $TemplateContent -replace '{LowCaseModuleNamePlaceHolder}', $ModuleName.ToLower()
            $TemplateContent = $TemplateContent -replace '{ModuleFolderPlaceHolder}', $ModuleFolder
            $TemplateContent -replace '{RootModuleNamePlaceHolder}', $RootModuleName | Set-Content -Path $DestPath

        }
    }
}
