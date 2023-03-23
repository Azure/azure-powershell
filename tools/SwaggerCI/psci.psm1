function Invoke-SwaggerCI {
    param(
        [string] $ConfigFilePath = "./generateInput.json",
        [string] $ResultFilePath = "./generateOutput.json"
    )

    Install-Module powershell-yaml -Force
    Import-Module powershell-yaml

    # Get the readme.md files need to be run from config file
    $config = Get-Content $ConfigFilePath | ConvertFrom-Json

    $packages = @()

    # region Phase 1
    foreach ($rd in $config.relatedReadmeMdFiles) {
        $moduleName = $rd.split("/")[1] + ".DefaultTag"
        # Set moduleName to modulePath at first
        $rdFolder = Join-Path $config.specFolder (Split-Path $rd -Parent)
        $rdPath = Join-Path $rdFolder "readme.md"
        $psRdPath = Join-Path $rdFolder "readme.powershell.md"

        #create the a folder for this RP
        $moduleFolder = Join-Path (Join-Path (Get-Location).Path swaggerci) $moduleName
        New-Item -Path $moduleFolder -ItemType Directory -Force

        #populate read.md.template
        $rdContent = Get-Content ./tools/SwaggerCI/readme.md.template
        $rdContent = $rdContent.replace('$(readme.md)', $rdPath)
        $rdContent = $rdContent.replace('$(readme.powershell.md)', $psRdPath)
        $rdContent | Out-File -Path (Join-Path $moduleFolder "readme.md")

        $package = Build-Module -moduleName $moduleName -moduleFolder $moduleFolder -rd $rd
        $packages += $package
    }
    # endregion

    # region Phase 2
    $swaggerSpecifcationPath = Join-Path (Get-Item $config.specFolder).FullName "specification"
    $azurePowerShellSourcePath = Join-Path (Get-Location).Path "src"

    $affectModule = Get-AffectModule -changedFiles $config.changedFiles -relatedReadmeMdFiles $config.relatedReadmeMdFiles -swaggerSpecifcationPath $swaggerSpecifcationPath -azurePowerShellSourcePath $azurePowerShellSourcePath

    foreach ($moduleName in $affectModule.keys) {
        $moduleFolder = (Get-ChildItem -Recurse -Path src -Directory -Filter $moduleName).FullName
        $rd = (Get-ChildItem -path $moduleFolder -Filter readme.md).FullName
        $noprofileMdPath = (Get-Item "tools/SwaggerCI/readme.azure.noprofile.md").FullName
        Write-Host $noprofileMdPath
        #populate read.md.template
        $rdContent = Get-Content $rd -Raw
        $rdContent = [regex]::Replace($rdContent, "\$.*readme\.azure\.noprofile\.md", $noprofileMdPath)
        $rdContent = $rdContent.replace("`$`(repo`)", (Get-Item $config.specFolder).FullName)
        $rdContent | Set-Content -Path $rd

        $package = Build-Module -moduleName $moduleName -moduleFolder $moduleFolder -rd $rd
        $packages += $package
    }

    $result = @{
        packages = $packages
    }
    #endregion

    $result | ConvertTo-Json -Depth 5 | Out-File -Path $ResultFilePath
}

