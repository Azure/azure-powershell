# Upcoming breaking changes in Azure PowerShell

## General

- In the upcoming major release of Azure PowerShell (Az 12.0.0), the `DisplaySecretsWarning` configuration option will be activated by default. A warning message will be shown when secrets are detected in the output of a cmdlet.
  For additional context, please visit [Hardening your defense in depth with secrets awareness in Azure command line tools](https://techcommunity.microsoft.com/t5/azure-tools-blog/hardening-your-defense-in-depth-with-secrets-awareness-in-azure/ba-p/4049883).
  For command usage details, please refer to [Protect secrets in Azure PowerShell](https://go.microsoft.com/fwlink/?linkid=2258844).

## Az.Accounts

### `Clear-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

### `Get-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

### `Update-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

## Az.Compute

### `Get-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "Get-AzVmss" cmdlet will no longer allow an empty value for resource group name and virtual machine scale set name.
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

### `New-AzGalleryImageDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzGalleryImage" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzVM" cmdlet will deploy with the image 'Windows Server 2022 Azure Edition' by default. This will make migrating to Trusted Launch easier in the future. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzVmss" cmdlet will deploy with the image 'Windows Server 2022 Azure Edition' by default. This will make migrating to Trusted Launch easier in the future. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

## Az.CosmosDB

### `Get-AzCosmosDBAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  - Output type for -Type ConnectionStrings will be changed to List<DatabaseAccountConnectionString> in next major version.
  - This change is expected to take effect from Az.CosmosDB version: 2.0.0 and Az version: 12.0.0

## Az.EventGrid

### `Get-AzEventGridChannel`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridDomain`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridDomainTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridFullUrlForPartnerTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridPartnerConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridPartnerNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridPartnerRegistration`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridPartnerTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridPartnerTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-IncludeFullEndpointUrl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-IncludeFullEndpointUrl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Location`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-TopicTypeName`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridSystemTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridSystemTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-IncludeFullEndpointUrl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridTopicType`

- Parameter breaking-change will happen to all parameter sets
  - `-IncludeEventTypeData`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Get-AzEventGridVerifiedPartner`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridDomain`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InboundIpRule`
    - The parameter : 'InboundIpRule' is changing.
    The type of the parameter is changing from 'System.Collections.Hashtable' to 'IInboundIPRule[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InputMappingDefaultValue`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InputMappingField`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridPartnerConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-AuthorizedPartner`
    - The parameter : 'AuthorizedPartner' is changing.
    The type of the parameter is changing from 'System.Collections.Hashtable[]' to 'IPartner[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridPartnerNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InboundIpRule`
    - The parameter : 'InboundIpRule' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventGrid.Models.PSInboundIpRule[]' to 'IInboundIPRule[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-PrivateEndpointConnection`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridPartnerRegistration`

- Cmdlet breaking-change will happen to all parameter sets
  - Added new required parameter: Location <String>
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridPartnerTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridPartnerTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-AdvancedFilter`
    - The parameter : 'AdvancedFilter' is changing.
    The type of the parameter is changing from 'System.Collections.Hashtable[]' to 'IAdvancedFilter[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-AzureActiveDirectoryApplicationIdOrUri`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-AzureActiveDirectoryTenantId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-EndpointType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-MaxEventsPerBatch`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-PreferredBatchSizeInKiloByte`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-StorageQueueMessageTtl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-AzureActiveDirectoryApplicationIdOrUri`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-AzureActiveDirectoryTenantId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-MaxEventsPerBatch`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-PreferredBatchSizeInKiloByte`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-StorageQueueMessageTtl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridSystemTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridSystemTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-AzureActiveDirectoryApplicationIdOrUri`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-AzureActiveDirectoryTenantId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-EndpointType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-MaxEventsPerBatch`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-PreferredBatchSizeInKiloByte`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-StorageQueueMessageTtl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `New-AzEventGridTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InboundIpRule`
    - The parameter : 'InboundIpRule' is changing.
    The type of the parameter is changing from 'System.Collections.Hashtable' to 'IInboundIPRule[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InputMappingDefaultValue`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-InputMappingField`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Remove-AzEventGridSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-DomainInputObject`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DomainName`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DomainTopicInputObject`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DomainTopicName`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceGroupName`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-TopicName`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Set-AzEventGridTopic`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Update-AzEventGridPartnerTopic`

- Cmdlet breaking-change will happen to all parameter sets
  - The existing syntax will be extended. The new syntax will support updating more properties.
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Update-AzEventGridPartnerTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-EndpointType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-StorageQueueMessageTtl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Update-AzEventGridSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-AzureActiveDirectoryApplicationIdOrUri`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-AzureActiveDirectoryTenantId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-EndpointType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-MaxEventsPerBatch`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-PreferredBatchSizeInKiloByte`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

### `Update-AzEventGridSystemTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-DeadLetterEndpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-DeliveryAttributeMapping`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-Endpoint`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-EndpointType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-StorageQueueMessageTtl`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

## Az.EventHub

### `New-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-CleanupPolicy`
    - The parameter : 'CleanupPolicy' is changing.
    The type of the parameter is changing from 'CleanupPolicyRetentionDescription' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Encoding`
    - The parameter : 'Encoding' is changing.
    The type of the parameter is changing from 'EncodingCaptureDescription' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    The type of the parameter is changing from 'CaptureIdentityType' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubIPRuleConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubKey`

- Parameter breaking-change will happen to all parameter sets
  - `-KeyType`
    - The parameter : 'KeyType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubSchemaGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-SchemaCompatibility`
    - The parameter : 'SchemaCompatibility' is changing.
    The type of the parameter is changing from 'SchemaCompatibility' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SchemaType`
    - The parameter : 'SchemaType' is changing.
    The type of the parameter is changing from 'SchemaType' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzEventHubThrottlingPolicyConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-MetricId`
    - The parameter : 'MetricId' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Set-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-Encoding`
    - The parameter : 'Encoding' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Set-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Set-AzEventHubNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Set-AzEventHubNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Set-AzEventHubNetworkRuleSet`

- Parameter breaking-change will happen to all parameter sets
  - `-DefaultAction`
    - The parameter : 'DefaultAction' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.KeyVault

### `Invoke-AzKeyVaultKeyOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.KeyVault.Models.PSKeyOperationResult' is changing
  - The following properties in the output type are being deprecated : 'Result'
  - The following properties are being added to the output type : 'RawResult'
  - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    - The parameter : 'Value' is being replaced by parameter : 'ByteArrayValue'.
    - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

### `New-AzKeyVault`

- Parameter breaking-change will happen to all parameter sets
  - `-EnableRbacAuthorization`
    - RBAC will be enabled by default during the process of key vault creation. To disable RBAC authorization, please use parameter 'DisableRbacAuthorization'.
    - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

### `Update-AzKeyVault`

- Parameter breaking-change will happen to all parameter sets
  - `-EnableRbacAuthorization`
    - RBAC will be enabled by default during the process of key vault creation. To disable RBAC authorization, please use parameter 'DisableRbacAuthorization'.
    - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

## Az.Monitor

### `Get-AzMetric`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set GetWithDefaultParameters will be removed
  - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0
  - Parameter set GetWithFullParameters will be changed to List2 and be 'Default' set
  - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.Insights.OutputClasses.PSMetric' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IResponse'
  - The following properties in the output type are being deprecated : 'Microsoft.Azure.Commands.Insights.OutputClasses.PSMetric'
  - The following properties are being added to the output type : 'Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.ISubscriptionScopeMetricDefinition'
  - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-DetailedOutput`
    - The parameter : 'Parameter DetailedOutput will be removed' is changing.
    - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0
  - `-Dimension`
    - The parameter : 'Parameter Dimension will be removed' is changing.
    - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0
  - `-TimeGrain`
    - The parameter : 'The interval (i.e.timegrain) of the query in ISO 8601 duration format' is changing.
    - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0

### `Get-AzMetricDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.Insights.OutputClasses.PSMetricDefinition' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricDefinition'
  - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-DetailedOutput`
    - The parameter : 'Parameter DetailedOutput will be removed' is changing.
    - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0
  - `-MetricName`
    - The parameter : 'Parameter MetricName will be removed' is changing.
    - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0

### `New-AzMetricFilter`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter DefaultProfile will be removed
  - This change is expected to take effect from Az.Monitor version: 6.0.0 and Az version: 12.0.0

## Az.RecoveryServices

### `Get-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

### `Import-AzRecoveryServicesAsrVaultSettingsFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

### `Set-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

## Az.Resources

### `Get-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

## Az.ServiceBus

### `New-AzServiceBusAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusIPRuleConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusKey`

- Parameter breaking-change will happen to all parameter sets
  - `-KeyType`
    - The parameter : 'KeyType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `New-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusNetworkRuleSet`

- Parameter breaking-change will happen to all parameter sets
  - `-DefaultAction`
    - The parameter : 'DefaultAction' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusRule`

- Parameter breaking-change will happen to all parameter sets
  - `-FilterType`
    - The parameter : 'FilterType' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

### `Set-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '05/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

## Az.Sql

### `New-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

### `Set-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

## Az.Storage

### `Get-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `New-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `New-AzStorageQueueSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-UpgradeToStorageV2`
    - A prompt that needs users' confirmation will be added when upgrading a storage account from StorageV1 or BlobStorage to StorageV2. Suppress it with -Force.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `Set-AzStorageFileContent`

- Parameter breaking-change will happen to all parameter sets
  - `-Path`
    - When uploading using SAS token without Read permission, the destination path will be taken as a file path, instead of a directory path previously.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

## Az.Support

### `Get-AzSupportProblemClassification`

- Cmdlet breaking-change will happen to all parameter sets
  - Piping of Get-AzSupportProblemClassification with a service object will no longer be supported for list. Get via piping will still be supported.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Id`
    - Parameter name 'Id' will be changed to 'Name'.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-ServiceId`
    - Parameter name 'ServiceId' will be changed to 'ServiceName'.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `Get-AzSupportService`

- Cmdlet breaking-change will happen to all parameter sets
  - Output property name 'ResourceTypes' will be changed to 'ResourceType'.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Id`
    - Parameter name 'Id' will be changed to 'Name'.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `Get-AzSupportTicket`

- Cmdlet breaking-change will happen to all parameter sets
  - Input parameter 'Skip' will be removed
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Input parameter 'IncludeTotalCount' will be removed
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Parameter 'First' will be renamed to 'Top'
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property ContactDetail will be deprecated. Use properties ContactDetailAdditionalEmailAddress,ContactDetailCountry, ContactDetailFirstName, ContactDetailLastName, ContactDetailPhoneNumber, ContactDetailPreferredContactMethod, ContactDetailPreferredSupportLanguage, ContactDetailPreferredTimeZone, and ContactDetailPrimaryEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property SupportEngineer will be deprecated. Use property SupportEngineerEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property QuotaTicketDetail will be deprecated. Use properties QuotaTicketDetailQuotaChangeRequest,QuotaTicketDetailQuotaChangeRequestSubType, QuotaTicketDetailQuotaChangeRequestVersion instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The output property TechnicalTicketResourceId will be changed to TechnicalTicketDetailResourceId
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - If no parameters are specified, Get-AzSupportTicket will return support tickets from the last week be default
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `Get-AzSupportTicketCommunication`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet Get-AzSupportTicketCommunication will be renamed to Get-AzSupportCommunication
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Input parameter 'Skip' will be removed
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Input parameter 'IncludeTotalCount' will be removed
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Parameter 'First' will be renamed to 'Top'
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Piping of Get-AzSupportTicketCommunication with a support ticket object will no longer be supported for list. Get via piping will still be supported.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `New-AzSupportContactProfileObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `New-AzSupportTicket`

- Cmdlet breaking-change will happen to all parameter sets
  - New parameter 'ServiceId' will be required
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - New parameter 'AdvancedDiagnosticConsent' will be required
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property ContactDetail will be deprecated. Use properties ContactDetailAdditionalEmailAddress,ContactDetailCountry, ContactDetailFirstName, ContactDetailLastName, ContactDetailPhoneNumber, ContactDetailPreferredContactMethod, ContactDetailPreferredSupportLanguage, ContactDetailPreferredTimeZone, and ContactDetailPrimaryEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property SupportEngineer will be deprecated. Use property SupportEngineerEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property QuotaTicketDetail will be deprecated. Use properties QuotaTicketDetailQuotaChangeRequest,QuotaTicketDetailQuotaChangeRequestSubType, QuotaTicketDetailQuotaChangeRequestVersion instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The output property TechnicalTicketResourceId will be changed to TechnicalTicketDetailResourceId
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-AdditionalEmailAddress`
    - Parameter 'AdditionalEmailAddress' will be renamed to 'ContactDetailAdditionalEmailAddress'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CSPHomeTenantId`
    - Parameter 'CSPHomeTenantId' will be removed.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerContactDetail`
    - CustomerContactDetail will be removed. Use new parameters ContactDetailCountry, ContactDetailFirstName, ContactDetailLastName,ContactDetailPhoneNumber, ContactDetailPreferredSupportLanguage, ContactDetailPreferredTimeZone, ContactDetailPrimaryEmailAddress, ContactDetailPreferredContactMethod instead.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerCountry`
    - Parameter 'CustomerCountry' will be renamed to 'ContactDetailCountry'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerFirstName`
    - Parameter 'CustomerFirstName' will be renamed to 'ContactDetailFirstName'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerLastName`
    - Parameter 'CustomerLastName' will be renamed to 'ContactDetailLastName'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPhoneNumber`
    - Parameter 'CustomerPhoneNumber' will be renamed to 'ContactDetailPhoneNumber'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPreferredSupportLanguage`
    - Parameter 'CustomerPreferredSupportLanguage' will be renamed to 'ContactDetailPreferredSupportLanguage'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPreferredTimeZone`
    - Parameter 'CustomerPreferredTimeZone' will be renamed to 'ContactDetailPreferredTimeZone'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPrimaryEmailAddress`
    - Parameter 'CustomerPrimaryEmailAddress' will be renamed to 'ContactDetailPrimaryEmailAddress'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-PreferredContactMethod`
    - Parameter 'PreferredContactMethod' will be renamed to 'ContactDetailPreferredContactMethod'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-QuotaTicketDetail`
    - Parameter QuotaTicketDetail will be removed. Use new parameters QuotaTicketDetailQuotaChangeRequest, QuotaTicketDetailQuotaChangeRequestSubType, QuotaTicketDetailQuotaChangeRequestVersion instead.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-TechnicalTicketResourceId`
    - Parameter 'TechnicalTicketResourceId' will be renamed to 'TechnicalTicketDetailResourceId'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `New-AzSupportTicketCommunication`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet New-AzSupportTicketCommunication will be renamed to New-AzSupportCommunication
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Piping of New-AzSupportTicketCommunication with a support ticket object will no longer be supported.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

### `Update-AzSupportTicket`

- Cmdlet breaking-change will happen to all parameter sets
  - The child output property ContactDetail will be deprecated. Use properties ContactDetailAdditionalEmailAddress,ContactDetailCountry, ContactDetailFirstName, ContactDetailLastName, ContactDetailPhoneNumber, ContactDetailPreferredContactMethod, ContactDetailPreferredSupportLanguage, ContactDetailPreferredTimeZone, and ContactDetailPrimaryEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property SupportEngineer will be deprecated. Use property SupportEngineerEmailAddress instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The child output property QuotaTicketDetail will be deprecated. Use properties QuotaTicketDetailQuotaChangeRequest,QuotaTicketDetailQuotaChangeRequestSubType, QuotaTicketDetailQuotaChangeRequestVersion instead
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - The output property TechnicalTicketResourceId will be changed to TechnicalTicketDetailResourceId
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-AdditionalEmailAddress`
    - Parameter 'AdditionalEmailAddress' will be renamed to 'ContactDetailAdditionalEmailAddress'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerContactDetail`
    - CustomerContactDetail will be removed. Use new parameters ContactDetailCountry, ContactDetailFirstName, ContactDetailLastName,ContactDetailPhoneNumber, ContactDetailPreferredSupportLanguage, ContactDetailPreferredTimeZone, ContactDetailPrimaryEmailAddress, ContactDetailPreferredContactMethod instead.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerCountry`
    - Parameter 'CustomerCountry' will be renamed to 'ContactDetailCountry'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerFirstName`
    - Parameter 'CustomerFirstName' will be renamed to 'ContactDetailFirstName'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerLastName`
    - Parameter 'CustomerLastName' will be renamed to 'ContactDetailLastName'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPhoneNumber`
    - Parameter 'CustomerPhoneNumber' will be renamed to 'ContactDetailPhoneNumber'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPreferredSupportLanguage`
    - Parameter 'CustomerPreferredSupportLanguage' will be renamed to 'ContactDetailPreferredSupportLanguage'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPreferredTimeZone`
    - Parameter 'CustomerPreferredTimeZone' will be renamed to 'ContactDetailPreferredTimeZone'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-CustomerPrimaryEmailAddress`
    - Parameter 'CustomerPrimaryEmailAddress' will be renamed to 'ContactDetailPrimaryEmailAddress'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - `-PreferredContactMethod`
    - Parameter 'PreferredContactMethod' will be renamed to 'ContactDetailPreferredContactMethod'
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

