## 12.0.0 - May 2024
#### Az.Accounts 3.0.0 
* Modified cmdlet `Clear-AzConfig`
   - Removed parameter `-DisableErrorRecordsPersistence`
   - Added parameters `-EnableErrorRecordsPersistence`, `-LoginExperienceV2`
* Modified cmdlet `Get-AzConfig`
   - Removed parameter `-DisableErrorRecordsPersistence`
   - Added parameters `-EnableErrorRecordsPersistence`, `-LoginExperienceV2`
* Modified cmdlet `Update-AzConfig`
   - Removed parameter `-DisableErrorRecordsPersistence`
   - Added parameters `-EnableErrorRecordsPersistence`, `-LoginExperienceV2`
#### Az.Compute 8.0.0 
* Modified cmdlet `Get-AzVmss`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `False` to `True`
   - Parameter `-VMScaleSetName` ValidateNotNullOrEmpty changed from `False` to `True`
* Modified cmdlet `Grant-AzDiskAccess`
   - Added parameter `-SecureVMGuestStateSAS`
* Modified cmdlet `New-AzVM`
   - Added parameters `-IfMatch`, `-IfNoneMatch`
* Modified cmdlet `New-AzVmss`
   - Added parameters `-IfMatch`, `-IfNoneMatch`
* Modified cmdlet `Update-AzVM`
   - Added parameters `-IfMatch`, `-IfNoneMatch`
* Modified cmdlet `Update-AzVmss`
   - Added parameters `-IfMatch`, `-IfNoneMatch`
#### Az.EventGrid 2.0.0 
* Modified cmdlet `Enable-AzEventGridPartnerTopic`
   - Added parameters `-SubscriptionId`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerTopic` to `IEventGridIdentity`
   - Output type changed from ``PSPartnerTopic`` to ``IPartnerTopic``
* Modified cmdlet `Get-AzEventGridChannel`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-PartnerNamespaceInputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSChannelListInstance``, ``PSChannel`` to ``IChannel``
* Modified cmdlet `Get-AzEventGridDomain`
   - Removed parameters `-ResourceId`, `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSDomain``, ``PSDomainListInstance`` to ``IDomain``
* Modified cmdlet `Get-AzEventGridDomainKey`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-Name`, `-DomainObject`, `-DomainResourceId`
   - Added parameters `-DomainName`, `-SubscriptionId`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsDomainSharedAccessKeys`` to ``IDomainSharedAccessKeys``
* Modified cmdlet `Get-AzEventGridDomainTopic`
   - Removed parameters `-ResourceId`, `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-DomainInputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DomainName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSDomainTopic``, ``PSDomainTopicListInstance`` to ``IDomainTopic``
* Modified cmdlet `Get-AzEventGridFullUrlForPartnerTopicEventSubscription`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-Name`, `-ResourceId`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``String`` to ``IEventSubscriptionFullUrl``
* Modified cmdlet `Get-AzEventGridFullUrlForSystemTopicEventSubscription`
   - `SupportsShouldProcess` changed from False to True
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-PassThru`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``String`` to ``IEventSubscriptionFullUrl``
* Modified cmdlet `Get-AzEventGridPartnerConfiguration`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-Filter`, `-PassThru`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSPartnerConfigurationListInstance``, ``PSPartnerConfiguration`` to ``IPartnerConfiguration``
* Modified cmdlet `Get-AzEventGridPartnerNamespace`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSPartnerNamespaceListInstance``, ``PSPartnerNamespace`` to ``IPartnerNamespace``
* Modified cmdlet `Get-AzEventGridPartnerNamespaceKey`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameter `-InputObject`
   - Added parameters `-SubscriptionId`, `-PassThru`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSPartnerNamespaceListInstance``, ``PSPartnerNamespace`` to ``IPartnerNamespaceSharedAccessKeys``
* Modified cmdlet `Get-AzEventGridPartnerRegistration`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSPartnerRegistrationListInstance``, ``PSPartnerRegistration`` to ``IPartnerRegistration``
* Modified cmdlet `Get-AzEventGridPartnerTopic`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSPartnerTopic``, ``PSSytemTopicListInstance`` to ``IPartnerTopic``
* Modified cmdlet `Get-AzEventGridPartnerTopicEventSubscription`
   - Removed parameters `-Name`, `-ResourceId`, `-IncludeFullEndpointUrl`, `-ODataQuery`, `-NextLink`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSEventSubscription``, ``PSEventSubscriptionListInstance`` to ``IEventSubscription``
* Modified cmdlet `Get-AzEventGridPartnerTopicEventSubscriptionDeliveryAttribute`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-Name`, `-ResourceId`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsDeliveryAttribute`` to ``IDeliveryAttributeListResult``
* Modified cmdlet `Get-AzEventGridSubscription`
   - Removed parameters `-EventSubscriptionName`, `-ResourceId`, `-DomainTopicName`, `-TopicTypeName`, `-Location`, `-DomainInputObject`, `-DomainTopicInputObject`, `-IncludeFullEndpointUrl`, `-ODataQuery`, `-NextLink`
   - Added parameters `-Name`, `-Scope`, `-ProviderNamespace`, `-ResourceName`, `-ResourceTypeName`, `-SubscriptionId`, `-Filter`, `-PassThru`
   - Added parameter alias `DomainTopicName` to parameter `-TopicName`
   - Changed the type of parameter `-InputObject` from `PSTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `Get-AzEventGridSystemTopic`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSSystemTopic``, ``PSSytemTopicListInstance`` to ``ISystemTopic``
* Modified cmdlet `Get-AzEventGridSystemTopicEventSubscription`
   - Removed parameters `-IncludeFullEndpointUrl`, `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-Filter`, `-PassThru`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSEventSubscription``, ``PSEventSubscriptionListInstance`` to ``IEventSubscription``
* Modified cmdlet `Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute`
   - `SupportsShouldProcess` changed from False to True
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-PassThru`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsDeliveryAttribute`` to ``IDeliveryAttributeListResult``
* Modified cmdlet `Get-AzEventGridTopic`
   - Removed parameters `-ResourceId`, `-ODataQuery`, `-NextLink`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Filter`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Top` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSTopic``, ``PSTopicListInstance`` to ``ITopic``
