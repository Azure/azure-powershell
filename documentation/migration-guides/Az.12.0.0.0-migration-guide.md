# Migration Guide for Az 12.0.0

## Az.Accounts

### `Clear-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

#### Before
```powershell
Clear-AzConfig -DisableErrorRecordsPersistence
```
#### After
```powershell
error record will be disabled by default. New parameter 'EnableErrorRecordsPersistence' added to enable erro record.
```


### `Get-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

#### Before
```powershell
Get-AzConfig -DisableErrorRecordsPersistence 
```
#### After
```powershell
error record will be disabled by default. New parameter 'EnableErrorRecordsPersistence' added to enable erro record.
```


### `Update-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

#### Before
```powershell
Update-AzConfig -DisableErrorRecordsPersistence 
```
#### After
```powershell
error record will be disabled by default. New parameter 'EnableErrorRecordsPersistence' added to enable erro record.
```


## Az.Compute

### `Get-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "Get-AzVmss" cmdlet will no longer allow an empty value for resource group name and virtual machine scale set name.
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzVmss -ResourceGroupName ""
# Returned an empty list.
```
#### After
```powershell
Get-AzVmss -ResourceGroupName ""
# Will return an error from empty string validation in the parameter.
```


### `New-AzGalleryImageDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzGalleryImage" cmdlet will deploy with the Trusted Launch configuration and Gen2 Hyper V Generation by default. To know more about Trusted Launch, please visit [https://learn.microsoft.com/azure/virtual-machines/trusted-launch](/azure/virtual-machines/trusted-launch)
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Specialized" -OsType "Linux"
# Defaulted to HyperVGeneration: Gen1 and SecurityType: Standard in the service side .
```
#### After
```powershell
New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $galleryImageDefinitionName -Location $location -Publisher $publisherName -Offer $offerName -Sku $skuName -OsState "Specialized" -OsType "Linux"
# Defaults to HyperVGeneration: Gen2 and SecurityType: TrustedLaunchSupported at the PowerShell level.
```


### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzVM" cmdlet will deploy with the image 'Windows Server 2022 Azure Edition' by default. This will make migrating to Trusted Launch easier in the future. To know more about Trusted Launch, please visit [https://learn.microsoft.com/azure/virtual-machines/trusted-launch](/azure/virtual-machines/trusted-launch)
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

#### Before
```powershell
$vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -SecurityType "Standard" -DomainNameLabel $domainNameLabel
# Creates a VM with the image Windows 2016 Datacenter. 
```
#### After
```powershell
$vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -SecurityType "Standard" -DomainNameLabel $domainNameLabel
# Now generates with the Windows 2022 Azure Edition image.
```


### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in May 2024 the "New-AzVmss" cmdlet will deploy with the image 'Windows Server 2022 Azure Edition' by default. This will make migrating to Trusted Launch easier in the future. To know more about Trusted Launch, please visit [https://learn.microsoft.com/azure/virtual-machines/trusted-launch](/azure/virtual-machines/trusted-launch)
  - This change is expected to take effect from Az.Compute version: 8.0.0 and Az version: 12.0.0

#### Before
```powershell
$vmss = New-AzVmss -ResourceGroupName $rgname -Credential $cred -VMScaleSetName $vmssName -SecurityType "Standard" -DomainNameLabel $domainNameLabel1
# would create a VMSS with a Windows 2016 Datacenter image. 
```
#### After
```powershell
$vmss = New-AzVmss -ResourceGroupName $rgname -Credential $cred -VMScaleSetName $vmssName -SecurityType "Standard" -DomainNameLabel $domainNameLabel1
# Now it will generate with a Windows 2022 Azure Edition image.
```


## Az.EventGrid

### `Get-AzEventGridChannel`
- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridChannel -ResourceGroup MyResourceGroupName -PartnerNamespaceName PartnerNamespace1 -Name Channel1
```
#### After
```powershell
Get-AzEventGridChannel -ResourceGroupName azps_test_group_eventgrid -PartnerNamespaceName azps-partnernamespace
```


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

#### Before
```powershell
Get-AzEventGridDomain -ResourceGroup MyResourceGroupName -Name Domain1
```
#### After
```powershell
Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
```


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

#### Before
```powershell
Get-AzEventGridDomainTopic -ResourceGroup MyResourceGroupName -DomainName Domain1 -DomainTopicName DomainTopic1
```
#### After
```powershell
Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -Name azps-domaintopics
```


### `Get-AzEventGridFullUrlForPartnerTopicEventSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1
```
#### After
```powershell
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -EventSubscriptionName azps-eventsubname
```


### `Get-AzEventGridPartnerConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridPartnerConfiguration -ResourceGroupName ResourceGroup1
```
#### After
```powershell
Get-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid
```


### `Get-AzEventGridPartnerNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridPartnerNamespace -ResourceGroup MyResourceGroupName -Name PartnerNamespace1
```
#### After
```powershell
Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-partnernamespace
```


### `Get-AzEventGridPartnerRegistration`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridPartnerRegistration -ResourceGroupName MyResourceGroupName -Name PartnerRegistration1
```
#### After
```powershell
Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
```


### `Get-AzEventGridPartnerTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridPartnerTopic -ResourceGroupName MyResourceGroupName -Name PartnerTopic1
```
#### After
```powershell
Get-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid
```


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

#### Before
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1 -IncludeFullEndpointUrl
```
#### After
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -EventSubscriptionName azps-eventsubname
```


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

#### Before
```powershell
Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName"
```
#### After
```powershell
Get-AzEventGridSubscription -Name azps-eventsub -Scope "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/topics/azps-topic"
```


### `Get-AzEventGridSystemTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridSystemTopic -ResourceGroup MyResourceGroupName -Name Topic1
```
#### After
```powershell
Get-AzEventGridSystemTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-systopic
```


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

#### Before
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1 -IncludeFullEndpointUrl
```
#### After
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -EventSubscriptionName azps-evnetsub
```


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

#### Before
```powershell
Get-AzEventGridTopic -ResourceGroup MyResourceGroupName -Name Topic1
```
#### After
```powershell
Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
```


### `Get-AzEventGridTopicType`

- Parameter breaking-change will happen to all parameter sets
  - `-IncludeEventTypeData`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridTopicType -Name "Microsoft.Storage.StorageAccounts"
```
#### After
```powershell
Get-AzEventGridTopicType -Name Microsoft.EventGrid.Namespaces
```


### `Get-AzEventGridVerifiedPartner`

