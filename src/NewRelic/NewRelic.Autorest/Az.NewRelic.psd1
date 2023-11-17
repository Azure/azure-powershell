@{
  GUID = 'fcb6df7e-4a86-4278-88de-1e16f349572c'
  RootModule = './Az.NewRelic.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NewRelic cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NewRelic.private.dll'
  FormatsToProcess = './Az.NewRelic.format.ps1xml'
  FunctionsToExport = 'Get-AzNewRelicAccount', 'Get-AzNewRelicMonitor', 'Get-AzNewRelicMonitorAppService', 'Get-AzNewRelicMonitorHost', 'Get-AzNewRelicMonitorMetricRule', 'Get-AzNewRelicMonitorMetricStatus', 'Get-AzNewRelicMonitorMonitoredResource', 'Get-AzNewRelicMonitorTagRule', 'Get-AzNewRelicOrganization', 'Get-AzNewRelicPlan', 'Invoke-AzNewRelicHostMonitor', 'New-AzNewRelicMonitor', 'New-AzNewRelicMonitorTagRule', 'Remove-AzNewRelicMonitor', 'Remove-AzNewRelicMonitorTagRule', 'Switch-AzNewRelicMonitorBilling', 'Update-AzNewRelicMonitorTagRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NewRelic'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
