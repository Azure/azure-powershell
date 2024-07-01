@{
  GUID = 'f889aadf-56ba-485c-8077-283219e39439'
  RootModule = './Az.DynatraceObservability.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DynatraceObservability cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DynatraceObservability.private.dll'
  FormatsToProcess = './Az.DynatraceObservability.format.ps1xml'
  FunctionsToExport = 'Get-AzDynatraceMonitor', 'Get-AzDynatraceMonitorAppService', 'Get-AzDynatraceMonitoredResource', 'Get-AzDynatraceMonitorHost', 'Get-AzDynatraceMonitorLinkableEnv', 'Get-AzDynatraceMonitorSSOConfig', 'Get-AzDynatraceMonitorSSODetail', 'Get-AzDynatraceMonitorTagRule', 'Get-AzDynatraceMonitorVMHostPayload', 'New-AzDynatraceMonitor', 'New-AzDynatraceMonitorFilteringTagObject', 'New-AzDynatraceMonitorSSOConfig', 'New-AzDynatraceMonitorTagRule', 'Remove-AzDynatraceMonitor', 'Remove-AzDynatraceMonitorTagRule', 'Update-AzDynatraceMonitor', 'Update-AzDynatraceMonitorTagRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DynatraceObservability'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
