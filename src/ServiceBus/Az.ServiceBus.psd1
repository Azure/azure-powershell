@{
# region definition 
  RootModule = './Az.ServiceBus.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ServiceBus cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ServiceBus.private.dll'
  FormatsToProcess = './Az.ServiceBus.format.ps1xml'
# endregion 

# region persistent data 
  GUID = '23b7f05e-3f54-4644-39ea-c8c772c84aad'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'ServiceBus'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-01'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Complete-AzServiceBusMigrationConfigMigration', 'Get-AzServiceBusDisasterRecoveryConfig', 'Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule', 'Get-AzServiceBusDisasterRecoveryConfigKey', 'Get-AzServiceBusEventHub', 'Get-AzServiceBusMigrationConfig', 'Get-AzServiceBusNamespace', 'Get-AzServiceBusNamespaceAuthorizationRule', 'Get-AzServiceBusNamespaceIPFilterRule', 'Get-AzServiceBusNamespaceKey', 'Get-AzServiceBusNamespaceNetworkRuleSet', 'Get-AzServiceBusNamespaceVirtualNetworkRule', 'Get-AzServiceBusPremiumMessagingRegion', 'Get-AzServiceBusQueue', 'Get-AzServiceBusQueueAuthorizationRule', 'Get-AzServiceBusQueueKey', 'Get-AzServiceBusRegion', 'Get-AzServiceBusRule', 'Get-AzServiceBusSubscription', 'Get-AzServiceBusTopic', 'Get-AzServiceBusTopicAuthorizationRule', 'Get-AzServiceBusTopicKey', 'Invoke-AzServiceBusBreakDisasterRecoveryConfigPairing', 'Invoke-AzServiceBusFailDisasterRecoveryConfigOver', 'Invoke-AzServiceBusRevertMigrationConfig', 'Move-AzServiceBusNamespace', 'New-AzServiceBusDisasterRecoveryConfig', 'New-AzServiceBusMigrationConfigAndStartMigration', 'New-AzServiceBusNamespace', 'New-AzServiceBusNamespaceAuthorizationRule', 'New-AzServiceBusNamespaceIPFilterRule', 'New-AzServiceBusNamespaceKey', 'New-AzServiceBusNamespaceNetworkRuleSet', 'New-AzServiceBusNamespaceVirtualNetworkRule', 'New-AzServiceBusQueue', 'New-AzServiceBusQueueAuthorizationRule', 'New-AzServiceBusQueueKey', 'New-AzServiceBusRule', 'New-AzServiceBusSubscription', 'New-AzServiceBusTopic', 'New-AzServiceBusTopicAuthorizationRule', 'New-AzServiceBusTopicKey', 'Remove-AzServiceBusDisasterRecoveryConfig', 'Remove-AzServiceBusMigrationConfig', 'Remove-AzServiceBusNamespace', 'Remove-AzServiceBusNamespaceAuthorizationRule', 'Remove-AzServiceBusNamespaceIPFilterRule', 'Remove-AzServiceBusNamespaceVirtualNetworkRule', 'Remove-AzServiceBusQueue', 'Remove-AzServiceBusQueueAuthorizationRule', 'Remove-AzServiceBusRule', 'Remove-AzServiceBusSubscription', 'Remove-AzServiceBusTopic', 'Remove-AzServiceBusTopicAuthorizationRule', 'Set-AzServiceBusDisasterRecoveryConfig', 'Set-AzServiceBusNamespace', 'Set-AzServiceBusNamespaceAuthorizationRule', 'Set-AzServiceBusNamespaceIPFilterRule', 'Set-AzServiceBusNamespaceNetworkRuleSet', 'Set-AzServiceBusNamespaceVirtualNetworkRule', 'Set-AzServiceBusQueue', 'Set-AzServiceBusQueueAuthorizationRule', 'Set-AzServiceBusRule', 'Set-AzServiceBusSubscription', 'Set-AzServiceBusTopic', 'Set-AzServiceBusTopicAuthorizationRule', 'Test-AzServiceBusDisasterRecoveryConfigNameAvailability', 'Test-AzServiceBusNamespaceNameAvailability', 'Update-AzServiceBusNamespace', '*'
  AliasesToExport = '*'
# endregion

}