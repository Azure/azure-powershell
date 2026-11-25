@{
  GUID = '22b48398-5303-4151-bc99-bad11248a7b8'
  RootModule = './Az.Commvault.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Commvault cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Commvault.private.dll'
  FormatsToProcess = './Az.Commvault.format.ps1xml'
  FunctionsToExport = 'Backup-AzCommvaultProtectionGroup', 'Connect-AzCommvaultCloudAccountSaaS', 'Disable-AzCommvaultStorageComplianceLock', 'Enable-AzCommvaultStorageComplianceLock', 'Get-AzCommvaultCloudAccount', 'Get-AzCommvaultCloudAccountLatestLinkedSaaS', 'Get-AzCommvaultPlan', 'Get-AzCommvaultProtectedItem', 'Get-AzCommvaultProtectedItemCount', 'Get-AzCommvaultProtectedItemRestorePoint', 'Get-AzCommvaultProtectionGroup', 'Get-AzCommvaultRoleMapping', 'Get-AzCommvaultStorage', 'Initialize-AzCommvaultSaaS', 'New-AzCommvaultCloudAccount', 'New-AzCommvaultPlan', 'New-AzCommvaultProtectionGroup', 'New-AzCommvaultRoleMapping', 'New-AzCommvaultStorage', 'Remove-AzCommvaultCloudAccount', 'Remove-AzCommvaultPlan', 'Remove-AzCommvaultProtectionGroup', 'Remove-AzCommvaultRoleMapping', 'Remove-AzCommvaultStorage', 'Restore-AzCommvaultProtectedItem', 'Restore-AzCommvaultProtectionGroup', 'Resume-AzCommvaultProtectionGroupBackup', 'Stop-AzCommvaultProtectionGroupBackup', 'Sync-AzCommvaultStorage', 'Update-AzCommvaultCloudAccount', 'Update-AzCommvaultPlan', 'Update-AzCommvaultProtectionGroup', 'Update-AzCommvaultRoleMapping', 'Update-AzCommvaultStorage'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Commvault'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
