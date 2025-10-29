#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Find all .tests.ps1 files in test folders containing the "live" keyword
.DESCRIPTION
    This script searches for .tests.ps1 files under the src directory in test folders,
    filters files that contain the keyword "live" (case-insensitive), and excludes
    files in LiveTests folders.
.EXAMPLE
    ./Find-LiveTestFiles.ps1
    Displays all matching file paths
.EXAMPLE
    ./Find-LiveTestFiles.ps1 | Out-File live-test-files.txt
    Saves matching file paths to a file
#>

# Set strict mode for better error catching
Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

# Get the repository root directory
$repoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path

Write-Host "Searching for .tests.ps1 files with 'live' keyword in src directory..." -ForegroundColor Cyan
Write-Host "Excluding LiveTests folders..." -ForegroundColor Cyan
Write-Host ""

# Find all .tests.ps1 files in test folders
$testFiles = Get-ChildItem -Path (Join-Path $repoRoot "src") -Recurse -Filter "*.tests.ps1" -File -ErrorAction SilentlyContinue |
    Where-Object {
        # Include only files in 'test' folders (case-insensitive)
        $_.DirectoryName -match '[\\/]test[\\/]|[\\/]test$'
    } |
    Where-Object {
        # Exclude files in 'LiveTests' folders
        $_.FullName -notmatch '[\\/]LiveTests[\\/]'
    }

Write-Host "Found $($testFiles.Count) .tests.ps1 files in test folders (excluding LiveTests)" -ForegroundColor Yellow
Write-Host "Filtering files containing 'live' keyword..." -ForegroundColor Cyan
Write-Host ""

# Filter files that contain "live" keyword
$matchingFiles = $testFiles | Where-Object {
    $content = Get-Content -Path $_.FullName -Raw -ErrorAction SilentlyContinue
    $content -match 'live'
}

Write-Host "Found $($matchingFiles.Count) files containing 'live' keyword:" -ForegroundColor Green
Write-Host ""

# Get relative paths from repository root
$results = $matchingFiles | ForEach-Object {
    $relativePath = $_.FullName.Replace($repoRoot + [System.IO.Path]::DirectorySeparatorChar, "")
    # Normalize path separators to forward slashes for consistency
    $relativePath.Replace('\', '/')
}

# Output the results
$results | Sort-Object | ForEach-Object {
    Write-Output $_
}

Write-Host ""
Write-Host "Total: $($results.Count) files" -ForegroundColor Green
