---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridFullUrlForPartnerTopicEventSubscription

## SYNOPSIS
Gets the full URL for partner topic event subscription

## SYNTAX

### PartnerTopicEventSubscriptionParameterSet (Default)
```
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -Name <String> -ResourceGroupName <String>
 -PartnerTopicName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdPartnerTopicEventSubscriptionParameterSet
```
Get-AzEventGridFullUrlForPartnerTopicEventSubscription [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get the full endpoint URL if it is a webhook based event subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroupName MyResourceGroupName -PartnerTopicName Topic1 -EventSubscriptionName EventSubscription1
```

Gets the full  endpoint URL for event subscription \`EventSubscription1\` created for partner topic \`Topic1\` in resource group \`MyResourceGroupName\`.


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

### -PartnerTopicName
Event Grid partner topic name.

```yaml
Type: String
Parameter Sets: PartnerTopicEventSubscriptionParameterSet
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
Parameter Sets: PartnerTopicEventSubscriptionParameterSet
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
