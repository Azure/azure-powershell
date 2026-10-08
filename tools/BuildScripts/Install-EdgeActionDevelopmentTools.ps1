# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
#Requires -Version 7.3
<#
.SYNOPSIS
Installs and activates the pinned EdgeAction generation tools for the current PowerShell process.
.DESCRIPTION
Requires native Node.js 20 or later, PowerShell 7.3 or later, and .NET SDK 8 or later.
Installs AutoRest and PowerShell modules under artifacts/edgeaction-tools without changing global
packages, PowerShell profiles, NuGet.Config, or certificate validation. Native runtime installation
steps and the exact validated versions are documented in the EdgeAction AutoRest README.
.PARAMETER ActivateOnly
Checks existing local packages and activates them without downloading or installing anything.
.PARAMETER UseMicrosoftPackageFeedProxy
Uses Microsoft's package-feed proxy for npm and public NuGet packages in this process.
Use only in an environment where this proxy is approved.
.PARAMETER NpmRegistry
An approved HTTPS npm registry. Defaults to the registry reported by npm config get registry.
.PARAMETER DotNetPath
Path to a native dotnet executable, for installations not discoverable on PATH.
.PARAMETER ToolsDirectory
Installation directory. Defaults to artifacts/edgeaction-tools in this repository.
.EXAMPLE
& ./tools/BuildScripts/Install-EdgeActionDevelopmentTools.ps1
.EXAMPLE
& ./tools/BuildScripts/Install-EdgeActionDevelopmentTools.ps1 -ActivateOnly -UseMicrosoftPackageFeedProxy
#>
[CmdletBinding()]
param(
    [switch]$ActivateOnly,
    [switch]$UseMicrosoftPackageFeedProxy,
    [string]$NpmRegistry,
    [string]$DotNetPath,
    [string]$ToolsDirectory
)

$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true
$repoRoot = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
if (-not $ToolsDirectory) {
    $ToolsDirectory = Join-Path $repoRoot 'artifacts' 'edgeaction-tools'
}
$ToolsDirectory = [System.IO.Path]::GetFullPath($ToolsDirectory)
$npmDirectory = Join-Path $ToolsDirectory 'npm'
$moduleDirectory = Join-Path $ToolsDirectory 'modules'
$npmPackages = [ordered]@{
    'autorest' = '3.8.0'
    '@autorest/core' = '3.10.9'
}
$powerShellModules = [ordered]@{
    'Pester' = '4.10.1'
    'platyPS' = '0.14.2'
}

function Invoke-EdgeActionTool {
    param([string]$FilePath, [string[]]$Arguments)
    $output = & $FilePath @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "Tool '$FilePath' failed with exit code $LASTEXITCODE."
    }
    $output
}

$node = Get-Command node -CommandType Application -ErrorAction Stop | Select-Object -First 1
$npm = Get-Command npm -ErrorAction Stop
$nodeVersion = (Invoke-EdgeActionTool $node.Source @('--version') | Out-String).Trim()
if ([version]$nodeVersion.TrimStart('v') -lt [version]'20.0.0') {
    throw "Node.js 20 or later is required; found $nodeVersion. See the EdgeAction README for native installation steps."
}

if (-not $DotNetPath) {
    $nativeDotnet = Get-Command dotnet -CommandType Application -All -ErrorAction SilentlyContinue |
        Where-Object { -not $IsWindows -or [System.IO.Path]::GetExtension($_.Source) -eq '.exe' } |
        Select-Object -First 1
    if (-not $nativeDotnet) {
        throw 'A native .NET SDK is required. Install .NET SDK 10.0.401 as documented in the EdgeAction README, or specify -DotNetPath.'
    }
    $DotNetPath = $nativeDotnet.Source
}
$DotNetPath = (Resolve-Path -LiteralPath $DotNetPath -ErrorAction Stop).Path
$sdkVersion = (Invoke-EdgeActionTool $DotNetPath @('--version') | Out-String).Trim()
if ([version]($sdkVersion -replace '-.*$', '') -lt [version]'8.0.0') {
    throw "A native .NET SDK 8 or later is required; '$DotNetPath' reports $sdkVersion. Do not use the npm dotnet shim."
}

