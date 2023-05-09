& (Join-Path -Path $PSScriptRoot -ChildPath "AnalyzeTestCoverage.ps1")

$cvgRootDir = (Get-AzConfig -TestCoverageLocation).Value
$cvgResultsDir = Join-Path -Path $cvgRootDir -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Results"
$rptCsv = Join-Path -Path $cvgResultsDir -ChildPath "Report.csv"
if (!(Test-Path -Path $rptCsv -PathType Leaf)) {
    Write-Warning "No test coverage analysis result was found!"
    return
}

$blCsv = Join-Path -Path $PSScriptRoot -ChildPath "Baseline.csv"
if (!(Test-Path -Path $blCsv -PathType Leaf)) {
    Write-Warning "No test coverage baseline was found!"
    return
}

$repoRootDir = $PSScriptRoot | Split-Path | Split-Path | Split-Path
$cipJson = Join-Path -Path $repoRootDir -ChildPath "artifacts" | Join-Path -ChildPath "PipelineResult" | Join-Path -ChildPath "CIPlan.json"
if (!(Test-Path -Path $cipJson -PathType Leaf)) {
    Write-Warning "No CI plan was found!"
    return
}

$cipJson = Get-Content -Path $cipJson -Raw | ConvertFrom-Json
$testedModules = $cipJson.test | Where-Object { $_ -ne "Accounts" }

$toolsDir = $PSScriptRoot | Split-Path | Split-Path
$funcTestStatus = Join-Path -Path $toolsDir -ChildPath "ExecuteCIStep.ps1"
. $funcTestStatus

$rptData = Import-Csv -Path $rptCsv
$blData = Import-Csv -Path $blCsv

$cvgMessageHeader50 = "|Type|Title|Current Coverage|Description|`n|---|---|---|---|`n"
$cvgMessageHeader80 = "|Type|Title|Current Coverage|Last Coverage|Description|`n|---|---|---|---|---|`n"

$rptData | Where-Object Module -in $testedModules | ForEach-Object {
    $module = $_.Module
    Write-Host "##[section]Validating test coverage for module $module..."

    $cmdCvg = $_.CommandCoverage
    $cmdCvgD = [decimal]$cmdCvg.TrimEnd("%") / 100

    Write-Host "Test coverage for module $module is $cmdCvg."
    if ($cmdCvgD -lt 0.5) {
        Write-Warning "Test coverage for module $module is less than 50% !"
        $cvgMessageBody50 = "|⚠️|Test Coverage Less Than 50%|$cmdCvg|Test coverage for the module cannot be lower than 50%.|`n"
        Set-ModuleTestStatusInPipelineResult -ModuleName "Az.$module" -Status Warning -Content ($cvgMessageHeader50 + $cvgMessageBody50)
    }
    elseif ($cmdCvgD -lt 0.8) {
        $blCvgRow = $blData | Where-Object Module -eq $module
        $blCvg = $blCvgRow.CommandCoverage
        $blCvgD = [decimal]$blCvg.TrimEnd("%") / 100
        Write-Host "Last release test coverage for module $module is $blCvg."
        if ($cmdCvgD -lt $blCvgD) {
            Write-Warning "Test coverage for module $module is less than 80% and lower than the last release !"
            $cvgMessageBody80 = "|⚠️|Test Coverage Less Than 80%|$cmdCvg|$blCvg|Test coverage cannot be lower than the number of the last release.|`n"
            Set-ModuleTestStatusInPipelineResult -ModuleName "Az.$module" -Status Warning -Content ($cvgMessageHeader80 + $cvgMessageBody80)
        }
    }

    Write-Host
}
