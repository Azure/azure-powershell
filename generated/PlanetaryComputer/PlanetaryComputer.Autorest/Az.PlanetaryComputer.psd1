@{
  GUID = '042ac5d9-acee-470e-9a87-c6c3b18e07de'
  RootModule = './Az.PlanetaryComputer.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PlanetaryComputer cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PlanetaryComputer.private.dll'
  FormatsToProcess = './Az.PlanetaryComputer.format.ps1xml'
  FunctionsToExport = 'Get-AzPlanetaryComputerGeoCatalog', 'New-AzPlanetaryComputerGeoCatalog', 'Remove-AzPlanetaryComputerGeoCatalog', 'Update-AzPlanetaryComputerGeoCatalog'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PlanetaryComputer'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