* Modified cmdlet `Get-AzEventGridTopicKey`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-Name`, `-InputObject`, `-ResourceId`
   - Added parameters `-TopicName`, `-SubscriptionId`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``TopicSharedAccessKeys`` to ``ITopicSharedAccessKeys``
* Modified cmdlet `Get-AzEventGridTopicType`
   - Removed parameter `-IncludeEventTypeData`
   - Added parameters `-InputObject`, `-PassThru`
   - Added parameter alias `TopicTypeName` to parameter `-Name`
   - Output type changed from ``PSTopicTypeInfoListInstance``, ``PSTopicTypeInfo`` to ``ITopicTypeInfo``
* Modified cmdlet `Get-AzEventGridVerifiedPartner`
   - Removed parameters `-ODataQuery`, `-NextLink`
   - Added parameters `-InputObject`, `-Filter`, `-PassThru`
   - Added parameter alias `VerifiedPartnerName` to parameter `-Name`
   - Output type changed from ``PSVerifiedPartnerListInstance``, ``PSVerifiedPartner`` to ``IVerifiedPartner``
* Modified cmdlet `Grant-AzEventGridPartnerConfiguration`
   - Removed parameters `-InputObject`, `-AuthorizationExpirationTime`
   - Added parameters `-SubscriptionId`, `-PartnerInfo`, `-AuthorizationExpirationTimeInUtc`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-PartnerRegistrationImmutableId` from `Nullable`1[System.Guid]` to `String`
   - Output type changed from ``PSPartnerConfiguration`` to ``IPartnerConfiguration``
* Modified cmdlet `New-AzEventGridChannel`
   - Removed parameters `-PartnerTopicSource`, `-PartnerTopicName`, `-EventTypeKind`, `-InlineEvent`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-PartnerNamespaceInputObject`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-PartnerDestinationInfoAzureSubscriptionId`, `-PartnerDestinationInfoEndpointServiceContext`, `-PartnerDestinationInfoName`, `-PartnerDestinationInfoResourceGroupName`, `-PartnerDestinationInfoResourceMoveChangeHistory`, `-PartnerTopicInfoAzureSubscriptionId`, `-PartnerTopicInfoName`, `-PartnerTopicInfoResourceGroupName`, `-PartnerTopicInfoSource`, `-ProvisioningState`, `-ReadinessState`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-ExpirationTimeIfNotActivatedUtc` from `Nullable`1[System.DateTime]` to `DateTime`
   - Output type changed from ``PSChannel`` to ``IChannel``
* Modified cmdlet `New-AzEventGridDomain`
   - Removed parameters `-InputMappingField`, `-InputMappingDefaultValue`, `-InboundIpRule`, `-IdentityType`, `-IdentityId`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-DataResidencyBoundary`, `-EnableSystemAssignedIdentity`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-InboundIPRule`, `-MinimumTlsVersionAllowed`, `-SkuName`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Location` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-InputSchema` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PublicNetworkAccess` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DisableLocalAuth` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-AutoCreateTopicWithFirstSubscription` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-AutoDeleteTopicWithLastSubscription` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSDomain`` to ``IDomain``
* Modified cmdlet `New-AzEventGridDomainKey`
   - Removed parameters `-Name`, `-DomainInputObject`, `-DomainResourceId`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-KeyName`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DomainName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsDomainSharedAccessKeys`` to ``IDomainSharedAccessKeys``
* Modified cmdlet `New-AzEventGridDomainTopic`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DomainName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSDomainTopic`` to ``IDomainTopic``
* Modified cmdlet `New-AzEventGridPartnerConfiguration`
   - Removed parameters `-MaxExpirationTimeInDays`, `-AuthorizedPartner`
   - Added parameters `-SubscriptionId`, `-Location`, `-PartnerAuthorizationAuthorizedPartnersList`, `-PartnerAuthorizationDefaultMaximumExpirationTimeInDay`, `-ProvisioningState`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSPartnerConfiguration`` to ``IPartnerConfiguration``
* Modified cmdlet `New-AzEventGridPartnerNamespace`
   - Removed parameters `-PrivateEndpointConnection`, `-InboundIpRule`, `-Endpoint`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-InboundIPRule`, `-MinimumTlsVersionAllowed`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Location` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-DisableLocalAuth` from `Nullable`1[System.Boolean]` to `SwitchParameter`
   - Output type changed from ``PSPartnerNamespace`` to ``IPartnerNamespace``
