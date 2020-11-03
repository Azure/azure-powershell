@{
  GUID = '1a549fcc-2674-4e11-9865-ea4f934ae6ff'
  RootModule = './Az.DataDog.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataDog cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataDog.private.dll'
  FormatsToProcess = './Az.DataDog.format.ps1xml'
  FunctionsToExport = 'Get-AzDataDogApiKey', 'Get-AzDataDogApiKeyDefaultKey', 'Get-AzDataDogHost', 'Get-AzDataDogLinkedResource', 'Get-AzDataDogMonitor', 'Get-AzDataDogMonitoredResource', 'Get-AzDataDogRefreshSetPassword', 'Get-AzDataDogSingleSignOnConfiguration', 'Get-AzDataDogTagRule', 'New-AzDataDogMonitor', 'New-AzDataDogSingleSignOnConfiguration', 'New-AzDataDogTagRule', 'Remove-AzDataDogMonitor', 'Set-AzDataDogApiKeyDefaultKey', 'Set-AzDataDogSingleSignOnConfiguration', 'Set-AzDataDogTagRule', 'Update-AzDataDogMonitor', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataDog'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
