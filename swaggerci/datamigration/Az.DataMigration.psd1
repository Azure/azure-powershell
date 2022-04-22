@{
  GUID = 'b49682f6-3563-4e8c-b685-8e8facd121e7'
  RootModule = './Az.DataMigration.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataMigration cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataMigration.private.dll'
  FormatsToProcess = './Az.DataMigration.format.ps1xml'
  FunctionsToExport = 'Get-AzDataMigrationDatabaseMigrationsSqlDb', 'Get-AzDataMigrationDatabaseMigrationsSqlMi', 'Get-AzDataMigrationDatabaseMigrationsSqlVM', 'Get-AzDataMigrationFile', 'Get-AzDataMigrationProject', 'Get-AzDataMigrationResourceSku', 'Get-AzDataMigrationService', 'Get-AzDataMigrationServiceSku', 'Get-AzDataMigrationServiceTask', 'Get-AzDataMigrationSqlMigrationService', 'Get-AzDataMigrationSqlMigrationServiceAuthKey', 'Get-AzDataMigrationSqlMigrationServiceMigration', 'Get-AzDataMigrationSqlMigrationServiceMonitoringData', 'Get-AzDataMigrationTask', 'Get-AzDataMigrationUsage', 'Invoke-AzDataMigrationCommandTask', 'Invoke-AzDataMigrationCutoverDatabaseMigrationSqlMi', 'Invoke-AzDataMigrationCutoverDatabaseMigrationSqlVM', 'New-AzDataMigrationDatabaseMigrationSqlDb', 'New-AzDataMigrationDatabaseMigrationSqlMi', 'New-AzDataMigrationDatabaseMigrationSqlVM', 'New-AzDataMigrationFile', 'New-AzDataMigrationProject', 'New-AzDataMigrationService', 'New-AzDataMigrationServiceTask', 'New-AzDataMigrationSqlMigrationService', 'New-AzDataMigrationSqlMigrationServiceAuthKey', 'New-AzDataMigrationTask', 'Read-AzDataMigrationFile', 'Read-AzDataMigrationFileWrite', 'Remove-AzDataMigrationDatabaseMigrationsSqlDb', 'Remove-AzDataMigrationFile', 'Remove-AzDataMigrationProject', 'Remove-AzDataMigrationService', 'Remove-AzDataMigrationServiceTask', 'Remove-AzDataMigrationSqlMigrationService', 'Remove-AzDataMigrationSqlMigrationServiceNode', 'Remove-AzDataMigrationTask', 'Start-AzDataMigrationService', 'Stop-AzDataMigrationDatabaseMigrationsSqlDb', 'Stop-AzDataMigrationDatabaseMigrationsSqlMi', 'Stop-AzDataMigrationDatabaseMigrationsSqlVM', 'Stop-AzDataMigrationService', 'Stop-AzDataMigrationServiceTask', 'Stop-AzDataMigrationTask', 'Test-AzDataMigrationServiceChildNameAvailability', 'Test-AzDataMigrationServiceNameAvailability', 'Test-AzDataMigrationServiceStatus', 'Update-AzDataMigrationFile', 'Update-AzDataMigrationProject', 'Update-AzDataMigrationService', 'Update-AzDataMigrationServiceTask', 'Update-AzDataMigrationSqlMigrationService', 'Update-AzDataMigrationTask', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataMigration'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