* Modified cmdlet `New-AzEventGridPartnerNamespaceKey`
   - Removed parameter `-Name`
   - Added parameters `-SubscriptionId`, `-KeyName`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerNamespace` to `IEventGridIdentity`
   - Output type changed from ``PSPartnerNamespace`` to ``IPartnerNamespaceSharedAccessKeys``
* Modified cmdlet `New-AzEventGridPartnerRegistration`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Location`, `-PartnerRegistrationImmutableId`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSPartnerRegistration`` to ``IPartnerRegistration``
* Modified cmdlet `New-AzEventGridPartnerTopic`
   - Removed parameters `-IdentityType`, `-IdentityId`, `-EventTypeKind`, `-InlineEvent`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-ActivationState`, `-EnableSystemAssignedIdentity`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Source` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Location` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-ExpirationTimeIfNotActivatedUtc` from `Nullable`1[System.DateTime]` to `DateTime`
   - Changed the type of parameter `-PartnerRegistrationImmutableId` from `Nullable`1[System.Guid]` to `String`
   - Output type changed from ``PSPartnerTopic`` to ``IPartnerTopic``
* Modified cmdlet `New-AzEventGridPartnerTopicEventSubscription`
   - Removed parameters `-Name`, `-AzureActiveDirectoryApplicationIdOrUri`, `-AzureActiveDirectoryTenantId`, `-DeadLetterEndpoint`, `-DeliveryAttributeMapping`, `-Endpoint`, `-EndpointType`, `-DeliverySchema`, `-EventTtl`, `-ExpirationDate`, `-MaxDeliveryAttempt`, `-MaxEventsPerBatch`, `-PreferredBatchSizeInKiloByte`, `-StorageQueueMessageTtl`, `-AdvancedFilter`, `-AdvancedFilteringOnArray`, `-IncludedEventType`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-SubjectCaseSensitive`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `New-AzEventGridSubscription`
   - Removed parameters `-ResourceId`, `-DomainInputObject`, `-DomainTopicInputObject`, `-EventSubscriptionName`, `-Endpoint`, `-ResourceGroupName`, `-TopicName`, `-DomainName`, `-DomainTopicName`, `-EndpointType`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-SubjectCaseSensitive`, `-IncludedEventType`, `-EventTtl`, `-MaxDeliveryAttempt`, `-DeliverySchema`, `-DeadLetterEndpoint`, `-ExpirationDate`, `-AdvancedFilter`, `-MaxEventsPerBatch`, `-PreferredBatchSizeInKiloByte`, `-AzureActiveDirectoryTenantId`, `-AzureActiveDirectoryApplicationIdOrUri`, `-AdvancedFilteringOnArray`, `-DeliveryAttributeMapping`, `-StorageQueueMessageTtl`
   - Added parameters `-Name`, `-Scope`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Changed the type of parameter `-InputObject` from `PSTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `New-AzEventGridSystemTopic`
   - Removed parameters `-IdentityType`, `-IdentityId`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-EnableSystemAssignedIdentity`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `SystemTopicName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Source` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-TopicType` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Location` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSSystemTopic`` to ``ISystemTopic``
* Modified cmdlet `New-AzEventGridSystemTopicEventSubscription`
   - Removed parameters `-AzureActiveDirectoryApplicationIdOrUri`, `-AzureActiveDirectoryTenantId`, `-DeadLetterEndpoint`, `-DeliveryAttributeMapping`, `-Endpoint`, `-EndpointType`, `-DeliverySchema`, `-EventTtl`, `-ExpirationDate`, `-MaxDeliveryAttempt`, `-MaxEventsPerBatch`, `-PreferredBatchSizeInKiloByte`, `-StorageQueueMessageTtl`, `-AdvancedFilter`, `-AdvancedFilteringOnArray`, `-IncludedEventType`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-SubjectCaseSensitive`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `New-AzEventGridTopic`
   - Removed parameters `-InputMappingField`, `-InputMappingDefaultValue`, `-InboundIpRule`, `-IdentityType`, `-IdentityId`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-DataResidencyBoundary`, `-DisableLocalAuth`, `-EnableSystemAssignedIdentity`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-ExtendedLocationName`, `-ExtendedLocationType`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-InboundIPRule`, `-Kind`, `-MinimumTlsVersionAllowed`, `-SkuName`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Location` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-InputSchema` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PublicNetworkAccess` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSTopic`` to ``ITopic``
* Modified cmdlet `New-AzEventGridTopicKey`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-TopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-KeyName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``TopicSharedAccessKeys`` to ``ITopicSharedAccessKeys``
* Modified cmdlet `Remove-AzEventGridChannel`
   - Removed parameter `-Force`
   - Added parameters `-SubscriptionId`, `-PartnerNamespaceInputObject`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSChannel` to `IEventGridIdentity`
* Modified cmdlet `Remove-AzEventGridDomain`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSDomain` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridDomainTopic`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-DomainInputObject`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `Domain` to parameter `-DomainName`
   - Parameter `-DomainName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSDomainTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridPartnerConfiguration`
   - Removed parameters `-InputObject`, `-Force`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridPartnerNamespace`
   - Removed parameter `-Force`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerNamespace` to `IEventGridIdentity`
* Modified cmdlet `Remove-AzEventGridPartnerRegistration`
   - Removed parameter `-Force`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerRegistration` to `IEventGridIdentity`
