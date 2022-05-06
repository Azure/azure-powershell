---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Update-AzEventGridSystemTopicEventSubscription

## SYNOPSIS
Update the properties of an Event Grid System topic event subscription.

## SYNTAX

### TopicNameParameterSet (Default)
```
Update-AzEventGridSystemTopicEventSubscription [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SystemTopicEventSuscriptionParameterSet
```
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 -SystemTopicName <String> [-DeadLetterEndpoint <String>] [-DeliveryAttributeMapping <String[]>]
 [-Endpoint <String>] [-EndpointType <String>] [-Label <String[]>] [-StorageQueueMessageTtl <Int64>]
 [-AdvancedFilter <Hashtable[]>] [-AdvancedFilteringOnArray] [-IncludedEventType <String[]>]
 [-SubjectBeginsWith <String>] [-SubjectEndsWith <String>] [-SubjectCaseSensitive]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update the properties of an Event Grid System topic event subscription. This can be used to update the filter, destination, or labels of an existing event subscription.

## EXAMPLES

### Example 1
```powershell
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName ES1 -SystemTopicName Topic1 -ResourceGroup MyResourceGroupName -Endpoint https://requestb.in/1kxxoui1
```

Updates the endpoint of the event subscription \`ES1\` for system topic \`Topic1\` in resource group \`MyResourceGroupName\` to \`https://requestb.in/1kxxoui1\`

### Example 2
```powershell
$labels = "Finance", "HR"
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName ES1 -SystemTopicName Topic1 -ResourceGroup MyResourceGroupName -Label $labels
```

Updates the properties of the event subscription \`ES1\` for system topic \`Topic1\` in \`MyResourceGroupName\` with the new labels $labels.

### Example 3
```powershell
Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName ES1 -SystemTopicName Topic1 -ResourceGroup MyResourceGroupName -Endpoint https://requestb.in/1kxxoui1 -SubjectEndsWith "jpg"
```

Updates the properties of the event subscription \`ES1\` for system topic \`Topic1\` in \`MyResourceGroupName\` with new endpoint \`https://requestb.in/1kxxoui1\` and the new SubjectEndsWith filter as \`jpg\`

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

### System.Int64

### System.Collections.Hashtable[]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscription

## NOTES

## RELATED LINKS
