@{
  GUID = '371559d1-2851-48f7-9167-f1cd1cd73ed8'
  RootModule = './Az.Logz.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Logz cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Logz.private.dll'
  FormatsToProcess = './Az.Logz.format.ps1xml'
  FunctionsToExport = 'Get-AzLogzMonitor', 'Get-AzLogzMonitorMonitoredResource', 'Get-AzLogzMonitorUserRole', 'Get-AzLogzMonitorVMHost', 'Get-AzLogzMonitorVMHostUpdate', 'Get-AzLogzSingleSignOn', 'Get-AzLogzSubAccount', 'Get-AzLogzSubAccountMonitoredResource', 'Get-AzLogzSubAccountTagRule', 'Get-AzLogzSubAccountVMHost', 'Get-AzLogzSubAccountVMHostUpdate', 'Get-AzLogzTagRule', 'Invoke-AzLogzHostMonitor', 'Invoke-AzLogzHostSubAccount', 'New-AzLogzMonitor', 'New-AzLogzSingleSignOn', 'New-AzLogzSubAccount', 'New-AzLogzSubAccountTagRule', 'New-AzLogzTagRule', 'Remove-AzLogzMonitor', 'Remove-AzLogzSubAccount', 'Remove-AzLogzSubAccountTagRule', 'Remove-AzLogzTagRule', 'Update-AzLogzMonitor', 'Update-AzLogzSubAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Logz'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
