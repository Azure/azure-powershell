@{
  GUID = '12efdd0f-d9f3-4860-8f48-2e117a1864a8'
  RootModule = './Az.DiagnosticSetting.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DiagnosticSetting cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DiagnosticSetting.private.dll'
  FormatsToProcess = './Az.DiagnosticSetting.format.ps1xml'
  FunctionsToExport = 'Get-AzDiagnosticSetting', 'Get-AzDiagnosticSettingCategory', 'Get-AzEventCategory', 'Get-AzSubscriptionDiagnosticSetting', 'New-AzDiagnosticSetting', 'New-AzDiagnosticSettingLogSettingsObject', 'New-AzDiagnosticSettingMetricSettingsObject', 'New-AzDiagnosticSettingSubscriptionLogSettingsObject', 'New-AzSubscriptionDiagnosticSetting', 'Remove-AzDiagnosticSetting', 'Remove-AzSubscriptionDiagnosticSetting', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DiagnosticSetting'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
