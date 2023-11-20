# Move-Generation2Master -SourcePath .\src\Storage -DestPath ..\tmp\src\Storage

Function Move-Generation2Master {
    Param(
        [string]
        ${SourcePath},
        [string]
        ${DestPath}
    )

    process {
        #Region Handle the module whoes folder is a subfolder of the module folder.
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
            New-Item "$DestPath\$ModuleName\Properties" -ItemType Directory
            New-Item "$DestPath\$ModuleName\help" -ItemType Directory
        }
        $Dir2Copy = @('custom', 'examples', 'exports', 'generated', 'internal', 'test', 'utils', 'docs')
        $File2Copy = @('*.ps1', 'how-to.md', 'readme.md', 'README.md', '*.psm1', '*.ps1xml', '*.psd1')
        $submoduleDirs = Get-ChildItem -Filter *.Autorest -Directory -Path $SourcePath
        $Psd1FolderPostfix = '';
        if (Test-Path "$DestPath/$ModuleName.Management/Az.$ModuleName.psd1") {
            $Psd1FolderPostfix = '.Management'
        }
        $DestPsd1Path = "$DestPath/$ModuleName$Psd1FolderPostfix/Az.$ModuleName.psd1"
        if (Test-Path $DestPsd1Path) {
            $Psd1Metadata = Import-LocalizedData -BaseDirectory "$DestPath/$ModuleName$Psd1FolderPostfix" -FileName "Az.$ModuleName.psd1"
        }
        else {
            $Psd1Metadata = Import-LocalizedData -BaseDirectory "$PSScriptRoot/Templates" -FileName "Module.psd1"
        }
        foreach ($submoduleDir in $submoduleDirs) {
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
            # Write-Host "Copying file from $SourcePath\$($submoduleDir.Name)\docs\* to $DestPath\$ModuleName$Psd1FolderPostfix\help"
            # Copy-Item -Path "$SourcePath\$($submoduleDir.Name)\docs\*" -Destination "$DestPath\$ModuleName$Psd1FolderPostfix\help" -Filter *-* -Force

            # Update psd1
            $SubModulePsd1MetaData = Import-LocalizedData -BaseDirectory (Join-Path -Path $SourcePath -ChildPath $submoduleDir.Name) -FileName "Az.$submoduleName.psd1"
            
            $Psd1Metadata.RequiredAssemblies = @($Psd1Metadata.RequiredAssemblies) + ("{0}\bin\Az.${submoduleName}.private.dll" -f $submoduleDir.Name)
            $Psd1Metadata.FormatsToProcess = @($Psd1Metadata.FormatsToProcess) + ("{0}\Az.${submoduleName}.format.ps1xml" -f $submoduleDir.Name)
            $Psd1Metadata.NestedModules = @($Psd1Metadata.NestedModules) + ("{0}\Az.${submoduleName}.psm1" -f $submoduleDir.Name)

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
            # Generate csproj file and add the dependency in the solution file
            Copy-Template -SourceName Az.ModuleName.csproj -DestPath (Join-Path $DestPath $submoduleDir.Name) -DestName "Az.$submoduleName.csproj" -RootModuleName $ModuleName -ModuleName $submoduleName -ModuleFolder $submoduleDir.Name
        }

        $slnFilePath = "$DestPath\$ModuleName.sln"
        if (-not (Test-Path -path $slnFilePath)) {
            # It means there is no handcraft module for this module, so we need to create the solution file and other related files
            Copy-Template -SourceName ChangeLog.md -DestPath $DestPath\$ModuleName -DestName ChangeLog.md -ModuleName $ModuleName
            Copy-Template -SourceName Module.psd1 -DestPath $DestPath\$ModuleName -DestName "Az.$ModuleName.psd1" -ModuleName $ModuleName
            Copy-Template -SourceName HandcraftedModule.csproj -DestPath $DestPath\$ModuleName -DestName "$ModuleName.csproj" -ModuleName $ModuleName
            Copy-Template -SourceName ModulePage.md -DestPath $DestPath\$ModuleName\help -DestName "Az.$ModuleName.md" -ModuleName $ModuleName
            Copy-Template -SourceName AssemblyInfo.cs -DestPath $DestPath\$ModuleName\Properties -DestName AssemblyInfo.cs -ModuleName $ModuleName

            dotnet new sln -n $ModuleName -o $DestPath
            Get-ChildItem -Filter *.csproj -File -Path "$DestPath\..\Accounts" -Recurse | ForEach-Object {
                if ($_.FullName -notmatch "Test")
                {
                    dotnet sln $slnFilePath add $_.FullName --solution-folder Accounts
                }
            }
            Get-ChildItem -Filter *.csproj -File -Path $DestPath -Recurse | ForEach-Object {
                dotnet sln $slnFilePath add $_.FullName
            }
        }
        
        $Psd1Metadata.RequiredAssemblies = Unique-PathList $Psd1Metadata.RequiredAssemblies
        $Psd1Metadata.FormatsToProcess = Unique-PathList $Psd1Metadata.FormatsToProcess
        $Psd1Metadata.NestedModules = Unique-PathList $Psd1Metadata.NestedModules
        
        New-ModuleManifest -Path $DestPsd1Path @Psd1Metadata
        
        if (-not (Test-Path "$DestPath\$ModuleName\Properties")) {
            New-Item "$DestPath\$ModuleName\Properties" -ItemType Directory
            # Copy the assemblyinfo file
            Copy-Template -SourceName AssemblyInfo.cs -DestPath "$DestPath\$ModuleName\Properties" -DestName AssemblyInfo.cs -ModuleName $submoduleName
            
        }
        #update module page
        dotnet build $slnFilePath
        # start a job to update markdown help module, since we can not uninstall a module in the same process.
        $job = start-job {
            param(
                [string] $ModuleName,
                [string] $DestPath,
                [string] $Psd1FolderPostfix
            )
            $psd1Path = "$DestPath\..\..\artifacts\Debug\Az.$ModuleName\Az.$ModuleName.psd1"
            $assemblyToRemove = "YamlDotNet.dll"
            $psd1Data = Import-PowerShellDataFile -Path $psd1Path
            if ($psd1Data.ContainsKey('RequiredAssemblies') -and $psd1Data.RequiredAssemblies -contains $assemblyToRemove) {
                $psd1Data.RequiredAssemblies = $psd1Data.RequiredAssemblies | Where-Object { $_ -ne $assemblyToRemove }
                Update-ModuleManifest -Path $psd1Path -RequiredAssemblies $psd1Data.RequiredAssemblies
            }
            Import-Module $psd1Path
            Import-Module platyPS
            Update-MarkdownHelpModule -Path "$DestPath\$ModuleName$Psd1FolderPostfix\help" -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -ExcludeDontShow
        } -ArgumentList $ModuleName, $DestPath, $Psd1FolderPostfix

        $job | Wait-Job | Receive-Job
    }
}

Function Unique-PathList {
    Param(
        [string[]]
        $PathList
    )

    return $PathList | ForEach-Object { return $_.Replace('/', '\') } | Select-Object -Unique | Sort-Object
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
