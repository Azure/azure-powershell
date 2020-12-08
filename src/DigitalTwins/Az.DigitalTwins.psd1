@{
  GUID = '938cd822-353e-462c-a393-a2871ae2f354'
  RootModule = './Az.DigitalTwins.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DigitalTwins cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DigitalTwins.private.dll'
  FormatsToProcess = './Az.DigitalTwins.format.ps1xml'
  FunctionsToExport = 'Get-AzDigitalTwinsEndpoint', 'Get-AzDigitalTwinsInstance', 'New-AzDigitalTwinsCheckNameRequestObject', 'New-AzDigitalTwinsDigitalTwinsIdentityObject', 'New-AzDigitalTwinsEndpoint', 'New-AzDigitalTwinsInstance', 'Remove-AzDigitalTwinsEndpoint', 'Remove-AzDigitalTwinsInstance', 'Test-AzDigitalTwinsInstanceNameAvailability', 'Update-AzDigitalTwinsInstance', '*'
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
