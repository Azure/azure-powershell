---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridSystemTopicEventSubscription

## SYNOPSIS
Creates a new Azure Event Grid Event Subscription to a System topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
New-AzEventGridSystemTopicEventSubscription [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SystemTopicEventSuscriptionParameterSet
```
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 -SystemTopicName <String> [-AzureActiveDirectoryApplicationIdOrUri <String>]
 [-AzureActiveDirectoryTenantId <String>] [-DeadLetterEndpoint <String>] [-DeliveryAttributeMapping <String[]>]
 [-Endpoint <String>] [-EndpointType <String>] [-DeliverySchema <String>] [-EventTtl <Int32>]
 [-ExpirationDate <DateTime>] [-Label <String[]>] [-MaxDeliveryAttempt <Int32>] [-MaxEventsPerBatch <Int32>]
 [-PreferredBatchSizeInKiloByte <Int32>] [-StorageQueueMessageTtl <Int64>] [-AdvancedFilter <Hashtable[]>]
 [-AdvancedFilteringOnArray] [-IncludedEventType <String[]>] [-SubjectBeginsWith <String>]
 [-SubjectEndsWith <String>] [-SubjectCaseSensitive] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new event subscription to an Azure Event Grid System topic.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridSystemTopicEventSubscription -ResourceGroup MyResourceGroup -SystemTopicName Topic1 -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName EventSubscription1
```

Creates a new event subscription \`EventSubscription1\` to an Azure Event Grid System topic \`Topic1\` in resource group \`MyResourceGroupName\` with the webhook destination endpoint `https://requestb.in/19qlscd1`. This event subscription uses default filters.

### Example 2
```powershell
$includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
$labels = "Finance", "HR"
New-AzEventGridSystemTopicEventSubscription -ResourceGroup MyResourceGroup -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1 -Endpoint https://requestb.in/19qlscd1  -SubjectBeginsWith "TestPrefix" -SubjectEndsWith "TestSuffix" -IncludedEventType $includedEventTypes -Label $labels
```

Creates a new event subscription \`EventSubscription1\` to Sytem Topic \`Topic1\` in  resource group \`MyResourceGroup\` with the webhook destination endpoint `https://requestb.in/19qlscd1`. This event subscription specifies the additional filters for event types and subject, and only events matching those filters will be delivered to the destination endpoint.

### Example 3
```powershell
New-AzEventGridSystemTopicEventSubscription -ResourceGroup MyResourceGroup -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1 -EndpointType "eventhub" -Endpoint "/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/TestRG/providers/Microsoft.EventHub/namespaces/ContosoNamespace/eventhubs/EH1"
```

Creates a new event subscription \`EventSubscription1\` to Sytem Topic \`Topic1\` in  resource group \`MyResourceGroup\` with the specified event hub as the destination for events. This event subscription uses default filters.

## PARAMETERS

### -AdvancedFilter
Advanced filter that specifies an array of multiple Hashtable values that are used for the attribute-based filtering.
Each Hashtable value has the following keys-value info: Operation, Key and Value or Values.
Operator can be one of the following values: NumberIn, NumberNotIn, NumberLessThan, NumberGreaterThan, NumberLessThanOrEquals, NumberGreaterThanOrEquals, BoolEquals, StringIn, StringNotIn, StringBeginsWith, StringEndsWith or StringContains.
Key represents the payload property where the advanced filtering policies are applied.
Finally, Value or Values represent the value or set of values to be matched.
This can be a single value of the corresponding type or an array of values.
As an example of the advanced filter parameters: $AdvancedFilters=@($AdvFilter1, $AdvFilter2) where $AdvFilter1=@{operator="NumberIn"; key="Data.Key1"; Values=@(1,2)} and $AdvFilter2=@{operator="StringBringsWith"; key="Subject"; Values=@("SubjectPrefix1","SubjectPrefix2")}

```yaml
Type: System.Collections.Hashtable[]
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdvancedFilteringOnArray
The presence of this parameter denotes that advanced filtering on arrays is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureActiveDirectoryApplicationIdOrUri
The Azure Active Directory (AAD) Application Id or Uri to get the access token that will be included as the bearer token in delivery requests.Applicable only for webhook as a destination.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureActiveDirectoryTenantId
The Azure Active Directory (AAD) Tenant Id to get the access token that will be included as the bearer token in delivery requests.Applicable only for webhook as a destination.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DeadLetterEndpoint
The endpoint used for storing undelivered events.
Specify the Azure resource ID of a Storage blob container.
For example: /subscriptions/\[SubscriptionId\]/resourceGroups/\[ResourceGroupName\]/providers/Microsoft.Storage/storageAccounts/\[StorageAccountName\]/blobServices/default/containers/\[ContainerName\].

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryAttributeMapping
The delivery attribute mappings for this system topic event subscription

```yaml
Type: System.String[]
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DeliverySchema
The schema to be used when delivering events to the destination.
The possible values are: eventgridschema, CustomInputSchema, or cloudeventv01schema.
Default value is CustomInputSchema.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Endpoint
Event subscription destination endpoint.
This can be a webhook URL, or the Azure resource ID of an EventHub, storage queue, hybridconnection, servicebusqueue, servicebustopic or azurefunction.
For example, the resource ID for a hybrid connection takes the following form: /subscriptions/\[Azure Subscription ID\]/resourceGroups/\[ResourceGroupName\]/providers/Microsoft.Relay/namespaces/\[NamespaceName\]/hybridConnections/\[HybridConnectionName\].
It is expected that the destination endpoint to be created and available for use before executing any Event Grid cmdlets.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndpointType
Endpoint Type.
This can be webhook, eventhub, storagequeue, hybridconnection, servicebusqueue, servicebustopic or azurefunction.
Default value is webhook.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventSubscriptionName
EventGrid event subscription name.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventTtl
The time in minutes for the event delivery.
This value must be between 1 and 1440

```yaml
Type: System.Int32
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpirationDate
Determines the expiration DateTime for the event subscription after which event subscription will retire.

```yaml
Type: System.DateTime
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludedEventType
Filter that specifies a list of event types to include.
If not specified, all event types (for the custom topics and domains) or default event types (for other topic types) will be included.

```yaml
Type: System.String[]
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Label
Labels for the event subscription.

```yaml
Type: System.String[]
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxDeliveryAttempt
The maximum number of attempts to deliver the event.
This value must be between 1 and 30.

```yaml
Type: System.Int32
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxEventsPerBatch
The maximum number of events in a batch.
This value must be between 1 and 5000.
This parameter is valid when Endpint Type is webhook only.

```yaml
Type: System.Int32
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PreferredBatchSizeInKiloByte
The preferred batch size in kilobytes.
This value must be between 1 and 1024.
This parameter is valid when Endpint Type is webhook only.

```yaml
Type: System.Int32
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageQueueMessageTtl
The time in milliseconds for time to live of a storage queue message

```yaml
Type: System.Int64
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubjectBeginsWith
Filter that specifies that only events matching the specified subject prefix will be included.
If not specified, events with all subject prefixes will be included.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubjectCaseSensitive
Filter that specifies that the subject field should be compared in a case sensitive manner.
If not specified, subject will be compared in a case insensitive manner.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubjectEndsWith
Filter that specifies that only events matching the specified subject suffix will be included.
If not specified, events with all subject suffixes will be included.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SystemTopicName
EventGrid topic name.

```yaml
Type: System.String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### System.String[]

### System.Int32

### System.DateTime

### System.Int64

### System.Collections.Hashtable[]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscription

## NOTES

## RELATED LINKS