- Parameter breaking-change will happen to all parameter sets
  - `-NextLink`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0
  - `-ODataQuery`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-AzEventGridVerifiedPartner -Name VerifiedPartner1
```
#### After
```powershell
Get-AzEventGridVerifiedPartner -Name MicrosoftGraphAPI
```


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

#### Before
```powershell
New-AzEventGridDomain -ResourceGroupName MyResourceGroupName -Name Domain1 -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
```
#### After
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
New-AzEventGridDomain -Name azps-domain -ResourceGroupName azps_test_group_eventgrid -Location westus2 -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```


### `New-AzEventGridPartnerConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-AuthorizedPartner`
    - The parameter : 'AuthorizedPartner' is changing.
    The type of the parameter is changing from 'System.Collections.Hashtable[]' to 'IPartner[]'.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzEventGridPartnerConfiguration -ResourceGroupName MyResourceGroupName -MaxExpirationTimeInDays 14
```
#### After
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
$partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -RegistrationImmutableId $partnerRegistration.ImmutableId
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10 -PartnerAuthorizationAuthorizedPartnersList $partner
```


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

#### Before
```powershell
New-AzEventGridPartnerNamespace -ResourceGroupName MyResourceGroupName -Name PartnerNamespace1 -Location westus2 -PartnerRegistrationFullyQualifiedId 23e0092b-f336-4833-9ab3-9353a15650fc
```
#### After
```powershell
New-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -PartnerTopicRoutingMode ChannelNameHeader -PartnerRegistrationFullyQualifiedId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/partnerRegistrations/azps-registration"
```


### `New-AzEventGridPartnerRegistration`

- Cmdlet breaking-change will happen to all parameter sets
  - Added new required parameter: Location `<String>`
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzEventGridPartnerRegistration -ResourceGroupName MyResourceGroupName -Name PartnerRegistration1
```
#### After
```powershell
New-AzEventGridPartnerRegistration -Name azps-registration -ResourceGroupName azps_test_group_eventgrid -Location global
```


### `New-AzEventGridPartnerTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzEventGridPartnerTopic -ResourceGroupName MyResourceGroupName -Name PartnerTopic1 -Source ContosoCorp.Accounts.User1 -Location westus2 -PartnerRegistrationImmutableId 23e0092b-f336-4833-9ab3-9353a15650fc
```
#### After
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
New-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid -Location eastus -partnerRegistrationImmutableId $partnerRegistration.ImmutableId -Source "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc "2023-11-17T11:06:13.109Z" -PartnerTopicFriendlyDescription "Example description" -MessageForActivation "Example message for activation"
```


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

#### Before
```powershell
$includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
$labels = "Finance", "HR"
New-AzEventGridPartnerTopicEventSubscription -ResourceGroup MyResourceGroup -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1 -Endpoint https://requestb.in/19qlscd1  -SubjectBeginsWith "TestPrefix" -SubjectEndsWith "TestSuffix" -IncludedEventType $includedEventTypes -Label $labels
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net"
New-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName azps-eventsub -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
```


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

#### Before
```powershell
$includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
$labels = "Finance", "HR"
New-AzEventGridSubscription -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName EventSubscription1 -SubjectBeginsWith "TestPrefix" -SubjectEndsWith "TestSuffix" -IncludedEventType $includedEventTypes -Label $labels
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
$topic = Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
New-AzEventGridSubscription -Name azps-eventsub -Scope $topic.Id -Destination $obj -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix"
```


### `New-AzEventGridSystemTopic`
- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Source ServiceBusNamespaceResourceId -TopicType 'Microsoft.ServiceBus.Namespaces' -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
```
#### After
```powershell
New-AzEventGridSystemTopic -Name azps-systopic -ResourceGroupName azps_test_group_eventgrid -Location eastus -Source "/subscriptions/{subId}/resourcegroups/azps_test_group_eventgrid/providers/Microsoft.Storage/storageAccounts/azpssa" -TopicType "microsoft.storage.storageaccounts"
```


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

#### Before
```powershell
$includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
$labels = "Finance", "HR"
New-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroup -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1 -Endpoint https://requestb.in/19qlscd1  -SubjectBeginsWith "TestPrefix" -SubjectEndsWith "TestSuffix" -IncludedEventType $includedEventTypes -Label $labels
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net"
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName azps-evnetsub -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```


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

#### Before
```powershell
New-AzEventGridTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
```
#### After
```powershell
$inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
New-AzEventGridTopic -Name azps-topic -ResourceGroupName azps_test_group_eventgrid -Location eastus -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
```


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

#### Before
```powershell
Remove-AzEventGridSubscription -ResourceGroup MyResourceGroup -TopicName Topic1 -EventSubscriptionName EventSubscription1
```
#### After
```powershell
Remove-AzEventGridSubscription -Name azps-eventsub -Scope "subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
```


### `Set-AzEventGridTopic`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Set-AzEventGridTopic -ResourceGroup MyResourceGroupName -Name Topic1 -Tag @{ Department="Finance"; Environment="Test" }
```
#### After



### `Update-AzEventGridPartnerTopic`

- Cmdlet breaking-change will happen to all parameter sets
  - The existing syntax will be extended. The new syntax will support updating more properties.
  - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - This parameter will be deprecated.
    - This change is expected to take effect from Az.EventGrid version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
Update-AzEventGridPartnerTopic -ResourceGroup MyResourceGroupName -Name Topic1 -IdentityType "SystemAssigned"
```
#### After
```powershell
Update-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid -UserAssignedIdentity "/subscriptions/{subId}/resourcegroups/azps_test_group_eventgrid/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami"
```


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

#### Before
```powershell
Update-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName ES1 -PartnerTopicName Topic1 -ResourceGroup MyResourceGroupName -Endpoint https://requestb.in/1kxxoui1 -SubjectEndsWith "jpg"
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName azps-eventsubname -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
```


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

#### Before
```powershell
Update-AzEventGridSubscription -EventSubscriptionName ES1 -TopicName Topic1 -ResourceGroup MyResourceGroupName -Endpoint https://requestb.in/1kxxoui1
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridSubscription -Name azps-eventsub -Scope "subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -Destination $obj -FilterIsSubjectCaseSensitive:$false
```


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

#### Before
```powershell
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName ES1 -SystemTopicName Topic1 -ResourceGroupName MyResourceGroupName -Endpoint https://requestb.in/1kxxoui1 -SubjectEndsWith "jpg"
```
#### After
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName azps-evnetsub -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```


## Az.EventHub

