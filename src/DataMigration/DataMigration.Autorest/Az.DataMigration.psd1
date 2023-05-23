@{
  GUID = 'e23fee23-903d-423e-9275-f8763efede9d'
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
  FunctionsToExport = 'Get-AzDataMigrationAssessment', 'Get-AzDataMigrationPerformanceDataCollection', 'Get-AzDataMigrationSkuRecommendation', 'Get-AzDataMigrationSqlService', 'Get-AzDataMigrationSqlServiceAuthKey', 'Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric', 'Get-AzDataMigrationSqlServiceMigration', 'Get-AzDataMigrationToSqlDb', 'Get-AzDataMigrationToSqlManagedInstance', 'Get-AzDataMigrationToSqlVM', 'Invoke-AzDataMigrationCutoverToSqlManagedInstance', 'Invoke-AzDataMigrationCutoverToSqlVM', 'New-AzDataMigrationLoginsMigration', 'New-AzDataMigrationTdeCertificateMigration','New-AzDataMigrationSqlService', 'New-AzDataMigrationSqlServiceAuthKey', 'New-AzDataMigrationToSqlDb', 'New-AzDataMigrationToSqlManagedInstance', 'New-AzDataMigrationToSqlVM', 'Register-AzDataMigrationIntegrationRuntime', 'Remove-AzDataMigrationSqlService', 'Remove-AzDataMigrationSqlServiceNode', 'Remove-AzDataMigrationToSqlDb', 'Stop-AzDataMigrationToSqlDb', 'Stop-AzDataMigrationToSqlManagedInstance', 'Stop-AzDataMigrationToSqlVM', 'Update-AzDataMigrationSqlService', '*'
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
