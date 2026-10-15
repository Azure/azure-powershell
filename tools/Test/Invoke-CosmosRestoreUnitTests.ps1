# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

<#
.SYNOPSIS
Runs offline Cosmos restore and cross-workload regression tests against a locally built module.
.DESCRIPTION
Run in a fresh PowerShell process after building the tracked DataProtection project.
No Azure context, provisioning, or recording environment is required. Azure
boundaries in permission tests are mocked. Test result files contain synthetic IDs.
#>
[CmdletBinding()]
param(
    [string] $RepoRoot = (Split-Path -Parent (Split-Path -Parent $PSScriptRoot)),
    [string] $OutputDirectory,
    [string[]] $TestName = @('CosmosRestoreConfiguration', 'CosmosRestoreRegression', 'CosmosRestorePermission', 'CosmosRestoreTransport', 'CosmosRestoreHarness', 'CosmosRestoreSharedIdentity')
)

$ErrorActionPreference = 'Stop'
$moduleRoot = Join-Path $RepoRoot 'artifacts/Debug/Az.DataProtection/DataProtection.Autorest'
$sourceRoot = Join-Path $RepoRoot 'src/DataProtection/DataProtection.Autorest'
$pesterManifest = Join-Path $sourceRoot 'generated/modules/Pester/4.10.1/Pester.psd1'
Import-Module $pesterManifest -RequiredVersion 4.10.1 -ErrorAction Stop
Import-Module Az.Accounts -MinimumVersion 5.5.3 -ErrorAction Stop
Import-Module Az.Resources -ErrorAction Stop
Import-Module (Join-Path $moduleRoot 'Az.DataProtection.psd1') -ErrorAction Stop

$type = 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type]
if ($null -eq $type -or $type.Assembly.Location -ne (Join-Path $moduleRoot 'bin/Az.DataProtection.private.dll')) {
    throw 'Tests require the freshly built tracked DataProtection assembly in a clean PowerShell process.'
}
if ([string]::IsNullOrEmpty($OutputDirectory)) {
    $OutputDirectory = Join-Path $RepoRoot 'artifacts/CosmosRestoreTests'
}
$null = New-Item -ItemType Directory -Path $OutputDirectory -Force
$files = @($TestName | ForEach-Object { Join-Path $sourceRoot "test/$_.Tests.ps1" })
$result = Invoke-Pester -Script $files -PassThru -OutputFile (Join-Path $OutputDirectory 'UnitTests.xml') -OutputFormat NUnitXml
$result | Select-Object TotalCount, PassedCount, FailedCount, SkippedCount, PendingCount, Time | Format-List
if ($result.TotalCount -eq 0 -or $result.FailedCount -gt 0 -or $result.SkippedCount -gt 0 -or $result.PendingCount -gt 0) {
    throw 'Cosmos restore unit/regression tests did not all pass.'
}