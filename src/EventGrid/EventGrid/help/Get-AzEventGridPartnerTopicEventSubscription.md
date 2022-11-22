---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridPartnerTopicEventSubscription

## SYNOPSIS
Gets the details of an event subscription, or gets a list of all event subscriptions for a given Azure Event Grid partner topic.

## SYNTAX

### PartnerTopicNameParameterSet (Default)
```
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName <String> -PartnerTopicName <String>
 [-IncludeFullEndpointUrl] [-ODataQuery <String>] [-Top <Int32>] [-NextLink <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PartnerTopicEventSubscriptionParameterSet
```
Get-AzEventGridPartnerTopicEventSubscription -Name <String> -ResourceGroupName <String>
 -PartnerTopicName <String> [-IncludeFullEndpointUrl] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceIdPartnerTopicEventSubscriptionParameterSet
```
Get-AzEventGridPartnerTopicEventSubscription [-ResourceId] <String> [-IncludeFullEndpointUrl]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridPartnerTopicEventSubscription cmdlet gets either the details of a specified Event Grid partner topic subscription, or a list of all Event Grid partner topic subscriptions for a given Azure Eventgrid partner topic.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1
```

Gets the details of event subscription \`EventSubscription1\` created for partner topic \`Topic1\` in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1 -IncludeFullEndpointUrl
```

Gets the details of event subscription \`EventSubscription1\` created for partner topic \`Topic1\` in resource group \`MyResourceGroupName\`, including the full endpoint URL if it is a webhook based event subscription.

### Example 3
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1
```

Get a list of all the event subscriptions created for partner topic \`Topic1\` in resource group \`MyResourceGroupName\` without pagination.

### Example 4
```powershell
$odataFilter = "Name ne 'ABCD'"
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -Top 10 -ODataQuery $odataFilter
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -NextLink $result.NextLink
```

List the first 10 event subscriptions (if any) created for partner topic \`Topic1\` in resource group \`MyResourceGroupName\` that satisfies the $odataFilter query. If more results are available, the $result.NextLink will not be $null. In order to get next page(s) of event subscriptions, user is expected to re-call Get-AzEventGridPartnerTopicEventSubscription and uses result.NextLink obtained from the previous call. Caller should stop when result.NextLink becomes $null.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeFullEndpointUrl
If specified, include the full endpoint URL of the event subscription destination in the response.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
EventGrid event subscription name.

```yaml
Type: String
Parameter Sets: PartnerTopicEventSubscriptionParameterSet
Aliases: EventSubscriptionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextLink
The link for the next page of resources to be obtained.
This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ODataQuery
The OData query used for filtering the list results.
Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerTopicName
Event Grid partner topic name.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet, PartnerTopicEventSubscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet, PartnerTopicEventSubscriptionParameterSet
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource Identifier representing the Event Grid Event Subscription.

```yaml
Type: String
Parameter Sets: ResourceIdPartnerTopicEventSubscriptionParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
The maximum number of resources to be obtained.
Valid value is between 1 and 100.
If top value is specified and more results are still available, the result will contain a link to the next page to be queried in NextLink.
If the Top value is not specified, the full list of resources will be returned at once.

```yaml
Type: Int32
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscription

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscriptionListInstance

## NOTES

## RELATED LINKS
