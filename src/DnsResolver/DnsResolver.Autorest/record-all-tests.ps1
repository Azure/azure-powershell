# record-all-tests.ps1
# Records each test individually and preserves recordings.
# The test framework erases ALL recording files when in record mode,
# so we must backup each recording immediately after it's created.
#
# Usage: .\record-all-tests.ps1
# Usage: .\record-all-tests.ps1 -TestName "New-AzDnsResolver"
# Usage: .\record-all-tests.ps1 -Skip "Invoke-AzDnsResolverBulkDnsResolverDomainList","New-AzDnsResolverIPConfigurationObject"

param(
    [string]$TestName,
    [string[]]$Skip = @()
)

$ErrorActionPreference = 'Stop'
$testDir = Join-Path $PSScriptRoot 'test'
$backupDir = Join-Path $PSScriptRoot 'test' '.recording-backups'

# Create backup directory
if (-not (Test-Path $backupDir)) {
    New-Item -ItemType Directory -Path $backupDir -Force | Out-Null
}

# Determine which tests to record
if ($TestName) {
    $tests = @($TestName)
} else {
    $tests = Get-ChildItem "$testDir\*.Tests.ps1" |
        ForEach-Object { $_.BaseName -replace '\.Tests$','' } |
        Where-Object { $_ -notin $Skip } |
        Sort-Object
}

Write-Host "Tests to record: $($tests.Count)" -ForegroundColor Cyan
Write-Host "Backup dir: $backupDir" -ForegroundColor Cyan
Write-Host ""

$passed = 0
$failed = 0
$failedTests = @()

foreach ($test in $tests) {
    Write-Host "=== [$($passed + $failed + 1)/$($tests.Count)] Recording: $test ===" -ForegroundColor Yellow

    # Run the recording
    $output = & pwsh -NoProfile -Command "& '$PSScriptRoot\test-module.ps1' -Record -TestName '$test'" 2>&1
    $resultLine = $output | Select-String "Tests Passed" | Select-Object -Last 1

    if ($resultLine -match 'Failed:\s+0') {
        Write-Host "  PASSED" -ForegroundColor Green
        $passed++
    } else {
        Write-Host "  FAILED" -ForegroundColor Red
        $output | Select-String "\[\-\]" | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
        $failed++
        $failedTests += $test
    }

    # Backup the recording file (the only one that survived the erase)
    $recordingFile = Join-Path $testDir "$test.Recording.json"
    if ((Test-Path $recordingFile) -and (Get-Item $recordingFile).Length -gt 2) {
        Copy-Item $recordingFile "$backupDir\$test.Recording.json" -Force
        Write-Host "  Backed up recording ($((Get-Item $recordingFile).Length) bytes)" -ForegroundColor DarkGray
    } else {
        Write-Host "  WARNING: No recording file produced!" -ForegroundColor Red
    }

    Write-Host ""
}

# Restore ALL backups to the test directory
Write-Host "=== Restoring all backed-up recordings ===" -ForegroundColor Cyan
$restored = 0
Get-ChildItem "$backupDir\*.Recording.json" | ForEach-Object {
    Copy-Item $_.FullName "$testDir\$($_.Name)" -Force
    $restored++
}
Write-Host "Restored $restored recording files" -ForegroundColor Green

# Summary
Write-Host ""
Write-Host "=== Summary ===" -ForegroundColor Cyan
Write-Host "Passed: $passed / $($tests.Count)" -ForegroundColor $(if ($failed -eq 0) { 'Green' } else { 'Yellow' })
if ($failed -gt 0) {
    Write-Host "Failed: $failed" -ForegroundColor Red
    Write-Host "Failed tests:" -ForegroundColor Red
    $failedTests | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
}

# Cleanup backup dir
if ($failed -eq 0) {
    Remove-Item $backupDir -Recurse -Force -ErrorAction SilentlyContinue
    Write-Host "Cleaned up backup directory" -ForegroundColor DarkGray
} else {
    Write-Host "Backups preserved at: $backupDir" -ForegroundColor Yellow
}
