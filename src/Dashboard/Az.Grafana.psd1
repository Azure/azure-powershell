@{
  GUID = '9d9a40ad-32cc-4718-9abb-a3dae5225322'
  RootModule = './Az.Grafana.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Grafana cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Grafana.private.dll'
  FormatsToProcess = './Az.Grafana.format.ps1xml'
  FunctionsToExport = 'Get-AzGrafana', 'New-AzGrafana', 'Remove-AzGrafana', 'Update-AzGrafana', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Grafana'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