### `New-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-CleanupPolicy`
    - The parameter : 'CleanupPolicy' is changing.
    The type of the parameter is changing from 'CleanupPolicyRetentionDescription' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Encoding`
    - The parameter : 'Encoding' is changing.
    The type of the parameter is changing from 'EncodingCaptureDescription' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    The type of the parameter is changing from 'CaptureIdentityType' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHub -Name $env.eventHub9 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name -PartitionCount 2 -CleanupPolicy Delete -IdentityType UserAssigned  

 (CleanupPolicy type is CleanupPolicyRetentionDescription), 
 (Status type is EntityStatus),
 (IdentityType type is CaptureIdentiType), 
 (EncodingType type is EncodingCaptureDescription)
```
#### After
```powershell
New-AzEventHub -Name $env.eventHub9 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name -PartitionCount 2 -CleanupPolicy Delete -IdentityType UserAssigned  

 (CleanupPolicy type is String),
 (Status type is String), 
 (IdentityType type is String), 
 (EncodingType type is String)
```


### `New-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type AccessRights[])
```
#### After
```powershell
New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type System.String[])
```


### `New-AzEventHubIPRuleConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
(Action is of type NetworkRuleIPAction )
```
#### After
```powershell
(Action is of type String)
```


### `New-AzEventHubKey`

- Parameter breaking-change will happen to all parameter sets
  - `-KeyType`
    - The parameter : 'KeyType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey

(KeyType is of type KeyType)
```
#### After
```powershell
New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey

(KeyType is of type String)
```


### `New-AzEventHubNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
( SkuName is of type SkuName)
```
#### After
```powershell
New-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is String),
(PublicNetworkAccess is of type String),
( SkuName is of type String)
```


### `New-AzEventHubNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
( SkuName is of type SkuName)
```
#### After
```powershell
New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is String),
(PublicNetworkAccess is of type String),
( SkuName is of type String)
```


### `New-AzEventHubSchemaGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-SchemaCompatibility`
    - The parameter : 'SchemaCompatibility' is changing.
    The type of the parameter is changing from 'SchemaCompatibility' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-SchemaType`
    - The parameter : 'SchemaType' is changing.
    The type of the parameter is changing from 'SchemaType' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
New-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup2 -SchemaCompatibility Forward -SchemaType Avro -GroupProperty @{a='b'; c='d'}

(SchemaCompatibility is of type SchemaCompatibility)
(SchemaType is of type SchemaType)
```
#### After
```powershell
New-AzEventHubSchemaGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.schemaGroup2 -SchemaCompatibility Forward -SchemaType Avro -GroupProperty @{a='b'; c='d'}

(SchemaCompatibility is of type String),
(SchemaType is of type String)
```


### `New-AzEventHubThrottlingPolicyConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-MetricId`
    - The parameter : 'MetricId' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
(MetricId is of type MetricId)
```
#### After
```powershell
(MetricId is of type String)
```


### `Set-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-Encoding`
    - The parameter : 'Encoding' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
Set-AzEventHub -Name $env.eventHub9 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name  -IdentityType UserAssigned  

 
 (Status type is EntityStatus),
 (IdentityType type is CaptureIdentiType), 
 (Encoding type is EncodingCaptureDescription)
```
#### After
```powershell
Set-AzEventHub -Name $env.eventHub9 -ResourceGroupName $env.resourceGroup -NamespaceName $eventHubNamespace.Name  -IdentityType UserAssigned  

 
 (Status type is String),
 (IdentityType type is String), 
 (Encoding type is String)
```


### `Set-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
Set-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type AccessRights[])
```
#### After
```powershell
Set-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type System.String[])
```


### `Set-AzEventHubNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
Set-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess)
```
#### After
```powershell
Set-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type String),
(PublicNetworkAccess is of type String)
```


### `Set-AzEventHubNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess)
```
#### After
```powershell
Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type String),
(PublicNetworkAccess is of type String)
```


### `Set-AzEventHubNetworkRuleSet`

- Parameter breaking-change will happen to all parameter sets
  - `-DefaultAction`
    - The parameter : 'DefaultAction' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '5.0.0'

#### Before
```powershell
Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled -DefaultAction deny

 ( DefaultAction is of type DefaultAction),
 ( PublicNetworkAccess is of type PublicNetworkAccess)
```
#### After
```powershell
Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled -DefaultAction deny

 ( DefaultAction is of type String),
 ( PublicNetworkAccess is of type String)
```


## Az.KeyVault

### `Add-AzKeyVaultKey`

- Parameter breaking-change will happen to all parameter sets
  - `-UseDefaultCVMPolicy`
    - The offline fallback policy will be removed. Key creation will fail if unable to get regional default CVM SKR policy from MAA Service Discovery API.
    - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

### `Invoke-AzKeyVaultKeyOperation`
Remove parameter Value from Invoke-AzKeyVaultKeyOperation and property Result from the output type PSKeyOperationResult

#### Before
```powershell
$encryptedData = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force)
```
#### After
```powershell
"$plainText = ""test""
$byteArray = [system.Text.Encoding]::UTF8.GetBytes($plainText)
$encryptedData = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -ByteArrayValue $byteArray"
```


### `New-AzKeyVault`
Replaced parameter EnableRbacAuthorization by DisableRbacAuthorization in New-AzKeyVault and Update-AzKeyVault, RbacAuthorization will be enabled by default

#### Before
```powershell
New-AzKeyVault -VaultName 'Contoso03Vault' -ResourceGroupName 'Group14' -Location 'East US' -DisableRbacAuthorization 
```
#### After
```powershell
New-AzKeyVault -VaultName 'Contoso03Vault' -ResourceGroupName 'Group14' -Location 'East US' 
```


### `Update-AzKeyVault`
Replaced parameter EnableRbacAuthorization by DisableRbacAuthorization in Update-AzKeyVault

#### Before
```powershell
Get-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName | Update-AzKeyVault -EnableRbacAuthorization $true
```
#### After
```powershell
Get-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName | Update-AzKeyVault -DisableRbacAuthorization $false
```


## Az.RecoveryServices

### `Get-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
$VaultSettings = Get-AzRecoveryServicesAsrVaultContext
$ResourceType = $VaultSettings.ResouceType
```
#### After
```powershell
$VaultSettings = Get-AzRecoveryServicesAsrVaultContext
$ResourceType = $VaultSettings.ResourceType
```


### `Import-AzRecoveryServicesAsrVaultSettingsFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
$VaultSettings = Import-AzRecoveryServicesAsrVaultSettingsFile -Path $FilePath
$ResourceType = $VaultSettings.ResouceType
```
#### After
```powershell
$VaultSettings = Import-AzRecoveryServicesAsrVaultSettingsFile -Path $FilePath
$ResourceType = $VaultSettings.ResourceType
```


### `Set-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
$vaultSettings = Set-AzRecoveryServicesAsrVaultContext -Vault $RecoveryServicesVault
$ResourceType = $VaultSettings.ResouceType
```
#### After
```powershell
$vaultSettings = Set-AzRecoveryServicesAsrVaultContext -Vault $RecoveryServicesVault
$ResourceType = $VaultSettings.ResourceType
```


## Az.Resources

### `Get-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyAssignment = Get-AzPolicyAssignment -Name MyAssignment
$description = $policyAssignment.Properties.Description

