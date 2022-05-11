@{
  GUID = '03c08964-dac8-45d3-b0d9-a241c11df432'
  RootModule = './Az.EventGrid.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EventGrid cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EventGrid.private.dll'
  FormatsToProcess = './Az.EventGrid.format.ps1xml'
  FunctionsToExport = 'Get-AzEventGridChannel', 'Get-AzEventGridChannelFullUrl', 'Get-AzEventGridDomain', 'Get-AzEventGridDomainEventSubscription', 'Get-AzEventGridDomainEventSubscriptionDeliveryAttribute', 'Get-AzEventGridDomainEventSubscriptionFullUrl', 'Get-AzEventGridDomainSharedAccessKey', 'Get-AzEventGridDomainTopic', 'Get-AzEventGridDomainTopicEventSubscription', 'Get-AzEventGridDomainTopicEventSubscriptionDeliveryAttribute', 'Get-AzEventGridDomainTopicEventSubscriptionFullUrl', 'Get-AzEventGridEventChannel', 'Get-AzEventGridEventSubscription', 'Get-AzEventGridEventSubscriptionDeliveryAttribute', 'Get-AzEventGridEventSubscriptionFullUrl', 'Get-AzEventGridEventSubscriptionGlobal', 'Get-AzEventGridEventSubscriptionRegional', 'Get-AzEventGridExtensionTopic', 'Get-AzEventGridPartnerConfiguration', 'Get-AzEventGridPartnerDestination', 'Get-AzEventGridPartnerNamespace', 'Get-AzEventGridPartnerNamespaceSharedAccessKey', 'Get-AzEventGridPartnerRegistration', 'Get-AzEventGridPartnerTopic', 'Get-AzEventGridPartnerTopicEventSubscription', 'Get-AzEventGridPartnerTopicEventSubscriptionDeliveryAttribute', 'Get-AzEventGridPartnerTopicEventSubscriptionFullUrl', 'Get-AzEventGridPrivateEndpointConnection', 'Get-AzEventGridPrivateLinkResource', 'Get-AzEventGridSystemTopic', 'Get-AzEventGridSystemTopicEventSubscription', 'Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute', 'Get-AzEventGridSystemTopicEventSubscriptionFullUrl', 'Get-AzEventGridTopic', 'Get-AzEventGridTopicEventSubscription', 'Get-AzEventGridTopicEventSubscriptionDeliveryAttribute', 'Get-AzEventGridTopicEventSubscriptionFullUrl', 'Get-AzEventGridTopicEventType', 'Get-AzEventGridTopicSharedAccessKey', 'Get-AzEventGridTopicType', 'Get-AzEventGridTopicTypeEventType', 'Get-AzEventGridVerifiedPartner', 'Grant-AzEventGridPartnerConfigurationPartner', 'Initialize-AzEventGridPartnerDestination', 'Initialize-AzEventGridPartnerTopic', 'Invoke-AzEventGridDeactivatePartnerTopic', 'Invoke-AzEventGridPartnerConfigurationUnauthorize', 'New-AzEventGridChannel', 'New-AzEventGridDomain', 'New-AzEventGridDomainEventSubscription', 'New-AzEventGridDomainKey', 'New-AzEventGridDomainTopicEventSubscription', 'New-AzEventGridEventChannel', 'New-AzEventGridEventSubscription', 'New-AzEventGridPartnerConfiguration', 'New-AzEventGridPartnerDestination', 'New-AzEventGridPartnerNamespace', 'New-AzEventGridPartnerNamespaceKey', 'New-AzEventGridPartnerRegistration', 'New-AzEventGridPartnerTopic', 'New-AzEventGridPartnerTopicEventSubscription', 'New-AzEventGridSystemTopic', 'New-AzEventGridSystemTopicEventSubscription', 'New-AzEventGridTopic', 'New-AzEventGridTopicEventSubscription', 'New-AzEventGridTopicKey', 'Remove-AzEventGridChannel', 'Remove-AzEventGridDomain', 'Remove-AzEventGridDomainEventSubscription', 'Remove-AzEventGridDomainTopic', 'Remove-AzEventGridDomainTopicEventSubscription', 'Remove-AzEventGridEventChannel', 'Remove-AzEventGridEventSubscription', 'Remove-AzEventGridPartnerConfiguration', 'Remove-AzEventGridPartnerDestination', 'Remove-AzEventGridPartnerNamespace', 'Remove-AzEventGridPartnerRegistration', 'Remove-AzEventGridPartnerTopic', 'Remove-AzEventGridPartnerTopicEventSubscription', 'Remove-AzEventGridPrivateEndpointConnection', 'Remove-AzEventGridSystemTopic', 'Remove-AzEventGridSystemTopicEventSubscription', 'Remove-AzEventGridTopic', 'Remove-AzEventGridTopicEventSubscription', 'Update-AzEventGridChannel', 'Update-AzEventGridDomain', 'Update-AzEventGridDomainEventSubscription', 'Update-AzEventGridDomainTopicEventSubscription', 'Update-AzEventGridEventSubscription', 'Update-AzEventGridPartnerConfiguration', 'Update-AzEventGridPartnerDestination', 'Update-AzEventGridPartnerNamespace', 'Update-AzEventGridPartnerRegistration', 'Update-AzEventGridPartnerTopic', 'Update-AzEventGridPartnerTopicEventSubscription', 'Update-AzEventGridSystemTopic', 'Update-AzEventGridSystemTopicEventSubscription', 'Update-AzEventGridTopic', 'Update-AzEventGridTopicEventSubscription', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EventGrid'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