function Build-Module {
    param(
        [string]
        $moduleName,
        [string]
        $moduleFolder,
        [string]
        $rd
    )
    try {
        Write-Host "================================="
        Write-Host $moduleName
        Write-Host $moduleFolder
        Write-Host $rd
        Write-Host "================================="
        #generate code
        $Null = autorest (Join-Path $moduleFolder "readme.md") --version:3.7.6
        #Build the module
        $Null = . (Join-Path $moduleFolder "build-module.ps1")
        if ($LASTEXITCODE -ne 0) {
            # throw except if build fails
            throw
        }
        #Override the generated .gitignore file
        cp ./tools/SwaggerCI/gitignoreconf (Join-Path $moduleFolder ".gitignore")
        #Package
        $Null = . (Join-Path $moduleFolder "pack-module.ps1")

        $package = Get-ChildItem -Path $moduleFolder -Recurse -Filter "*.nupkg"
        $packageName = $package.Name
        $packagePath = Split-Path $package.FullName -Parent
        $packageFolder = [System.IO.Path]::GetRelativePath((Get-Location), $packagePath)

        #Generate result
        $downloadUrl = $config.installInstructionInput.downloadUrlPrefix + "Az.$moduleName/$packageName"
        $downloadCmd = "curl -L $downloadUrl -o $packageName"
        $package = @{
            packageName = "Az.$moduleName"
            path = @([System.IO.Path]::GetRelativePath((Get-Location), $moduleFolder))
            readmeMd = @($rd)
            artifacts = @("$packageFolder/$packageName")
            installInstructions = @{full = "Please download the package through the curl command '$downloadCmd', and then you could have a try locally."}
            result = "succeeded"
        }
        return $package
    } catch {
        Write-Warning "Azure PowerShell CI validation failed for Az.$moduleName"
        $package = @{
            packageName = "Az.$moduleName"
            path = @("swaggerci/$moduleName")
            readmeMd = @($rd)
            result = "failed"
        }
        return $package
    }
}

function Get-YamlConfig {
    param(
        [string]
        $readmePath
    )
    $content = Get-Content $readmePath -Raw
    $yamlBlockList = [regex]::Matches($content, "(?s)``````\s*yaml(?: (?<tag>.+?))?\r?\n(?<code>.*?)``````")
    return $yamlBlockList | ForEach-Object { return @{
            tag  = $_.Groups["tag"].Value
            code = ($_.Groups["code"].Value | ConvertFrom-Yaml)
        } }
}

function Get-RequiredReadmeList {
    param(
        [hashtable[]]
        $yamlConfig
    )
    [array]$requiredReadmeList = $yamlConfig.require
    | Where-Object { ($_.endswith('readme.md') -or ($_.endswith('readme.powershell.md'))) } 
    | ForEach-Object { 'specification' + $_.split('specification')[1] }
    if ($null -ne $yamlConfig.'try-require') {
        $requiredReadmeList += $yamlConfig.'try-require'
        | Where-Object { ($_.endswith('readme.md') -or ($_.endswith('readme.powershell.md'))) } 
        | ForEach-Object { 'specification' + $_.split('specification')[1] }
    }
    return $requiredReadmeList
}

function Get-InputJsonInSwaggerReadmeTag {
    param(
        [string]
        $readmePath,
        [string]
        $tag
    )
    $yamlConfig = Get-YamlConfig $readmePath
    $config = $yamlConfig | Where-Object { ($_.tag -eq "") -and ($_.code."openapi-type" -eq "arm") }
    if ($config.Length -ne 1) {
        return @()
    }
    else {
        if ($config.data."openapi-type" -eq "data-plane") {
            return @()
        }
        if (($tag -eq $null) -or ($tag -eq "")) {
            $tag = $config.code.tag
        }
        $config = $yamlConfig | Where-Object { $_.tag -eq "`$(tag) == '$tag'" }
        if ($config.Length -ne 1) {
            throw "There should be only one tag $defaultTag in $readmePath"
        }
        $jsonList = $config.code."input-file"
        if ($jsonList.GetType() -ne [System.Array]) {
            $jsonList = @($jsonList)
        }
        return $jsonList
    }
}

