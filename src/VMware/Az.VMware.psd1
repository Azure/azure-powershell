@{
  GUID = '6ced3ed2-fb86-4a72-aca7-369161b12fea'
  RootModule = './Az.VMware.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: VMware cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.VMware.private.dll'
  FormatsToProcess = './Az.VMware.format.ps1xml'
  FunctionsToExport = 'Get-AzVMwareAddon', 'Get-AzVMwareAuthorization', 'Get-AzVMwareCloudLink', 'Get-AzVMwareCluster', 'Get-AzVMwareDatastore', 'Get-AzVMwareGlobalReachConnection', 'Get-AzVMwareHcxEnterpriseSite', 'Get-AzVMwarePlacementPolicy', 'Get-AzVMwarePrivateCloud', 'Get-AzVMwarePrivateCloudAdminCredential', 'Get-AzVMwareScriptCmdlet', 'Get-AzVMwareScriptExecution', 'Get-AzVMwareScriptExecutionLog', 'Get-AzVMwareScriptPackage', 'Get-AzVMwareVirtualMachine', 'Get-AzVMwareWorkloadNetworkDhcp', 'Get-AzVMwareWorkloadNetworkDnsService', 'Get-AzVMwareWorkloadNetworkDnsZone', 'Get-AzVMwareWorkloadNetworkGateway', 'Get-AzVMwareWorkloadNetworkPortMirroring', 'Get-AzVMwareWorkloadNetworkPublicIP', 'Get-AzVMwareWorkloadNetworkSegment', 'Get-AzVMwareWorkloadNetworkVM', 'Get-AzVMwareWorkloadNetworkVMGroup', 'Lock-AzVMwareVirtualMachineMovement', 'New-AzVMwareAddon', 'New-AzVMwareAddonSrmPropertiesObject', 'New-AzVMwareAddonVrPropertiesObject', 'New-AzVMwareAuthorization', 'New-AzVMwareCloudLink', 'New-AzVMwareCluster', 'New-AzVMwareDatastore', 'New-AzVMwareGlobalReachConnection', 'New-AzVMwareHcxEnterpriseSite', 'New-AzVMwarePlacementPolicy', 'New-AzVMwarePrivateCloud', 'New-AzVMwarePrivateCloudNsxtPassword', 'New-AzVMwarePrivateCloudVcenterPassword', 'New-AzVMwarePSCredentialExecutionParameterObject', 'New-AzVMwareScriptExecution', 'New-AzVMwareScriptSecureStringExecutionParameterObject', 'New-AzVMwareScriptStringExecutionParameterObject', 'New-AzVMwareWorkloadNetworkDhcp', 'New-AzVMwareWorkloadNetworkDnsService', 'New-AzVMwareWorkloadNetworkDnsZone', 'New-AzVMwareWorkloadNetworkPortMirroring', 'New-AzVMwareWorkloadNetworkPublicIP', 'New-AzVMwareWorkloadNetworkSegment', 'New-AzVMwareWorkloadNetworkVMGroup', 'Remove-AzVMwareAddon', 'Remove-AzVMwareAuthorization', 'Remove-AzVMwareCloudLink', 'Remove-AzVMwareCluster', 'Remove-AzVMwareDatastore', 'Remove-AzVMwareGlobalReachConnection', 'Remove-AzVMwareHcxEnterpriseSite', 'Remove-AzVMwarePlacementPolicy', 'Remove-AzVMwarePrivateCloud', 'Remove-AzVMwareScriptExecution', 'Remove-AzVMwareWorkloadNetworkDhcp', 'Remove-AzVMwareWorkloadNetworkDnsService', 'Remove-AzVMwareWorkloadNetworkDnsZone', 'Remove-AzVMwareWorkloadNetworkPortMirroring', 'Remove-AzVMwareWorkloadNetworkPublicIP', 'Remove-AzVMwareWorkloadNetworkSegment', 'Remove-AzVMwareWorkloadNetworkVMGroup', 'Test-AzVMwareLocationQuotaAvailability', 'Test-AzVMwareLocationTrialAvailability', 'Update-AzVMwareCluster', 'Update-AzVMwarePlacementPolicy', 'Update-AzVMwarePrivateCloud', 'Update-AzVMwareWorkloadNetworkDhcp', 'Update-AzVMwareWorkloadNetworkDnsService', 'Update-AzVMwareWorkloadNetworkDnsZone', 'Update-AzVMwareWorkloadNetworkPortMirroring', 'Update-AzVMwareWorkloadNetworkSegment', 'Update-AzVMwareWorkloadNetworkVMGroup', '*'
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
