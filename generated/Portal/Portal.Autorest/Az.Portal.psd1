@{
  GUID = 'abd8c13e-6209-4e5a-a276-61e7a80845f9'
  RootModule = './Az.Portal.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Portal Dashboard cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Portal.private.dll'
  FormatsToProcess = './Az.Portal.format.ps1xml'
  FunctionsToExport = 'Get-AzPortalDashboard', 'New-AzPortalDashboard', 'Remove-AzPortalDashboard', 'Set-AzPortalDashboard', 'Update-AzPortalDashboard', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Portal', 'Dashboard'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
