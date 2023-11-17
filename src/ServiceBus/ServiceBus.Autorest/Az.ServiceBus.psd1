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
  FunctionsToExport = 'Approve-AzServiceBusPrivateEndpointConnection', 'Complete-AzServiceBusMigration', 'Deny-AzServiceBusPrivateEndpointConnection', 'Get-AzServiceBusAuthorizationRule', 'Get-AzServiceBusGeoDRConfiguration', 'Get-AzServiceBusKey', 'Get-AzServiceBusMigration', 'Get-AzServiceBusNamespace', 'Get-AzServiceBusNetworkRuleSet', 'Get-AzServiceBusPrivateEndpointConnection', 'Get-AzServiceBusPrivateLink', 'Get-AzServiceBusQueue', 'Get-AzServiceBusRule', 'Get-AzServiceBusSubscription', 'Get-AzServiceBusTopic', 'New-AzServiceBusAuthorizationRule', 'New-AzServiceBusGeoDRConfiguration', 'New-AzServiceBusIPRuleConfig', 'New-AzServiceBusKey', 'New-AzServiceBusKeyVaultPropertiesObject', 'New-AzServiceBusNamespace', 'New-AzServiceBusQueue', 'New-AzServiceBusRule', 'New-AzServiceBusSubscription', 'New-AzServiceBusTopic', 'New-AzServiceBusVirtualNetworkRuleConfig', 'Remove-AzServiceBusAuthorizationRule', 'Remove-AzServiceBusGeoDRConfiguration', 'Remove-AzServiceBusMigration', 'Remove-AzServiceBusNamespace', 'Remove-AzServiceBusPrivateEndpointConnection', 'Remove-AzServiceBusQueue', 'Remove-AzServiceBusRule', 'Remove-AzServiceBusSubscription', 'Remove-AzServiceBusTopic', 'Set-AzServiceBusAuthorizationRule', 'Set-AzServiceBusGeoDRConfigurationBreakPair', 'Set-AzServiceBusGeoDRConfigurationFailOver', 'Set-AzServiceBusNamespace', 'Set-AzServiceBusNetworkRuleSet', 'Set-AzServiceBusQueue', 'Set-AzServiceBusRule', 'Set-AzServiceBusSubscription', 'Set-AzServiceBusTopic', 'Start-AzServiceBusMigration', 'Stop-AzServiceBusMigration', 'Test-AzServiceBusName', '*'
  AliasesToExport = 'Get-AzServiceBusNamespaceV2', 'New-AzServiceBusNamespaceV2', 'Remove-AzServiceBusNamespaceV2', 'Set-AzServiceBusNamespaceV2', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ServiceBus'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
