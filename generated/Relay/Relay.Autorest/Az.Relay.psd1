@{
  GUID = '4bf8fb16-5644-49f6-85ac-c4c6573a2ecd'
  RootModule = './Az.Relay.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Relay cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Relay.private.dll'
  FormatsToProcess = './Az.Relay.format.ps1xml'
  FunctionsToExport = 'Get-AzRelayAuthorizationRule', 'Get-AzRelayCluster', 'Get-AzRelayClusterAvailableClusterRegion', 'Get-AzRelayClusterNamespace', 'Get-AzRelayClusterSku', 'Get-AzRelayHybridConnection', 'Get-AzRelayKey', 'Get-AzRelayNamespace', 'Get-AzRelayNamespaceNetworkRuleSet', 'Get-AzWcfRelay', 'New-AzRelayAuthorizationRule', 'New-AzRelayCluster', 'New-AzRelayHybridConnection', 'New-AzRelayKey', 'New-AzRelayNamespace', 'New-AzRelayNetworkRuleSetIPRuleObject', 'New-AzWcfRelay', 'Remove-AzRelayAuthorizationRule', 'Remove-AzRelayCluster', 'Remove-AzRelayHybridConnection', 'Remove-AzRelayNamespace', 'Remove-AzWcfRelay', 'Set-AzRelayAuthorizationRule', 'Set-AzRelayCluster', 'Set-AzRelayHybridConnection', 'Set-AzRelayNamespaceNetworkRuleSet', 'Set-AzWcfRelay', 'Test-AzRelayName', 'Update-AzRelayNamespace'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Relay'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
