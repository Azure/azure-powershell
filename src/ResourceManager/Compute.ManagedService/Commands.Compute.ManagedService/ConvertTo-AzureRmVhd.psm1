# Root module manifest for module 'AzureRM.ManagedComputeServices'

$PSDefaultParameterValues.Clear()
Set-StrictMode -Version Latest

$installedModule = Get-Module -ListAvailable Hyper-V | Select -First 1;
if ($installedModule -eq $null -or ($installedModule -ne $null -and $installedModule.Version.ToString().CompareTo("1.1") -lt 0))
{
        $instructions =
@"
This module requires Hyper-V version 1.1. Please follow the instructions below to enable Hyper-V on your Windows System:
1) https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v
2) https://docs.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/install-the-hyper-v-role-on-windows-server
"@;
    Write-Error $instructions -ErrorAction Stop
}
else
{
    Import-Module Hyper-V -MinimumVersion 1.1 -Scope Global
	. $PSScriptRoot\Tools\ConvertTo-AzureRmVhd.ps1
}
