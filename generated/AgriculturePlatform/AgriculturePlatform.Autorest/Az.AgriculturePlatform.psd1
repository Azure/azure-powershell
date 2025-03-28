@{
  GUID = 'd5a702ae-ba47-4da6-86d3-c4a2f4238705'
  RootModule = './Az.AgriculturePlatform.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AgriculturePlatform cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AgriculturePlatform.private.dll'
  FormatsToProcess = './Az.AgriculturePlatform.format.ps1xml'
  FunctionsToExport = 'Get-AzAgriculturePlatformAgriService', 'Get-AzAgriculturePlatformAgriServiceAvailableSolution', 'New-AzAgriculturePlatformAgriService', 'Remove-AzAgriculturePlatformAgriService', 'Update-AzAgriculturePlatformAgriService'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AgriculturePlatform'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
