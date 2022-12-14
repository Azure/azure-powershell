@{
  GUID = '14fdcc41-318e-4838-8905-9cf090a8339c'
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
  FunctionsToExport = 'Get-AzRelayHybridConnection', 'Get-AzRelayHybridConnectionAuthorizationRule', 'Get-AzRelayHybridConnectionKey', 'Get-AzRelayNamespace', 'Get-AzRelayNamespaceAuthorizationRule', 'Get-AzRelayNamespaceKey', 'Get-AzRelayNamespaceNetworkRuleSet', 'Get-AzRelayWcfRelayAuthorizationRule', 'Get-AzWcfRelay', 'Get-AzWcfRelayKey', 'New-AzRelayHybridConnection', 'New-AzRelayHybridConnectionAuthorizationRule', 'New-AzRelayHybridConnectionKey', 'New-AzRelayNamespace', 'New-AzRelayNamespaceAuthorizationRule', 'New-AzRelayNamespaceKey', 'New-AzRelayNamespaceNetworkRuleSet', 'New-AzRelayPrivateEndpointConnectionObject', 'New-AzRelayWcfRelayAuthorizationRule', 'New-AzWcfRelay', 'New-AzWcfRelayKey', 'Remove-AzRelayHybridConnection', 'Remove-AzRelayHybridConnectionAuthorizationRule', 'Remove-AzRelayNamespace', 'Remove-AzRelayNamespaceAuthorizationRule', 'Remove-AzRelayWcfRelayAuthorizationRule', 'Remove-AzWcfRelay', 'Set-AzRelayHybridConnection', 'Set-AzRelayHybridConnectionAuthorizationRule', 'Set-AzRelayNamespace', 'Set-AzRelayNamespaceAuthorizationRule', 'Set-AzRelayNamespaceNetworkRuleSet', 'Set-AzRelayWcfRelayAuthorizationRule', 'Set-AzWcfRelay', 'Test-AzRelayName', 'Update-AzRelayNamespace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Relay'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
