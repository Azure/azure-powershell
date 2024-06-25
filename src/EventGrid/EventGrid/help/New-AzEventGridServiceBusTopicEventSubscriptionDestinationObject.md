---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridservicebustopiceventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridServiceBusTopicEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridServiceBusTopicEventSubscriptionDestinationObject
 [-DeliveryAttributeMapping <IDeliveryAttributeMapping[]>] [-ResourceId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.

## EXAMPLES

### Example 1: Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.
```powershell
$damObj = New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
$eventSubObj = Get-AzEventGridSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
New-AzEventGridServiceBusTopicEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

```output
EndpointType
------------
ServiceBusTopic
```

Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.

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
The Azure Resource Id that represents the endpoint of the Service Bus Topic destination of an event subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination

## NOTES

## RELATED LINKS
