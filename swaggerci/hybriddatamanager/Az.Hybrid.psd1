@{
  GUID = 'b02ee2fa-aad3-4fdf-94e9-6617ea1d8106'
  RootModule = './Az.Hybrid.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Hybrid cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Hybrid.private.dll'
  FormatsToProcess = './Az.Hybrid.format.ps1xml'
  FunctionsToExport = 'Get-AzHybridDataManager', 'Get-AzHybridDataService', 'Get-AzHybridDataStore', 'Get-AzHybridDataStoreType', 'Get-AzHybridJob', 'Get-AzHybridJobDefinition', 'Get-AzHybridPublicKey', 'New-AzHybridDataManager', 'New-AzHybridDataStore', 'New-AzHybridJobDefinition', 'Remove-AzHybridDataManager', 'Remove-AzHybridDataStore', 'Remove-AzHybridJobDefinition', 'Resume-AzHybridJob', 'Start-AzHybridJobDefinition', 'Stop-AzHybridJob', 'Update-AzHybridDataManager', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Hybrid'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
