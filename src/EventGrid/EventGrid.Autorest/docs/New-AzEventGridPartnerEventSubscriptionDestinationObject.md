---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridpartnereventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridPartnerEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for PartnerEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridPartnerEventSubscriptionDestinationObject [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PartnerEventSubscriptionDestination.

## EXAMPLES

### Example 1: Create an in-memory object for PartnerEventSubscriptionDestination.
```powershell
New-AzEventGridPartnerEventSubscriptionDestinationObject -ResourceId "TestDestinationId"
```

```output
EndpointType
------------
PartnerDestination
```

Create an in-memory object for PartnerEventSubscriptionDestination.

## PARAMETERS

### -ResourceId
The Azure Resource Id that represents the endpoint of a Partner Destination of an event subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.PartnerEventSubscriptionDestination

## NOTES

## RELATED LINKS

