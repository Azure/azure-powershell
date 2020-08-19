@{
  GUID = '6f322dc6-0b52-4caf-9fef-3dccf811ac93'
  RootModule = './Az.Migrate.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Migrate cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Migrate.private.dll'
  FormatsToProcess = './Az.Migrate.format.ps1xml'
  FunctionsToExport = 'Export-AzMigrateReplicationJob', 'Find-AzMigrateReplicationProtectionContainerProtectableItem', 'Get-AzMigrateMigrationRecoveryPoint', 'Get-AzMigrateReplicationJob', 'Get-AzMigrateReplicationMigrationItem', 'Get-AzMigrateReplicationPolicy', 'Get-AzMigrateReplicationProtectableItem', 'Get-AzMigrateReplicationProtectionContainer', 'Initialize-AzMigrateReplicationInfrastructure', 'Move-AzMigrateReplicationMigrationItem', 'New-AzMigratePolicy', 'New-AzMigrateReplicationMigrationItem', 'New-AzMigrateReplicationPolicy', 'New-AzMigrateReplicationProtectionContainer', 'Remove-AzMigrateReplicationMigrationItem', 'Remove-AzMigrateReplicationPolicy', 'Remove-AzMigrateReplicationProtectionContainer', 'Restart-AzMigrateReplicationJob', 'Resume-AzMigrateReplicationJob', 'Stop-AzMigrateReplicationJob', 'Switch-AzMigrateReplicationProtectionContainerProtection', 'Test-AzMigrateReplicationMigrationItemMigrate', 'Test-AzMigrateReplicationMigrationItemMigrateCleanup', 'Update-AzMigrateReplicationMigrationItem', 'Update-AzMigrateReplicationPolicy', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Migrate'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
