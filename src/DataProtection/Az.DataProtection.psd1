@{
  GUID = 'e7388191-d3e0-4d54-b898-d55f0992a1dc'
  RootModule = './Az.DataProtection.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataProtection cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataProtection.private.dll'
  FormatsToProcess = './Az.DataProtection.format.ps1xml'
  FunctionsToExport = 'Backup-AzDataProtectionBackupInstanceAdhoc', 'Edit-AzDataProtectionPolicyRetentionRuleClientObject', 'Edit-AzDataProtectionPolicyTagClientObject', 'Edit-AzDataProtectionPolicyTriggerClientObject', 'Find-AzDataProtectionRestorableTimeRange', 'Get-AzDataProtectionBackupInstance', 'Get-AzDataProtectionBackupPolicy', 'Get-AzDataProtectionBackupVault', 'Get-AzDataProtectionJob', 'Get-AzDataProtectionOperation', 'Get-AzDataProtectionPolicyTemplate', 'Get-AzDataProtectionRecoveryPoint', 'Get-AzDataProtectionResourceGuard', 'Initialize-AzDataProtectionBackupInstance', 'Initialize-AzDataProtectionRestoreRequest', 'New-AzDataProtectionBackupConfigurationClientObject', 'New-AzDataProtectionBackupInstance', 'New-AzDataProtectionBackupPolicy', 'New-AzDataProtectionBackupVault', 'New-AzDataProtectionBackupVaultStorageSettingObject', 'New-AzDataProtectionPolicyTagCriteriaClientObject', 'New-AzDataProtectionPolicyTriggerScheduleClientObject', 'New-AzDataProtectionResourceGuard', 'New-AzDataProtectionRestoreConfigurationClientObject', 'New-AzDataProtectionRetentionLifeCycleClientObject', 'Remove-AzDataProtectionBackupInstance', 'Remove-AzDataProtectionBackupPolicy', 'Remove-AzDataProtectionBackupVault', 'Remove-AzDataProtectionResourceGuard', 'Resume-AzDataProtectionBackupInstanceProtection', 'Search-AzDataProtectionBackupInstanceInAzGraph', 'Search-AzDataProtectionJobInAzGraph', 'Set-AzDataProtectionMSIPermission', 'Start-AzDataProtectionBackupInstanceRestore', 'Stop-AzDataProtectionBackupInstanceProtection', 'Suspend-AzDataProtectionBackupInstanceBackup', 'Sync-AzDataProtectionBackupInstance', 'Test-AzDataProtectionBackupInstanceReadiness', 'Test-AzDataProtectionBackupInstanceRestore', 'Update-AzDataProtectionBackupInstanceAssociatedPolicy', 'Update-AzDataProtectionBackupVault', 'Update-AzDataProtectionResourceGuard', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataProtection'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
