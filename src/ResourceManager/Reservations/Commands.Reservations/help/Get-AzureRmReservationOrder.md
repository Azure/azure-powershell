---
external help file: Microsoft.Azure.Commands.Reservations.dll-Help.xml
Module Name: AzureRM.Reservations
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.reservations/get-azurermreservationorder
schema: 2.0.0
---

# Get-AzureRmReservationOrder

## SYNOPSIS
Get `ReservationOrder`

## SYNTAX

```
Get-AzureRmReservationOrder [-ReservationOrderId <String>] [<CommonParameters>]
```

## DESCRIPTION
List of all the `ReservationOrder`s that the user has access to in the current tenant. If ReservationOrderId parameter is set, get that specific ReservationOrder.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmReservationOrder
```

List all `ReservationOrder` that the user has access to in the current tenant

### Example 2
```
PS C:\> Get-AzureRmReservationOrder -ReservationOrderId "00000000-ffff-ffff-0000-00000fffff"
```

Get `ReservationOrder` with the specified ReservationOrderId

## PARAMETERS

### -ReservationOrderId
Id of the specific ReservationOrder that user wants to see

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

### Microsoft.Azure.Commands.Reservations.Models.PSReservationOrderPage
Microsoft.Azure.Commands.Reservations.Models.PSReservationOrder

## NOTES

## RELATED LINKS

