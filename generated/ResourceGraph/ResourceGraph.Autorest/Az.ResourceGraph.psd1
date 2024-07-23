@{
  GUID = '2c8440b2-9a3f-4b55-b024-d88cf74f7bd7'
  RootModule = './Az.ResourceGraph.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ResourceGraph cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ResourceGraph.private.dll'
  FormatsToProcess = './Az.ResourceGraph.format.ps1xml'
  FunctionsToExport = 'Get-AzResourceGraphQuery', 'New-AzResourceGraphQuery', 'Remove-AzResourceGraphQuery', 'Update-AzResourceGraphQuery', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ResourceGraph'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
