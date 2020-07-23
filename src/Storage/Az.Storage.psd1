@{
  GUID = 'f53f52d4-46f1-4c1a-ea8d-2b74552f6379'
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '4.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml', './custom/Microsoft.WindowsAzure.Commands.Storage.format.ps1xml', './custom/Microsoft.WindowsAzure.Commands.Storage.generated.format.ps1xml', './custom/Storage.format.ps1xml', './custom/Storage.generated.format.ps1xml'
  CmdletsToExport = 'Clear-AzRmStorageContainerLegalHold', 'Close-AzStorageFileHandle', 'Disable-AzStorageDeleteRetentionPolicy', 'Disable-AzStorageStaticWebsite', 'Enable-AzStorageDeleteRetentionPolicy', 'Enable-AzStorageStaticWebsite', 'Get-AzFileService', 'Get-AzFileServiceProperty', 'Get-AzFileShare', 'Get-AzRmStorageContainer', 'Get-AzRmStorageContainerImmutabilityPolicy', 'Get-AzSku', 'Get-AzStorageAccount', 'Get-AzStorageAccountKey', 'Get-AzStorageAccountManagementPolicy', 'Get-AzStorageAccountSas', 'Get-AzStorageAccountServiceSas', 'Get-AzStorageBlob', 'Get-AzStorageBlobContent', 'Get-AzStorageBlobCopyState', 'Get-AzStorageBlobService', 'Get-AzStorageBlobServiceProperty', 'Get-AzStorageContainer', 'Get-AzStorageContainerStoredAccessPolicy', 'Get-AzStorageCORSRule', 'Get-AzStorageFile', 'Get-AzStorageFileContent', 'Get-AzStorageFileCopyState', 'Get-AzStorageFileHandle', 'Get-AzStorageQueue', 'Get-AzStorageQueueStoredAccessPolicy', 'Get-AzStorageServiceLoggingProperty', 'Get-AzStorageServiceMetricsProperty', 'Get-AzStorageServiceProperty', 'Get-AzStorageShare', 'Get-AzStorageShareStoredAccessPolicy', 'Get-AzStorageTable', 'Get-AzStorageTableStoredAccessPolicy', 'Get-AzStorageUsage', 'Invoke-AzLeaseBlobContainer', 'Invoke-AzStorageAccountFailover', 'Lock-AzRmStorageContainerImmutabilityPolicy', 'New-AzFileShare', 'New-AzRmStorageContainer', 'New-AzRmStorageContainerImmutabilityPolicy', 'New-AzStorageAccount', 'New-AzStorageAccountKey', 'New-AzStorageAccountManagementPolicy', 'New-AzStorageAccountSASToken', 'New-AzStorageBlobSASToken', 'New-AzStorageContainer', 'New-AzStorageContainerSASToken', 'New-AzStorageContainerStoredAccessPolicy', 'New-AzStorageContext', 'New-AzStorageDirectory', 'New-AzStorageFileSASToken', 'New-AzStorageQueue', 'New-AzStorageQueueSASToken', 'New-AzStorageQueueStoredAccessPolicy', 'New-AzStorageShare', 'New-AzStorageShareSASToken', 'New-AzStorageShareStoredAccessPolicy', 'New-AzStorageTable', 'New-AzStorageTableSASToken', 'New-AzStorageTableStoredAccessPolicy', 'Remove-AzFileShare', 'Remove-AzRmStorageContainer', 'Remove-AzRmStorageContainerImmutabilityPolicy', 'Remove-AzStorageAccount', 'Remove-AzStorageAccountManagementPolicy', 'Remove-AzStorageBlob', 'Remove-AzStorageContainer', 'Remove-AzStorageContainerStoredAccessPolicy', 'Remove-AzStorageCORSRule', 'Remove-AzStorageDirectory', 'Remove-AzStorageFile', 'Remove-AzStorageQueue', 'Remove-AzStorageQueueStoredAccessPolicy', 'Remove-AzStorageShare', 'Remove-AzStorageShareStoredAccessPolicy', 'Remove-AzStorageTable', 'Remove-AzStorageTableStoredAccessPolicy', 'Revoke-AzStorageAccountUserDelegationKey', 'Set-AzFileServiceProperty', 'Set-AzRmStorageContainerImmutabilityPolicy', 'Set-AzRmStorageContainerLegalHold', 'Set-AzStorageAccountManagementPolicy', 'Set-AzStorageBlobContent', 'Set-AzStorageBlobServiceProperty', 'Set-AzStorageContainerAcl', 'Set-AzStorageContainerStoredAccessPolicy', 'Set-AzStorageCORSRule', 'Set-AzStorageFileContent', 'Set-AzStorageQueueStoredAccessPolicy', 'Set-AzStorageServiceLoggingProperty', 'Set-AzStorageServiceMetricsProperty', 'Set-AzStorageShareQuota', 'Set-AzStorageShareStoredAccessPolicy', 'Set-AzStorageTableStoredAccessPolicy', 'Start-AzStorageBlobCopy', 'Start-AzStorageBlobIncrementalCopy', 'Start-AzStorageFileCopy', 'Stop-AzStorageBlobCopy', 'Stop-AzStorageFileCopy', 'Test-AzStorageAccountNameAvailability', 'Update-AzFileShare', 'Update-AzRmStorageContainer', 'Update-AzStorageAccount', 'Update-AzStorageServiceProperty', '*'
  AliasesToExport = 'Remove-AzRmStorageContainerLegalHold', 'Disable-AzStorageSoftDelete', 'Enable-AzStorageSoftDelete', 'Get-AzStorageContainerAcl', 'Add-AzRmStorageContainerLegalHold', 'Start-CopyAzureStorageBlob', 'Stop-CopyAzureStorageBlob', 'Get-AzStorageAccountNameAvailability', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
}
