@{
  GUID = '739ddedf-3d49-40e0-bc84-00bedfe6b2ec'
  RootModule = './Az.LoadTesting.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: LoadTesting cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.LoadTesting.private.dll'
  FormatsToProcess = './Az.LoadTesting.format.ps1xml'
  FunctionsToExport = 'Get-AzLoad', 'New-AzLoad', 'Remove-AzLoad', 'Update-AzLoad', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'LoadTesting'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
