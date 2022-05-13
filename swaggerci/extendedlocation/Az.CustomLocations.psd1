@{
  GUID = '36007b3e-f836-42aa-8d1b-458471c95876'
  RootModule = './Az.CustomLocations.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CustomLocations cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CustomLocations.private.dll'
  FormatsToProcess = './Az.CustomLocations.format.ps1xml'
  FunctionsToExport = 'Get-AzCustomLocationsCustomLocation', 'Get-AzCustomLocationsCustomLocationEnabledResourceType', 'Get-AzCustomLocationsCustomLocationOperation', 'New-AzCustomLocationsCustomLocation', 'Remove-AzCustomLocationsCustomLocation', 'Update-AzCustomLocationsCustomLocation', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CustomLocations'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