```
#### After
```powershell
$policyAssignment = Get-AzPolicyAssignment -Name MyAssignment
$description = $policyAssignment.Description

Compatible option:
$policyAssignment = Get-AzPolicyAssignment -Name MyAssignment -BackwardCompatible
$description = $policyAssignment.Properties.Description

```


### `Get-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyDefinition = Get-AzPolicyDefinition -Builtin | select -First 1
$policyRule = $policyDefinition.Properties.PolicyRule


```
#### After
```powershell
$policyDefinition = Get-AzPolicyDefinition -Builtin | select -First 1
$policyRule = $policyDefinition.PolicyRule

Compatible option:
$policyDefinition = Get-AzPolicyDefinition -Builtin -BackwardCompatible | select -First 1
$policyRule = $policyDefinition.Properties.PolicyRule

```


### `Get-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyExemption = Get-AzPolicyExemption -Scope /providers/Microsoft.Management/managementGroups/myManagementGroup -Name MyExemption
$expiresOn = $policyExemption.Properties.ExpiresOn

```
#### After
```powershell
$policyExemption = Get-AzPolicyExemption -Scope /providers/Microsoft.Management/managementGroups/myManagementGroup -Name MyExemption
$expiresOn = $policyExemption.ExpiresOn

Compatible option:
$policyExemption = Get-AzPolicyExemption -Scope /providers/Microsoft.Management/managementGroups/myManagementGroup -Name MyExemption -BackwardCompatible
$expiresOn = $policyExemption.Properties.ExpiresOn

```


### `Get-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameter' 'PolicyDefinitionGroup' 'PolicyDefinition' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policySetDefinition = Get-AzPolicySetDefinition -Builtin | select -First 1
$policySetParameters = $policySetDefinition.Properties.Parameters

```
#### After
```powershell
$policySetDefinition = Get-AzPolicySetDefinition -Builtin | select -First 1
$policySetParameters = $policySetDefinition.Parameter

Compatible option:
$policySetDefinition = Get-AzPolicySetDefinition -Builtin -BackwardCompatible | select -First 1
$policySetParameters = $policySetDefinition.Properties.Parameters

```


### `New-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyAssignment = New-AzPolicyAssignment -Name MyAssignment -PolicyDefinition MyPolicyDefinition
$enforcementMode = $policyAssignment.Properties.EnforcementMode

```
#### After
```powershell
$policyAssignment = New-AzPolicyAssignment -Name MyAssignment -PolicyDefinition MyPolicyDefinition
$enforcementMode = $policyAssignment.EnforcementMode

Compatible option:
$policyAssignment = New-AzPolicyAssignment -Name MyAssignment -PolicyDefinition MyPolicyDefinition -BackwardCompatible
$enforcementMode = $policyAssignment.Properties.EnforcementMode

```


### `New-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyRule = '{ "if": { "field": "type", "like": "Microsoft.DesktopVirtualization/*" }, "then": { "effect": "deny" } }'
$policyDefinition = New-AzPolicyDefinition -Name MyDefinition -Policy $policyRule
$policyType = $policyDefinition.Properties.PolicyType


```
#### After
```powershell
$policyRule = '{ "if": { "field": "type", "like": "Microsoft.DesktopVirtualization/*" }, "then": { "effect": "deny" } }'
$policyDefinition = New-AzPolicyDefinition -Name MyDefinition -Policy $policyRule
$policyType = $policyDefinition.PolicyType

Compatible option:
$policyDefinition = New-AzPolicyDefinition -Name MyDefinition -Policy $policyRule -BackwardCompatible
$policyType = $policyDefinition.Properties.PolicyType


```


### `New-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated
$policyDefinitionId = $policyExemption.Properties.PolicyAssignmentId


```
#### After
```powershell
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated
$policyDefinitionId = $policyExemption.PolicyAssignmentId

Compatible option:
$policyExemption = Get-AzPolicyAssignment -Name MyAssignment | New-AzPolicyExemption -Name MyExemption -ExemptionCategory Mitigated -BackwardCompatible
$policyDefinitionId = $policyExemption.Properties.PolicyAssignmentId

```


### `New-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyDefinitionReferences = ('[{ "policyDefinitionId": "' + (Get-AzPolicyDefinition -Name MyDefinition).ResourceId + '"}]')
$policySetDefinition = New-AzPolicySetDefinition -Name MySetDefinition -PolicyDefinition $policyDefinitionReferences
$policyDefinitionReferenceId = $policySetDefinition.Properties.PolicyDefinitions[0].policyDefinitionReferenceId


```
#### After
```powershell
$policyDefinitionReferences = ('[{ "policyDefinitionId": "' + (Get-AzPolicyDefinition -Name MyDefinition).ResourceId + '"}]')
$policySetDefinition = New-AzPolicySetDefinition -Name MySetDefinition -PolicyDefinition $policyDefinitionReferences
$policyDefinitionReferenceId = $policySetDefinition.PolicyDefinition[0].policyDefinitionReferenceId

Compatible option:
$policySetDefinition = New-AzPolicySetDefinition -Name MySetDefinition -PolicyDefinition $policyDefinitionReferences 
$policyDefinitionReferenceId = $policySetDefinition.Properties.PolicyDefinitions[0].policyDefinitionReferenceId

```


### `Set-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyAssignment = Set-AzPolicyAssignment -Name MyAssignment -DisplayName 'My cool assignment'
$displayName = $policyAssignment.Properties.DisplayName


```
#### After
```powershell
$policyAssignment = Update-AzPolicyAssignment -Name MyAssignment -DisplayName 'My cool assignment'
$displayName = $policyAssignment.DisplayName

