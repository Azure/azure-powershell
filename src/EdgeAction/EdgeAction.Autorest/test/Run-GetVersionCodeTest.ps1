# Quick test script for Get-AzEdgeActionVersionCode
param(
    [switch]$Record
)

$ErrorActionPreference = 'Stop'

# Import required modules
Write-Host "Importing Az.Accounts..." -ForegroundColor Cyan
Import-Module Az.Accounts -Force

Write-Host "Importing Az.EdgeAction..." -ForegroundColor Cyan
Import-Module C:\azpowershell\azure-powershell\artifacts\Debug\Az.EdgeAction\Az.EdgeAction.psd1 -Force

# Set test mode
if ($Record) {
    $env:TestMode = 'record'
    Write-Host "Running in RECORD mode - will execute against live Azure" -ForegroundColor Yellow
} else {
    $env:TestMode = 'playback'
    Write-Host "Running in PLAYBACK mode - will use recorded responses" -ForegroundColor Green
}

# Run the test
Write-Host "`nRunning Get-AzEdgeActionVersionCode tests..." -ForegroundColor Cyan
Invoke-Pester -Path .\Get-AzEdgeActionVersionCode.Tests.ps1 -Verbose
