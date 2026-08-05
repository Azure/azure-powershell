@{
  GUID = '113964d9-7d75-4a3d-ac1c-0014ed44358b'
  RootModule = './Az.StorageCache.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageCache cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageCache.private.dll'
  FormatsToProcess = './Az.StorageCache.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageCacheAmlFileSystem', 'Get-AzStorageCacheAmlFileSystemSubnetRequiredSize', 'Get-AzStorageCacheAutoExportJob', 'Get-AzStorageCacheAutoImportJob', 'Get-AzStorageCacheExpansionJob', 'Get-AzStorageCacheImportJob', 'Invoke-AzStorageCacheAmlFileSystemArchive', 'New-AzStorageCacheAmlFileSystem', 'New-AzStorageCacheAutoExportJob', 'New-AzStorageCacheAutoImportJob', 'New-AzStorageCacheExpansionJob', 'New-AzStorageCacheImportJob', 'Remove-AzStorageCacheAmlFileSystem', 'Remove-AzStorageCacheAutoExportJob', 'Remove-AzStorageCacheAutoImportJob', 'Remove-AzStorageCacheExpansionJob', 'Remove-AzStorageCacheImportJob', 'Stop-AzStorageCacheAmlFilesystemArchive', 'Test-AzStorageCacheAmlFileSystemSubnet', 'Update-AzStorageCacheAmlFileSystem', 'Update-AzStorageCacheAutoExportJob', 'Update-AzStorageCacheAutoImportJob', 'Update-AzStorageCacheExpansionJob', 'Update-AzStorageCacheImportJob'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageCache'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
