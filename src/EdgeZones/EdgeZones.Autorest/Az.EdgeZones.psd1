@{
  GUID = '256871a8-8961-41d8-b6b7-035a71a421d0'
  RootModule = './Az.EdgeZones.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Cdn cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EdgeZones.private.dll'
  FormatsToProcess = './Az.EdgeZones.format.ps1xml'
  FunctionsToExport = 'Get-AzExtendedZone', 'Register-AzExtendedZone', 'Unregister-AzExtendedZone'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Cdn'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
