function Get-CsprojFromModule {
    param (
        [string[]]$BuildModuleList,
        [string[]]$TestModuleList,
        [string]$RepoRoot,
        [string]$Configuration
    )
    $renamedModules = @{
        'Storage' = @('Storage.Management');
        'DataFactory' = @('DataFactoryV1', 'DataFactoryV2')
    }

    $SourceDirectory = Join-Path $RepoRoot 'src'
    $GeneratedDirectory = Join-Path $RepoRoot 'generated'
    $srcModulePath = @()
    $generatedModulePath = @()

    Write-Host "Finding modules under /src and /generated ..." -ForegroundColor DarkGreen
    foreach ($moduleName in $BuildModuleList) {
        $src = Join-Path $SourceDirectory $moduleName
        $gen = Join-Path $GeneratedDirectory $moduleName
        if (Test-Path $src) {
            $srcModulePath += $src
            Write-Host "Found $moduleName under $src" -ForegroundColor Cyan
        }
        if (Test-Path $gen) {
            $generatedModulePath += $gen
            Write-Host "Found $moduleName under $gen" -ForegroundColor Cyan
        }
    }

    Write-Host "Finding projects to include ..." -ForegroundColor DarkGreen
    $result = @()
    foreach ($module in $srcModulePath) {
        foreach ($csproj in (Get-ChildItem -Path $module -Recurse -Filter *.csproj -Exclude 'Az.*.csproj', "*.Test.csproj")) {
            $csprojPath = $csproj.FullName
            if ($csprojPath -in $result) {
                continue
            }
            $result += $csprojPath
            Write-Host "Including project: $($csprojPath)" -ForegroundColor Cyan
        }
    }

    foreach ($module in $generatedModulePath) {
        foreach ($csproj in (Get-ChildItem -Path $module -Recurse -Filter *.csproj)) {
            $csprojPath = $csproj.FullName
            $uniqueNameReturnCondition = $csprojPath -in $result
            if ($uniqueNameReturnCondition) {
                continue
            }
            $result += $csprojPath
            Write-Host "Including project: $($csprojPath)" -ForegroundColor Cyan
        }
    }

    foreach ($testModule in $TestModuleList) {
        if ($testModule -in $renamedModules.keys) {
            foreach ($renamedTestModule in $renamedModules[$testModule]) {
                $testCsproj = Join-Path $SourceDirectory $testModule "$renamedTestModule.Test" "$renamedTestModule.Test.csproj"
                if (Test-Path $testCsproj) {
                    $result += $testCsproj
                }
            }
        } else {
            $testCsproj = Join-Path $SourceDirectory $testModule "$testModule.Test" "$testModule.Test.csproj"
            if (Test-Path $testCsproj) {
                $result += $testCsproj
            }
        }
    }

    # if ('Debug' -eq $Configuration -and $TestModuleList -and $TestModuleList.Length -ne 0) {
    #     $testFxCsprojpath =  Join-Path $RepoRoot "tools" "TestFx" "TestFx.csproj"
    #     $result += $testFxCsprojpath
    #     Write-Host "Including project: $($testFxCsprojpath)" -ForegroundColor Cyan
    # }
    return $result
}

function Invoke-SubModuleGeneration {
    param (
        [string]$GenerateDirectory,
        [string]$GenerateLog,
        [switch]$IsInvokedByPipeline
    )
    Write-Host "----------Start code generation for $GenerateDirectory----------" -ForegroundColor DarkGreen
    Set-Location -Path $GenerateDirectory
    if ($IsInvokedByPipeline) {
        npx autorest --max-memory-size=8192 >> $GenerateLog
    } else {
        autorest --max-memory-size=8192 >> $GenerateLog
    }
    
    if ($lastexitcode -ne 0) {
        return $false
    } else {
        ./build-module.ps1 -DisableAfterBuildTasks
        Write-Host "----------End code generation for $GenerateDirectory----------" -ForegroundColor DarkGreen
        return $true
    }

}

