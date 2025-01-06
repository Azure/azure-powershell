@{
  GUID = '51b17cfa-b6cf-4bf1-afd7-a55f8cb67a6b'
  RootModule = './Az.DefenderForStorage.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DefenderForStorage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DefenderForStorage.private.dll'
  FormatsToProcess = './Az.DefenderForStorage.format.ps1xml'
  FunctionsToExport = 'Get-AzSecurityDefenderForStorage', 'Update-AzSecurityDefenderForStorage'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DefenderForStorage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
