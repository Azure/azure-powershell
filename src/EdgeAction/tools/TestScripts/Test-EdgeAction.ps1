# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3
<#
.SYNOPSIS
Runs the built EdgeAction scenario harness; playback is the default.
.DESCRIPTION
Record/Live require -AllowResourceChanges and an explicit expected subscription.
Shared settings select AzureCloud; the local example selects Brazilus. Only their
documented ARM endpoints and the public ARM audience are accepted.
Use -Login to authenticate inside the same isolated process as the harness.
Before support setup, Record/Live verify the configured registered environment.
If Brazilus is missing, an interactive console prompts before requesting endpoint
metadata and persisting its registration in the CurrentUser Az profile. Default is No.
Noninteractive runs must have the environment registered already.
Record/Live automatically generate/build missing or incomplete Resources test support
using the existing artifact dependency helper. Native build tools must be installed.
Playback never prepares Resources support; complete installations are reused.
After validated successful Record runs, recordings written by selected groups are copied
to source as unstaged changes for Git diff review, with compatible env.json when needed.
Playback, Live, and failed runs never copy back. No staging or commit is performed.
Known credential fields block handoff; other payloads, including embedded code/archives,
still require human review. This is not comprehensive sanitization.
No EdgeAction build or automatic cleanup of cloud resources is performed.
Artifact recordings remain available without automatic backups.
Review source changes and preserve any uncopied outputs before rebuilding or rerunning.
Fresh NUnit results are checked independently of the generated runner's exit code.
Repository, default settings, and artifact paths are resolved from this script,
independently of the caller's working directory.
The documented test working directory is src/EdgeAction/EdgeAction.Autorest:
invoke ../tools/TestScripts/Test-EdgeAction.ps1 there without setting root variables.
.PARAMETER ConfigPath
Optional override data file. Defaults to TestSettings.local.psd1 beside this script,
when present, layered over TestSettings.psd1. An explicit path replaces the local
override, not the tracked AzureCloud defaults. Copy TestSettings.local.example.psd1 to
TestSettings.local.psd1 for Brazilus overrides; the example is not auto-loaded.
A relative explicit ConfigPath is resolved from the caller's working directory.
#>
[CmdletBinding()]
param(
    [string]$ConfigPath,
    [ValidateSet('Playback', 'Record', 'Live')]
    [string]$Mode = 'Playback',
    [string]$SubscriptionId,
    [string[]]$TestName,
    [switch]$AllowResourceChanges,
    [switch]$Login
)
$ErrorActionPreference = 'Stop'
Import-Module (Join-Path $PSScriptRoot 'EdgeAction.TestRunner.psm1') -Force
$options = @{}
foreach ($key in $PSBoundParameters.Keys) { $options[$key] = $PSBoundParameters[$key] }
Invoke-EdgeActionTests -Options $options
