#Requires -Version 7.0
<#
.SYNOPSIS
    One-time per-clone setup for the Az.CosmosDB-preview branch.

.DESCRIPTION
    Configures git so future `git merge main` operations on this preview
    branch require minimal manual conflict resolution.

    Enables rerere so previously-resolved conflicts are auto-replayed on
    subsequent merges. This addresses the recurring CosmosDB-source-file
    conflicts (Az.CosmosDB.psd1, ChangeLog.md, AccountTests.ps1, etc.)
    once you have resolved them once with the help of the build-time
    overlay.

    Safe to re-run; commands are idempotent.

.EXAMPLE
    pwsh ./src/CosmosDB/PreviewOverlay/Setup-PreviewBranch.ps1
#>
[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

# Enable rerere - learns conflict resolutions and replays them on next merge.
git config rerere.enabled true
git config rerere.autoupdate true

Write-Host "Preview branch git setup complete:" -ForegroundColor Green
Write-Host "  rerere.enabled    = $(git config --get rerere.enabled)"
Write-Host "  rerere.autoupdate = $(git config --get rerere.autoupdate)"
Write-Host ""
Write-Host "Each developer working on this preview branch must run this script once per clone." -ForegroundColor Yellow
