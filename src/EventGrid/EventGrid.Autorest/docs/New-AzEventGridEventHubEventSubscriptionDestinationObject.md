---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgrideventhubeventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridEventHubEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for EventHubEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridEventHubEventSubscriptionDestinationObject
 [-DeliveryAttributeMapping <IDeliveryAttributeMapping[]>] [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventHubEventSubscriptionDestination.

## EXAMPLES

### Example 1: Create an in-memory object for EventHubEventSubscriptionDestination.
```powershell
$damObj = New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
$eventSubObj = Get-AzEventGridSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
New-AzEventGridEventHubEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

```output
New-AzEventGridEventHubEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

Create an in-memory object for EventHubEventSubscriptionDestination.

## PARAMETERS

### -DeliveryAttributeMapping
Delivery attribute details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure Resource Id that represents the endpoint of an Event Hub destination of an event subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.EventHubEventSubscriptionDestination

## NOTES

## RELATED LINKS

