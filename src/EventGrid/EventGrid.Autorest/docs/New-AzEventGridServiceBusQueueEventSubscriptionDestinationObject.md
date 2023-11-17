---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridservicebusqueueeventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridServiceBusQueueEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for ServiceBusQueueEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridServiceBusQueueEventSubscriptionDestinationObject
 [-DeliveryAttributeMapping <IDeliveryAttributeMapping[]>] [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceBusQueueEventSubscriptionDestination.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -DeliveryAttributeMapping
Delivery attribute details.
To construct, see NOTES section for DELIVERYATTRIBUTEMAPPING properties and create a hash table.

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
The Azure Resource Id that represents the endpoint of the Service Bus destination of an event subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination

## NOTES

## RELATED LINKS

