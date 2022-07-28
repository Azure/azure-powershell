@{
  GUID = '4fb1d4af-9f8d-4a19-9f17-d8186bf02cfb'
  RootModule = './Az.Orbital.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Orbital cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Orbital.private.dll'
  FormatsToProcess = './Az.Orbital.format.ps1xml'
  FunctionsToExport = 'Get-AzOrbitalAvailableGroundStation', 'Get-AzOrbitalAvailableSpacecraftContact', 'Get-AzOrbitalContactProfile', 'Get-AzOrbitalSpacecraft', 'Get-AzOrbitalSpacecraftContact', 'New-AzOrbitalContactProfile', 'New-AzOrbitalContactProfileLinkChannelObject', 'New-AzOrbitalContactProfileLinkObject', 'New-AzOrbitalSpacecraft', 'New-AzOrbitalSpacecraftContact', 'New-AzOrbitalSpacecraftLinkObject', 'Remove-AzOrbitalContactProfile', 'Remove-AzOrbitalSpacecraft', 'Remove-AzOrbitalSpacecraftContact', 'Update-AzOrbitalContactProfile', 'Update-AzOrbitalSpacecraft', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Orbital'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
