#Requires -Version 7.0
<#
.SYNOPSIS
    Applies preview-branch-only overrides to built artifacts.

.DESCRIPTION
    This script is the runtime half of the "preview overlay" pattern.

    Goal: keep source files (Az.<Module>.psd1, AssemblyInfo.cs, ChangeLog.md,
    AzPreview.psd1) byte-identical between main and the Az.CosmosDB-preview
    branch, so merging main never produces conflicts on metadata. Preview-
    specific values live only in tools/PreviewOverlay/overlay.json (a file
    main never sees) and are stamped into the built artifacts after build.

    Run after `dotnet msbuild build.proj /p:Scope=CosmosDB`.

.PARAMETER RepoRoot
    Repository root. Defaults to two levels above this script.

.PARAMETER Configuration
    Build configuration folder under artifacts/. Defaults to Debug.

.PARAMETER OverlayFile
    Path to overlay.json. Defaults to alongside this script.

.PARAMETER WhatIf
    Show what would change without writing.

.EXAMPLE
    pwsh ./tools/PreviewOverlay/Apply-PreviewOverlay.ps1
#>
[CmdletBinding(SupportsShouldProcess)]
param(
    [string] $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path,
    [string] $Configuration = 'Debug',
    [string] $OverlayFile = (Join-Path $PSScriptRoot 'overlay.json')
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path $OverlayFile)) {
    throw "Overlay file not found: $OverlayFile"
}

$overlay = Get-Content -Raw -Path $OverlayFile | ConvertFrom-Json
$artifactsRoot = Join-Path $RepoRoot "artifacts/$Configuration"

if (-not (Test-Path $artifactsRoot)) {
    throw "Artifacts folder not found: $artifactsRoot. Run the build first."
}

function Set-PsdValue {
    param(
        [string] $Path,
        [string] $Key,
        [string] $Value,
        [switch] $QuotedValue
    )
    $content = Get-Content -Raw -Path $Path
    $literal = if ($QuotedValue) { "'$($Value -replace "'", "''")'" } else { $Value }

    # Match either an existing assignment or a commented-out one (preserve leading whitespace).
    $patterns = @(
        "(?m)^(?<indent>\s*)$Key\s*=\s*'[^']*'",
        "(?m)^(?<indent>\s*)#\s*$Key\s*=.*$"
    )
    $replaced = $false
    foreach ($p in $patterns) {
        if ($content -match $p) {
            $content = [regex]::Replace($content, $p, "`${indent}$Key = $literal", 1)
            $replaced = $true
            break
        }
    }
    if (-not $replaced) {
        Write-Warning "Key '$Key' not found in $Path - skipping."
        return
    }
    if ($PSCmdlet.ShouldProcess($Path, "Set $Key = $literal")) {
        Set-Content -Path $Path -Value $content -NoNewline
        Write-Host "  patched $Key in $(Split-Path -Leaf $Path)" -ForegroundColor DarkGray
    }
}

function Set-PsdMultiLineString {
    param(
        [string] $Path,
        [string] $Key,
        [string[]] $Lines
    )
    $content = Get-Content -Raw -Path $Path
    $escaped = ($Lines | ForEach-Object { $_ -replace "'", "''" }) -join "`n"
    $literal = "'$escaped'"
    # Match Key = '...' across multiple lines (non-greedy to first unescaped close quote).
    $pattern = "(?ms)^(?<indent>[ \t]*)$Key\s*=\s*'(?:[^']|'')*'"
    if ($content -match $pattern) {
        $content = [regex]::Replace($content, $pattern, "`${indent}$Key = $literal", 1)
        if ($PSCmdlet.ShouldProcess($Path, "Set $Key (multiline)")) {
            Set-Content -Path $Path -Value $content -NoNewline
            Write-Host "  patched $Key in $(Split-Path -Leaf $Path)" -ForegroundColor DarkGray
        }
    }
    else {
        Write-Warning "Key '$Key' not found (or commented) in $Path - skipping."
    }
}

Write-Host "Applying preview overlay from $OverlayFile" -ForegroundColor Cyan

foreach ($moduleName in $overlay.modules.PSObject.Properties.Name) {
    $cfg = $overlay.modules.$moduleName
    $moduleArtifactDir = Join-Path $artifactsRoot $moduleName
    $psd1 = Join-Path $moduleArtifactDir "$moduleName.psd1"

    if (-not (Test-Path $psd1)) {
        Write-Warning "Skipping $moduleName : $psd1 not found."
        continue
    }

    Write-Host "[$moduleName]" -ForegroundColor Yellow
    if ($cfg.moduleVersion)   { Set-PsdValue        -Path $psd1 -Key 'ModuleVersion' -Value $cfg.moduleVersion -QuotedValue }
    if ($cfg.prerelease)      { Set-PsdValue        -Path $psd1 -Key 'Prerelease'    -Value $cfg.prerelease    -QuotedValue }
    if ($cfg.releaseNotes)    { Set-PsdMultiLineString -Path $psd1 -Key 'ReleaseNotes' -Lines $cfg.releaseNotes }

    # Append preview ChangeLog entries to the staged ChangeLog (does not modify source).
    $stagedChangeLog = Join-Path $moduleArtifactDir 'ChangeLog.md'
    if ($cfg.changeLogPreviewEntries -and (Test-Path $stagedChangeLog)) {
        $marker = '<!-- preview-overlay-applied -->'
        $existing = Get-Content -Raw -Path $stagedChangeLog
        if ($existing -notmatch [regex]::Escape($marker)) {
            $insertion = "`n$marker`n" + ($cfg.changeLogPreviewEntries -join "`n") + "`n"
            $patched = $existing -replace '(?ms)(## Upcoming Release\s*\r?\n)', "`$1$insertion"
            if ($PSCmdlet.ShouldProcess($stagedChangeLog, "Append preview entries")) {
                Set-Content -Path $stagedChangeLog -Value $patched -NoNewline
                Write-Host "  appended preview entries to ChangeLog.md" -ForegroundColor DarkGray
            }
        }
    }
}

# Patch AzPreview.psd1 with preview-version pins for the modules in this overlay.
$azPreviewPsd1 = Join-Path $artifactsRoot 'AzPreview/AzPreview.psd1'
if (Test-Path $azPreviewPsd1) {
    Write-Host "[AzPreview.psd1]" -ForegroundColor Yellow
    foreach ($mod in $overlay.azPreviewModuleVersions.PSObject.Properties.Name) {
        $version = $overlay.azPreviewModuleVersions.$mod
        $content = Get-Content -Raw -Path $azPreviewPsd1
        $pattern = "ModuleName\s*=\s*'$([regex]::Escape($mod))'\s*;\s*RequiredVersion\s*=\s*'[^']*'"
        $replacement = "ModuleName = '$mod'; RequiredVersion = '$version'"
        if ($content -match $pattern) {
            $content = [regex]::Replace($content, $pattern, $replacement, 1)
            if ($PSCmdlet.ShouldProcess($azPreviewPsd1, "Pin $mod = $version")) {
                Set-Content -Path $azPreviewPsd1 -Value $content -NoNewline
                Write-Host "  pinned $mod = $version" -ForegroundColor DarkGray
            }
        }
        else {
            Write-Warning "Did not find $mod entry in AzPreview.psd1"
        }
    }
}

Write-Host "Preview overlay applied." -ForegroundColor Green
