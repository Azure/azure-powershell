@{
  GUID = '9e6f7276-93b8-48dc-8c37-abd95fe7d667'
  RootModule = './Az.MySql.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MySql cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MySql.private.dll'
  FormatsToProcess = './Az.MySql.format.ps1xml'
  FunctionsToExport = 'Get-AzMySqlAdvancedThreatProtectionSetting', 'Get-AzMySqlAzureAdAdministrator', 'Get-AzMySqlBackup', 'Get-AzMySqlConfiguration', 'Get-AzMySqlDatabase', 'Get-AzMySqlFirewallRule', 'Get-AzMySqlLocationBasedCapability', 'Get-AzMySqlLocationBasedCapabilitySet', 'Get-AzMySqlLogFile', 'Get-AzMySqlLongRunningBackup', 'Get-AzMySqlMaintenance', 'Get-AzMySqlOperationProgress', 'Get-AzMySqlOperationResult', 'Get-AzMySqlReplica', 'Get-AzMySqlServer', 'Get-AzMySqlServerSecurityAlertPolicy', 'Invoke-AzMySqlBatchConfigurationUpdate', 'Invoke-AzMySqlCutoverServersMigration', 'Invoke-AzMySqlExecuteCheckNameAvailability', 'Invoke-AzMySqlExecuteCheckNameAvailabilityWithoutLocation', 'Invoke-AzMySqlExecuteCheckVirtualNetworkSubnetUsage', 'Invoke-AzMySqlExecuteGetPrivateDnsZoneSuffix', 'New-AzMySqlAzureAdAdministrator', 'New-AzMySqlBackupAndExport', 'New-AzMySqlConfiguration', 'New-AzMySqlDatabase', 'New-AzMySqlFirewallRule', 'New-AzMySqlLongRunningBackup', 'New-AzMySqlServer', 'New-AzMySqlServerSecurityAlertPolicy', 'Read-AzMySqlMaintenance', 'Remove-AzMySqlAzureAdAdministrator', 'Remove-AzMySqlDatabase', 'Remove-AzMySqlFirewallRule', 'Remove-AzMySqlServer', 'Reset-AzMySqlServerGtid', 'Restart-AzMySqlServer', 'Set-AzMySqlAdvancedThreatProtectionSettingPut', 'Set-AzMySqlAzureAdAdministrator', 'Set-AzMySqlBackup', 'Set-AzMySqlConfiguration', 'Set-AzMySqlDatabase', 'Set-AzMySqlFirewallRule', 'Set-AzMySqlServer', 'Set-AzMySqlServerSecurityAlertPolicy', 'Start-AzMySqlServer', 'Stop-AzMySqlServer', 'Test-AzMySqlBackupAndExportBackup', 'Test-AzMySqlServerEstimateHighAvailability', 'Update-AzMySqlAdvancedThreatProtectionSetting', 'Update-AzMySqlAzureAdAdministrator', 'Update-AzMySqlConfiguration', 'Update-AzMySqlDatabase', 'Update-AzMySqlFirewallRule', 'Update-AzMySqlMaintenance', 'Update-AzMySqlServer', 'Update-AzMySqlServerSecurityAlertPolicy'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MySql'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
