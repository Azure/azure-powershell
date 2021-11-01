@{
  GUID = 'c638312b-9fd1-4611-a5cc-11a8caa5b698'
  RootModule = './Az.Migrate.psm1'
  ModuleVersion = '1.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Migrate cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Migrate.private.dll'
  FormatsToProcess = './Az.Migrate.format.ps1xml'
  FunctionsToExport = 'Get-AzMigrateDiscoveredServer', 'Get-AzMigrateJob', 'Get-AzMigrateProject', 'Get-AzMigrateReplicationEligibilityResult', 'Get-AzMigrateReplicationFabric', 'Get-AzMigrateReplicationPolicy', 'Get-AzMigrateReplicationProtectionContainer', 'Get-AzMigrateReplicationProtectionContainerMapping', 'Get-AzMigrateReplicationProtectionIntent', 'Get-AzMigrateReplicationRecoveryServicesProvider', 'Get-AzMigrateReplicationVaultSetting', 'Get-AzMigrateRunAsAccount', 'Get-AzMigrateServerReplication', 'Get-AzMigrateSite', 'Get-AzMigrateSolution', 'Get-AzMigrateSupportedOperatingSystem', 'Initialize-AzMigrateReplicationInfrastructure', 'New-AzMigrateDiskMapping', 'New-AzMigrateNicMapping', 'New-AzMigrateProject', 'New-AzMigrateReplicationPolicy', 'New-AzMigrateReplicationProtectionContainerMapping', 'New-AzMigrateReplicationProtectionIntent', 'New-AzMigrateReplicationVaultSetting', 'New-AzMigrateServerReplication', 'Register-AzMigrateProjectTool', 'Remove-AzMigrateProject', 'Remove-AzMigrateServerReplication', 'Restart-AzMigrateServerReplication', 'Set-AzMigrateDiskMapping', 'Set-AzMigrateServerReplication', 'Start-AzMigrateServerMigration', 'Start-AzMigrateTestMigration', 'Start-AzMigrateTestMigrationCleanup', '*'
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
