@{
  GUID = 'fb901933-d4f5-4a58-9488-562544ba6303'
  RootModule = './Az.AlertsManagement.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Alerts cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AlertsManagement.private.dll'
  FormatsToProcess = './Az.AlertsManagement.format.ps1xml'
  FunctionsToExport = 'Get-AzPrometheusRuleGroup', 'New-AzPrometheusRuleGroup', 'New-AzPrometheusRuleObject', 'Remove-AzPrometheusRuleGroup', 'Update-AzPrometheusRuleGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Alerts'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
