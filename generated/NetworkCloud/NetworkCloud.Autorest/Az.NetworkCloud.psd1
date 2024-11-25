@{
  GUID = 'c1da95ce-b8cb-46c5-bb1c-80e3132dbb72'
  RootModule = './Az.NetworkCloud.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NetworkCloud cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkCloud.private.dll'
  FormatsToProcess = './Az.NetworkCloud.format.ps1xml'
  FunctionsToExport = 'Deploy-AzNetworkCloudCluster', 'Disable-AzNetworkCloudStorageApplianceRemoteVendorManagement', 'Enable-AzNetworkCloudStorageApplianceRemoteVendorManagement', 'Get-AzNetworkCloudAgentPool', 'Get-AzNetworkCloudBareMetalMachine', 'Get-AzNetworkCloudBareMetalMachineKeySet', 'Get-AzNetworkCloudBmcKeySet', 'Get-AzNetworkCloudCluster', 'Get-AzNetworkCloudClusterManager', 'Get-AzNetworkCloudConsole', 'Get-AzNetworkCloudKubernetesCluster', 'Get-AzNetworkCloudL2Network', 'Get-AzNetworkCloudL3Network', 'Get-AzNetworkCloudMetricsConfiguration', 'Get-AzNetworkCloudRack', 'Get-AzNetworkCloudRackSku', 'Get-AzNetworkCloudServicesNetwork', 'Get-AzNetworkCloudStorageAppliance', 'Get-AzNetworkCloudTrunkedNetwork', 'Get-AzNetworkCloudVirtualMachine', 'Get-AzNetworkCloudVolume', 'Invoke-AzNetworkCloudBareMetalMachineCordon', 'Invoke-AzNetworkCloudBareMetalMachineDataExtract', 'Invoke-AzNetworkCloudBareMetalMachineReimage', 'Invoke-AzNetworkCloudBareMetalMachineReplace', 'Invoke-AzNetworkCloudBareMetalMachineRunCommand', 'Invoke-AzNetworkCloudBareMetalMachineRunReadCommand', 'Invoke-AzNetworkCloudBareMetalMachineUncordon', 'Invoke-AzNetworkCloudClusterVersionUpdate', 'Invoke-AzNetworkCloudVirtualMachineReimage', 'New-AzNetworkCloudAgentPool', 'New-AzNetworkCloudBareMetalMachineConfigurationDataObject', 'New-AzNetworkCloudBareMetalMachineKeySet', 'New-AzNetworkCloudBgpAdvertisementObject', 'New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject', 'New-AzNetworkCloudBmcKeySet', 'New-AzNetworkCloudCluster', 'New-AzNetworkCloudClusterManager', 'New-AzNetworkCloudConsole', 'New-AzNetworkCloudControlPlaneNodeConfigurationObject', 'New-AzNetworkCloudEgressEndpointObject', 'New-AzNetworkCloudEndpointDependencyObject', 'New-AzNetworkCloudInitialAgentPoolConfigurationObject', 'New-AzNetworkCloudIpAddressPoolObject', 'New-AzNetworkCloudKeySetUserObject', 'New-AzNetworkCloudKubernetesCluster', 'New-AzNetworkCloudL2Network', 'New-AzNetworkCloudL3Network', 'New-AzNetworkCloudL3NetworkAttachmentConfigurationObject', 'New-AzNetworkCloudMetricsConfiguration', 'New-AzNetworkCloudNetworkAttachmentObject', 'New-AzNetworkCloudRackDefinitionObject', 'New-AzNetworkCloudServiceLoadBalancerBgpPeerObject', 'New-AzNetworkCloudServicesNetwork', 'New-AzNetworkCloudStorageApplianceConfigurationDataObject', 'New-AzNetworkCloudTrunkedNetwork', 'New-AzNetworkCloudVirtualMachine', 'New-AzNetworkCloudVirtualMachinePlacementHintObject', 'New-AzNetworkCloudVolume', 'Remove-AzNetworkCloudAgentPool', 'Remove-AzNetworkCloudBareMetalMachineKeySet', 'Remove-AzNetworkCloudBmcKeySet', 'Remove-AzNetworkCloudCluster', 'Remove-AzNetworkCloudClusterManager', 'Remove-AzNetworkCloudConsole', 'Remove-AzNetworkCloudKubernetesCluster', 'Remove-AzNetworkCloudL2Network', 'Remove-AzNetworkCloudL3Network', 'Remove-AzNetworkCloudMetricsConfiguration', 'Remove-AzNetworkCloudServicesNetwork', 'Remove-AzNetworkCloudTrunkedNetwork', 'Remove-AzNetworkCloudVirtualMachine', 'Remove-AzNetworkCloudVolume', 'Restart-AzNetworkCloudBareMetalMachine', 'Restart-AzNetworkCloudKubernetesClusterNode', 'Restart-AzNetworkCloudVirtualMachine', 'Start-AzNetworkCloudBareMetalMachine', 'Start-AzNetworkCloudVirtualMachine', 'Stop-AzNetworkCloudBareMetalMachine', 'Stop-AzNetworkCloudVirtualMachine', 'Update-AzNetworkCloudAgentPool', 'Update-AzNetworkCloudBareMetalMachine', 'Update-AzNetworkCloudBareMetalMachineKeySet', 'Update-AzNetworkCloudBmcKeySet', 'Update-AzNetworkCloudCluster', 'Update-AzNetworkCloudClusterManager', 'Update-AzNetworkCloudConsole', 'Update-AzNetworkCloudKubernetesCluster', 'Update-AzNetworkCloudL2Network', 'Update-AzNetworkCloudL3Network', 'Update-AzNetworkCloudMetricsConfiguration', 'Update-AzNetworkCloudRack', 'Update-AzNetworkCloudServicesNetwork', 'Update-AzNetworkCloudStorageAppliance', 'Update-AzNetworkCloudTrunkedNetwork', 'Update-AzNetworkCloudVirtualMachine', 'Update-AzNetworkCloudVolume', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NetworkCloud'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
