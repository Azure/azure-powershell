$target = "$(Target)"
Write-Host "Building targets: $target"

$buildModulesPath = Join-Path "$(Build.SourcesDirectory)" 'tools' 'BuildScripts' 'BuildModules.ps1'
$modules = $target -split ','
$results = @()

foreach ($module in $modules) {
    $startTime = Get-Date
    $result = @{
        Module = $module
        Status = "Success"
        DurationSeconds = 0
        Error = ""
    }
    try {
        Write-Host "Building module: $module"
        & $buildModulesPath -TargetModule $module
    } catch {
        Write-Warning "Failed to build module: $module"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    } finally {
        $endTime = Get-Date
        $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
        $results += $result
    }
}

git add .
$patchPath = "$(Build.ArtifactStagingDirectory)/changed.patch"
git diff --cached > $patchPath

$reportPath = Join-Path "$(Build.ArtifactStagingDirectory)" "BuildReport-$(MatrixKey).json"
$results | ConvertTo-Json -Depth 3 | Out-File -FilePath $reportPath -Encoding utf8

Write-Host "Build report written to $reportPath"
