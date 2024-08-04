@{
  GUID = '2f9cd489-4cb4-432b-a8d1-1ee22501f45c'
  RootModule = './Az.Security.psm1'
  ModuleVersion = '1.5.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Security cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Security.private.dll'
  FormatsToProcess = './Az.Security.format.ps1xml'
  FunctionsToExport = 'Get-AzSecurityDefenderForStorage', 'Update-AzSecurityDefenderForStorage'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Security'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
