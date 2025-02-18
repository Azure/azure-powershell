@{
  GUID = '85809807-c6ca-41fb-b667-7ac040e536a4'
  RootModule = './Az.PostgreSql.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PostgreSql cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PostgreSql.private.dll'
  FormatsToProcess = './Az.PostgreSql.format.ps1xml'
  FunctionsToExport = 'Get-AzPostgreSqlConfiguration', 'Get-AzPostgreSqlConnectionString', 'Get-AzPostgreSqlFirewallRule', 'Get-AzPostgreSqlFlexibleServer', 'Get-AzPostgreSqlFlexibleServerConfiguration', 'Get-AzPostgreSqlFlexibleServerConnectionString', 'Get-AzPostgreSqlFlexibleServerDatabase', 'Get-AzPostgreSqlFlexibleServerFirewallRule', 'Get-AzPostgreSqlFlexibleServerLocationBasedCapability', 'Get-AzPostgreSqlReplica', 'Get-AzPostgreSqlServer', 'Get-AzPostgreSqlVirtualNetworkRule', 'New-AzPostgreSqlFirewallRule', 'New-AzPostgreSqlFlexibleServer', 'New-AzPostgreSqlFlexibleServerDatabase', 'New-AzPostgreSqlFlexibleServerFirewallRule', 'New-AzPostgreSqlReplica', 'New-AzPostgreSqlServer', 'New-AzPostgreSqlVirtualNetworkRule', 'Remove-AzPostgreSqlFirewallRule', 'Remove-AzPostgreSqlFlexibleServer', 'Remove-AzPostgreSqlFlexibleServerDatabase', 'Remove-AzPostgreSqlFlexibleServerFirewallRule', 'Remove-AzPostgreSqlServer', 'Remove-AzPostgreSqlVirtualNetworkRule', 'Restart-AzPostgreSqlFlexibleServer', 'Restart-AzPostgreSqlServer', 'Restore-AzPostgreSqlFlexibleServer', 'Restore-AzPostgreSqlServer', 'Start-AzPostgreSqlFlexibleServer', 'Stop-AzPostgreSqlFlexibleServer', 'Test-AzPostgreSqlFlexibleServerConnect', 'Update-AzPostgreSqlConfiguration', 'Update-AzPostgreSqlFirewallRule', 'Update-AzPostgreSqlFlexibleServer', 'Update-AzPostgreSqlFlexibleServerConfiguration', 'Update-AzPostgreSqlFlexibleServerFirewallRule', 'Update-AzPostgreSqlServer', 'Update-AzPostgreSqlVirtualNetworkRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PostgreSql'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