function Update-GeneratedSubModule {
    param (
        [string]$ModuleRootName,
        [string]$SubModuleName,
        [string]$SourceDirectory,
        [string]$GeneratedDirectory,
        [string]$GenerateLog,
        [boolean]$IsInvokedByPipeline
    )
    $SourceDirectory = Join-Path $SourceDirectory $ModuleRootName $SubModuleName
    $GeneratedDirectory = Join-Path $GeneratedDirectory $ModuleRootName $SubModuleName
    if (-not (Test-Path $GeneratedDirectory)) {
        New-Item -ItemType Directory -Force -Path $GeneratedDirectory
    }

    # save guid from psd1 if existed for later use
    $subModuleNameTrimmed = $SubModuleName.split('.')[-2]
    if (Test-Path (Join-Path $GeneratedDirectory "Az.$subModuleNameTrimmed.psd1")) {
        $guid = (Import-LocalizedData -BaseDirectory $GeneratedDirectory -FileName "Az.$subModuleNameTrimmed.psd1").GUID
    }

    # clean generated directory before update
    Write-Host "Cleaning directory: $GeneratedDirectory ..." -ForegroundColor DarkGreen
    Get-ChildItem $GeneratedDirectory | Foreach-Object { Remove-Item -Path $_.FullName -Recurse -Force }

    # Copy generate-info.json separately because it will be regenerated
    Write-Host "Copying generate-info.json from $SourceDirectory to $GeneratedDirectory ..." -ForegroundColor DarkGreen
    $generateInfoPath = Join-Path $SourceDirectory "generate-info.json"
    Copy-Item -Path $generateInfoPath -Destination $GeneratedDirectory -Force

    # Copy assemblyinfo.cs separately because it will be regenerated
    Write-Host "Copying AssemblyInfo.cs from $SourceDirectory to $GeneratedDirectory ..." -ForegroundColor DarkGreen
    $assemblyInfoPath = Join-Path $SourceDirectory "Properties"
    if (Test-Path $assemblyInfoPath) {
        Copy-Item -Path $assemblyInfoPath -Destination $GeneratedDirectory -Recurse -Force
    }

    if (-not (Invoke-SubModuleGeneration -GenerateDirectory $SourceDirectory -GenerateLog $GenerateLog -IsInvokedByPipeline $IsInvokedByPipeline)) {
        return $false;
    }
    # remove $sourceDirectory/generated/modules
    $localModulesPath = Join-Path $SourceDirectory 'generated' 'modules'
    if (Test-Path $localModulesPath) {
        Remove-Item -Path $localModulesPath -Recurse -Force
    }
    $fileToUpdate = @('generated', 'resources', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', 'test-module.ps1', 'check-dependencies.ps1')
    # Copy from src/ to generated/ 
    $fileToUpdate | Foreach-Object {
        $moveFrom = Join-Path $SourceDirectory $_
        $moveTo = Join-Path $GeneratedDirectory $_
        Write-Host "Copying $moveFrom to $moveTo ..." -ForegroundColor Cyan
        Copy-Item -Path $moveFrom -Destination $moveTo -Recurse -Force
    }
    # regenerate csproj
    New-GeneratedFileFromTemplate -TemplateName 'Az.ModuleName.csproj' -GeneratedFileName "Az.$subModuleNameTrimmed.csproj" -GeneratedDirectory $GeneratedDirectory -ModuleRootName $ModuleRootName -SubModuleName $subModuleNameTrimmed
    
    # revert guid in psd1 so that no conflict in updating this file
    if ($guid) {
        $psd1Path = Join-Path $GeneratedDirectory "Az.$subModuleNameTrimmed.psd1"
        $psd1Content = Get-Content $psd1Path
        $newGuid = (Import-LocalizedData -BaseDirectory $GeneratedDirectory -FileName "Az.$subModuleNameTrimmed.psd1").GUID
        $psd1Content -replace $newGuid, $guid | Set-Content $psd1Path -Force
    }

    Write-Host "Copying generate-info.json from $GeneratedDirectory to $SourceDirectory ..." -ForegroundColor DarkGreen
    $generateInfoPath = Join-Path $GeneratedDirectory "generate-info.json"
    Copy-Item -Path $generateInfoPath -Destination $SourceDirectory -Force

    return $true
}

function New-GeneratedFileFromTemplate {
    Param(
        [string]
        $TemplateName,
        [string]
        $GeneratedFileName,
        [string]
        $GeneratedDirectory,
        [string]
        $ModuleRootName,
        [string]
        $SubModuleName
    )
    $TemplatePath = Join-Path $PSScriptRoot "Templates"
    $templateFile = Join-Path $TemplatePath $TemplateName
    $GeneratedFile = Join-Path $GeneratedDirectory $GeneratedFileName

    $templateFile = Get-Content -Path $templateFile
    If ($templateFile -Match "{GUID}") {
        $templateFile = $templateFile -replace '{GUID}', (New-Guid).Guid
    }
    $templateFile = $templateFile -replace '{ModuleNamePlaceHolder}', $SubModuleName
    $templateFile = $templateFile -replace '{LowCaseModuleNamePlaceHolder}', $SubModuleName.ToLower()
    $templateFile = $templateFile -replace '{ModuleFolderPlaceHolder}', "$SubModuleName.Autorest"
    $templateFile = $templateFile -replace '{RootModuleNamePlaceHolder}', $ModuleRootName
    Write-Host "Copying template: $TemplateName." -ForegroundColor Yellow
    $templateFile | Set-Content $GeneratedFile -force
}

function New-GenerateInfoJson {
    param (
        [string]$GeneratedDirectory,
        [string]$GenerateId = (New-Guid).ToString()
    )
    $generateInfoJsonPath = Join-Path $GeneratedDirectory "/generate-info.json"
    $generateInfoJson = @{
        generate_Id = $GenerateId
    } | ConvertTo-Json
    if (Test-Path $generateInfoJsonPath -PathType Leaf) {
        Write-Host "Refreshing generate-info.json file: $generateInfoJsonPath"
        $generateInfoJson = Get-Content $generateInfoJsonPath | ConvertFrom-Json -AsHashtable
        $generateInfoJson["generate_Id"] = $GenerateId
        $generateInfoJson | ConvertTo-Json | Set-Content -Path $generateInfoJsonPath -Force
    }
    else{
        Write-Host "Generating generate-info.json file: $generateInfoJsonPath"
        $generateInfoJson | Set-Content -Path $generateInfoJsonPath -Force
    }
}