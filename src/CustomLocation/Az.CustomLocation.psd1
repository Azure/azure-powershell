@{
  GUID = 'b5a68592-6b36-4d8f-b582-a157eb4dfacf'
  RootModule = './Az.CustomLocation.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CustomLocation cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CustomLocation.private.dll'
  FormatsToProcess = './Az.CustomLocation.format.ps1xml'
  FunctionsToExport = 'Get-AzCustomLocation', 'Get-AzCustomLocationEnabledResourceType', 'New-AzCustomLocation', 'Remove-AzCustomLocation', 'Update-AzCustomLocation', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CustomLocation'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
