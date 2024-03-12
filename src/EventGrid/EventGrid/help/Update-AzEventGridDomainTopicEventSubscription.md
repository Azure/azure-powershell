---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgriddomaintopiceventsubscription
schema: 2.0.0
---

# Update-AzEventGridDomainTopicEventSubscription

## SYNOPSIS
Update an existing event subscription for a domain topic.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridDomainTopicEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String>
 [-DeadLetterWithResourceIdentityType <String>] [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzEventGridDomainTopicEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEventGridDomainTopicEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityTopicExpanded
```
Update-AzEventGridDomainTopicEventSubscription -EventSubscriptionName <String>
 -TopicInputObject <IEventGridIdentity> [-DeadLetterWithResourceIdentityType <String>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityDomainExpanded
```
Update-AzEventGridDomainTopicEventSubscription -EventSubscriptionName <String> -TopicName <String>
 -DomainInputObject <IEventGridIdentity> [-DeadLetterWithResourceIdentityType <String>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridDomainTopicEventSubscription -InputObject <IEventGridIdentity>
 [-DeadLetterWithResourceIdentityType <String>] [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-PassThru]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an existing event subscription for a domain topic.

## EXAMPLES

### EXAMPLE 1
```
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -EventSubscriptionName azps-eventsubname -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterWithResourceIdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterWithResourceIdentityUserAssignedIdentity
The user identity associated with the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryWithResourceIdentityDestination
Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryWithResourceIdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryWithResourceIdentityUserAssignedIdentity
The user identity associated with the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityDomainExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DomainName
Name of the domain.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventDeliverySchema
The event delivery schema for the event subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSubscriptionName
Name of the event subscription to be updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTimeUtc
Information about the expiration time for the event subscription.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAdvancedFilter
An array of advanced filters that are used for filtering event subscriptions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IAdvancedFilter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterEnableAdvancedFilteringOnArray
Allows advanced filters to be evaluated against an array of values instead of expecting a singular value.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterIncludedEventType
A list of applicable event types that need to be part of the event subscription.
If it is desired to subscribe to all default event types, set the IncludedEventTypes to null.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterIsSubjectCaseSensitive
Specifies if the SubjectBeginsWith and SubjectEndsWith properties of the filtershould be compared in a case sensitive manner.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSubjectBeginsWith
An optional string to filter events for an event subscription based on a resource path prefix.The format of this depends on the publisher of the events.Wildcard characters are not supported in this path.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSubjectEndsWith
An optional string to filter events for an event subscription based on a resource path suffix.Wildcard characters are not supported in this path.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
List of user defined labels.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyEventTimeToLiveInMinute
Time To Live (in minutes) for events.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyMaxDeliveryAttempt
Maximum number of delivery retry attempts for events.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityTopicExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TopicName
Name of the topic.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityDomainExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscription
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

DELIVERYWITHRESOURCEIDENTITYDESTINATION \<IEventSubscriptionDestination\>: Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.
  EndpointType \<String\>: Type of the endpoint for the event subscription destination.

DESTINATION \<IEventSubscriptionDestination\>: Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.
  EndpointType \<String\>: Type of the endpoint for the event subscription destination.

DOMAININPUTOBJECT \<IEventGridIdentity\>: Identity Parameter
  \[CaCertificateName \<String\>\]: Name of the CA certificate.
  \[ChannelName \<String\>\]: Name of the channel.
  \[ClientGroupName \<String\>\]: Name of the client group.
  \[ClientName \<String\>\]: Name of the client.
  \[DomainName \<String\>\]: Name of the domain.
  \[DomainTopicName \<String\>\]: Name of the topic.
  \[EventSubscriptionName \<String\>\]: Name of the event subscription.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Name of the location.
  \[NamespaceName \<String\>\]: Name of the namespace.
  \[ParentName \<String\>\]: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name or namespace name).
  \[ParentType \<String\>\]: The type of the parent resource.
This can be either \'topics\', \'domains\', or \'partnerNamespaces\' or \'namespaces\'.
  \[PartnerDestinationName \<String\>\]: Name of the partner destination.
  \[PartnerNamespaceName \<String\>\]: Name of the partner namespace.
  \[PartnerRegistrationName \<String\>\]: Name of the partner registration.
  \[PartnerTopicName \<String\>\]: Name of the partner topic.
  \[PermissionBindingName \<String\>\]: Name of the permission binding.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection connection.
  \[PrivateLinkResourceName \<String\>\]: The name of private link resource will be either topic, domain, partnerNamespace or namespace.
  \[ProviderNamespace \<String\>\]: Namespace of the provider of the topic.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
  \[ResourceName \<String\>\]: Name of the resource.
  \[ResourceTypeName \<String\>\]: Name of the resource type.
  \[Scope \<String\>\]: The scope of the event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  \[SubscriptionId \<String\>\]: Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.
  \[SystemTopicName \<String\>\]: Name of the system topic.
  \[TopicName \<String\>\]: Name of the domain topic.
  \[TopicSpaceName \<String\>\]: Name of the Topic space.
  \[TopicTypeName \<String\>\]: Name of the topic type.
  \[VerifiedPartnerName \<String\>\]: Name of the verified partner.

FILTERADVANCEDFILTER \<IAdvancedFilter\[\]\>: An array of advanced filters that are used for filtering event subscriptions.
  OperatorType \<String\>: The operator type used for filtering, e.g., NumberIn, StringContains, BoolEquals and others.
  \[Key \<String\>\]: The field/property in the event based on which you want to filter.

INPUTOBJECT \<IEventGridIdentity\>: Identity Parameter
  \[CaCertificateName \<String\>\]: Name of the CA certificate.
  \[ChannelName \<String\>\]: Name of the channel.
  \[ClientGroupName \<String\>\]: Name of the client group.
  \[ClientName \<String\>\]: Name of the client.
  \[DomainName \<String\>\]: Name of the domain.
  \[DomainTopicName \<String\>\]: Name of the topic.
  \[EventSubscriptionName \<String\>\]: Name of the event subscription.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Name of the location.
  \[NamespaceName \<String\>\]: Name of the namespace.
  \[ParentName \<String\>\]: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name or namespace name).
  \[ParentType \<String\>\]: The type of the parent resource.
This can be either \'topics\', \'domains\', or \'partnerNamespaces\' or \'namespaces\'.
  \[PartnerDestinationName \<String\>\]: Name of the partner destination.
  \[PartnerNamespaceName \<String\>\]: Name of the partner namespace.
  \[PartnerRegistrationName \<String\>\]: Name of the partner registration.
  \[PartnerTopicName \<String\>\]: Name of the partner topic.
  \[PermissionBindingName \<String\>\]: Name of the permission binding.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection connection.
  \[PrivateLinkResourceName \<String\>\]: The name of private link resource will be either topic, domain, partnerNamespace or namespace.
  \[ProviderNamespace \<String\>\]: Namespace of the provider of the topic.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
  \[ResourceName \<String\>\]: Name of the resource.
  \[ResourceTypeName \<String\>\]: Name of the resource type.
  \[Scope \<String\>\]: The scope of the event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  \[SubscriptionId \<String\>\]: Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.
  \[SystemTopicName \<String\>\]: Name of the system topic.
  \[TopicName \<String\>\]: Name of the domain topic.
  \[TopicSpaceName \<String\>\]: Name of the Topic space.
  \[TopicTypeName \<String\>\]: Name of the topic type.
  \[VerifiedPartnerName \<String\>\]: Name of the verified partner.

TOPICINPUTOBJECT \<IEventGridIdentity\>: Identity Parameter
  \[CaCertificateName \<String\>\]: Name of the CA certificate.
  \[ChannelName \<String\>\]: Name of the channel.
  \[ClientGroupName \<String\>\]: Name of the client group.
  \[ClientName \<String\>\]: Name of the client.
  \[DomainName \<String\>\]: Name of the domain.
  \[DomainTopicName \<String\>\]: Name of the topic.
  \[EventSubscriptionName \<String\>\]: Name of the event subscription.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Name of the location.
  \[NamespaceName \<String\>\]: Name of the namespace.
  \[ParentName \<String\>\]: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name or namespace name).
  \[ParentType \<String\>\]: The type of the parent resource.
This can be either \'topics\', \'domains\', or \'partnerNamespaces\' or \'namespaces\'.
  \[PartnerDestinationName \<String\>\]: Name of the partner destination.
  \[PartnerNamespaceName \<String\>\]: Name of the partner namespace.
  \[PartnerRegistrationName \<String\>\]: Name of the partner registration.
  \[PartnerTopicName \<String\>\]: Name of the partner topic.
  \[PermissionBindingName \<String\>\]: Name of the permission binding.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection connection.
  \[PrivateLinkResourceName \<String\>\]: The name of private link resource will be either topic, domain, partnerNamespace or namespace.
  \[ProviderNamespace \<String\>\]: Namespace of the provider of the topic.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
  \[ResourceName \<String\>\]: Name of the resource.
  \[ResourceTypeName \<String\>\]: Name of the resource type.
  \[Scope \<String\>\]: The scope of the event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  \[SubscriptionId \<String\>\]: Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.
  \[SystemTopicName \<String\>\]: Name of the system topic.
  \[TopicName \<String\>\]: Name of the domain topic.
  \[TopicSpaceName \<String\>\]: Name of the Topic space.
  \[TopicTypeName \<String\>\]: Name of the topic type.
  \[VerifiedPartnerName \<String\>\]: Name of the verified partner.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgriddomaintopiceventsubscription](https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgriddomaintopiceventsubscription)

