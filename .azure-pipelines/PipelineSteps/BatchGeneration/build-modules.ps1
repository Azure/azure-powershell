param (
    [string]$MatrixKey,
    [string]$RepoRoot
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force

$buildTargetsOutputFile = Join-Path $RepoRoot "artifacts" "buildTargets.json"
$buildTargets = Get-Content -Path $buildTargetsOutputFile -Raw | ConvertFrom-Json
$moduleGroup = $buildTargets.$MatrixKey
Write-Host "##[group]Building module group $MatrixKey"
$moduleGroup | ForEach-Object { Write-Output $_ }
Write-Host "##[endgroup]"
Write-Host
$buildModulesPath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildModules.ps1'

$results = @()  
foreach ($moduleName in $moduleGroup) {
    Write-Host "=============================================================="
    Write-Host "Building Module: $moduleName"

    $startTime = Get-Date
    $result = @{
        Module = $moduleName
        Status = "Success"
        DurationSeconds = 0
        Error = ""
    }

    try {
        & $buildModulesPath -TargetModule $moduleName -InvokedByPipeline
    } catch {
        Write-Warning "Failed to build module: $moduleName"
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
