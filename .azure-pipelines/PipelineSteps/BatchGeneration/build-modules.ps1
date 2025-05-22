param (
    [string]$MatrixKey,
    [string]$RepoRoot
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force
$moduleGroup = Get-Targets -RepoRoot $RepoRoot -TargetsOutputFileName "buildTargets.json" -MatrixKey $MatrixKey
$buildModulesPath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildModules.ps1'

$results = @()  
foreach ($moduleName in $moduleGroup) {
    Write-Host "=============================================================="
    Write-Host "Building Module: $moduleName"

    $startTime = Get-Date
    $result = @{
        MatrixKey = $MatrixKey
        Module = $moduleName
        Status = "Success"
        DurationSeconds = 0
        Error = ""
    }

    try {
        & $buildModulesPath -TargetModule $moduleName -InvokedByPipeline
    } catch {
        Write-Warning "Failed to build module: $moduleName"
        Write-Warning "Error message: $($_.Exception.Message)"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    } finally {
        $endTine = Get-Date
        $result.DurationSeconds = ($endTine - $startTime).TotalSeconds
        $results += $result
    }
}

$reportPath = Join-Path $RepoRoot "artifacts" "BuildReport-$MatrixKey.json"
$results | ConvertTo-Json -Depth 5 | Out-File -FilePath $reportPath -Encoding utf8
