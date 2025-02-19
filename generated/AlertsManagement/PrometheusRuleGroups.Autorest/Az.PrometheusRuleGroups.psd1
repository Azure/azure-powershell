@{
  GUID = 'dbc2402c-0892-4d72-9279-ab2398e7e02e'
  RootModule = './Az.PrometheusRuleGroups.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PrometheusRuleGroups cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PrometheusRuleGroups.private.dll'
  FormatsToProcess = './Az.PrometheusRuleGroups.format.ps1xml'
  FunctionsToExport = 'Get-AzPrometheusRuleGroup', 'New-AzPrometheusRuleGroup', 'New-AzPrometheusRuleGroupActionObject', 'New-AzPrometheusRuleObject', 'Remove-AzPrometheusRuleGroup', 'Update-AzPrometheusRuleGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PrometheusRuleGroups'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
