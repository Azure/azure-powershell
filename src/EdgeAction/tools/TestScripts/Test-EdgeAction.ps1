# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3
<#
.SYNOPSIS
Runs the built EdgeAction scenario harness; playback is the default.
.DESCRIPTION
After configuration and mutation-consent validation, every mode refreshes maintained
test/*.Tests.ps1 and test/utils.ps1 into the existing artifact test directory.
Only changed scripts are copied and verified. Recordings, metadata, results, binaries,
and unrelated files are not changed by refresh. Orphan artifact scenario scripts stop
the run for manual review; missing artifacts require a build, not an implicit rebuild.
Cmdlet/runtime and other fixture changes still require the normal build workflow.
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
All modes leave recordings and metadata in artifacts; no automatic source copy-back,
staging, commit, or subsequent Playback is performed. After a successful full Record,
verify cleanup, run Playback separately, review the complete matching recordings and
env.json, and manually copy those reviewed outputs to source.
The scenario helper creates a randomized, run-owned resource group and deletes that
exact group during cleanup. It normalizes the RG name after successful Record cleanup;
async polling query values are not redacted. Inspect saved ownership metadata and use
the documented recovery procedure after a cleanup failure. Shared groups are not used.
Legacy ResourceGroupName settings are accepted with a warning and ignored.
No EdgeAction build is performed.
Artifact recordings remain available without automatic backups.
Review source changes and preserve any uncopied outputs before rebuilding or rerunning.
Fresh NUnit results are checked independently of the generated runner's exit code.
Failures add a concise XML summary without replacing child stdout/stderr or Pester
output. Record may add a matching fresh HTTP error's status and service code/message;
ambiguous or stale responses are not attributed. Added text redacts common sensitive
patterns, not arbitrary secrets. Raw artifact recordings are not rewritten.
Source scenario/helper edits during Record fail final consistency validation. Refreshed tests
can require fresh recordings before Playback; existing recordings are not rewritten.
Repository, default settings, and artifact paths are resolved from this script,
independently of the caller's working directory.
The documented test working directory is src/EdgeAction/EdgeAction.Autorest:
invoke ../tools/TestScripts/Test-EdgeAction.ps1 there without setting root variables.
.PARAMETER ConfigPath
Optional override data file. Defaults to TestSettings.local.psd1 beside this script,
when present, layered over TestSettings.psd1. An explicit path replaces the local
override, not the shared AzureCloud defaults. Copy TestSettings.local.example.psd1 to
TestSettings.local.psd1 for Brazilus overrides; the example is not auto-loaded.
A relative explicit ConfigPath is resolved from the caller's working directory.
.EXAMPLE
..\tools\TestScripts\Test-EdgeAction.ps1 -Mode Record -AllowResourceChanges -Login
Run from src\EdgeAction\EdgeAction.Autorest with an authorized subscription configured
in TestSettings.local.psd1. Omit TestName for a complete matching recording set.
.EXAMPLE
..\tools\TestScripts\Test-EdgeAction.ps1 -Mode Playback
Replay artifact recordings without login or live Azure resources.
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
