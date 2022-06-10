@{
  GUID = '0a430783-990a-47b9-bb3a-1a74838ee9cf'
  RootModule = './Az.StorSimple.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorSimple cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorSimple.private.dll'
  FormatsToProcess = './Az.StorSimple.format.ps1xml'
  FunctionsToExport = 'Backup-AzStorSimpleFileServerNow', 'Backup-AzStorSimpleIscsiServerNow', 'Clear-AzStorSimpleAlert', 'Copy-AzStorSimpleBackup', 'Get-AzStorSimpleAccessControlRecord', 'Get-AzStorSimpleAlert', 'Get-AzStorSimpleAvailableProviderOperation', 'Get-AzStorSimpleBackup', 'Get-AzStorSimpleBackupScheduleGroup', 'Get-AzStorSimpleChapSetting', 'Get-AzStorSimpleDevice', 'Get-AzStorSimpleDeviceAlertSetting', 'Get-AzStorSimpleDeviceFailoverTarget', 'Get-AzStorSimpleDeviceMetric', 'Get-AzStorSimpleDeviceMetricDefinition', 'Get-AzStorSimpleDeviceNetworkSetting', 'Get-AzStorSimpleDeviceTimeSetting', 'Get-AzStorSimpleDeviceUpdateSummary', 'Get-AzStorSimpleFileServer', 'Get-AzStorSimpleFileServerMetric', 'Get-AzStorSimpleFileServerMetricDefinition', 'Get-AzStorSimpleFileShare', 'Get-AzStorSimpleFileShareMetric', 'Get-AzStorSimpleFileShareMetricDefinition', 'Get-AzStorSimpleIscsiDisk', 'Get-AzStorSimpleIscsiDiskMetric', 'Get-AzStorSimpleIscsiDiskMetricDefinition', 'Get-AzStorSimpleIscsiServer', 'Get-AzStorSimpleIscsiServerMetric', 'Get-AzStorSimpleIscsiServerMetricDefinition', 'Get-AzStorSimpleJob', 'Get-AzStorSimpleManager', 'Get-AzStorSimpleManagerEncryptionKey', 'Get-AzStorSimpleManagerEncryptionSetting', 'Get-AzStorSimpleManagerExtendedInfo', 'Get-AzStorSimpleManagerMetric', 'Get-AzStorSimpleManagerMetricDefinition', 'Get-AzStorSimpleStorageAccountCredentials', 'Get-AzStorSimpleStorageDomain', 'Install-AzStorSimpleDeviceUpdate', 'Invoke-AzStorSimpleDeactivateDevice', 'Invoke-AzStorSimpleDownloadDeviceUpdate', 'Invoke-AzStorSimpleScanDevice', 'Invoke-AzStorSimpleUploadManagerRegistrationCertificate', 'New-AzStorSimpleAccessControlRecord', 'New-AzStorSimpleBackupScheduleGroup', 'New-AzStorSimpleChapSetting', 'New-AzStorSimpleDeviceAlertSetting', 'New-AzStorSimpleDeviceSecuritySetting', 'New-AzStorSimpleFileServer', 'New-AzStorSimpleFileShare', 'New-AzStorSimpleIscsiDisk', 'New-AzStorSimpleIscsiServer', 'New-AzStorSimpleManager', 'New-AzStorSimpleManagerExtendedInfo', 'New-AzStorSimpleStorageAccountCredentials', 'New-AzStorSimpleStorageDomain', 'Remove-AzStorSimpleAccessControlRecord', 'Remove-AzStorSimpleBackup', 'Remove-AzStorSimpleBackupScheduleGroup', 'Remove-AzStorSimpleChapSetting', 'Remove-AzStorSimpleDevice', 'Remove-AzStorSimpleFileServer', 'Remove-AzStorSimpleFileShare', 'Remove-AzStorSimpleIscsiDisk', 'Remove-AzStorSimpleIscsiServer', 'Remove-AzStorSimpleManager', 'Remove-AzStorSimpleManagerExtendedInfo', 'Remove-AzStorSimpleStorageAccountCredentials', 'Remove-AzStorSimpleStorageDomain', 'Send-AzStorSimpleAlertTestEmail', 'Update-AzStorSimpleDevice', 'Update-AzStorSimpleDeviceSecuritySetting', 'Update-AzStorSimpleManager', 'Update-AzStorSimpleManagerExtendedInfo', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorSimple'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
