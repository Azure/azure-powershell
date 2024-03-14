@{
  GUID = '256871a8-8961-41d8-b6b7-035a71a421d0'
  RootModule = './EdgeZones.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/EdgeZones.private.dll'
  FormatsToProcess = './EdgeZones.format.ps1xml'
  FunctionsToExport = 'Get-AzureExtendedZone', 'Get-Operation', 'Register-AzureExtendedZone', 'Unregister-AzureExtendedZone'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
