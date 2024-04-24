@{
  GUID = 'dc0410d0-8396-4441-a4d3-fdaaa915369d'
  RootModule = './Az.Maps.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Maps cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Maps.private.dll'
  FormatsToProcess = './Az.Maps.format.ps1xml'
  FunctionsToExport = 'Get-AzMapsAccount', 'Get-AzMapsAccountKey', 'Get-AzMapsCreator', 'Get-AzMapsSubscriptionOperation', 'New-AzMapsAccount', 'New-AzMapsAccountKey', 'New-AzMapsCreator', 'Remove-AzMapsAccount', 'Remove-AzMapsCreator', 'Update-AzMapsAccount', 'Update-AzMapsCreator', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Maps'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
