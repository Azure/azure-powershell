@{
  GUID = 'd2e2bdb3-c508-4621-8659-e7a9542a3447'
  RootModule = './Az.ServiceGroups.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ServiceGroups cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ServiceGroups.private.dll'
  FormatsToProcess = './Az.ServiceGroups.format.ps1xml'
  FunctionsToExport = 'Get-AzServiceGroup', 'Get-AzServiceGroupAncestor', 'New-AzServiceGroup', 'Remove-AzServiceGroup', 'Update-AzServiceGroup'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ServiceGroups'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
