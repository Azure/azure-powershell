@{
  GUID = 'b9bd614b-04ad-4673-9601-09e6099a4d60'
  RootModule = './Az.PrivateTrafficManager.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PrivateTrafficManager cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PrivateTrafficManager.private.dll'
  FormatsToProcess = './Az.PrivateTrafficManager.format.ps1xml'
  FunctionsToExport = 'Get-AzPrivateTrafficManagerEndpoint', 'Get-AzPrivateTrafficManagerHealthPolicy', 'Get-AzPrivateTrafficManagerProfile', 'Get-AzPrivateTrafficManagerSite', 'Get-AzPrivateTrafficManagerTopologyMap', 'New-AzPrivateTrafficManagerEndpoint', 'New-AzPrivateTrafficManagerHealthPolicy', 'New-AzPrivateTrafficManagerProfile', 'New-AzPrivateTrafficManagerSite', 'New-AzPrivateTrafficManagerTopologyMap', 'Remove-AzPrivateTrafficManagerEndpoint', 'Remove-AzPrivateTrafficManagerHealthPolicy', 'Remove-AzPrivateTrafficManagerProfile', 'Remove-AzPrivateTrafficManagerSite', 'Remove-AzPrivateTrafficManagerTopologyMap', 'Update-AzPrivateTrafficManagerEndpoint', 'Update-AzPrivateTrafficManagerHealthPolicy', 'Update-AzPrivateTrafficManagerProfile', 'Update-AzPrivateTrafficManagerSite', 'Update-AzPrivateTrafficManagerTopologyMap'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PrivateTrafficManager'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
