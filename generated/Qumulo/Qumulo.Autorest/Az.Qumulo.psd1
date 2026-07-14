@{
  GUID = '181af76f-3704-40ce-9fa9-c5826313916c'
  RootModule = './Az.Qumulo.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Qumulo cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Qumulo.private.dll'
  FormatsToProcess = './Az.Qumulo.format.ps1xml'
  FunctionsToExport = 'Get-AzQumuloFileSystem', 'New-AzQumuloFileSystem', 'Remove-AzQumuloFileSystem', 'Update-AzQumuloFileSystem', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Qumulo'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
