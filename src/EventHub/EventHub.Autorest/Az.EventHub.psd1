@{
  GUID = '9e121baf-ee5e-4cb7-bb95-fff6bb4ee003'
  RootModule = './Az.EventHub.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EventHub cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EventHub.private.dll'
  FormatsToProcess = './Az.EventHub.format.ps1xml'
  FunctionsToExport = 'Approve-AzEventHubPrivateEndpointConnection', 'Deny-AzEventHubPrivateEndpointConnection', 'Get-AzEventHub', 'Get-AzEventHubApplicationGroup', 'Get-AzEventHubAuthorizationRule', 'Get-AzEventHubCluster', 'Get-AzEventHubClusterNamespace', 'Get-AzEventHubClustersAvailableRegion', 'Get-AzEventHubConsumerGroup', 'Get-AzEventHubGeoDRConfiguration', 'Get-AzEventHubKey', 'Get-AzEventHubNamespace', 'Get-AzEventHubNetworkRuleSet', 'Get-AzEventHubPrivateEndpointConnection', 'Get-AzEventHubPrivateLink', 'Get-AzEventHubSchemaGroup', 'New-AzEventHub', 'New-AzEventHubApplicationGroup', 'New-AzEventHubAuthorizationRule', 'New-AzEventHubCluster', 'New-AzEventHubConsumerGroup', 'New-AzEventHubGeoDRConfiguration', 'New-AzEventHubIPRuleConfig', 'New-AzEventHubKey', 'New-AzEventHubKeyVaultPropertiesObject', 'New-AzEventHubNamespace', 'New-AzEventHubSchemaGroup', 'New-AzEventHubThrottlingPolicyConfig', 'New-AzEventHubVirtualNetworkRuleConfig', 'Remove-AzEventHub', 'Remove-AzEventHubApplicationGroup', 'Remove-AzEventHubAuthorizationRule', 'Remove-AzEventHubCluster', 'Remove-AzEventHubConsumerGroup', 'Remove-AzEventHubGeoDRConfiguration', 'Remove-AzEventHubNamespace', 'Remove-AzEventHubPrivateEndpointConnection', 'Remove-AzEventHubSchemaGroup', 'Set-AzEventHub', 'Set-AzEventHubApplicationGroup', 'Set-AzEventHubAuthorizationRule', 'Set-AzEventHubCluster', 'Set-AzEventHubConsumerGroup', 'Set-AzEventHubGeoDRConfigurationBreakPair', 'Set-AzEventHubGeoDRConfigurationFailOver', 'Set-AzEventHubNamespace', 'Set-AzEventHubNetworkRuleSet', 'Test-AzEventHubName', '*'
  AliasesToExport = 'Get-AzEventHubNamespaceV2', 'New-AzEventHubNamespaceV2', 'Remove-AzEventHubNamespaceV2', 'Set-AzEventHubNamespaceV2', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EventHub'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
