---
external help file:
Module Name: Az.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventgrid/update-azeventgriddomaintopiceventsubscription
schema: 2.0.0
---

# Update-AzEventGridDomainTopicEventSubscription

## SYNOPSIS
Update an existing event subscription for a domain topic.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridDomainTopicEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> -TopicName <String> [-SubscriptionId <String>]
 [-DeadLetterWithResourceIdentityType <EventSubscriptionIdentityType>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestinationEndpointType <EndpointType>]
 [-DeliveryWithResourceIdentityType <EventSubscriptionIdentityType>]
 [-DeliveryWithResourceIdentityUserAssignedIdentity <String>] [-EndpointType <EndpointType>]
 [-EventDeliverySchema <EventDeliverySchema>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridDomainTopicEventSubscription -InputObject <IEventGridIdentity>
 [-DeadLetterWithResourceIdentityType <EventSubscriptionIdentityType>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestinationEndpointType <EndpointType>]
 [-DeliveryWithResourceIdentityType <EventSubscriptionIdentityType>]
 [-DeliveryWithResourceIdentityUserAssignedIdentity <String>] [-EndpointType <EndpointType>]
 [-EventDeliverySchema <EventDeliverySchema>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing event subscription for a domain topic.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterWithResourceIdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EventSubscriptionIdentityType
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeliveryWithResourceIdentityDestinationEndpointType
Type of the endpoint for the event subscription destination.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EndpointType
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EventSubscriptionIdentityType
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainName
Name of the domain.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointType
Type of the endpoint for the event subscription destination.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EndpointType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventDeliverySchema
The event delivery schema for the event subscription.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Support.EventDeliverySchema
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAdvancedFilter
An array of advanced filters that are used for filtering event subscriptions.
To construct, see NOTES section for FILTERADVANCEDFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Api20211015Preview.IAdvancedFilter[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterIncludedEventType
A list of applicable event types that need to be part of the event subscription.
If it is desired to subscribe to all default event types, set the IncludedEventTypes to null.

```yaml
Type: System.String[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSubjectBeginsWith
An optional string to filter events for an event subscription based on a resource path prefix.The format of this depends on the publisher of the events.Wildcard characters are not supported in this path.

```yaml
Type: System.String
Parameter Sets: (All)
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -Label
List of user defined labels.

```yaml
Type: System.String[]
Parameter Sets: (All)
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyMaxDeliveryAttempt
Maximum number of delivery retry attempts for events.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicName
Name of the topic.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FILTERADVANCEDFILTER <IAdvancedFilter[]>: An array of advanced filters that are used for filtering event subscriptions.
  - `OperatorType <AdvancedFilterOperatorType>`: The operator type used for filtering, e.g., NumberIn, StringContains, BoolEquals and others.
  - `[Key <String>]`: The field/property in the event based on which you want to filter.

INPUTOBJECT <IEventGridIdentity>: Identity Parameter
  - `[ChannelName <String>]`: Name of the channel.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainTopicName <String>]`: Name of the topic.
  - `[EventChannelName <String>]`: Name of the event channel.
  - `[EventSubscriptionName <String>]`: Name of the event subscription.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Name of the location.
  - `[ParentName <String>]`: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name).
  - `[ParentType <ParentType?>]`: The type of the parent resource. This can be either \'topics\', \'domains\', or \'partnerNamespaces\'.
  - `[PartnerDestinationName <String>]`: Name of the partner destination.
  - `[PartnerNamespaceName <String>]`: Name of the partner namespace.
  - `[PartnerRegistrationName <String>]`: Name of the partner registration.
  - `[PartnerTopicName <String>]`: Name of the partner topic.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection connection.
  - `[PrivateLinkResourceName <String>]`: The name of private link resource.
  - `[ProviderNamespace <String>]`: Namespace of the provider of the topic.
  - `[ResourceGroupName <String>]`: The name of the resource group within the partners subscription.
  - `[ResourceName <String>]`: Name of the resource.
  - `[ResourceTypeName <String>]`: Name of the resource type.
  - `[Scope <String>]`: The scope of the event subscription. The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic. For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SystemTopicName <String>]`: Name of the system topic.
  - `[TopicName <String>]`: Name of the domain topic.
  - `[TopicTypeName <String>]`: Name of the topic type.
  - `[VerifiedPartnerName <String>]`: Name of the verified partner.

## RELATED LINKS

