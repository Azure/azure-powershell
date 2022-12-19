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
  FunctionsToExport = 'Get-AzRelayAuthorizationRule', 'Get-AzRelayHybridConnection', 'Get-AzRelayKey', 'Get-AzRelayNamespace', 'Get-AzRelayNamespaceNetworkRuleSet', 'Get-AzWcfRelay', 'New-AzRelayAuthorizationRule', 'New-AzRelayHybridConnection', 'New-AzRelayKey', 'New-AzRelayNamespace', 'New-AzRelayNamespaceNetworkRuleSet', 'New-AzRelayNetworkRuleSetIPRuleObject', 'New-AzWcfRelay', 'Remove-AzRelayAuthorizationRule', 'Remove-AzRelayHybridConnection', 'Remove-AzRelayNamespace', 'Remove-AzWcfRelay', 'Set-AzRelayAuthorizationRule', 'Set-AzRelayHybridConnection', 'Set-AzRelayNamespace', 'Set-AzWcfRelay', 'Test-AzRelayName', '*'
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
