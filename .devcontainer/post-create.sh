#!/bin/bash
set -e

echo "� Updating npm..."
npm update -g npm

echo "�📦 Installing AutoRest..."
npm install -g autorest

echo "⚡ Installing platyPS..."
pwsh -c "Install-Module -Name platyPS -Force -Scope CurrentUser"

echo "🔐 Installing Az.Accounts for authentication..."
pwsh -c "Install-Module -Name Az.Accounts -Force -Scope CurrentUser"

echo "🧪 Installing PSScriptAnalyzer for static analysis..."
pwsh -c "Install-Module -Name PSScriptAnalyzer -Force -Scope CurrentUser"

