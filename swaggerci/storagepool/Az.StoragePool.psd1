@{
  GUID = '5e51c90b-b1ea-4f00-9567-0a0f3e780d9f'
  RootModule = './Az.StoragePool.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StoragePool cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StoragePool.private.dll'
  FormatsToProcess = './Az.StoragePool.format.ps1xml'
  FunctionsToExport = 'Get-AzStoragePoolDiskPool', 'Get-AzStoragePoolDiskPoolOutboundNetworkDependencyEndpoint', 'Get-AzStoragePoolDiskPoolZone', 'Get-AzStoragePoolIscsiTarget', 'Get-AzStoragePoolResourceSku', 'Invoke-AzStoragePoolDeallocateDiskPool', 'New-AzStoragePoolDiskPool', 'New-AzStoragePoolIscsiTarget', 'Remove-AzStoragePoolDiskPool', 'Remove-AzStoragePoolIscsiTarget', 'Start-AzStoragePoolDiskPool', 'Update-AzStoragePoolDiskPool', 'Update-AzStoragePoolIscsiTarget', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StoragePool'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
