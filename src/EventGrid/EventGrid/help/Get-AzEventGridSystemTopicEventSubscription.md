---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridSystemTopicEventSubscription

## SYNOPSIS
Gets the details of an event subscription, or gets a list of all event subscriptions for a given Azure Eventgrid system topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
Get-AzEventGridSystemTopicEventSubscription [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SystemTopicEventSuscriptionParameterSet
```
Get-AzEventGridSystemTopicEventSubscription [-EventSubscriptionName <String>] -ResourceGroupName <String>
 -SystemTopicName <String> [-IncludeFullEndpointUrl] [-ODataQuery <String>] [-Top <Int32>] [-NextLink <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridSystemTopicEventSubscription cmdlet gets either the details of a specified Event Grid sytem topic subscription, or a list of all Event Grid sytem topic subscriptions for a given Azure Eventgrid system topic.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1
```

Gets the details of event subscription \`EventSubscription1\` created for system topic \`Topic1\` in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1 -IncludeFullEndpointUrl
```

Gets the details of event subscription \`EventSubscription1\` created for system topic \`Topic1\` in resource group \`MyResourceGroupName\`, including the full endpoint URL if it is a webhook based event subscription.

### Example 3
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -SystemTopicName Topic1
```

Get a list of all the event subscriptions created for system topic \`Topic1\` in resource group \`MyResourceGroupName\` without pagination.

### Example 4
```powershell
$odataFilter = "Name ne 'ABCD'"
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -TopicName Topic1 -Top 10 -ODataQuery $odataFilter
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName MyResourceGroupName -TopicName Topic1 $result.NextLink
```

List the first 10 event subscriptions (if any) created for system topic \`Topic1\` in resource group \`MyResourceGroupName\` that satisfies the $odataFilter query. If more results are available, the $result.NextLink will not be $null. In order to get next page(s) of event subscriptions, user is expected to re-call Get-AzEventGridSystemTopicEventSubscription and uses result.NextLink obtained from the previous call. Caller should stop when result.NextLink becomes $null.

## PARAMETERS

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

### -EventSubscriptionName
EventGrid event subscription name.

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

### -IncludeFullEndpointUrl
If specified, include the full endpoint URL of the event subscription destination in the response.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextLink
The link for the next page of resources to be obtained.
This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.

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

### -ODataQuery
The OData query used for filtering the list results.
Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

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

### -Top
The maximum number of resources to be obtained.
Valid value is between 1 and 100.
If top value is specified and more results are still available, the result will contain a link to the next page to be queried in NextLink.
If the Top value is not specified, the full list of resources will be returned at once.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: SystemTopicEventSuscriptionParameterSet
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

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscription

### Microsoft.Azure.Commands.EventGrid.Models.PSEventSubscriptionListInstance

## NOTES

## RELATED LINKS
