@{
  GUID = '66d504a5-3bf8-4570-92f4-620ec297b16a'
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
  FunctionsToExport = 'Get-AzLogzMonitor', 'Get-AzLogzMonitoredResource', 'Get-AzLogzMonitorSSOConfiguration', 'Get-AzLogzMonitorTagRule', 'Get-AzLogzMonitorUserRole', 'Get-AzLogzMonitorVMHost', 'Get-AzLogzSubAccount', 'Get-AzLogzSubAccountTagRule', 'Get-AzLogzSubAccountVMHost', 'Invoke-AzLogzHostMonitor', 'Invoke-AzLogzHostSubAccount', 'New-AzLogzFilteringTagObject', 'New-AzLogzMonitor', 'New-AzLogzMonitorSSOConfiguration', 'New-AzLogzMonitorTagRule', 'New-AzLogzSubAccount', 'New-AzLogzSubAccountTagRule', 'New-AzLogzVMResourcesObject', 'Remove-AzLogzMonitor', 'Remove-AzLogzMonitorTagRule', 'Remove-AzLogzSubAccount', 'Remove-AzLogzSubAccountTagRule', 'Update-AzLogzMonitor', 'Update-AzLogzMonitorVMHost', 'Update-AzLogzSubAccount', 'Update-AzLogzSubAccountVMHost', '*'
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
