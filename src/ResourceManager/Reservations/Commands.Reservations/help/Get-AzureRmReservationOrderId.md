---
external help file: Microsoft.Azure.Commands.Reservations.dll-Help.xml
Module Name: AzureRM.Reservations
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.reservations/get-azurermreservationorderid
schema: 2.0.0
---

# Get-AzureRmReservationOrderId

## SYNOPSIS
Get list of applicable `ReservationOrder` Ids.

## SYNTAX

```
Get-AzureRmReservationOrderId [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Get Ids of applicable `ReservationOrder`s that can be applied to this subscription.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmReservationOrderId
```

Get applied `ReservationOrder` for default subscription

### Example 2
```
PS C:\> Get-AzureRmReservationOrderId -SubscriptionId "1111aaaa-b1b2-c0c2-d0d2-00000fffff"
```

Get applied `ReservationOrder` for specified subscription

## PARAMETERS

### -SubscriptionId
Id of the subscription to get the applied `ReservationOrder`s

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Reservations.Models.PSAppliedReservationOrderId

## NOTES

## RELATED LINKS

