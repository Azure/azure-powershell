@{
  GUID = 'f73d11ef-c690-49f3-8c2c-9000e0e4fe69'
  RootModule = './Az.ServiceBus.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ServiceBus cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ServiceBus.private.dll'
  FormatsToProcess = './Az.ServiceBus.format.ps1xml'
  FunctionsToExport = 'Complete-AzServiceBusMigration', 'Deny-AzServiceBusPrivateEndpointConnection', 'Get-AzServiceBusAuthorizationRule', 'Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule', 'Get-AzServiceBusDisasterRecoveryConfigKey', 'Get-AzServiceBusGeoDRConfiguration', 'Get-AzServiceBusKey', 'Get-AzServiceBusMigration', 'Get-AzServiceBusNamespace', 'Get-AzServiceBusNamespaceAuthorizationRule', 'Get-AzServiceBusNamespaceKey', 'Get-AzServiceBusNamespaceNetworkRuleSet', 'Get-AzServiceBusPrivateEndpointConnection', 'Get-AzServiceBusPrivateLinkResource', 'Get-AzServiceBusQueue', 'Get-AzServiceBusQueueAuthorizationRule', 'Get-AzServiceBusQueueKey', 'Get-AzServiceBusRule', 'Get-AzServiceBusSubscription', 'Get-AzServiceBusTopic', 'Get-AzServiceBusTopicAuthorizationRule', 'Get-AzServiceBusTopicKey', 'New-AzServiceBusAuthorizationRule', 'New-AzServiceBusGeoDRConfiguration', 'New-AzServiceBusKey', 'New-AzServiceBusNamespace', 'New-AzServiceBusNamespaceAuthorizationRule', 'New-AzServiceBusNamespaceKey', 'New-AzServiceBusNamespaceNetworkRuleSet', 'New-AzServiceBusPrivateEndpointConnection', 'New-AzServiceBusQueue', 'New-AzServiceBusQueueAuthorizationRule', 'New-AzServiceBusQueueKey', 'New-AzServiceBusRule', 'New-AzServiceBusSubscription', 'New-AzServiceBusTopic', 'New-AzServiceBusTopicAuthorizationRule', 'New-AzServiceBusTopicKey', 'Remove-AzServiceBusAuthorizationRule', 'Remove-AzServiceBusGeoDRConfiguration', 'Remove-AzServiceBusMigration', 'Remove-AzServiceBusNamespace', 'Remove-AzServiceBusNamespaceAuthorizationRule', 'Remove-AzServiceBusPrivateEndpointConnection', 'Remove-AzServiceBusQueue', 'Remove-AzServiceBusQueueAuthorizationRule', 'Remove-AzServiceBusRule', 'Remove-AzServiceBusSubscription', 'Remove-AzServiceBusTopic', 'Remove-AzServiceBusTopicAuthorizationRule', 'Set-AzServiceBusAuthorizationRule', 'Set-AzServiceBusGeoDRConfigurationBreakPair', 'Set-AzServiceBusGeoDRConfigurationFailOver', 'Set-AzServiceBusQueue', 'Set-AzServiceBusRule', 'Set-AzServiceBusSubscription', 'Set-AzServiceBusTopic', 'Start-AzServiceBusMigration', 'Stop-AzServiceBusMigration', 'Test-AzServiceBusDisasterRecoveryConfigNameAvailability', 'Test-AzServiceBusNamespaceNameAvailability', 'Update-AzServiceBusNamespace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ServiceBus'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
