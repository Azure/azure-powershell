---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute

## SYNOPSIS
Gets the delivery attributes for system topic event subscription

## SYNTAX

### TopicNameParameterSet (Default)
```
Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SystemTopicEventSuscriptionParameterSet
```
Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute -EventSubscriptionName <String>
 -ResourceGroupName <String> -SystemTopicName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the list of delivery attributes for system topic event subscription

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute -ResourceGroupName MyResourceGroupName -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1
```

Gets the list of delivery attributest for event subscription \`EventSubscription1\` created for system topic \`Topic1\` in resource group \`MyResourceGroupName\`.

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

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PsDeliveryAttribute

## NOTES

## RELATED LINKS
