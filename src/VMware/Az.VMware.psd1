@{
  GUID = '78d2fac8-ec90-47ad-b8aa-a27106b158f5'
  RootModule = './Az.VMware.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VMware cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VMware.private.dll'
  FormatsToProcess = './Az.VMware.format.ps1xml'
  FunctionsToExport = 'Get-AzVMwareAddon', 'Get-AzVMwareCloudLink', 'Get-AzVMwareCluster', 'Get-AzVMwareDatastore', 'Get-AzVMwareExpressRouteAuthorization', 'Get-AzVMwareGlobalReachConnection', 'Get-AzVMwarePrivateCloud', 'Get-AzVMwarePrivateCloudAdminCredential', 'Get-AzVMwareScriptCmdlet', 'Get-AzVMwareScriptExecution', 'Get-AzVMwareScriptExecutionLog', 'Get-AzVMwareScriptPackage', 'Get-AzVMwareWorkloadNetworkDhcp', 'Get-AzVMwareWorkloadNetworkDnsService', 'Get-AzVMwareWorkloadNetworkDnsZone', 'Get-AzVMwareWorkloadNetworkGateway', 'Get-AzVMwareWorkloadNetworkPortMirroring', 'Get-AzVMwareWorkloadNetworkPublicIP', 'Get-AzVMwareWorkloadNetworkSegment', 'Get-AzVMwareWorkloadNetworkVM', 'Get-AzVMwareWorkloadNetworkVMGroup', 'New-AzVMwareAddon', 'New-AzVMwareAddonHcxPropertiesObject', 'New-AzVMwareAddonSrmPropertiesObject', 'New-AzVMwareAddonVrPropertiesObject', 'New-AzVMwareCloudLink', 'New-AzVMwareCluster', 'New-AzVMwareDatastore', 'New-AzVMwareExpressRouteAuthorization', 'New-AzVMwareGlobalReachConnection', 'New-AzVMwarePrivateCloud', 'New-AzVMwarePrivateCloudNsxtPassword', 'New-AzVMwarePrivateCloudVcenterPassword', 'New-AzVMwarePSCredentialExecutionParameterObject', 'New-AzVMwareScriptExecution', 'New-AzVMwareScriptExecutionParameterObject', 'New-AzVMwareScriptSecureStringExecutionParameterObject', 'New-AzVMwareScriptStringExecutionParameterObject', 'New-AzVMwareWorkloadNetworkDhcp', 'New-AzVMwareWorkloadNetworkDnsService', 'New-AzVMwareWorkloadNetworkDnsZone', 'New-AzVMwareWorkloadNetworkPortMirroring', 'New-AzVMwareWorkloadNetworkPublicIP', 'New-AzVMwareWorkloadNetworkSegment', 'New-AzVMwareWorkloadNetworkVMGroup', 'Remove-AzVMwareAddon', 'Remove-AzVMwareCloudLink', 'Remove-AzVMwareCluster', 'Remove-AzVMwareDatastore', 'Remove-AzVMwareExpressRouteAuthorization', 'Remove-AzVMwareGlobalReachConnection', 'Remove-AzVMwarePrivateCloud', 'Remove-AzVMwareScriptExecution', 'Remove-AzVMwareWorkloadNetworkDhcp', 'Remove-AzVMwareWorkloadNetworkDnsService', 'Remove-AzVMwareWorkloadNetworkDnsZone', 'Remove-AzVMwareWorkloadNetworkPortMirroring', 'Remove-AzVMwareWorkloadNetworkPublicIP', 'Remove-AzVMwareWorkloadNetworkSegment', 'Remove-AzVMwareWorkloadNetworkVMGroup', 'Test-AzVMwareLocationQuotaAvailability', 'Test-AzVMwareLocationTrialAvailability', 'Update-AzVMwareCluster', 'Update-AzVMwarePrivateCloud', 'Update-AzVMwareWorkloadNetworkDhcp', 'Update-AzVMwareWorkloadNetworkDnsService', 'Update-AzVMwareWorkloadNetworkDnsZone', 'Update-AzVMwareWorkloadNetworkPortMirroring', 'Update-AzVMwareWorkloadNetworkSegment', 'Update-AzVMwareWorkloadNetworkVMGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'VMware'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
