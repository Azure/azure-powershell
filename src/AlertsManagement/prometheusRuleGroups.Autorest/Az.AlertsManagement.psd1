@{
  GUID = '4f8040cf-2321-48be-b66f-10d77ec02391'
  RootModule = './Az.AlertsManagement.psm1'
  ModuleVersion = '0.6.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Alerts cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AlertsManagement.private.dll'
  FormatsToProcess = './Az.AlertsManagement.format.ps1xml'
  FunctionsToExport = 'Get-AzPrometheusRuleGroup', 'New-AzPrometheusRuleGroup', 'New-AzPrometheusRuleGroupActionObject', 'New-AzPrometheusRuleObject', 'Remove-AzPrometheusRuleGroup', 'Set-AzPrometheusRuleGroup', 'Update-AzPrometheusRuleGroup', '*'
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