* Modified cmdlet `Remove-AzEventGridPartnerTopic`
   - Removed parameter `-Force`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerTopic` to `IEventGridIdentity`
* Modified cmdlet `Remove-AzEventGridPartnerTopicEventSubscription`
   - Removed parameters `-Name`, `-ResourceId`, `-Force`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridSubscription`
   - Removed parameters `-ResourceId`, `-DomainInputObject`, `-DomainTopicInputObject`, `-EventSubscriptionName`, `-ResourceGroupName`, `-TopicName`, `-DomainName`, `-DomainTopicName`
   - Added parameters `-Name`, `-Scope`, `-AsJob`, `-NoWait`
   - Changed the type of parameter `-InputObject` from `PSTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridSystemTopic`
   - Removed parameters `-ResourceId`, `-Force`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSSystemTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridSystemTopicEventSubscription`
   - Removed parameter `-Force`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-AsJob`, `-NoWait`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzEventGridTopic`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSTopic` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Revoke-AzEventGridPartnerConfiguration`
   - Removed parameters `-InputObject`, `-AuthorizationExpirationTime`
   - Added parameters `-SubscriptionId`, `-PartnerInfo`, `-AuthorizationExpirationTimeInUtc`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-PartnerRegistrationImmutableId` from `Nullable`1[System.Guid]` to `String`
   - Output type changed from ``PSPartnerConfiguration`` to ``IPartnerConfiguration``
* Removed cmdlet `Set-AzEventGridTopic`
* Modified cmdlet `Update-AzEventGridChannel`
   - Removed parameters `-EventTypeKind`, `-InlineEvent`
   - Added parameters `-SubscriptionId`, `-PartnerNamespaceInputObject`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-JsonFilePath`, `-JsonString`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerNamespaceName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSChannel` to `IEventGridIdentity`
   - Changed the type of parameter `-ExpirationTimeIfNotActivatedUtc` from `Nullable`1[System.DateTime]` to `DateTime`
   - Output type changed from ``PSChannel`` to ``IChannel``
* Modified cmdlet `Update-AzEventGridPartnerConfiguration`
   - Removed parameters `-InputObject`, `-MaxExpirationTimeInDays`
   - Added parameters `-SubscriptionId`, `-DefaultMaximumExpirationTimeInDay`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSPartnerConfiguration`` to ``IPartnerConfiguration``
* Modified cmdlet `Update-AzEventGridPartnerTopic`
   - Removed parameters `-IdentityType`, `-IdentityId`
   - Added parameters `-SubscriptionId`, `-ActivationState`, `-EnableSystemAssignedIdentity`, `-EventTypeInfoInlineEventType`, `-EventTypeInfoKind`, `-ExpirationTimeIfNotActivatedUtc`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-Location`, `-MessageForActivation`, `-PartnerRegistrationImmutableId`, `-PartnerTopicFriendlyDescription`, `-Source`, `-UserAssignedIdentity`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPartnerTopic` to `IEventGridIdentity`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSPartnerTopic`` to ``IPartnerTopic``
* Modified cmdlet `Update-AzEventGridPartnerTopicEventSubscription`
   - Removed parameters `-Name`, `-ResourceId`, `-DeadLetterEndpoint`, `-DeliveryAttributeMapping`, `-Endpoint`, `-EndpointType`, `-StorageQueueMessageTtl`, `-AdvancedFilter`, `-AdvancedFilteringOnArray`, `-IncludedEventType`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-SubjectCaseSensitive`
   - Added parameters `-EventSubscriptionName`, `-SubscriptionId`, `-InputObject`, `-PartnerTopicInputObject`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PartnerTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `Update-AzEventGridSubscription`
   - Removed parameters `-ResourceId`, `-EventSubscriptionName`, `-ResourceGroupName`, `-TopicName`, `-DomainName`, `-DomainTopicName`, `-EndpointType`, `-Endpoint`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-IncludedEventType`, `-ExpirationDate`, `-AdvancedFilter`, `-DeliveryAttributeMapping`, `-EventTtl`, `-MaxDeliveryAttempt`, `-DeadLetterEndpoint`, `-MaxEventsPerBatch`, `-PreferredBatchSizeInKiloByte`, `-AzureActiveDirectoryApplicationIdOrUri`, `-AzureActiveDirectoryTenantId`
   - Added parameters `-Name`, `-Scope`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Changed the type of parameter `-InputObject` from `PSEventSubscription` to `IEventGridIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Modified cmdlet `Update-AzEventGridSystemTopic`
   - Removed parameters `-IdentityType`, `-IdentityId`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-EnableSystemAssignedIdentity`, `-IdentityPrincipalId`, `-IdentityTenantId`, `-Location`, `-Source`, `-TopicType`, `-UserAssignedIdentity`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSSystemTopic`` to ``ISystemTopic``
* Modified cmdlet `Update-AzEventGridSystemTopicEventSubscription`
   - Removed parameters `-DeadLetterEndpoint`, `-DeliveryAttributeMapping`, `-Endpoint`, `-EndpointType`, `-StorageQueueMessageTtl`, `-AdvancedFilter`, `-AdvancedFilteringOnArray`, `-IncludedEventType`, `-SubjectBeginsWith`, `-SubjectEndsWith`, `-SubjectCaseSensitive`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-SystemTopicInputObject`, `-DeadLetterWithResourceIdentityType`, `-DeadLetterWithResourceIdentityUserAssignedIdentity`, `-DeliveryWithResourceIdentityDestination`, `-DeliveryWithResourceIdentityType`, `-DeliveryWithResourceIdentityUserAssignedIdentity`, `-Destination`, `-EventDeliverySchema`, `-ExpirationTimeUtc`, `-FilterAdvancedFilter`, `-FilterEnableAdvancedFilteringOnArray`, `-FilterIncludedEventType`, `-FilterIsSubjectCaseSensitive`, `-FilterSubjectBeginsWith`, `-FilterSubjectEndsWith`, `-RetryPolicyEventTimeToLiveInMinute`, `-RetryPolicyMaxDeliveryAttempt`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-EventSubscriptionName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `ResourceGroup` to parameter `-ResourceGroupName`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-SystemTopicName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Label` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSEventSubscription`` to ``IEventSubscription``
