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
  FunctionsToExport = 'Get-AzMySqlConfiguration', 'Get-AzMySqlConnectionString', 'Get-AzMySqlFirewallRule', 'Get-AzMySqlFlexibleServer', 'Get-AzMySqlFlexibleServerConfiguration', 'Get-AzMySqlFlexibleServerConnectionString', 'Get-AzMySqlFlexibleServerDatabase', 'Get-AzMySqlFlexibleServerFirewallRule', 'Get-AzMySqlFlexibleServerLocationBasedCapability', 'Get-AzMySqlFlexibleServerReplica', 'Get-AzMySqlReplica', 'Get-AzMySqlServer', 'Get-AzMySqlVirtualNetworkRule', 'New-AzMySqlFirewallRule', 'New-AzMySqlFlexibleServer', 'New-AzMySqlFlexibleServerDatabase', 'New-AzMySqlFlexibleServerFirewallRule', 'New-AzMySqlFlexibleServerReplica', 'New-AzMySqlReplica', 'New-AzMySqlServer', 'New-AzMySqlVirtualNetworkRule', 'Remove-AzMySqlFirewallRule', 'Remove-AzMySqlFlexibleServer', 'Remove-AzMySqlFlexibleServerDatabase', 'Remove-AzMySqlFlexibleServerFirewallRule', 'Remove-AzMySqlServer', 'Remove-AzMySqlVirtualNetworkRule', 'Restart-AzMySqlFlexibleServer', 'Restart-AzMySqlServer', 'Restore-AzMySqlFlexibleServer', 'Restore-AzMySqlServer', 'Start-AzMySqlFlexibleServer', 'Stop-AzMySqlFlexibleServer', 'Test-AzMySqlFlexibleServerConnect', 'Update-AzMySqlConfiguration', 'Update-AzMySqlFirewallRule', 'Update-AzMySqlFlexibleServer', 'Update-AzMySqlFlexibleServerConfiguration', 'Update-AzMySqlFlexibleServerFirewallRule', 'Update-AzMySqlServer', 'Update-AzMySqlServerConfigurationsList', 'Update-AzMySqlVirtualNetworkRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MySql'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