Compatible option:
$policyAssignment = Set-AzPolicyAssignment -Name MyAssignment -DisplayName 'My cool assignment' -BackwardCompatible
$displayName = $policyAssignment.Properties.DisplayName


```


### `Set-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyDefinition = Set-AzPolicyDefinition -Name MyDefinition -Description 'A much better policy definition'
$description = $policyDefinition.Properties.Description


```
#### After
```powershell
$policyDefinition = Update-AzPolicyDefinition -Name MyDefinition -Description 'A much better policy definition'
$description = $policyDefinition.Description

Compatible option:
$policyDefinition = Set-AzPolicyDefinition -Name MyDefinition -Description 'A much better policy definition' -BackwardCompatible
$description = $policyDefinition.Properties.Description

```


### `Set-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policyExemption = Set-AzPolicyExemption -Name MyExemption -ExemptionCategory Waiver
$exemptionCategory = $policyExemption.Properties.ExemptionCategory


```
#### After
```powershell
$policyExemption = Update-AzPolicyExemption -Name MyExemption -ExemptionCategory Waiver
$exemptionCategory = $policyExemption.ExemptionCategory

Compatbile option:
$policyExemption = Update-AzPolicyExemption -Name MyExemption -ExemptionCategory Waiver -BackwardCompatible
$exemptionCategory = $policyExemption.Properties.ExemptionCategory


```


### `Set-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

#### Before
```powershell
$policySetDefinition = Set-AzPolicySetDefinition -Name MySetDefinition -Metadata '{ "MyThing": "A really good thing" }'
$myThing = $policySetDefinition.Properties.Metadata.MyThing


```
#### After
```powershell
$policySetDefinition = Update-AzPolicySetDefinition -Name MySetDefinition -Metadata '{ "MyThing": "A really good thing" }'
$myThing = $policySetDefinition.Metadata.MyThing

Compatible option:
$policySetDefinition = Set-AzPolicySetDefinition -Name MySetDefinition -Metadata '{ "MyThing": "A really good thing" }' -BackwardCompatible
$myThing = $policySetDefinition.Properties.Metadata.MyThing


```


## Az.ServiceBus

### `New-AzServiceBusAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type AccessRights[])
```
#### After
```powershell
New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type System.String[])
```


### `New-AzServiceBusIPRuleConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Action is of type NetworkRuleIPAction )
```
#### After
```powershell
(Action is of type String )
```


### `New-AzServiceBusKey`

- Parameter breaking-change will happen to all parameter sets
  - `-KeyType`
    - The parameter : 'KeyType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey

(KeyType is of type KeyType)
```
#### After
```powershell
New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey

(KeyType is of type String)
```


### `New-AzServiceBusNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
New-ServiceBusNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
( SkuName is of type SkuName)
```
#### After
```powershell
New-ServiceBusNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is String),
(PublicNetworkAccess is of type String),
( SkuName is of type String)
```


### `New-AzServiceBusNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
New-ServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
( SkuName is of type SkuName)
```
#### After
```powershell
New-ServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is String),
(PublicNetworkAccess is of type String),
( SkuName is of type String)
```


### `New-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String)
```


### `New-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String)
```


### `New-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    The type of the parameter is changing from 'EntityStatus' to 'String'.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String)
```


### `Set-AzServiceBusAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The parameter : 'Rights' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
Set-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type AccessRights[])
```
#### After
```powershell
Set-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
 
 (Rights is of type System.String[])
```


### `Set-AzServiceBusNamespace`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
Set-AzServiceBusNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
 (SkuName is of type SkuName) 
```
#### After
```powershell
Set-AzServiceBusNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type String),
(PublicNetworkAccess is of type String),
 (SkuName is of type String) 
```


### `Set-AzServiceBusNamespaceV2`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-SkuName`
    - The parameter : 'SkuName' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type ManagedServiceIdentityType),
(PublicNetworkAccess is of type PublicNetworkAccess),
 (SkuName is of type SkuName) 
```
#### After
```powershell
Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4  -IdentityType SystemAssigned -PublicNetworkAccess Disabled

( IdentityType is of type String),
(PublicNetworkAccess is of type String),
 (SkuName is of type String) 
```


### `Set-AzServiceBusNetworkRuleSet`

- Parameter breaking-change will happen to all parameter sets
  - `-DefaultAction`
    - The parameter : 'DefaultAction' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'
  - `-PublicNetworkAccess`
    - The parameter : 'PublicNetworkAccess' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled -DefaultAction deny

 ( DefaultAction is of type DefaultAction),
 ( PublicNetworkAccess is of type PublicNetworkAccess)
```
#### After
```powershell
Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled -DefaultAction deny

 ( DefaultAction is of type String),
 ( PublicNetworkAccess is of type String)
```


### `Set-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String.)
```


### `Set-AzServiceBusRule`

- Parameter breaking-change will happen to all parameter sets
  - `-FilterType`
    - The parameter : 'FilterType' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
Set-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRule2 -FilterType SqlFilter -SqlExpression x=y

( FilterType is of type FilterType)
```
#### After
```powershell
Set-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRule2 -FilterType SqlFilter -SqlExpression x=y

( FilterType is of type String)
```


### `Set-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String)
```


### `Set-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-Status`
    - The parameter : 'Status' is changing.
    - This change will take effect on '5/21/2024'- The change is expected to take effect from Az version : '12.0.0'
    - The change is expected to take effect from version : '4.0.0'

#### Before
```powershell
(Status is of type EntityStatus)
```
#### After
```powershell
(Status is of type String)
```


## Az.Sql

### `New-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzSqlDatabaseFailoverGroup -ServerName example-primary-server -ResourceGroupName example-rg -PartnerServerName example-secondary-server -FailoverGroupName example-fg     (FailoverPolicy defaults to Automatic)
```
#### After
```powershell
New-AzSqlDatabaseFailoverGroup -ServerName example-primary-server -ResourceGroupName example-rg -PartnerServerName example-secondary-server -FailoverGroupName example-fg     (FailoverPolicy defaults to Manual)
```


### `Set-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

#### Before
```powershell
Get-Help Set-AzSqlDatabaseFailoverGroup -Parameter FailoverPolicy (Output shows default value = Automatic)
```
#### After
```powershell
Get-Help Set-AzSqlDatabaseFailoverGroup -Parameter FailoverPolicy (Output shows default value = Manual)
```


## Az.Storage

### `Get-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
PS C:\WINDOWS\system32> $queue = Get-AzStorageQueue -Context $ctx-Name myqueue
PS C:\WINDOWS\system32> $queue | fl