* Added cmdlet `Disable-AzEventGridPartnerTopic`, `Enable-AzEventGridPartnerDestination`, `Get-AzEventGridCaCertificate`, `Get-AzEventGridChannelFullUrl`, `Get-AzEventGridClient`, `Get-AzEventGridClientGroup`, `Get-AzEventGridDomainEventSubscription`, `Get-AzEventGridDomainEventSubscriptionDeliveryAttribute`, `Get-AzEventGridDomainEventSubscriptionFullUrl`, `Get-AzEventGridDomainTopicEventSubscription`, `Get-AzEventGridDomainTopicEventSubscriptionDeliveryAttribute`, `Get-AzEventGridDomainTopicEventSubscriptionFullUrl`, `Get-AzEventGridExtensionTopic`, `Get-AzEventGridNamespace`, `Get-AzEventGridNamespaceKey`, `Get-AzEventGridNamespaceTopic`, `Get-AzEventGridNamespaceTopicEventSubscription`, `Get-AzEventGridNamespaceTopicKey`, `Get-AzEventGridPartnerDestination`, `Get-AzEventGridPermissionBinding`, `Get-AzEventGridSubscriptionDeliveryAttribute`, `Get-AzEventGridSubscriptionFullUrl`, `Get-AzEventGridSubscriptionGlobal`, `Get-AzEventGridSubscriptionRegional`, `Get-AzEventGridTopicEventSubscription`, `Get-AzEventGridTopicEventSubscriptionDeliveryAttribute`, `Get-AzEventGridTopicEventSubscriptionFullUrl`, `Get-AzEventGridTopicEventType`, `Get-AzEventGridTopicSpace`, `Get-AzEventGridTopicTypeEventType`, `New-AzEventGridAdvancedFilterObject`, `New-AzEventGridAzureFunctionEventSubscriptionDestinationObject`, `New-AzEventGridCaCertificate`, `New-AzEventGridClient`, `New-AzEventGridClientGroup`, `New-AzEventGridDeliveryAttributeMappingObject`, `New-AzEventGridDomainEventSubscription`, `New-AzEventGridDomainTopicEventSubscription`, `New-AzEventGridDynamicRoutingEnrichmentObject`, `New-AzEventGridEventHubEventSubscriptionDestinationObject`, `New-AzEventGridFilterObject`, `New-AzEventGridHybridConnectionEventSubscriptionDestinationObject`, `New-AzEventGridInboundIPRuleObject`, `New-AzEventGridNamespace`, `New-AzEventGridNamespaceKey`, `New-AzEventGridNamespaceTopic`, `New-AzEventGridNamespaceTopicEventSubscription`, `New-AzEventGridNamespaceTopicKey`, `New-AzEventGridPartnerDestination`, `New-AzEventGridPartnerEventSubscriptionDestinationObject`, `New-AzEventGridPartnerObject`, `New-AzEventGridPermissionBinding`, `New-AzEventGridPrivateEndpointConnectionObject`, `New-AzEventGridResourceMoveChangeHistoryObject`, `New-AzEventGridServiceBusQueueEventSubscriptionDestinationObject`, `New-AzEventGridServiceBusTopicEventSubscriptionDestinationObject`, `New-AzEventGridStaticRoutingEnrichmentObject`, `New-AzEventGridStorageQueueEventSubscriptionDestinationObject`, `New-AzEventGridTopicEventSubscription`, `New-AzEventGridTopicSpace`, `New-AzEventGridWebHookEventSubscriptionDestinationObject`, `Remove-AzEventGridCaCertificate`, `Remove-AzEventGridClient`, `Remove-AzEventGridClientGroup`, `Remove-AzEventGridDomainEventSubscription`, `Remove-AzEventGridDomainTopicEventSubscription`, `Remove-AzEventGridNamespace`, `Remove-AzEventGridNamespaceTopic`, `Remove-AzEventGridNamespaceTopicEventSubscription`, `Remove-AzEventGridPartnerDestination`, `Remove-AzEventGridPermissionBinding`, `Remove-AzEventGridTopicEventSubscription`, `Remove-AzEventGridTopicSpace`, `Update-AzEventGridClient`, `Update-AzEventGridClientGroup`, `Update-AzEventGridDomain`, `Update-AzEventGridDomainEventSubscription`, `Update-AzEventGridDomainTopicEventSubscription`, `Update-AzEventGridNamespace`, `Update-AzEventGridNamespaceTopic`, `Update-AzEventGridNamespaceTopicEventSubscription`, `Update-AzEventGridPartnerDestination`, `Update-AzEventGridPartnerNamespace`, `Update-AzEventGridPermissionBinding`, `Update-AzEventGridTopic`, `Update-AzEventGridTopicEventSubscription`, `Update-AzEventGridTopicSpace`
#### Az.EventHub 5.0.0 
* Modified cmdlet `Get-AzEventHub`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzEventHubApplicationGroup`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzEventHubConsumerGroup`
   - Added parameters `-EventhubInputObject`, `-NamespaceInputObject`
