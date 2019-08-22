@{
  GUID = '71be773a-0f23-4714-b4df-eba7fbcf42ba'
  RootModule = './Az.Hana.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Hana cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Hana.private.dll'
  FormatsToProcess = './Az.Hana.format.ps1xml'
  CmdletsToExport = 'Get-AzHanaInstance', 'New-AzHanaInstance', 'Remove-AzHanaInstance', 'Restart-AzHanaInstance', 'Start-AzHanaInstance', 'Stop-AzHanaInstance', 'Update-AzHanaInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Hana'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30'
    }
  }
}
