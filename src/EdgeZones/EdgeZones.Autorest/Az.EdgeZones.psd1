@{
  GUID = '50af1b5f-90c1-433f-b4af-2e92bac1f29f'
  RootModule = './Az.EdgeZones.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EdgeZones cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EdgeZones.private.dll'
  FormatsToProcess = './Az.EdgeZones.format.ps1xml'
  FunctionsToExport = 'Get-AzEdgeZonesExtendedZone', 'Register-AzEdgeZonesExtendedZone', 'Unregister-AzEdgeZonesExtendedZone'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EdgeZones'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
