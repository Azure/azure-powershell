@{
  GUID = '50196261-2b3a-4dac-808d-3a2a25b147cd'
  RootModule = './Az.Oracle.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Oracle cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Oracle.private.dll'
  FormatsToProcess = './Az.Oracle.format.ps1xml'
  FunctionsToExport = 'Add-AzOracleCloudVMClusterVM', 'Get-AzOracleAutonomousDatabase', 'Get-AzOracleAutonomousDatabaseBackup', 'Get-AzOracleAutonomousDatabaseCharacterSet', 'Get-AzOracleAutonomousDatabaseNationalCharacterSet', 'Get-AzOracleAutonomousDatabaseVersion', 'Get-AzOracleCloudExadataInfrastructure', 'Get-AzOracleCloudVMCluster', 'Get-AzOracleDbNode', 'Get-AzOracleDbServer', 'Get-AzOracleDbSystemShape', 'Get-AzOracleDnsPrivateView', 'Get-AzOracleDnsPrivateZone', 'Get-AzOracleExadbVMCluster', 'Get-AzOracleExascaleDbNode', 'Get-AzOracleExascaleDbStorageVault', 'Get-AzOracleFlexComponent', 'Get-AzOracleGiMinorVersion', 'Get-AzOracleGiVersion', 'Invoke-AzOracleActionDbNode', 'Invoke-AzOracleActionExascaleDbNode', 'Invoke-AzOracleSwitchoverAutonomousDatabase', 'New-AzOracleAutonomousDatabase', 'New-AzOracleAutonomousDatabaseBackup', 'New-AzOracleCloudExadataInfrastructure', 'New-AzOracleCloudVMCluster', 'New-AzOracleCustomerContactObject', 'New-AzOracleExadbVMCluster', 'New-AzOracleExascaleDbStorageVault', 'New-AzOracleNsgCidrObject', 'Remove-AzOracleAutonomousDatabase', 'Remove-AzOracleAutonomousDatabaseBackup', 'Remove-AzOracleCloudExadataInfrastructure', 'Remove-AzOracleCloudVMCluster', 'Remove-AzOracleCloudVMClusterVM', 'Remove-AzOracleExadbVMCluster', 'Remove-AzOracleExadbVMClusterVM', 'Remove-AzOracleExascaleDbStorageVault', 'Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration', 'Restore-AzOracleAutonomousDatabase', 'Update-AzOracleAutonomousDatabase', 'Update-AzOracleCloudExadataInfrastructure', 'Update-AzOracleCloudVMCluster', 'Update-AzOracleExadbVMCluster', 'Update-AzOracleExascaleDbStorageVault'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Oracle'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
