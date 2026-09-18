@{
  GUID = 'c3b6a676-7237-4989-99d0-9df520acda9f'
  RootModule = './Az.MariaDb.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MariaDb cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MariaDb.private.dll'
  FormatsToProcess = './Az.MariaDb.format.ps1xml'
  FunctionsToExport = 'Get-AzMariaDbConfiguration', 'Get-AzMariaDbConnectionString', 'Get-AzMariaDbFirewallRule', 'Get-AzMariaDbReplica', 'Get-AzMariaDbServer', 'Get-AzMariaDbVirtualNetworkRule', 'New-AzMariaDbFirewallRule', 'New-AzMariaDbReplica', 'New-AzMariaDbServer', 'New-AzMariaDbVirtualNetworkRule', 'Remove-AzMariaDbFirewallRule', 'Remove-AzMariaDbServer', 'Remove-AzMariaDbVirtualNetworkRule', 'Restart-AzMariaDbServer', 'Restore-AzMariaDbServer', 'Update-AzMariaDbConfiguration', 'Update-AzMariaDbFirewallRule', 'Update-AzMariaDbServer', 'Update-AzMariaDbVirtualNetworkRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MariaDb'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
