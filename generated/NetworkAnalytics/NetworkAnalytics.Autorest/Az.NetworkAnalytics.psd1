@{
  GUID = 'fc3cf493-678e-4df4-9c18-64daa0ab008a'
  RootModule = './Az.NetworkAnalytics.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NetworkAnalytics cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkAnalytics.private.dll'
  FormatsToProcess = './Az.NetworkAnalytics.format.ps1xml'
  FunctionsToExport = 'Add-AzNetworkAnalyticsDataProductUserRole', 'Get-AzNetworkAnalyticsDataProduct', 'Get-AzNetworkAnalyticsDataProductRoleAssignment', 'New-AzNetworkAnalyticsDataProduct', 'Remove-AzNetworkAnalyticsDataProduct', 'Remove-AzNetworkAnalyticsDataProductUserRole', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NetworkAnalytics'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
