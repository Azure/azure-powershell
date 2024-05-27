@{
  GUID = '95624dd6-2184-4886-a492-5588342c3255'
  RootModule = './Az.ScheduledQueryRule.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ScheduledQueryRule cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ScheduledQueryRule.private.dll'
  FormatsToProcess = './Az.ScheduledQueryRule.format.ps1xml'
  FunctionsToExport = 'Get-AzScheduledQueryRule', 'New-AzScheduledQueryRule', 'New-AzScheduledQueryRuleConditionObject', 'New-AzScheduledQueryRuleDimensionObject', 'Remove-AzScheduledQueryRule', 'Update-AzScheduledQueryRule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ScheduledQueryRule'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
