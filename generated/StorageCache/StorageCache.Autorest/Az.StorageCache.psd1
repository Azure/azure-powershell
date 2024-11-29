@{
  GUID = '113964d9-7d75-4a3d-ac1c-0014ed44358b'
  RootModule = './Az.StorageCache.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageCache cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageCache.private.dll'
  FormatsToProcess = './Az.StorageCache.format.ps1xml'
  FunctionsToExport = 'Clear-AzStorageCache', 'Clear-AzStorageCacheTarget', 'Debug-AzStorageCache', 'Get-AzStorageCache', 'Get-AzStorageCacheAmlFileSystem', 'Get-AzStorageCacheAmlFileSystemSubnetRequiredSize', 'Get-AzStorageCacheAscUsage', 'Get-AzStorageCacheSku', 'Get-AzStorageCacheTarget', 'Get-AzStorageCacheUsageModel', 'Invoke-AzStorageCacheAmlFileSystemArchive', 'Invoke-AzStorageCacheInvalidateTarget', 'New-AzStorageCache', 'New-AzStorageCacheAmlFileSystem', 'New-AzStorageCacheDirectorySettingObject', 'New-AzStorageCacheNamespaceJunctionObject', 'New-AzStorageCacheNfsAccessPolicyObject', 'New-AzStorageCacheNfsAccessRuleObject', 'New-AzStorageCachePrimingJobObject', 'New-AzStorageCacheTarget', 'New-AzStorageCacheTargetSpaceAllocationObject', 'Remove-AzStorageCache', 'Remove-AzStorageCacheAmlFileSystem', 'Remove-AzStorageCacheTarget', 'Restore-AzStorageCacheTargetSetting', 'Resume-AzStorageCachePrimingJob', 'Resume-AzStorageCacheTarget', 'Start-AzStorageCache', 'Start-AzStorageCachePrimingJob', 'Stop-AzStorageCache', 'Stop-AzStorageCacheAmlFilesystemArchive', 'Stop-AzStorageCachePrimingJob', 'Suspend-AzStorageCachePrimingJob', 'Suspend-AzStorageCacheTarget', 'Test-AzStorageCacheAmlFileSystemSubnet', 'Update-AzStorageCache', 'Update-AzStorageCacheAmlFileSystem', 'Update-AzStorageCacheFirmware', 'Update-AzStorageCacheSpaceAllocation', 'Update-AzStorageCacheTargetDns', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageCache'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
