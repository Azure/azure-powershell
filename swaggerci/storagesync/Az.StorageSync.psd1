@{
  GUID = 'b3586b6b-d352-4234-a731-67ae5e00bb35'
  RootModule = './Az.StorageSync.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageSync cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageSync.private.dll'
  FormatsToProcess = './Az.StorageSync.format.ps1xml'
  FunctionsToExport = 'Backup-AzStorageSyncCloudEndpointPre', 'Get-AzStorageSyncCloudEndpoint', 'Get-AzStorageSyncGroup', 'Get-AzStorageSyncOperationStatus', 'Get-AzStorageSyncPrivateEndpointConnection', 'Get-AzStorageSyncPrivateLinkResource', 'Get-AzStorageSyncRegisteredServer', 'Get-AzStorageSyncServerEndpoint', 'Get-AzStorageSyncService', 'Get-AzStorageSyncWorkflow', 'Invoke-AzStorageSyncAbortWorkflow', 'Invoke-AzStorageSyncCloudEndpointBackup', 'Invoke-AzStorageSyncCloudEndpointRestore', 'Invoke-AzStorageSyncLocationOperationStatus', 'Invoke-AzStorageSyncRecallServerEndpointAction', 'Invoke-AzStorageSyncRestoreheartbeatCloudEndpoint', 'New-AzStorageSyncCloudEndpoint', 'New-AzStorageSyncGroup', 'New-AzStorageSyncPrivateEndpointConnection', 'New-AzStorageSyncRegisteredServer', 'New-AzStorageSyncServerEndpoint', 'New-AzStorageSyncService', 'Remove-AzStorageSyncCloudEndpoint', 'Remove-AzStorageSyncGroup', 'Remove-AzStorageSyncPrivateEndpointConnection', 'Remove-AzStorageSyncRegisteredServer', 'Remove-AzStorageSyncServerEndpoint', 'Remove-AzStorageSyncService', 'Restore-AzStorageSyncCloudEndpointPre', 'Start-AzStorageSyncCloudEndpointChangeDetection', 'Start-AzStorageSyncRegisteredServerRollover', 'Test-AzStorageSyncServiceNameAvailability', 'Update-AzStorageSyncServerEndpoint', 'Update-AzStorageSyncService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageSync'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
