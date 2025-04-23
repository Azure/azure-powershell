param (
    [string]$MatrixKey,
    [string]$Target,
    [string]$TestEnvName
)

$modules = $Target -split ','
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
        Write-Host "Testing module: $module"
        $subModulePath = Join-Path "$(Build.SourcesDirectory)" 'src' $module
        # TODO(Bernard) Remove log after test
        Write-Host "Sub module path: $subModulePath"
        Set-Location -Path $subModulePath
        & ".\test-module.ps1"  
    }
    catch {
        Write-Warning "Failed to test module: $module"
        $result.Status = "Failed"
        $result.Error = $_.Exception.Message
    }
    finally {
        $endTime = Get-Date
        $result.DurationSeconds = ($endTime - $startTime).TotalSeconds
        $results += $result
    }
}

$reportPath = Join-Path "$(Build.ArtifactStagingDirectory)" "Test$(TestEnvName)Report-$(MatrixKey).json"
$results | ConvertTo-Json -Depth 3 | Out-File -FilePath $reportPath -Encoding utf8
