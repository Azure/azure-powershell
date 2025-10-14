@{
  GUID = '3b9833a8-dc77-4172-afe7-da97ed36393d'
  RootModule = './Az.AppConfigurationdata.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AppConfigurationdata cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AppConfigurationdata.private.dll'
  FormatsToProcess = './Az.AppConfigurationdata.format.ps1xml'
  FunctionsToExport = 'Get-AzAppConfigurationKey', 'Get-AzAppConfigurationKeyValue', 'Get-AzAppConfigurationLabel', 'Get-AzAppConfigurationRevision', 'Remove-AzAppConfigurationKeyValue', 'Remove-AzAppConfigurationLock', 'Set-AzAppConfigurationKeyValue', 'Set-AzAppConfigurationLock', 'Test-AzAppConfigurationKeyValue'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AppConfigurationdata'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