CloudQueue              : Microsoft.Azure.Storage.Queue.CloudQueue
Uri                     : https://mystorageaccount.queue.core.windows.net/myqueue
ApproximateMessageCount : 0
EncodeMessage           : True
QueueClient             : Azure.Storage.Queues.QueueClient
QueueProperties         : Azure.Storage.Queues.Models.QueueProperties
Context                 : Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext
Name                    : myqueue

PS C:\WINDOWS\system32> $queueMessage = [Microsoft.Azure.Storage.Queue.CloudQueueMessage]::new("This is message 1")
PS C:\WINDOWS\system32> $queue.CloudQueue.AddMessageAsync($queueMessage)
```
#### After
```powershell
PS C:\WINDOWS\system32> $queue = Get-AzStorageQueue -Context $ctx-Name myqueue
PS C:\WINDOWS\system32> $queue | fl

QueueClient             : Azure.Storage.Queues.QueueClient
Uri                     : https://mystorageaccount.queue.core.windows.net/myqueue
ApproximateMessageCount : 0
QueueProperties         : Azure.Storage.Queues.Models.QueueProperties
Context                 : Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext
Name                    : myqueue

PS C:\WINDOWS\system32> $queueMessage = "This is message 1"
PS C:\WINDOWS\system32> $queue.QueueClient.SendMessage($queueMessage)
```


### `New-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
PS C:\WINDOWS\system32> $queue = New-AzStorageQueue -Name myqueue -Context $ctx
PS C:\WINDOWS\system32> $queue | fl

CloudQueue              : Microsoft.Azure.Storage.Queue.CloudQueue
Uri                     : https://mystorageaccount.queue.core.windows.net/myqueue
ApproximateMessageCount : 0
EncodeMessage           : True
QueueClient             : Azure.Storage.Queues.QueueClient
QueueProperties         : Azure.Storage.Queues.Models.QueueProperties
Context                 :
Name                    : myqueue
```
#### After
```powershell
PS C:\WINDOWS\system32> $queue = New-AzStorageQueue -Name myqueue -Context $ctx
PS C:\WINDOWS\system32> $queue | fl


QueueClient             : Azure.Storage.Queues.QueueClient
Uri                     : https://mystorageaccount.queue.core.windows.net/myqueue
ApproximateMessageCount : 0
QueueProperties         : Azure.Storage.Queues.Models.QueueProperties
Context                 : Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext
Name                    : myqueue
```


### `New-AzStorageQueueSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzStorageQueueSASToken -Name testq1 -Permission ruap -Protocol HttpsOnly -Context $ctx
(The parameter Protocol is of type SharedAccessProtocol)
```
#### After
```powershell
New-AzStorageQueueSASToken -Name testq1 -Permission ruap -Protocol HttpsOnly -Context $ctx
(The parameter Protocol is of type string)
```


### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-UpgradeToStorageV2`
    - A prompt that needs users' confirmation will be added when upgrading a storage account from StorageV1 or BlobStorage to StorageV2. Suppress it with -Force.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
No prompt when upgrading to StorageV2:
Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -UpgradeToStorageV2
```
#### After
```powershell
Add -Force to skip the prompt when upgrading to StorageV2 
Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -UpgradeToStorageV2 -Force
```


### `Set-AzStorageFileContent`

- Parameter breaking-change will happen to all parameter sets
  - `-Path`
    - When uploading using SAS token without Read permission, the destination path will be taken as a file path, instead of a directory path previously.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

#### Before
```powershell
When uploading Azure File using SAS token without Read permission, the Path parameter will be taken as parent directory path, and will take source file name as destination file name.

$ctxsas = New-AzStorageContext -StorageAccountName $accountName  -SasToken $writeOnlySasToken
Set-AzStorageFileContent -ShareName $sharename -Path dir1/dir2 -Source C:\temp\test.txt -Context $ctxsas 
```
#### After
```powershell
When uploading Azure File using SAS token without Read permission, the Path parameter need be whole path of destination file, include file name

$ctxsas = New-AzStorageContext -StorageAccountName $accountName  -SasToken $writeOnlySasToken
Set-AzStorageFileContent -ShareName $sharename -Path dir1/dir2/test.txt -Source C:\temp\test.txt -Context $ctxsas 
```


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

#### Before
```powershell
Get-AzSupportProblemClassification -ServiceId b452a42b-3779-64de-532c-8a32738357a6 -Id 3400570d-442f-a892-48e2-ff4ad710b38f
```
#### After
```powershell
Get-AzSupportProblemClassification -ServiceName b452a42b-3779-64de-532c-8a32738357a6 -Name 3400570d-442f-a892-48e2-ff4ad710b38f
```


### `Get-AzSupportService`

- Cmdlet breaking-change will happen to all parameter sets
  - Output property name 'ResourceTypes' will be changed to 'ResourceType'.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Id`
    - Parameter name 'Id' will be changed to 'Name'.
    - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
"Get-AzSupportService -Id b452a42b-3779-64de-532c-8a32738357a6

Id            : /providers/Microsoft.Support/services/b452a42b-3779-64de-532c-8a32738357a6
Name          : b452a42b-3779-64de-532c-8a32738357a6
Type          : Microsoft.Support/services
DisplayName   : Web App (Linux)
ResourceTypes : {MICROSOFT.WEB/SITES}"
```
#### After
```powershell
Get-AzSupportService -Name b452a42b-3779-64de-532c-8a32738357a6

DisplayName       : Web App (Linux)
Id                : /providers/Microsoft.Support/services/b452a42b-3779-64de-532c-8a32738357a6
Name              : b452a42b-3779-64de-532c-8a32738357a6
ResourceGroupName :
ResourceType      : {MICROSOFT.WEB/SITES}
Type              : Microsoft.Support/services
```


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

#### Before
```powershell
Get-AzSupportTicket  -First 1

Id                               : /subscriptions/86cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft
                                   .Support/supportTickets/06bfd9d3-22f96a7f-496854d2-6b34-4c48-a4a9-69a6f
                                   599407a
Name                             : 06bfd9d3-22f96a7f-496854d2-6b34-4c48-a4a9-69a6f599407a
Type                             : Microsoft.Support/supportTickets
Title                            : Quota request for Storage: Azure NetApp Files limits
SupportTicketId                  : 3505060040007427
Description                      : Question: Quota type
                                   Answer: Regional Capacity Quota per Subscription (TiB)

                                   Question: Region requested
                                   Answer: Australia Central 2

                                   Question: Quota State
                                   Answer: Current:25, Default:25

                                   Question: Enter value for new limit
                                   Answer: 22