# Create a mapping, key is the path of readme.md, value is the input json file list in default tag
function New-SwaggerInputFileMapping {
    param(
        [string]
        $swaggerSpecifcationPath,
        [System.Collections.Specialized.IOrderedDictionary]
        $swaggerReadMeAzPowerShellModuleMapping
    )
    Write-Warning $swaggerSpecifcationPath
    $allReadMeInSwagger = Get-ChildItem -Recurse -Path $swaggerSpecifcationPath -Filter "readme.md" | ForEach-Object { $_.FullName }
    $allReadMeInSwagger += Get-ChildItem -Recurse -Path $swaggerSpecifcationPath -Filter "readme.powershell.md" | ForEach-Object { $_.FullName }
    $mapping = [ordered]@{}
    
    foreach ($readmePath in $allReadMeInSwagger) {
        try {
            [array]$jsonList = Get-InputJsonInSwaggerReadmeTag -readmePath $readmePath -tag $swaggerReadMeAzPowerShellModuleMapping[$readmePath].tag
            if ($jsonList.Length -eq 0) {
                continue
            }
            $key = "specification" + $readmePath.split('specification')[1].Replace("\", "/")
            $mapping[$key] = $jsonList
        }
        catch {
            Write-Warning $_
        }
    }

    return $mapping
}

# Create a mapping, the key is the path of readme.md in swagger, the value is the module name and tag in azure-powershell
function New-SwaggerReadMeAzPowerShellModuleMapping {
    param(
        [string]
        $azurePowerShellSourcePath
    )
    $readmeList = Get-ChildItem -Recurse -Path $azurePowerShellSourcePath -Filter *.psd1 | Where-Object { Test-Path (Join-Path $_.Directory -ChildPath README.md) } | ForEach-Object { Join-Path $_.Directory -ChildPath README.md }
    $mapping = [ordered]@{}

    foreach ($readme in $readmeList) {
        $yamlConfig = Get-YamlConfig $readme
        [array]$requiredReadmeList = Get-RequiredReadmeList $yamlConfig.code
        foreach ($requiredReadme in $requiredReadmeList) {
            $moduleName = Split-Path -Parent -Path $readme | Split-Path -Leaf
            if ($mapping.Contains($requiredReadme)) {
                $mapping[$requiredReadme] += @{
                    moduleName = $moduleName
                    tag = $yamlConfig.code.tag
                }
            }
            else {
                $mapping[$requiredReadme] = @(@{
                    moduleName = $moduleName
                    tag = $yamlConfig.code.tag
                })
            }
        }
    }

    return $mapping
}

function Get-AffectedReadme {
    param(
        [string[]]
        $changedFiles,
        [string[]]
        $relatedReadmeMdFiles,
        [System.Collections.Specialized.IOrderedDictionary]
        $swaggerInputFileMapping
    )
    $affectedReadme = New-Object System.Collections.Generic.HashSet[string]

    foreach ($readmePath in $relatedReadmeMdFiles) {
        if ($changedFiles -contains $readmePath) {
            $Null = $affectedReadme.Add($readmePath)
        }
        else {
            if (-not $swaggerInputFileMapping.Contains($readmePath)) {
                Write-Warning "Cannot find the input json file list in $readmePath"
                continue
            }

            $relatedJsonList = $swaggerInputFileMapping[$readmePath]
            foreach ($jsonPath in $relatedJsonList) {
                if ($changedFiles -contains $jsonPath) {
                    $Null = $affectedReadme.Add($readmePath)
                    break
                }
            }
        }
    }

    return $affectedReadme
}

function Get-AffectModule {
    param(
        [string[]]
        $changedFiles,
        [string[]]
        $relatedReadmeMdFiles,
        [string]
        $swaggerSpecifcationPath,
        [string]
        $azurePowerShellSourcePath
    )
    $swaggerReadMeAzPowerShellModuleMapping = New-SwaggerReadMeAzPowerShellModuleMapping $azurePowerShellSourcePath
    $swaggerInputFileMapping = New-SwaggerInputFileMapping -SwaggerSpecifcationPath $swaggerSpecifcationPath -SwaggerReadMeAzPowerShellModuleMapping $swaggerReadMeAzPowerShellModuleMapping
    $affectedReadme = Get-AffectedReadme -changedFiles $changedFiles -relatedReadmeMdFiles $relatedReadmeMdFiles -SwaggerInputFileMapping $swaggerInputFileMapping
    $affectedModule = @{}
    foreach ($readme in $affectedReadme) {
        if ($swaggerReadMeAzPowerShellModuleMapping.Contains($readme)) {
            $affectedModule[$swaggerReadMeAzPowerShellModuleMapping[$readme].moduleName] = $readme.Replace("readme.md", "").Replace("readme.powershell.md", "")
        }
    }
    
    return $affectedModule
}
