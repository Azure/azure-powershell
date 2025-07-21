param (
    [string]$RepoRoot,
    [string]$PipelineWorkspace
)

# Check number of generation targets
$generationTargetsFile = Join-Path $RepoRoot "artifacts" "generationTargets.json"
$generationTargets = Get-Content -Raw -Path $generationTargetsFile | ConvertFrom-Json
$totalGenerationModules = 0
foreach ($outerKey in $generationTargets.PSObject.Properties.Name) {
    $innerKeys = $generationTargets.$outerKey.PSObject.Properties.Name.Count
    $totalGenerationModules += $innerKeys
}
Write-Output "Total regeneration target modules: $totalGenerationModules"

# Check number of other targets
$targetPatterns = @{
    Analyse = "analyzeTargets.json"
    Build = "buildTargets.json"
    Test = "testWindowsTargets.json"
}
foreach ($pattern in $targetPatterns.GetEnumerator()) {
    $targetFilePath = Join-Path $RepoRoot "artifacts" $pattern.Value
    $targetJson = Get-Content -Raw -Path $targetFilePath | ConvertFrom-Json
    $total = ($targetJson.PSObject.Properties.Value | ForEach-Object {
        $_.Count
    }) | Measure-Object -Sum | Select-Object -ExpandProperty Sum

    Write-Output "Total $($pattern.Key) targets : $total"
}

# Check all steps reports
$reportFilePattern = @{
    Generation = "GenerationReport-*.json"
    Build = "BuildReport-*.json"
    Analyze = "AnalyseReport-*.json"
    TestWindows = "TestWindowsReport-*.json"
    TestLinux = "TestLinuxReport-*.json"
    TestMacOS = "TestMacOSReport-*.json"
}

$artifactRoot = Join-Path $RepoRoot 'artifacts'
if (-not (Test-Path -Path $artifactRoot)) {
    New-Item -Path $artifactRoot -ItemType Directory
}
$failedReports = @{}

foreach ($pattern in $reportFilePattern.GetEnumerator()) {
    Write-Host "Filtering $($pattern.Key) Report with pattern: $($pattern.Value)"
    $allResults = @()

    foreach ($dir in Get-ChildItem -Path $PipelineWorkspace -Directory) {
        $file = Get-ChildItem -Path $dir.FullName -Filter $pattern.Value -File | Select-Object -First 1
        if ($file) {
            Write-Host "Found file: $($file.FullName)"
            $jsonContent = Get-Content $file.FullName -Raw | ConvertFrom-Json

            if ($jsonContent -isnot [System.Collections.IEnumerable] -or $jsonContent -is [string]) {
                $jsonContent = @($jsonContent)
            }

            $allResults += $jsonContent
        }
    }

    Write-Host "$($pattern.Key): $($allResults.Count) result(s) found."
    $reportPath = Join-Path $artifactRoot "$($pattern.Key)Report.json"
    $allResults | ConvertTo-Json -Depth 10 | Set-Content -Path $reportPath -Encoding UTF8
    Write-Host "Written report to $reportPath"

    $failed = $allResults | Where-Object { $_.Status -ne "Success" }
    if ($failed.Count -gt 0) {
        $failedReports[$pattern.Key] = $failed
    }
}

if ($failedReports.Count -eq 0) {
    Write-Host "`n✅ Exist Successfully: All reports passed."
    exit 0
} else {
    Write-Host "`n❌ Exist with Errors: Some reports failed."
    foreach ($key in $failedReports.Keys) {
        Write-Host "##[group]Failed entries in $key"
        $failedReports[$key] | ConvertTo-Json -Depth 10 | Write-Host
        Write-Host "##[endgroup]"
        Write-Host
    }
    exit 1
}
