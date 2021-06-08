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
  FunctionsToExport = 'Get-AzDataDogMarketplaceAgreement', 'Get-AzDataDogMonitor', 'Get-AzDataDogMonitorApiKey', 'Get-AzDataDogMonitorDefaultKey', 'Get-AzDataDogMonitorHost', 'Get-AzDataDogMonitorLinkedResource', 'Get-AzDataDogMonitorMonitoredResource', 'Get-AzDataDogSingleSignOnConfiguration', 'Get-AzDataDogTagRule', 'New-AzDataDogFilteringTagObject', 'New-AzDataDogMarketplaceAgreement', 'New-AzDataDogMonitor', 'New-AzDataDogSingleSignOnConfiguration', 'New-AzDataDogTagRule', 'Remove-AzDataDogMonitor', 'Set-AzDataDogMonitorDefaultKey', 'Update-AzDataDogMonitor', 'Update-AzDataDogMonitorSetPasswordLink', '*'
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
