param (
    [string]$MatrixKey,
    [string]$RepoRoot
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force
$moduleGroup = Get-Targets -RepoRoot $RepoRoot -TargetsOutputFileName "analyzeTargets.json" -MatrixKey $MatrixKey
$RepoArtifacts = Join-Path $RepoRoot 'artifacts'
$StaticAnalysisOutputDirectory = Join-Path $RepoArtifacts 'StaticAnalysisResults'
if (-not (Test-Path -Path $StaticAnalysisOutputDirectory)) {
    New-Item -ItemType Directory -Path $StaticAnalysisOutputDirectory
}
$toolsDirectory = Join-Path $RepoRoot 'tools'

$results = @()  
foreach ($moduleName in $moduleGroup) {
    Write-Host "=============================================================="
    Write-Host "Analysing Module: $moduleName"

    $startTime = Get-Date
    $result = @{
        MatrixKey = $MatrixKey
        Module = $moduleName
        Status = "Success"
        DurationSeconds = 0
        Error = ""
        FailedTasks = @()
    }
    $Parameters = @{
        RepoArtifacts = $RepoArtifacts
        StaticAnalysisOutputDirectory = $StaticAnalysisOutputDirectory
        Configuration = "Debug"
        TargetModule = @($moduleName)
    }
    $FailedTasks = @()
    $ErrorLogPath = "$StaticAnalysisOutputDirectory/error.log"

    try {
        .("$toolsDirectory/ExecuteCIStep.ps1") -StaticAnalysisBreakingChange @Parameters 2>$ErrorLogPath
        If (($LASTEXITCODE -ne 0) -and ($LASTEXITCODE -ne $null))
        {
            $FailedTasks += "BreakingChange"
        }
        .("$toolsDirectory/ExecuteCIStep.ps1") -StaticAnalysisDependency @Parameters 2>>$ErrorLogPath
        If (($LASTEXITCODE -ne 0) -and ($LASTEXITCODE -ne $null))
        {
            $FailedTasks += "Dependency"
        }
        .("$toolsDirectory/ExecuteCIStep.ps1") -StaticAnalysisSignature @Parameters 2>>$ErrorLogPath
        If (($LASTEXITCODE -ne 0) -and ($LASTEXITCODE -ne $null))
        {
            $FailedTasks += "Signature"
        }
        .("$toolsDirectory/ExecuteCIStep.ps1") -StaticAnalysisHelp @Parameters 2>>$ErrorLogPath
        If (($LASTEXITCODE -ne 0) -and ($LASTEXITCODE -ne $null))
        {
            $FailedTasks += "Help"
        }
        .("$toolsDirectory/ExecuteCIStep.ps1") -StaticAnalysisUX @Parameters 2>>$ErrorLogPath
        If (($LASTEXITCODE -ne 0) -and ($LASTEXITCODE -ne $null))
        {
            $FailedTasks += "UXMetadata"
        }
        If ($FailedTasks.Length -ne 0)
        {
            Write-Host "There are failed tasks: $FailedTasks"
            $ErrorLog = Get-Content -Path $ErrorLogPath | Join-String -Separator "`n"
            Write-Error $ErrorLog
            $result.Status = "Failed"
            $result.Error = "Failed tasks: $($FailedTasks -join ', ')"
            $result.FailedTasks = $FailedTasks
        }
    } catch {
        Write-Warning "Failed to analyse module: $moduleName"
        Write-Warning "Error message: $($_.Exception.Message)"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    } finally {
        $endTime = Get-Date
        $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
        $results += $result
        $result | ConvertTo-Json -Depth 5 | Write-Output
    }
}

$reportPath = Join-Path $RepoRoot "artifacts" "AnalyseReport-$MatrixKey.json"
$results | ConvertTo-Json -Depth 5 | Out-File -FilePath $reportPath -Encoding utf8
