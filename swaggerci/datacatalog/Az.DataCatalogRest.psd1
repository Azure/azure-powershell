@{
  GUID = 'e6617f95-833e-4b12-aa19-3103f3d8f4cd'
  RootModule = './Az.DataCatalogRest.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataCatalogRest cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataCatalogRest.private.dll'
  FormatsToProcess = './Az.DataCatalogRest.format.ps1xml'
  FunctionsToExport = 'Get-AzDataCatalogRestAdcCatalog', 'Get-AzDataCatalogRestAdcOperation', 'Invoke-AzDataCatalogRestListtAdcCatalog', 'New-AzDataCatalogRestAdcCatalog', 'Remove-AzDataCatalogRestAdcCatalog', 'Update-AzDataCatalogRestAdcCatalog', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataCatalogRest'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
