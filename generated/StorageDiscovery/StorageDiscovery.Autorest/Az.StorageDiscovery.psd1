@{
  GUID = '81a2f031-8f0e-4640-9129-5f4b797b8a95'
  RootModule = './Az.StorageDiscovery.psm1'
  ModuleVersion = '1.0.0'
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
