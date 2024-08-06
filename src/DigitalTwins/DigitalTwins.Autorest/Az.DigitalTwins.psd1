@{
  GUID = '938cd822-353e-462c-a393-a2871ae2f354'
  RootModule = './Az.DigitalTwins.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DigitalTwins cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DigitalTwins.private.dll'
  FormatsToProcess = './Az.DigitalTwins.format.ps1xml'
  FunctionsToExport = 'Get-AzDigitalTwinsEndpoint', 'Get-AzDigitalTwinsInstance', 'Get-AzDigitalTwinsPrivateEndpointConnection', 'Get-AzDigitalTwinsPrivateLinkResource', 'Get-AzDigitalTwinsTimeSeriesDatabaseConnection', 'New-AzDigitalTwinsEndpoint', 'New-AzDigitalTwinsInstance', 'New-AzDigitalTwinsPrivateEndpointConnection', 'New-AzDigitalTwinsTimeSeriesDatabaseConnection', 'Remove-AzDigitalTwinsEndpoint', 'Remove-AzDigitalTwinsInstance', 'Remove-AzDigitalTwinsPrivateEndpointConnection', 'Remove-AzDigitalTwinsTimeSeriesDatabaseConnection', 'Test-AzDigitalTwinsInstanceNameAvailability', 'Update-AzDigitalTwinsInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DigitalTwins'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
