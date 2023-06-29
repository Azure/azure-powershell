@{
  GUID = '37eaf44e-78f7-4a5a-82d1-f6350681704b'
  RootModule = './Az.RecoveryServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: RecoveryServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.RecoveryServices.private.dll'
  FormatsToProcess = './Az.RecoveryServices.format.ps1xml'
  FunctionsToExport = 'Disable-AzRecoveryServicesProtection', 'Edit-AzRecoveryServicesBackupRetentionPolicyClientObject', 'Edit-AzRecoveryServicesBackupSchedulePolicyClientObject', 'Enable-AzRecoveryServicesProtection', 'Export-AzRecoveryServicesJob', 'Get-AzRecoveryServicesBackupEngine', 'Get-AzRecoveryServicesBackupJob', 'Get-AzRecoveryServicesBackupOperationResult', 'Get-AzRecoveryServicesBackupOperationStatuses', 'Get-AzRecoveryServicesBackupPolicy', 'Get-AzRecoveryServicesBackupProtectableItem', 'Get-AzRecoveryServicesBackupProtectedItem', 'Get-AzRecoveryServicesBackupProtectionContainer', 'Get-AzRecoveryServicesBackupProtectionIntent', 'Get-AzRecoveryServicesBackupResourceEncryptionConfig', 'Get-AzRecoveryServicesBackupResourceStorageConfigsNonCrr', 'Get-AzRecoveryServicesBackupResourceVaultConfig', 'Get-AzRecoveryServicesBackupStatus', 'Get-AzRecoveryServicesBackupUsageSummary', 'Get-AzRecoveryServicesBackupWorkloadItem', 'Get-AzRecoveryServicesBmsPrepareDataMoveOperationResult', 'Get-AzRecoveryServicesDeletedProtectionContainer', 'Get-AzRecoveryServicesExportJobsOperationResult', 'Get-AzRecoveryServicesJobDetail', 'Get-AzRecoveryServicesJobOperationResult', 'Get-AzRecoveryServicesOperationStatus', 'Get-AzRecoveryServicesPolicyTemplate', 'Get-AzRecoveryServicesPrivateEndpointConnection', 'Get-AzRecoveryServicesPrivateEndpointOperationStatus', 'Get-AzRecoveryServicesProtectableContainer', 'Get-AzRecoveryServicesProtectedItem', 'Get-AzRecoveryServicesProtectedItemOperationResult', 'Get-AzRecoveryServicesProtectedItemOperationStatuses', 'Get-AzRecoveryServicesProtectionContainer', 'Get-AzRecoveryServicesProtectionContainerOperationResult', 'Get-AzRecoveryServicesProtectionContainerRefreshOperationResult', 'Get-AzRecoveryServicesProtectionIntent', 'Get-AzRecoveryServicesProtectionPolicyOperationResult', 'Get-AzRecoveryServicesProtectionPolicyOperationStatuses', 'Get-AzRecoveryServicesRecoveryPoint', 'Get-AzRecoveryServicesRecoveryPointsRecommendedForMove', 'Get-AzRecoveryServicesResourceGuardProxy', 'Get-AzRecoveryServicesSecurityPiN', 'Get-AzRecoveryServicesValidateOperationResult', 'Get-AzRecoveryServicesValidateOperationStatuses', 'Invoke-AzRecoveryServicesInquireProtectionContainer', 'Invoke-AzRecoveryServicesPrepare', 'Move-AzRecoveryServicesRecoveryPoint', 'New-AzRecoveryServicesBackupPolicy', 'New-AzRecoveryServicesItemLevelRecoveryConnection', 'New-AzRecoveryServicesProtectedItem', 'New-AzRecoveryServicesProtectionIntent', 'Register-AzRecoveryServicesProtectionContainer', 'Remove-AzRecoveryServicesBackupPolicy', 'Remove-AzRecoveryServicesPrivateEndpointConnection', 'Remove-AzRecoveryServicesProtectedItem', 'Remove-AzRecoveryServicesProtectionIntent', 'Remove-AzRecoveryServicesResourceGuardProxy', 'Revoke-AzRecoveryServicesItemLevelRecoveryConnection', 'Set-AzRecoveryServicesBackupResourceEncryptionConfig', 'Set-AzRecoveryServicesBackupResourceStorageConfigsNonCrr', 'Set-AzRecoveryServicesBackupResourceVaultConfig', 'Set-AzRecoveryServicesPrivateEndpointConnection', 'Set-AzRecoveryServicesProtectedItem', 'Set-AzRecoveryServicesProtectionIntent', 'Set-AzRecoveryServicesResourceGuardProxy', 'Start-AzRecoveryServices', 'Start-AzRecoveryServicesBackup', 'Start-AzRecoveryServicesJobCancellation', 'Start-AzRecoveryServicesRestore', 'Start-AzRecoveryServicesValidateOperation', 'Test-AzRecoveryServicesFeatureSupport', 'Test-AzRecoveryServicesProtectionIntent', 'Unlock-AzRecoveryServicesResourceGuardProxyDelete', 'Unregister-AzRecoveryServicesProtectionContainer', 'Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr', 'Update-AzRecoveryServicesBackupResourceVaultConfig', 'Update-AzRecoveryServicesProtectionContainer', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'RecoveryServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
