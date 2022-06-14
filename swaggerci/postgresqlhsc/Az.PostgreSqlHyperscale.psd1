@{
  GUID = '07420515-d722-422c-a15a-eee2f740ca85'
  RootModule = './Az.PostgreSqlHyperscale.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PostgreSqlHyperscale cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PostgreSqlHyperscale.private.dll'
  FormatsToProcess = './Az.PostgreSqlHyperscale.format.ps1xml'
  FunctionsToExport = 'Get-AzPostgreSqlHyperscaleConfiguration', 'Get-AzPostgreSqlHyperscaleFirewallRule', 'Get-AzPostgreSqlHyperscaleRole', 'Get-AzPostgreSqlHyperscaleServer', 'Get-AzPostgreSqlHyperscaleServerGroup', 'New-AzPostgreSqlHyperscaleFirewallRule', 'New-AzPostgreSqlHyperscaleRole', 'New-AzPostgreSqlHyperscaleServerGroup', 'Remove-AzPostgreSqlHyperscaleFirewallRule', 'Remove-AzPostgreSqlHyperscaleRole', 'Remove-AzPostgreSqlHyperscaleServerGroup', 'Restart-AzPostgreSqlHyperscaleServerGroup', 'Start-AzPostgreSqlHyperscaleServerGroup', 'Stop-AzPostgreSqlHyperscaleServerGroup', 'Test-AzPostgreSqlHyperscaleServerGroupNameAvailability', 'Update-AzPostgreSqlHyperscaleConfiguration', 'Update-AzPostgreSqlHyperscaleServerGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PostgreSqlHyperscale'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
