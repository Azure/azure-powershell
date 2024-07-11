@{
  GUID = '76b7e2e9-0771-487e-98bb-37083f285a20'
  RootModule = './Az.OracleDatabase.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: OracleDatabase cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.OracleDatabase.private.dll'
  FormatsToProcess = './Az.OracleDatabase.format.ps1xml'
  FunctionsToExport = 'Add-AzOracleDatabaseCloudVMClusterVM', 'Get-AzOracleDatabaseAutonomousDatabase', 'Get-AzOracleDatabaseAutonomousDatabaseBackup', 'Get-AzOracleDatabaseAutonomousDatabaseCharacterSet', 'Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet', 'Get-AzOracleDatabaseAutonomousDatabaseVersion', 'Get-AzOracleDatabaseCloudExadataInfrastructure', 'Get-AzOracleDatabaseCloudVMCluster', 'Get-AzOracleDatabaseDbNode', 'Get-AzOracleDatabaseDbServer', 'Get-AzOracleDatabaseDbSystemShape', 'Get-AzOracleDatabaseDnsPrivateView', 'Get-AzOracleDatabaseDnsPrivateZone', 'Get-AzOracleDatabaseGiVersion', 'Invoke-AzOracleDatabaseActionDbNode', 'Invoke-AzOracleDatabaseShrinkAutonomousDatabase', 'Invoke-AzOracleDatabaseSwitchoverAutonomousDatabase', 'New-AzOracleDatabaseAutonomousDatabase', 'New-AzOracleDatabaseAutonomousDatabaseBackup', 'New-AzOracleDatabaseCloudExadataInfrastructure', 'New-AzOracleDatabaseCloudVMCluster', 'New-AzOracleDatabaseCustomerContactObject', 'New-AzOracleDatabaseNsgCidrObject', 'Remove-AzOracleDatabaseAutonomousDatabase', 'Remove-AzOracleDatabaseAutonomousDatabaseBackup', 'Remove-AzOracleDatabaseCloudExadataInfrastructure', 'Remove-AzOracleDatabaseCloudVMCluster', 'Remove-AzOracleDatabaseCloudVMClusterVM', 'Restore-AzOracleDatabaseAutonomousDatabase', 'Update-AzOracleDatabaseAutonomousDatabase', 'Update-AzOracleDatabaseAutonomousDatabaseBackup', 'Update-AzOracleDatabaseCloudExadataInfrastructure', 'Update-AzOracleDatabaseCloudVMCluster'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'OracleDatabase'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
