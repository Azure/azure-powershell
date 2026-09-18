@{
  GUID = 'c0d70364-96af-43cf-a3ca-76edff8b31b7'
  RootModule = './Az.DataBoundary.psm1'
  ModuleVersion = '0.1.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataBoundary cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataBoundary.private.dll'
  FormatsToProcess = './Az.DataBoundary.format.ps1xml'
  FunctionsToExport = 'Get-AzDataBoundaryScope', 'Get-AzDataBoundaryTenant', 'Set-AzDataBoundary'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataBoundary'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