* Modified cmdlet `Get-AzEventHubGeoDRConfiguration`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzEventHubPrivateEndpointConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzEventHubSchemaGroup`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `New-AzEventHub`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
   - Changed the type of parameter `-CleanupPolicy` from `CleanupPolicyRetentionDescription` to `String`
   - Changed the type of parameter `-Encoding` from `EncodingCaptureDescription` to `String`
   - Changed the type of parameter `-IdentityType` from `CaptureIdentityType` to `String`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `New-AzEventHubApplicationGroup`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
* Modified cmdlet `New-AzEventHubAuthorizationRule`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `New-AzEventHubConsumerGroup`
   - Added parameters `-EventhubInputObject`, `-NamespaceInputObject`, `-Parameter`
* Modified cmdlet `New-AzEventHubGeoDRConfiguration`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
* Modified cmdlet `New-AzEventHubIPRuleConfig`
   - Changed the type of parameter `-Action` from `NetworkRuleIPAction` to `String`
* Modified cmdlet `New-AzEventHubKey`
   - Changed the type of parameter `-KeyType` from `KeyType` to `String`
* Modified cmdlet `New-AzEventHubNamespace`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `New-AzEventHubSchemaGroup`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
   - Changed the type of parameter `-SchemaCompatibility` from `SchemaCompatibility` to `String`
   - Changed the type of parameter `-SchemaType` from `SchemaType` to `String`
* Modified cmdlet `New-AzEventHubThrottlingPolicyConfig`
   - Changed the type of parameter `-MetricId` from `MetricId` to `String`
* Modified cmdlet `Remove-AzEventHub`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzEventHubApplicationGroup`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzEventHubConsumerGroup`
   - Added parameters `-EventhubInputObject`, `-NamespaceInputObject`
* Modified cmdlet `Remove-AzEventHubGeoDRConfiguration`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzEventHubPrivateEndpointConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzEventHubSchemaGroup`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Set-AzEventHub`
   - Changed the type of parameter `-Encoding` from `EncodingCaptureDescription` to `String`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
* Modified cmdlet `Set-AzEventHubAuthorizationRule`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `Set-AzEventHubNamespace`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `Set-AzEventHubNetworkRuleSet`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-DefaultAction` from `DefaultAction` to `String`
#### Az.KeyVault 6.0.0 
* Modified cmdlet `Invoke-AzKeyVaultKeyOperation`
   - Removed parameter `-Value`
* Modified cmdlet `New-AzKeyVault`
   - Removed parameter `-EnableRbacAuthorization`
   - Added parameter `-DisableRbacAuthorization`
* Modified cmdlet `Update-AzKeyVault`
   - Removed parameter `-EnableRbacAuthorization`
   - Added parameter `-DisableRbacAuthorization`
#### Az.Network 7.6.0 
* Modified cmdlet `New-AzApplicationGatewayFirewallPolicySetting`
   - Added parameter `-JSChallengeCookieExpirationInMins`
* Modified cmdlet `New-AzApplicationGatewayRewriteRuleHeaderConfiguration`
   - Added parameter `-HeaderValueMatcher`
* Modified cmdlet `New-AzLoadBalancerBackendAddressConfig`
   - Added parameter `-AdminState`
* Modified cmdlet `New-AzNetworkVirtualAppliance`
   - Added parameter `-NetworkProfile`
* Added cmdlet `New-AzApplicationGatewayHeaderValueMatcher`, `New-AzVirtualApplianceInboundSecurityRulesProperty`, `New-AzVirtualApplianceIpConfiguration`, `New-AzVirtualApplianceNetworkInterfaceConfiguration`, `New-AzVirtualApplianceNetworkProfile`, `Update-AzVirtualApplianceInboundSecurityRule`
#### Az.Resources 7.1.0 
* Modified cmdlet `Get-AzPolicyAssignment`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-Filter`, `-BackwardCompatible`
   - Added parameter alias `PolicyAssignmentName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyAssignmentId` to parameter `-Id`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PolicyDefinitionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicyAssignment`` to ``IPolicyAssignment``
* Modified cmdlet `Get-AzPolicyDefinition`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-Filter`, `-Static`, `-BackwardCompatible`
   - Added parameter alias `PolicyDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicyDefinition`` to ``IPolicyDefinition``
* Modified cmdlet `Get-AzPolicyExemption`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-Filter`, `-BackwardCompatible`
   - Added parameter alias `PolicyExemptionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PolicyAssignmentIdFilter` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicyExemption`` to ``IPolicyExemption``
* Modified cmdlet `Get-AzPolicySetDefinition`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-Filter`, `-BackwardCompatible`
   - Added parameter alias `PolicySetDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicySetDefinition`` to ``IPolicySetDefinition``
* Modified cmdlet `New-AzManagementGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `New-AzPolicyAssignment`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-PolicySetDefinition`, `-AssignIdentity`, `-ApiVersion`, `-Pre`
   - Added parameter `-BackwardCompatible`
   - Added parameter alias `PolicyAssignmentName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-NotScope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DisplayName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Description` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicySetDefinition` to parameter `-PolicyDefinition`
   - Changed the type of parameter `-PolicyDefinition` from `PsPolicyDefinition` to `PSObject`
   - Parameter `-PolicyParameter` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Metadata` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-EnforcementMode` from `Nullable`1[Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy.PolicyAssignmentEnforcementMode]` to `String`
   - Parameter `-EnforcementMode` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-IdentityType` from `Nullable`1[Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources.ManagedIdentityType]` to `String`
   - Changed the type of parameter `-NonComplianceMessage` from `PsNonComplianceMessage[]` to `PSObject[]`
   - Output type changed from ``PsPolicyAssignment`` to ``IPolicyAssignment``
