@{
  GUID = '67304777-8937-4458-8102-924f8055cd9e'
  RootModule = './Az.AppConfiguration.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AppConfiguration cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AppConfiguration.private.dll'
  FormatsToProcess = './Az.AppConfiguration.format.ps1xml'
  FunctionsToExport = 'Get-AzAppConfigurationKey', 'Get-AzAppConfigurationKeyValue', 'Get-AzAppConfigurationLabel', 'Get-AzAppConfigurationRevision', 'Remove-AzAppConfigurationKeyValue', 'Remove-AzAppConfigurationLock', 'Set-AzAppConfigurationKeyValue', 'Set-AzAppConfigurationLock', 'Test-AzAppConfigurationKey', 'Test-AzAppConfigurationKeyValue', 'Test-AzAppConfigurationLabel', 'Test-AzAppConfigurationRevision', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AppConfiguration'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
