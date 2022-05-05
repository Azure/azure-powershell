@{
  GUID = 'ba64362c-d795-4229-81ab-db258e59bff4'
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
  FunctionsToExport = 'Complete-AzServiceBusMigrationConfigMigration', 'Get-AzServiceBusDisasterRecoveryConfig', 'Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule', 'Get-AzServiceBusDisasterRecoveryConfigKey', 'Get-AzServiceBusMigrationConfig', 'Get-AzServiceBusNamespace', 'Get-AzServiceBusNamespaceAuthorizationRule', 'Get-AzServiceBusNamespaceKey', 'Get-AzServiceBusNamespaceNetworkRuleSet', 'Get-AzServiceBusPrivateEndpointConnection', 'Get-AzServiceBusPrivateLinkResource', 'Get-AzServiceBusQueue', 'Get-AzServiceBusQueueAuthorizationRule', 'Get-AzServiceBusQueueKey', 'Get-AzServiceBusRule', 'Get-AzServiceBusSubscription', 'Get-AzServiceBusTopic', 'Get-AzServiceBusTopicAuthorizationRule', 'Get-AzServiceBusTopicKey', 'Invoke-AzServiceBusBreakDisasterRecoveryConfigPairing', 'Invoke-AzServiceBusFailDisasterRecoveryConfigOver', 'Invoke-AzServiceBusRevertMigrationConfig', 'New-AzServiceBusDisasterRecoveryConfig', 'New-AzServiceBusMigrationConfigAndStartMigration', 'New-AzServiceBusNamespace', 'New-AzServiceBusNamespaceAuthorizationRule', 'New-AzServiceBusNamespaceKey', 'New-AzServiceBusNamespaceNetworkRuleSet', 'New-AzServiceBusPrivateEndpointConnection', 'New-AzServiceBusQueue', 'New-AzServiceBusQueueAuthorizationRule', 'New-AzServiceBusQueueKey', 'New-AzServiceBusRule', 'New-AzServiceBusSubscription', 'New-AzServiceBusTopic', 'New-AzServiceBusTopicAuthorizationRule', 'New-AzServiceBusTopicKey', 'Remove-AzServiceBusDisasterRecoveryConfig', 'Remove-AzServiceBusMigrationConfig', 'Remove-AzServiceBusNamespace', 'Remove-AzServiceBusNamespaceAuthorizationRule', 'Remove-AzServiceBusPrivateEndpointConnection', 'Remove-AzServiceBusQueue', 'Remove-AzServiceBusQueueAuthorizationRule', 'Remove-AzServiceBusRule', 'Remove-AzServiceBusSubscription', 'Remove-AzServiceBusTopic', 'Remove-AzServiceBusTopicAuthorizationRule', 'Test-AzServiceBusDisasterRecoveryConfigNameAvailability', 'Test-AzServiceBusNamespaceNameAvailability', 'Update-AzServiceBusNamespace', '*'
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