* Modified cmdlet `New-AzPolicyDefinition`
   - `SupportsShouldProcess` changed from False to True
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-BackwardCompatible`
   - Added parameter alias `PolicyDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DisplayName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Description` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Policy` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Metadata` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Parameter` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Mode` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicyDefinition`` to ``IPolicyDefinition``
* Modified cmdlet `New-AzPolicyExemption`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-AssignmentScopeValidation`, `-BackwardCompatible`
   - Added parameter alias `PolicyExemptionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DisplayName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Description` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-PolicyAssignment` from `PsPolicyAssignment` to `PSObject`
   - Parameter `-PolicyDefinitionReferenceId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Metadata` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicyExemption`` to ``IPolicyExemption``
* Modified cmdlet `New-AzPolicySetDefinition`
   - Removed parameters `-GroupDefinition`, `-ApiVersion`, `-Pre`
   - Added parameters `-InputObject`, `-PolicyDefinitionGroup`, `-BackwardCompatible`
   - Added parameter alias `PolicySetDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-DisplayName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Description` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Metadata` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-PolicyDefinition` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Parameter` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PsPolicySetDefinition`` to ``IPolicySetDefinition``
* Modified cmdlet `New-AzResourceGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `New-AzSubscriptionDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `Remove-AzManagementGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `Remove-AzPolicyAssignment`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-Force`, `-BackwardCompatible`, `-PassThru`
   - Added parameter alias `PolicyAssignmentName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyAssignmentId` to parameter `-Id`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PsPolicyAssignment` to `IPolicyIdentity`
* Modified cmdlet `Remove-AzPolicyDefinition`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-BackwardCompatible`, `-PassThru`
   - Added parameter alias `PolicyDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PsPolicyDefinition` to `IPolicyIdentity`
* Modified cmdlet `Remove-AzPolicyExemption`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-BackwardCompatible`, `-PassThru`
   - Added parameter alias `PolicyExemptionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Scope` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyExemptionId` to parameter `-Id`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PsPolicyExemption` to `IPolicyIdentity`
* Modified cmdlet `Remove-AzPolicySetDefinition`
   - Removed parameters `-ApiVersion`, `-Pre`
   - Added parameters `-BackwardCompatible`, `-PassThru`
   - Added parameter alias `PolicySetDefinitionName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Id` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ManagementGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SubscriptionId` from `Nullable`1[System.Guid]` to `String`
   - Parameter `-SubscriptionId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PsPolicySetDefinition` to `IPolicyIdentity`
* Modified cmdlet `Remove-AzResourceGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `Remove-AzSubscriptionDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `Set-AzManagementGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Removed cmdlet `Set-AzPolicyAssignment`, `Set-AzPolicyDefinition`, `Set-AzPolicyExemption`, `Set-AzPolicySetDefinition`
* Modified cmdlet `Set-AzResourceGroupDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Modified cmdlet `Set-AzSubscriptionDeploymentStack`
   - Removed parameters `-DeleteAll`, `-DeleteResources`, `-DeleteResourceGroups`
   - Added parameters `-ActionOnUnmanage`, `-BypassStackOutOfSyncError`
* Added cmdlet `Update-AzPolicyAssignment`, `Update-AzPolicyDefinition`, `Update-AzPolicyExemption`, `Update-AzPolicySetDefinition`
#### Az.ServiceBus 4.0.0 
* Modified cmdlet `Get-AzServiceBusGeoDRConfiguration`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzServiceBusPrivateEndpointConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzServiceBusQueue`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzServiceBusRule`
   - Added parameters `-NamespaceInputObject`, `-SubscriptionInputObject`, `-TopicInputObject`
* Modified cmdlet `Get-AzServiceBusSubscription`
   - Added parameters `-NamespaceInputObject`, `-TopicInputObject`
* Modified cmdlet `Get-AzServiceBusTopic`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `New-AzServiceBusAuthorizationRule`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `New-AzServiceBusGeoDRConfiguration`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
* Modified cmdlet `New-AzServiceBusIPRuleConfig`
   - Changed the type of parameter `-Action` from `NetworkRuleIPAction` to `String`
* Modified cmdlet `New-AzServiceBusKey`
   - Changed the type of parameter `-KeyType` from `KeyType` to `String`
* Modified cmdlet `New-AzServiceBusNamespace`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
* Modified cmdlet `New-AzServiceBusQueue`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `New-AzServiceBusRule`
   - Added parameters `-NamespaceInputObject`, `-SubscriptionInputObject`, `-TopicInputObject`, `-Parameter`
   - Changed the type of parameter `-FilterType` from `FilterType` to `String`
* Modified cmdlet `New-AzServiceBusSubscription`
   - Added parameters `-NamespaceInputObject`, `-TopicInputObject`, `-Parameter`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `New-AzServiceBusTopic`
   - Added parameters `-NamespaceInputObject`, `-Parameter`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `Remove-AzServiceBusGeoDRConfiguration`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzServiceBusPrivateEndpointConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzServiceBusQueue`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzServiceBusRule`
   - Added parameters `-NamespaceInputObject`, `-SubscriptionInputObject`, `-TopicInputObject`
* Modified cmdlet `Remove-AzServiceBusSubscription`
   - Added parameters `-NamespaceInputObject`, `-TopicInputObject`
* Modified cmdlet `Remove-AzServiceBusTopic`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Set-AzServiceBusAuthorizationRule`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `Set-AzServiceBusNamespace`
   - Changed the type of parameter `-IdentityType` from `ManagedServiceIdentityType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-SkuName` from `SkuName` to `String`
* Modified cmdlet `Set-AzServiceBusNetworkRuleSet`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-DefaultAction` from `DefaultAction` to `String`
* Modified cmdlet `Set-AzServiceBusQueue`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `Set-AzServiceBusRule`
   - Changed the type of parameter `-FilterType` from `FilterType` to `String`
* Modified cmdlet `Set-AzServiceBusSubscription`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
* Modified cmdlet `Set-AzServiceBusTopic`
   - Changed the type of parameter `-Status` from `EntityStatus` to `String`
#### Az.Sql 5.0.0 
* Modified cmdlet `Set-AzSqlDatabase`
   - Added parameters `-ManualCutover`, `-PerformCutover`
#### Az.Storage 7.0.0 
* Modified cmdlet `New-AzStorageQueueSASToken`
   - Changed the type of parameter `-Protocol` from `Nullable`1[Microsoft.Azure.Storage.SharedAccessProtocol]` to `String`
