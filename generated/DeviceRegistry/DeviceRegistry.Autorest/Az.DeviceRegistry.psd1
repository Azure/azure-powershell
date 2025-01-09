@{
  GUID = '963de81d-125e-4a2a-8a50-b14c3b068c4d'
  RootModule = './Az.DeviceRegistry.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DeviceRegistry cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DeviceRegistry.private.dll'
  FormatsToProcess = './Az.DeviceRegistry.format.ps1xml'
  FunctionsToExport = 'Get-AzDeviceRegistryAsset', 'Get-AzDeviceRegistryAssetEndpointProfile', 'Get-AzDeviceRegistryBillingContainer', 'New-AzDeviceRegistryAsset', 'New-AzDeviceRegistryAssetEndpointProfile', 'Remove-AzDeviceRegistryAsset', 'Remove-AzDeviceRegistryAssetEndpointProfile', 'Update-AzDeviceRegistryAsset', 'Update-AzDeviceRegistryAssetEndpointProfile'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DeviceRegistry'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