ProblemClassificationId          : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800de
                                   c89/problemClassifications/22f96a7f-37b3-1504-0258-909e9f5ab3ac
ProblemClassificationDisplayName : Storage: Azure NetApp Files limits
Severity                         : Minimal
EnrollmentId                     :
Require24X7Response              : False
ContactDetail                    : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Azure Internal
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800de
                                   c89
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 5/6/2024 3:42:35 PM
ModifiedDate                     : 5/6/2024 3:42:46 PM
TechnicalTicketResourceId        :
QuotaTicketDetail                : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```
#### After
```powershell
Get-AzSupportTicket -Top 1

AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : First
ContactDetailLastName                      : Last
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 5/6/2024 3:42:35 PM
Description                                : Question: Quota type
                                             Answer: Regional Capacity Quota per Subscription (TiB)

                                             Question: Region requested
                                             Answer: Australia Central 2

                                             Question: Quota State
                                             Answer: Current:25, Default:25

                                             Question: Enter value for new limit
                                             Answer: 22
EnrollmentId                               :
FileWorkspaceName                          : 2405060040007416
Id                                         : /subscriptions/86cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Support/supportTickets/06bfd9
                                             d3-22f96a7f-496854d2-6b34-4c48-a4a9-69a6f599407a
IsTemporaryTicket                          : No
ModifiedDate                               : 5/6/2024 3:42:46 PM
Name                                       : 06bfd9d3-22f96a7f-496854d2-6b34-4c48-a4a9-69a6f599407a
ProblemClassificationDisplayName           : Storage: Azure NetApp Files limits
ProblemClassificationId                    : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800dec89/problemClassifications/22f
                                             96a7f-37b3-1504-0258-909e9f5ab3ac
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        : {{
                                               "region": "australiacentral2",
                                               "payload": "{\"QuotaBucket\":\"tib_per_subscription\",\"tib_per_subscription_text\":\"Current:25,
                                             Default:25\",\"NewLimit\":22}"
                                             }}
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion : 0.0
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : Service and subscription limits (quotas)
ServiceId                                  : /providers/Microsoft.Support/services/06bfd9d3-516b-d5c6-5802-169c800dec89
ServiceLevelAgreementExpirationTime        : 5/6/2024 11:42:35 PM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 5/6/2024 3:42:35 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : support plan
SupportPlanId                              : test
SupportPlanType                            : test
SupportTicketId                            : 3505060040007427
TechnicalTicketDetailResourceId            :
Title                                      : Quota request for Storage: Azure NetApp Files limits
Type                                       : Microsoft.Support/supportTickets
```


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

#### Before
```powershell
Get-AzSupportTicketCommunication -SupportTicketName 48cf91d7-69575ec1-65697697-e20c-4bfc-bc46-b69f0ef6d0a0 -First 5
```
#### After
```powershell
Get-AzSupportCommunication -SupportTicketName 48cf91d7-69575ec1-65697697-e20c-4bfc-bc46-b69f0ef6d0a0 -Top 5
```


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

#### Before
```powershell
New-AzSupportTicket -Name "test1" -Title "Test" -Description "Test" -Severity "minimal" -ProblemClassificationId "/providers/Microsoft.Support/services/{vm_windows_service_guid}/problemClassifications/{problemClassification_guid}" -TechnicalTicketResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM" -CustomerContactDetail @{FirstName = "first" ; LastName = "last" ; PreferredTimeZone = "pacific standard time" ; PreferredSupportLanguage = "en-us" ; Country = "USA" ; PreferredContactMethod = "Email" ; PrimaryEmailAddress = "test@test.com"}

New-AzSupportTicket -Name "test1" -Title "Test" -Description "Test" -Severity "minimal" -ProblemClassificationId "/providers/Microsoft.Support/services/{quota_service_guid}/problemClassifications/{cores_problemClassification_guid}" -QuotaTicketDetail @{QuotaChangeRequestVersion = "1.0" ; QuotaChangeRequests = (@{Region = "westus"; Payload = "{`"VMFamily`":`"Dv2 Series`",`"NewLimit`":350}"})} -CustomerContactDetail @{FirstName = "first" ; LastName = "last" ; PreferredTimeZone = "pacific standard time" ; PreferredSupportLanguage = "en-us" ; Country = "USA" ; PreferredContactMethod = "Email" ; PrimaryEmailAddress = "test@test.com"}

Id                               : /subscriptions/{subscription}/providers/Microsoft
                                   .Support/supportTickets/test_1
Name                             : test_1
Type                             : Microsoft.Support/supportTickets
Title                            : test
SupportTicketId                  : 3505060040008586
Description                      : test ticket please ignore and close
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_id}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Compute-VM (cores-vCPUs) subscription limit increases
Severity                         : Minimal
EnrollmentId                     :
Require24X7Response              : False
ContactDetail                    : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Azure Internal
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_id}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 5/6/2024 4:44:24 PM
ModifiedDate                     : 5/6/2024 4:44:34 PM
TechnicalTicketResourceId        :
QuotaTicketDetail                : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```
#### After
```powershell
New-AzSupportTicket -Name "test1" -AdvancedDiagnosticConsent "Yes" -ContactDetailCountry "USA" -ContactDetailFirstName "first" -ContactDetailLastName "last" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPrimaryEmailAddress "test@test.com" -Description "test ticket" -ProblemClassificationId "/providers/microsoft.support/services/{vm_windows_service_guid}/problemclassifications/{problemClassigication_guid}" -ServiceId "/providers/microsoft.support/services/{vm_windows_service_guid}" -Severity "minimal" -Title "test" -TechnicalTicketDetailResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM"

