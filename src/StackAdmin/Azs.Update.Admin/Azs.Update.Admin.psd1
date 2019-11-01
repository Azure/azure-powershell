@{
  GUID = 'b18e3b80-03e9-44e5-ba72-eb39e5edbc14'
  RootModule = 'Azs.Update.Admin.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Azs.Update.Admin.private.dll'
  FormatsToProcess = './Azs.Update.Admin.format.ps1xml'
  CmdletsToExport = 'Add-AzsUpdate', 'Get-AzsUpdate', 'Get-AzsUpdateLocation', 'Get-AzsUpdateRun', 'Get-AzsUpdateRunTopLevel', 'Invoke-AzsRerunUpdateRun', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
