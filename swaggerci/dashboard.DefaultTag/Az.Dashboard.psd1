@{
  GUID = 'fc21374e-5c39-4f07-af0d-3057096e97f2'
  RootModule = './Az.Dashboard.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Dashboard cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Dashboard.private.dll'
  FormatsToProcess = './Az.Dashboard.format.ps1xml'
  FunctionsToExport = 'Approve-AzDashboardPrivateEndpointConnection', 'Get-AzDashboardGrafana', 'Get-AzDashboardPrivateEndpointConnection', 'Get-AzDashboardPrivateLinkResource', 'New-AzDashboardGrafana', 'Remove-AzDashboardGrafana', 'Remove-AzDashboardPrivateEndpointConnection', 'Update-AzDashboardGrafana', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Dashboard'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
