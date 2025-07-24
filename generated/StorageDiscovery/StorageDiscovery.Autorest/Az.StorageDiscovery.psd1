@{
  GUID = '6c2f65ae-65d7-4e75-9e72-c150a3c860a2'
  RootModule = './Az.StorageDiscovery.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageDiscovery cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageDiscovery.private.dll'
  FormatsToProcess = './Az.StorageDiscovery.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageDiscoveryWorkspace', 'New-AzStorageDiscoveryScopeObject', 'New-AzStorageDiscoveryWorkspace', 'Remove-AzStorageDiscoveryWorkspace', 'Update-AzStorageDiscoveryWorkspace'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageDiscovery'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
