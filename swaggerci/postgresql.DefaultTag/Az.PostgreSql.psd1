@{
  GUID = '6316f94b-7665-4f0d-91de-7bba6a437734'
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
  FunctionsToExport = 'Get-AzPostgreSqlAdministrator', 'Get-AzPostgreSqlBackup', 'Get-AzPostgreSqlConfiguration', 'Get-AzPostgreSqlDatabase', 'Get-AzPostgreSqlFirewallRule', 'Get-AzPostgreSqlReplica', 'Get-AzPostgreSqlServer', 'Invoke-AzPostgreSqlExecuteCheckNameAvailability', 'Invoke-AzPostgreSqlExecuteCheckNameAvailabilityWithLocation', 'Invoke-AzPostgreSqlExecuteGetPrivateDnsZoneSuffix', 'Invoke-AzPostgreSqlExecuteLocationBasedCapability', 'Invoke-AzPostgreSqlExecuteVirtualNetworkSubnetUsage', 'New-AzPostgreSqlAdministrator', 'New-AzPostgreSqlDatabase', 'New-AzPostgreSqlFirewallRule', 'New-AzPostgreSqlServer', 'Remove-AzPostgreSqlAdministrator', 'Remove-AzPostgreSqlDatabase', 'Remove-AzPostgreSqlFirewallRule', 'Remove-AzPostgreSqlServer', 'Restart-AzPostgreSqlServer', 'Start-AzPostgreSqlServer', 'Stop-AzPostgreSqlServer', 'Update-AzPostgreSqlConfiguration', 'Update-AzPostgreSqlServer', '*'
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