if ($UseMicrosoftPackageFeedProxy) {
    if ($NpmRegistry) {
        throw 'Specify either -UseMicrosoftPackageFeedProxy or -NpmRegistry, not both.'
    }
    $NpmRegistry = 'https://packagefeedproxy.microsoft.io/npm/'
}
elseif (-not $NpmRegistry) {
    $NpmRegistry = (Invoke-EdgeActionTool $npm.Source @('config', 'get', 'registry') | Out-String).Trim()
}
$registryUri = $null
if (-not [System.Uri]::TryCreate($NpmRegistry, [System.UriKind]::Absolute, [ref]$registryUri) -or $registryUri.Scheme -ne 'https') {
    throw 'NpmRegistry must be an absolute HTTPS URL.'
}

$needsNpmInstall = $false
foreach ($package in $npmPackages.GetEnumerator()) {
    $manifest = Join-Path $npmDirectory 'node_modules' $package.Key 'package.json'
    if (-not (Test-Path -LiteralPath $manifest) -or
        (Get-Content -LiteralPath $manifest -Raw | ConvertFrom-Json).version -ne $package.Value) {
        $needsNpmInstall = $true
    }
}
if ($needsNpmInstall) {
    if ($ActivateOnly) {
        throw 'Pinned AutoRest packages are missing or have different versions. Run this script without -ActivateOnly first.'
    }
    $null = New-Item -ItemType Directory -Path $npmDirectory -Force
    $packages = @($npmPackages.GetEnumerator() | ForEach-Object { "$($_.Key)@$($_.Value)" })
    Invoke-EdgeActionTool $npm.Source (@('install', '--prefix', $npmDirectory, '--no-save', '--package-lock=false',
        '--registry', $NpmRegistry) + $packages) | Out-Host
}
foreach ($package in $npmPackages.GetEnumerator()) {
    $manifest = Join-Path $npmDirectory 'node_modules' $package.Key 'package.json'
    if ((Get-Content -LiteralPath $manifest -Raw | ConvertFrom-Json).version -ne $package.Value) {
        throw "Installed $($package.Key) does not match required version $($package.Value)."
    }
}

foreach ($module in $powerShellModules.GetEnumerator()) {
    $manifest = Join-Path $moduleDirectory $module.Key $module.Value "$($module.Key).psd1"
    if (-not (Test-Path -LiteralPath $manifest)) {
        if ($ActivateOnly) {
            throw "$($module.Key) $($module.Value) is missing. Run this script without -ActivateOnly first."
        }
        $null = New-Item -ItemType Directory -Path $moduleDirectory -Force
        Save-Module -Name $module.Key -RequiredVersion $module.Value -Path $moduleDirectory -Repository PSGallery -Force
    }
    $metadata = Test-ModuleManifest -Path $manifest -ErrorAction Stop
    if ($metadata.Version -ne [version]$module.Value) {
        throw "Installed $($module.Key) does not match required version $($module.Value)."
    }
}

$npmBin = Join-Path $npmDirectory 'node_modules' '.bin'
$env:PATH = (@($npmBin, (Split-Path $DotNetPath -Parent), $PSHOME, (Split-Path $node.Source -Parent)) +
    @($env:PATH -split [System.IO.Path]::PathSeparator) | Select-Object -Unique) -join [System.IO.Path]::PathSeparator
$env:PSModulePath = (@($moduleDirectory, (Join-Path $repoRoot 'artifacts' 'Debug')) +
    @($env:PSModulePath -split [System.IO.Path]::PathSeparator) | Select-Object -Unique) -join [System.IO.Path]::PathSeparator
$env:autorest_registry = $NpmRegistry
$env:AUTOREST_HOME = $ToolsDirectory
if ($UseMicrosoftPackageFeedProxy) {
    $env:RestoreSources = @(
        (Join-Path $repoRoot 'tools' 'LocalFeed')
        'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
        'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
    ) -join ';'
}

Write-Host "EdgeAction tools activated in this process: $ToolsDirectory"
[pscustomobject]@{
    Node = $nodeVersion
    PowerShell = $PSVersionTable.PSVersion.ToString()
    DotNetSdk = $sdkVersion
    AutoRest = $npmPackages['autorest']
    AutoRestCore = $npmPackages['@autorest/core']
    Pester = $powerShellModules['Pester']
    PlatyPS = $powerShellModules['platyPS']
}
