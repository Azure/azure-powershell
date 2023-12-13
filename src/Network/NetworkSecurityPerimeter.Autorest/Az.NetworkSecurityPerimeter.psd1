@{
  GUID = '9560a0c7-e4ed-40d0-a8c4-9b28b241edca'
  RootModule = './Az.NetworkSecurityPerimeter.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NetworkSecurityPerimeter cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkSecurityPerimeter.private.dll'
  FormatsToProcess = './Az.NetworkSecurityPerimeter.format.ps1xml'
  FunctionsToExport = 'Get-AzNetworkSecurityPerimeter', 'Get-AzNetworkSecurityPerimeterAccessRule', 'Get-AzNetworkSecurityPerimeterAssociableResourceType', 'Get-AzNetworkSecurityPerimeterAssociation', 'Get-AzNetworkSecurityPerimeterLink', 'Get-AzNetworkSecurityPerimeterLinkReference', 'Get-AzNetworkSecurityPerimeterProfile', 'New-AzNetworkSecurityPerimeter', 'New-AzNetworkSecurityPerimeterAccessRule', 'New-AzNetworkSecurityPerimeterAssociation', 'New-AzNetworkSecurityPerimeterLink', 'New-AzNetworkSecurityPerimeterProfile', 'Remove-AzNetworkSecurityPerimeter', 'Remove-AzNetworkSecurityPerimeterAccessRule', 'Remove-AzNetworkSecurityPerimeterAssociation', 'Remove-AzNetworkSecurityPerimeterLink', 'Remove-AzNetworkSecurityPerimeterLinkReference', 'Remove-AzNetworkSecurityPerimeterProfile', 'Update-AzNetworkSecurityPerimeterAccessRule', 'Update-AzNetworkSecurityPerimeterAssociation', 'Update-AzNetworkSecurityPerimeterLink', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NetworkSecurityPerimeter'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