#### Az.Support 2.0.0 
* Modified cmdlet `Get-AzSupportProblemClassification`
   - Removed parameters `-ServiceId`, `-Id`, `-ServiceObject`
   - Added parameters `-Name`, `-ServiceName`, `-InputObject`, `-ServiceInputObject`
   - Output type changed from ``PSSupportProblemClassification`` to ``IProblemClassification``
* Modified cmdlet `Get-AzSupportService`
   - Removed parameter `-Id`
   - Added parameters `-Name`, `-InputObject`
   - Output type changed from ``PSSupportService`` to ``IService``
* Modified cmdlet `Get-AzSupportTicket`
   - Removed parameters `-IncludeTotalCount`, `-Skip`, `-First`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-Top`
   - Added parameter alias `SupportTicketName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Filter` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSSupportTicket`` to ``ISupportTicketDetails``
* Removed cmdlet `Get-AzSupportTicketCommunication`, `New-AzSupportContactProfileObject`
* Modified cmdlet `New-AzSupportTicket`
   - Removed parameters `-CustomerContactDetail`, `-CustomerFirstName`, `-CustomerLastName`, `-PreferredContactMethod`, `-CustomerPrimaryEmailAddress`, `-AdditionalEmailAddress`, `-CustomerPhoneNumber`, `-CustomerPreferredTimeZone`, `-CustomerCountry`, `-CustomerPreferredSupportLanguage`, `-TechnicalTicketResourceId`, `-QuotaTicketDetail`, `-CSPHomeTenantId`
   - Added parameters `-SubscriptionId`, `-AdvancedDiagnosticConsent`, `-ContactDetailCountry`, `-ContactDetailFirstName`, `-ContactDetailLastName`, `-ContactDetailPreferredContactMethod`, `-ContactDetailPreferredSupportLanguage`, `-ContactDetailPreferredTimeZone`, `-ContactDetailPrimaryEmailAddress`, `-ServiceId`, `-ContactDetailAdditionalEmailAddress`, `-ContactDetailPhoneNumber`, `-EnrollmentId`, `-FileWorkspaceName`, `-ProblemScopingQuestion`, `-QuotaTicketDetailQuotaChangeRequest`, `-QuotaTicketDetailQuotaChangeRequestSubType`, `-QuotaTicketDetailQuotaChangeRequestVersion`, `-SecondaryConsent`, `-SupportPlanId`, `-SupportTicketId`, `-TechnicalTicketDetailResourceId`, `-NoWait`
   - Added parameter alias `SupportTicketName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Title` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Description` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ProblemClassificationId` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Severity` from `Severity` to `String`
   - Output type changed from ``PSSupportTicket`` to ``ISupportTicketDetails``
* Removed cmdlet `New-AzSupportTicketCommunication`
* Modified cmdlet `Update-AzSupportTicket`
   - Removed parameters `-CustomerContactDetail`, `-CustomerFirstName`, `-CustomerLastName`, `-PreferredContactMethod`, `-CustomerPrimaryEmailAddress`, `-AdditionalEmailAddress`, `-CustomerPhoneNumber`, `-CustomerPreferredTimeZone`, `-CustomerCountry`, `-CustomerPreferredSupportLanguage`
   - Added parameters `-SubscriptionId`, `-AdvancedDiagnosticConsent`, `-ContactDetailAdditionalEmailAddress`, `-ContactDetailCountry`, `-ContactDetailFirstName`, `-ContactDetailLastName`, `-ContactDetailPhoneNumber`, `-ContactDetailPreferredContactMethod`, `-ContactDetailPreferredSupportLanguage`, `-ContactDetailPreferredTimeZone`, `-ContactDetailPrimaryEmailAddress`, `-SecondaryConsent`
   - Added parameter alias `SupportTicketName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSSupportTicket` to `ISupportIdentity`
   - Changed the type of parameter `-Severity` from `Severity` to `String`
   - Changed the type of parameter `-Status` from `Status` to `String`
   - Output type changed from ``PSSupportTicket`` to ``ISupportTicketDetails``
* Added cmdlet `Get-AzSupportChatTranscript`, `Get-AzSupportChatTranscriptsNoSubscription`, `Get-AzSupportCommunication`, `Get-AzSupportCommunicationsNoSubscription`, `Get-AzSupportFile`, `Get-AzSupportFilesNoSubscription`, `Get-AzSupportFileWorkspace`, `Get-AzSupportFileWorkspacesNoSubscription`, `Get-AzSupportOperation`, `Get-AzSupportTicketsNoSubscription`, `New-AzSupportCommunication`, `New-AzSupportCommunicationsNoSubscription`, `New-AzSupportFileAndUpload`, `New-AzSupportFileAndUploadNoSubscription`, `New-AzSupportFileWorkspace`, `New-AzSupportFileWorkspacesNoSubscription`, `New-AzSupportTicketsNoSubscription`, `Test-AzSupportCommunicationNameAvailability`, `Test-AzSupportCommunicationsNoSubscriptionNameAvailability`, `Test-AzSupportTicketNameAvailability`, `Test-AzSupportTicketsNoSubscriptionNameAvailability`, `Update-AzSupportTicketsNoSubscription`


