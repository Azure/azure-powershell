@{
  GUID = 'cbe4435b-ce43-436a-a28d-eaec9bb4c556'
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
  FunctionsToExport = 'Add-AzNetworkCloudVirtualMachineVolume', 'Deploy-AzNetworkCloudCluster', 'Disable-AzNetworkCloudStorageApplianceRemoteVendorManagement', 'Enable-AzNetworkCloudStorageApplianceRemoteVendorManagement', 'Get-AzNetworkCloudBareMetalMachine', 'Get-AzNetworkCloudBareMetalMachineKeySet', 'Get-AzNetworkCloudBmcKeySet', 'Get-AzNetworkCloudCluster', 'Get-AzNetworkCloudClusterManager', 'Get-AzNetworkCloudConsole', 'Get-AzNetworkCloudDefaultCniNetwork', 'Get-AzNetworkCloudHybridAkCluster', 'Get-AzNetworkCloudHybridAksCluster', 'Get-AzNetworkCloudL2Network', 'Get-AzNetworkCloudL3Network', 'Get-AzNetworkCloudMetricConfiguration', 'Get-AzNetworkCloudMetricsConfiguration', 'Get-AzNetworkCloudRack', 'Get-AzNetworkCloudRackSku', 'Get-AzNetworkCloudServiceNetwork', 'Get-AzNetworkCloudServicesNetwork', 'Get-AzNetworkCloudStorageAppliance', 'Get-AzNetworkCloudTrunkedNetwork', 'Get-AzNetworkCloudVirtualMachine', 'Get-AzNetworkCloudVolume', 'Invoke-AzNetworkCloudCordonBareMetalMachine', 'Invoke-AzNetworkCloudDetachVirtualMachineVolume', 'Invoke-AzNetworkCloudUncordonBareMetalMachine', 'New-AzNetworkCloudBareMetalMachine', 'New-AzNetworkCloudBareMetalMachineKeySet', 'New-AzNetworkCloudBmcKeySet', 'New-AzNetworkCloudCluster', 'New-AzNetworkCloudClusterManager', 'New-AzNetworkCloudConsole', 'New-AzNetworkCloudDefaultCniNetwork', 'New-AzNetworkCloudHybridAkCluster', 'New-AzNetworkCloudL2Network', 'New-AzNetworkCloudL3Network', 'New-AzNetworkCloudMetricConfiguration', 'New-AzNetworkCloudRack', 'New-AzNetworkCloudServiceNetwork', 'New-AzNetworkCloudStorageAppliance', 'New-AzNetworkCloudTrunkedNetwork', 'New-AzNetworkCloudVirtualMachine', 'New-AzNetworkCloudVolume', 'Remove-AzNetworkCloudBareMetalMachine', 'Remove-AzNetworkCloudBareMetalMachineKeySet', 'Remove-AzNetworkCloudBmcKeySet', 'Remove-AzNetworkCloudCluster', 'Remove-AzNetworkCloudClusterManager', 'Remove-AzNetworkCloudConsole', 'Remove-AzNetworkCloudDefaultCniNetwork', 'Remove-AzNetworkCloudHybridAksCluster', 'Remove-AzNetworkCloudL2Network', 'Remove-AzNetworkCloudL3Network', 'Remove-AzNetworkCloudMetricsConfiguration', 'Remove-AzNetworkCloudRack', 'Remove-AzNetworkCloudServicesNetwork', 'Remove-AzNetworkCloudStorageAppliance', 'Remove-AzNetworkCloudTrunkedNetwork', 'Remove-AzNetworkCloudVirtualMachine', 'Remove-AzNetworkCloudVolume', 'Restart-AzNetworkCloudBareMetalMachine', 'Restart-AzNetworkCloudHybridAkClusterNode', 'Restart-AzNetworkCloudVirtualMachine', 'Start-AzNetworkCloudBareMetalMachine', 'Start-AzNetworkCloudBareMetalMachineCommand', 'Start-AzNetworkCloudBareMetalMachineDataExtract', 'Start-AzNetworkCloudBareMetalMachineReadCommand', 'Start-AzNetworkCloudStorageApplianceReadCommand', 'Start-AzNetworkCloudVirtualMachine', 'Stop-AzNetworkCloudBareMetalMachine', 'Stop-AzNetworkCloudVirtualMachine', 'Test-AzNetworkCloudBareMetalMachineHardware', 'Test-AzNetworkCloudStorageApplianceHardware', 'Update-AzNetworkCloudBareMetalMachine', 'Update-AzNetworkCloudBareMetalMachineKeySet', 'Update-AzNetworkCloudBmcKeySet', 'Update-AzNetworkCloudCluster', 'Update-AzNetworkCloudClusterManager', 'Update-AzNetworkCloudClusterVersion', 'Update-AzNetworkCloudConsole', 'Update-AzNetworkCloudDefaultCniNetwork', 'Update-AzNetworkCloudHybridAksCluster', 'Update-AzNetworkCloudL2Network', 'Update-AzNetworkCloudL3Network', 'Update-AzNetworkCloudMetricsConfiguration', 'Update-AzNetworkCloudRack', 'Update-AzNetworkCloudServicesNetwork', 'Update-AzNetworkCloudStorageAppliance', 'Update-AzNetworkCloudTrunkedNetwork', 'Update-AzNetworkCloudVirtualMachine', 'Update-AzNetworkCloudVolume', '*'
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
