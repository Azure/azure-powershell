@{
  GUID = 'f93d4912-a7fb-4df5-a251-edc09c325452'
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
  FunctionsToExport = 'Backup-AzDataProtectionBackupInstanceAdhoc', 'Get-AzDataProtectionBackupInstance', 'Get-AzDataProtectionBackupPolicy', 'Get-AzDataProtectionBackupVault', 'Get-AzDataProtectionExportJobsOperationResult', 'Get-AzDataProtectionJob', 'Get-AzDataProtectionOperationResult', 'Get-AzDataProtectionOperationResultPatch', 'Get-AzDataProtectionOperationStatus', 'Get-AzDataProtectionRecoveryPoint', 'Remove-AzDataProtectionBackupInstance', 'Remove-AzDataProtectionBackupPolicy', 'Remove-AzDataProtectionBackupVault', 'Set-AzDataProtectionBackupInstance', 'Set-AzDataProtectionBackupVault', 'Start-AzDataProtectionBackupInstanceRehydrate', 'Start-AzDataProtectionBackupInstanceRestore', 'Start-AzDataProtectionExportJob', 'Test-AzDataProtectionBackupInstance', 'Test-AzDataProtectionBackupInstanceRestore', 'Test-AzDataProtectionBackupVaultNameAvailability', 'Test-AzDataProtectionFeatureSupport', 'Update-AzDataProtectionBackupVault', '*'
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
