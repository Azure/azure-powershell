@{
  GUID = '17010ca7-144b-46a9-9a79-28d150dd4c6f'
  RootModule = './Az.DependencyMap.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DependencyMap cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DependencyMap.private.dll'
  FormatsToProcess = './Az.DependencyMap.format.ps1xml'
  FunctionsToExport = 'Get-AzDependencyMap', 'Get-AzDependencyMapDiscoverySource', 'New-AzDependencyMap', 'New-AzDependencyMapDiscoverySource', 'New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject', 'Remove-AzDependencyMap', 'Remove-AzDependencyMapDiscoverySource', 'Update-AzDependencyMap', 'Update-AzDependencyMapDiscoverySource'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DependencyMap'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