New-AzSupportTicket -Name "test1" -AdvancedDiagnosticConsent "Yes" -ContactDetailCountry "USA" -ContactDetailFirstName "firstName" -ContactDetailLastName "lastName" -ContactDetailPreferredContactMethod "email" -ContactDetailPreferredSupportLanguage "en-US" -ContactDetailPreferredTimeZone "Pacific Standard Time" -ContactDetailPrimaryEmailAddress "test@test.com" -Description "test ticket please ignore and close" -ProblemClassificationId "/providers/microsoft.support/services/{quota_service_guid}/problemclassifications/{cores_problemClassification_guid}" -ServiceId "/providers/microsoft.support/services/{quota_service_guid}" -Severity "minimal" -Title "test" -QuotaTicketDetailQuotaChangeRequest @(@{ Payload = "{`"VMFamily`":`"DV2 Series`",`"NewLimit`":`"350`",`"DeploymentStack`":`"ARM`",`"Type`":`"Regional`",`"EdgeZone`":`"`"}"; Region = "EASTUS"}) -QuotaTicketDetailQuotaChangeRequestVersion "1.0"

AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : firstName
ContactDetailLastName                      : lastName
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 5/6/2024 4:44:24 PM
Description                                : test ticket please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 3505060040008586
Id                                         : /subscriptions/{subscription_id}/providers/Microsoft.Support/supportTickets/test1
IsTemporaryTicket                          : No
ModifiedDate                               : 5/6/2024 4:44:36 PM
Name                                       : test_grace_2
ProblemClassificationDisplayName           : Compute-VM (cores-vCPUs) subscription limit increases
ProblemClassificationId                    : /providers/Microsoft.Support/services/{service_id}/problemClassifications/{problemClassification_guid}
ProblemScopingQuestion                     :
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        : {{
                                               "region": "EASTUS",
                                               "payload": "{\"VMFamily\":\"DV2
                                             Series\",\"NewLimit\":\"350\",\"DeploymentStack\":\"ARM\",\"Type\":\"Regional\",\"EdgeZone\":\"\"}"
                                             }}
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion : 1.0
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : Service and subscription limits (quotas)
ServiceId                                  : /providers/Microsoft.Support/services/{service_id}
ServiceLevelAgreementExpirationTime        : 5/7/2024 12:44:24 AM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 5/6/2024 4:44:24 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : suppport plan
SupportPlanId                              : test
SupportPlanType                            : support plan
SupportTicketId                            : 3505060040008586
TechnicalTicketDetailResourceId            :
Title                                      : test
Type                                       : Microsoft.Support/supportTickets
```


### `New-AzSupportTicketCommunication`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet New-AzSupportTicketCommunication will be renamed to New-AzSupportCommunication
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0
  - Piping of New-AzSupportTicketCommunication with a support ticket object will no longer be supported.
  - This change is expected to take effect from Az.Support version: 2.0.0 and Az version: 12.0.0

#### Before
```powershell
New-AzSupportTicketCommunication -SupportTicketName 48cf91d7-69575ec1-65697697-e20c-4bfc-bc46-b69f0ef6d0a0 -Name "testcomm1" -Subject "test" -Body "test"
```
#### After
```powershell
New-AzSupportCommunication -SupportTicketName 48cf91d7-69575ec1-65697697-e20c-4bfc-bc46-b69f0ef6d0a0 -Name "testcomm1" -Subject "test" -Body "test"
```


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

#### Before
```powershell
$contactDetail = New-Object Microsoft.Azure.Commands.Support.Models.PSContactProfile
$contactDetail.FirstName = "first name updated"
$contactDetail.LastName = "last name updated"
Update-AzSupportTicket -Name "test1" -CustomerContactDetail $contactDetail -CustomerCountry "USA" 

Id                               : /subscriptions/{subscription}/providers/Microsoft
                                   .Support/supportTickets/test_1
Name                             : test_1
Type                             : Microsoft.Support/supportTickets
Title                            : test
SupportTicketId                  : 3505060040008586
Description                      : test ticket please ignore and close
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_id}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName : Compute-VM (cores-vCPUs) subscription limit increases
Severity                         : Minimal
EnrollmentId                     :
Require24X7Response              : False
ContactDetail                    : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Azure Internal
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_id}
ServiceDisplayName               : Service and subscription limits (quotas)
Status                           : Open
CreatedDate                      : 5/6/2024 4:44:24 PM
ModifiedDate                     : 5/6/2024 4:44:34 PM
TechnicalTicketResourceId        :
QuotaTicketDetail                : Microsoft.Azure.Commands.Support.Models.PSQuotaTicketDetail
```
#### After
```powershell
Update-SupportTicket -Name "test1" -ContactDetailFirstName "first name updated" -ContactDetailLastName "last name updated" -ContactDetailCountry "USA"

AdvancedDiagnosticConsent                  : Yes
ContactDetailAdditionalEmailAddress        :
ContactDetailCountry                       : USA
ContactDetailFirstName                     : first name updated
ContactDetailLastName                      : last name updated
ContactDetailPhoneNumber                   :
ContactDetailPreferredContactMethod        : Email
ContactDetailPreferredSupportLanguage      : en-US
ContactDetailPreferredTimeZone             : Pacific Standard Time
ContactDetailPrimaryEmailAddress           : test@test.com
CreatedDate                                : 5/6/2024 4:44:24 PM
Description                                : test ticket please ignore and close
EnrollmentId                               :
FileWorkspaceName                          : 3505060040008586
Id                                         : /subscriptions/{subscription_id}/providers/Microsoft.Support/supportTickets/test1
IsTemporaryTicket                          : No
ModifiedDate                               : 5/6/2024 4:44:36 PM
Name                                       : test_grace_2
ProblemClassificationDisplayName           : Compute-VM (cores-vCPUs) subscription limit increases
ProblemClassificationId                    : /providers/Microsoft.Support/services/{service_id}/problemClassifications/{problemClassification_guid}
ProblemScopingQuestion                     :
ProblemStartTime                           :
QuotaTicketDetailQuotaChangeRequest        : {{
                                               "region": "EASTUS",
                                               "payload": "{\"VMFamily\":\"DV2
                                             Series\",\"NewLimit\":\"350\",\"DeploymentStack\":\"ARM\",\"Type\":\"Regional\",\"EdgeZone\":\"\"}"
                                             }}
QuotaTicketDetailQuotaChangeRequestSubType :
QuotaTicketDetailQuotaChangeRequestVersion : 1.0
Require24X7Response                        : False
ResourceGroupName                          :
SecondaryConsent                           :
ServiceDisplayName                         : Service and subscription limits (quotas)
ServiceId                                  : /providers/Microsoft.Support/services/{service_id}
ServiceLevelAgreementExpirationTime        : 5/7/2024 12:44:24 AM
ServiceLevelAgreementSlaMinute             : 480
ServiceLevelAgreementStartTime             : 5/6/2024 4:44:24 PM
Severity                                   : Minimal
Status                                     : Open
SupportEngineerEmailAddress                :
SupportPlanDisplayName                     : suppport plan
SupportPlanId                              : test
SupportPlanType                            : support plan
SupportTicketId                            : 3505060040008586
TechnicalTicketDetailResourceId            :
Title                                      : test
Type                                       : Microsoft.Support/supportTickets
```


