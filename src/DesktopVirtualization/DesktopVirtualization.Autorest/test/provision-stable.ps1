#Requires -Version 7.0
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Medium')]
param(
    [Parameter(Mandatory)][string]$TenantId,
    [Parameter(Mandatory)][string]$SubscriptionId,
    [Parameter(Mandatory)][string]$ResourceGroupName,
    [Parameter(Mandatory)][string]$Location,
    [ValidateSet('All', 'ControlPlane', 'SessionHosts', 'Msix')][string[]]$Include = @('All'),
    [pscredential]$VMAdminCredential,
    [string]$VMSize,
    [string]$MsixVhdxSourcePath,
    [string]$AvdDscConfigUrl = 'https://wvdportalstorageblob.blob.core.windows.net/galleryartifacts/Configuration_1.0.02790.438.zip',
    [string]$StatePath,
    [string]$RuntimeEnvPath,
    [switch]$RepairSessionHosts,
    [switch]$PlanOnly
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'provision-common.ps1')
Invoke-AvdProvision -Profile Stable @PSBoundParameters