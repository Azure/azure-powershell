function Get-CsprojFromModule {
    param (
        [string[]]$BuildModuleList,
        [string[]]$TestModuleList,
        [string]$RepoRoot,
        [string]$Configuration
    )

    $SourceDirectory = Join-Path $RepoRoot 'src'
    $GeneratedDirectory = Join-Path $RepoRoot 'generated'
    $modulePath = @()
    Write-Host "Finding modules under /src and /generated ..." -ForegroundColor DarkGreen
    foreach ($moduleName in $BuildModuleList) {
        $src = Join-Path $SourceDirectory $moduleName
        $gen = Join-Path $GeneratedDirectory $moduleName
        if (Test-Path $src) {
            $modulePath += $src
            Write-Host "Found $moduleName under $src" -ForegroundColor Cyan
        }
        if (Test-Path $gen) {
            $modulePath += $gen
            Write-Host "Found $moduleName under $gen" -ForegroundColor Cyan
        }
    }

    $testCsprojPattern = @()
    foreach ($testModule in $TestModuleList) {
        if ($testModule -in $renamedModules) {
            foreach ($renamedTestModule in $renamedModules[$testModule]) {
                $testCsprojPattern += "^*.$renamedTestModule.Test.csproj$"
            }
        } else {
            $testCsprojPattern += "^*.$testModule.Test.csproj$"
        }
    }
    $testCsprojPattern = ($testCsprojPattern | Join-String -Separator '|')

    Write-Host "Finding projects to include ..." -ForegroundColor DarkGreen
    $result = @()
    foreach ($module in $modulePath) {
        foreach ($csproj in (Get-ChildItem -Path $module -Recurse -Filter *.csproj)) {
            $csprojPath = $csproj.FullName
            # Release do not need test, exclude all test projects
            $releaseReturnCondition = ("Release" -eq $Configuration) -and ($csprojPath -match ".*Test.csproj$")
            # Debug only include: 1. not test project 2. is test projects and only in calculated test project list 
            $debugReturnCondition = ("Debug" -eq $Configuration) -and ($csprojPath -match ".*Test.csproj$") -and ($csprojPath -notmatch $testCsprojPattern)
            $uniqueNameReturnCondition = $csprojPath -in $result
            if ($uniqueNameReturnCondition -or $releaseReturnCondition -or $debugReturnCondition) {
                continue
            }
            $result += $csprojPath
            Write-Host "Including project: $($csprojPath)" -ForegroundColor Cyan
        }
    }

    if ('Debug' -eq $Configuration -and $TestModuleList -and $TestModuleList.Length -ne 0) {
        $testFxCsprojpath =  Join-Path $RepoRoot "tools" "TestFx" "TestFx.csproj"
        $result += $testFxCsprojpath
        Write-Host "Including project: $($testFxCsprojpath)" -ForegroundColor Cyan
    }
    return $result
}

function Get-OutdatedSubModule {
    param (
        [string]$SourceDirectory,
        [string]$GeneratedDirectory,
        [switch]$ForceRegenerate
    )
    $outdatedSubModule = @()
    $subModuleSource = Get-ChildItem -Path $SourceDirectory -Directory | Foreach-Object { $_.Name } | Where-Object { $_ -match "^*.Autorest$" }
    foreach ($subModule in $subModuleSource) {
        $generateInfoSource = Join-Path $SourceDirectory $subModule "generate-info.json"
        $generateInfoGenerated = Join-Path $GeneratedDirectory $subModule "generate-info.json"
        if (-not (Test-Path $generateInfoSource)) {
            Write-Error "$generateInfoSource was not found!"
            Exit 1
        }
        if (Test-Path $generateInfoGenerated) {
            $generateIdSource = (Get-Content -Path $generateInfoSource | ConvertFrom-Json).generate_Id
            $generateIdGenerated = (Get-Content -Path $generateInfoGenerated | ConvertFrom-Json).generate_Id
            Write-Host "Submodule $subModule generate Id src: $generateIdSource" -ForegroundColor Cyan
            Write-Host "Submodule $subModule generate Id generated: $generateIdGenerated" -ForegroundColor Cyan
            if ($generateIdSource -And $generateIdGenerated -And ($generateIdSource -eq $generateIdGenerated) -And (-not $ForceRegenerate)) {
                continue
            }
        }
        Write-Host "Found outdated submodule: $subModule" -ForegroundColor DarkMagenta
        $outDatedSubModule += $subModule
    }
    return $outDatedSubModule
}

function Invoke-SubModuleGeneration {
    param (
        [string]$GenerateDirectory,
        [string]$GenerateLog,
        [switch]$Pipeline
    )
    Write-Host "----------Start code generation for $GenerateDirectory----------" -ForegroundColor DarkGreen
    Set-Location -Path $GenerateDirectory
    if ($Pipeline) {
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
        [switch]$Pipeline
    )
    $SourceDirectory = Join-Path $SourceDirectory $ModuleRootName $SubModuleName
    $GeneratedDirectory = Join-Path $GeneratedDirectory $ModuleRootName $SubModuleName
    if (-not (Test-Path $GeneratedDirectory)) {
        New-Item -ItemType Directory -Force -Path $GeneratedDirectory
    }   
    #clean generated directory before update
    Write-Host "Cleaning directory: $GeneratedDirectory ..." -ForegroundColor DarkGreen
    Get-ChildItem $GeneratedDirectory | Foreach-Object { Remove-Item -Path $_.FullName -Recurse -Force }

    Write-Host "Copying generate-info.json from $SourceDirectory to $GeneratedDirectory ..." -ForegroundColor DarkGreen
    $generateInfoPath = Join-Path $SourceDirectory "generate-info.json"
    Copy-Item -Path $generateInfoPath -Destination $GeneratedDirectory -Force

    if (-not (Invoke-SubModuleGeneration -GenerateDirectory $SourceDirectory -GenerateLog $GenerateLog -Pipeline:$Pipeline)) {
        return $false;
    }
    # remove $sourceDirectory/generated/modules
    $localModulesPath = Join-Path $SourceDirectory 'generated' 'modules'
    if (Test-Path $localModulesPath) {
        Remove-Item -Path $localModulesPath -Recurse -Force
    }
    $subModuleNameTrimmed = $SubModuleName.split('.')[-2]
    $fileToUpdate = @('generated', "Az.$subModuleNameTrimmed.psd1", "Az.$subModuleNameTrimmed.psm1", "Az.$subModuleNameTrimmed.format.ps1xml", 'exports', 'internal', 'test-module.ps1', 'check-dependencies.ps1')
    # Copy from src/ to generated/ 
    $fileToUpdate | Foreach-Object {
        $moveFrom = Join-Path $SourceDirectory $_
        $moveTo = Join-Path $GeneratedDirectory $_
        Write-Host "Copying $moveFrom to $moveTo ..." -ForegroundColor Cyan
        Copy-Item -Path $moveFrom -Destination $moveTo -Recurse -Force
    }
    # regenerate csproj
    New-GeneratedFileFromTemplate -TemplateName 'Az.ModuleName.csproj' -GeneratedFileName "Az.$subModuleNameTrimmed.csproj" -GeneratedDirectory $GeneratedDirectory -ModuleRootName $ModuleRootName -SubModuleName $subModuleNameTrimmed
    
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
    $templateFile = $templateFile -replace '{ModuleFolderPlaceHolder}', $SubModuleName
    $templateFile -replace '{RootModuleNamePlaceHolder}', $ModuleRootName
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