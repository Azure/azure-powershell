#!/usr/bin/env pwsh
#Requires -Version 7.0

$ErrorActionPreference = "Stop"

Write-Host "📦 Updating npm..." -ForegroundColor Cyan
npm update -g npm
if ($LASTEXITCODE -ne 0) {
    throw "Failed to update npm"
}

Write-Host "🚀 Installing AutoRest..." -ForegroundColor Cyan
npm install -g autorest
if ($LASTEXITCODE -ne 0) {
    throw "Failed to install AutoRest"
}

Write-Host "⚡ Installing Microsoft.PowerShell.PlatyPS..." -ForegroundColor Cyan
# 1.0.2 is the first release with -ExcludeDontShow (PowerShell/platyPS#845).
Install-Module -Name Microsoft.PowerShell.PlatyPS -MinimumVersion 1.0.2 -Force -Scope CurrentUser -ErrorAction Stop

Write-Host "🔐 Installing Az.Accounts for authentication..." -ForegroundColor Cyan
Install-Module -Name Az.Accounts -Force -Scope CurrentUser -ErrorAction Stop

Write-Host "🧪 Installing PSScriptAnalyzer for static analysis..." -ForegroundColor Cyan
Install-Module -Name PSScriptAnalyzer -Force -Scope CurrentUser -ErrorAction Stop

Write-Host "✅ Post-create setup completed successfully!" -ForegroundColor Green
