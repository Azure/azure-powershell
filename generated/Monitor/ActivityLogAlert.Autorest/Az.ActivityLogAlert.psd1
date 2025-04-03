@{
  GUID = '51359a36-98ad-4a4b-878d-564c18864934'
  RootModule = './Az.ActivityLogAlert.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ActivityLogAlert cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ActivityLogAlert.private.dll'
  FormatsToProcess = './Az.ActivityLogAlert.format.ps1xml'
  FunctionsToExport = 'Get-AzActivityLogAlert', 'New-AzActivityLogAlert', 'New-AzActivityLogAlertActionGroupObject', 'New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject', 'New-AzActivityLogAlertAlertRuleLeafConditionObject', 'Remove-AzActivityLogAlert', 'Update-AzActivityLogAlert', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ActivityLogAlert'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
