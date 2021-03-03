@{
  GUID = '0796af7c-0a7c-417f-8d0d-19f9179dac7a'
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
  FunctionsToExport = 'Backup-AzDataProtectionBackupInstanceAdhoc',
                    'Get-AzDataProtectionBackupInstance',
                    'Search-AzDataProtectionBackupInstanceInAzGraph',
                    'Get-AzDataProtectionBackupPolicy',
                    'Get-AzDataProtectionBackupVault',
                    'Get-AzDataProtectionBackupVaultStorageSetting',
                    'Get-AzDataProtectionExportJobsOperationResult',
                    'Get-AzDataProtectionJob',
                    'Search-AzDataProtectionJobInAzGraph', 'Get-AzDataProtectionOperationResult',
                    'Get-AzDataProtectionOperationStatus', 'Get-AzDataProtectionPolicyTemplate',
                    'Get-AzDataProtectionRecoveryPoint',
                    'Initialize-AzDataProtectionBackupInstance', 'Initialize-AzDataProtectionRestoreRequest',
                    'New-AzDataProtectionPolicyTagCriteriaClientObject',
                    'New-AzDataProtectionPolicyTriggerScheduleClientObject', 'New-AzDataProtectionRetentionLifeCycleClientObject',
                    'Remove-AzDataProtectionBackupInstance', 'Remove-AzDataProtectionBackupPolicy',
                    'Remove-AzDataProtectionBackupVault', 'Set-AzDataProtectionBackupInstance',
                    'Set-AzDataProtectionBackupPolicy', 'Set-AzDataProtectionBackupVault',
                    'Start-AzDataProtectionBackupInstanceRehydrate', 'Start-AzDataProtectionBackupInstanceRestore',
                    'Start-AzDataProtectionExportJob', 'Update-AzDataProtectionBackupVault',
                    'Edit-AzDataProtectionPolicyRetentionRuleClientObject', 'Edit-AzDataProtectionPolicyTagClientObject',
                    'Edit-AzDataProtectionPolicyTriggerClientObject'
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
