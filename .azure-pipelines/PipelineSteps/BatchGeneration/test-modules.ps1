param (
    [string]$MatrixKey,
    [string]$TestEnvName,
    [string]$RepoRoot
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force
$subModuleGroup = Get-Targets -RepoRoot $RepoRoot -TargetsOutputFileName "test$($TestEnvName)Targets.json" -MatrixKey $MatrixKey

$results = @()  

foreach ($subModule in $subModuleGroup) {
    $startTime = Get-Date
    $moduleName, $subModuleName = $subModule -split '/'
    $result = @{
        Module = $moduleName
        SubModule = $subModuleName
        Status = "Success"
        DurationSeconds = 0
        Error = ""
    }

    try {
        Write-Host "Testing sub module: $subModule"
        $subModulePath = Join-Path $RepoRoot 'artifacts' 'Debug' "Az.$ModuleName" $subModuleName
        # if ($TestEnvName -ne 'Windows') {
        #     $subModulePath = "$RepoRoot/artifacts/Debug/az.$ModuleName/$subModuleName"
        # }
        Push-Location $subModulePath

        & ".\test-module.ps1"  

        if ($LASTEXITCODE -ne 0) {
            Write-Warning "❌ Test failed: $subModule (exit code $LASTEXITCODE)"
            $result.Status = "Failed"
            $result.Error = "Test failed with exit code $LASTEXITCODE"
        }
    }
    catch {
        Write-Warning "Failed to test module: $module"
        Write-Warning "Error message: $($_.Exception.Message)"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    }
    finally {
        $endTime = Get-Date
        $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
        $results += $result
        Pop-Location
    }
}

$artifactRoot = Join-Path $RepoRoot 'artifacts'
$reportPath = Join-Path $artifactRoot "Test$($TestEnvName)Report-$MatrixKey.json"
$results | ConvertTo-Json -Depth 3 | Out-File -FilePath $reportPath -Encoding utf8
