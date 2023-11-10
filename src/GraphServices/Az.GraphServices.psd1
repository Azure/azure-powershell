@{
  GUID = 'fc20d450-3067-4fe9-8c8b-09f3eb48055a'
  RootModule = './Az.GraphServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: GraphServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.GraphServices.private.dll'
  FormatsToProcess = './Az.GraphServices.format.ps1xml'
  FunctionsToExport = 'Get-AzGraphServicesAccount', 'New-AzGraphServicesAccount', 'Remove-AzGraphServicesAccount', 'Update-AzGraphServicesAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'GraphServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
