---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/split-azreservation
schema: 2.0.0
---

# Split-AzReservation

## SYNOPSIS
Split a Reservation order.

## SYNTAX

```
Split-AzReservation -OrderId <String> -Quantity <Int32[]> -ReservationId <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Split a Reservation order.

## EXAMPLES

### Example 1: Split one reservation order into two reservations
```powershell
Split-AzReservation -ReservationOrderId "c615c897-aaaa-4123-8527-c42cc0da41e0" -ReservationId "1bdfaf4a-159d-46ec-be3a-f4aa527d423c" -Quantity @(2,8)

```

```output
Location   ReservationOrderId/ReservationId                                             Sku           State     BenefitStartTime     ExpiryDate           LastUpdatedDateTime  SkuDescription
--------   --------------------------------                                             ---           -----     ----------------     ----------           -------------------  --------------
westeurope c615c897-aaaa-4123-8527-c42cc0da41e0/f4f0f24c-30d4-4f5d-823c-4a9e1e18b381/2  Standard_B1ls Succeeded 7/7/2022 10:55:12 PM 7/7/2025 12:00:00 AM 7/7/2022 11:21:51 PM Reserved VM Ins…
westeurope c615c897-aaaa-4123-8527-c42cc0da41e0/85cd4ee6-654e-47df-b230-7fb2f1e86714/2  Standard_B1ls Succeeded 7/7/2022 10:55:12 PM 7/7/2025 12:00:00 AM 7/7/2022 11:21:51 PM Reserved VM Ins…
westeurope c615c897-aaaa-4123-8527-c42cc0da41e0/1bdfaf4a-159d-46ec-be3a-f4aa527d423c/12 Standard_B1ls Cancelled 7/7/2022 10:55:12 PM 7/7/2025 12:00:00 AM 7/7/2022 11:21:51 PM Reserved VM Ins…
```

Split one reservation order into two reservations, given the quantity of each reservation.
The quantity sum up should be equal to the original reservation before splitting.
ReservationId can be either GUID form or fully qulified reservation id form "providers/Microsoft.Capacity/reservationOrders/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/reservations/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderId
Reservation Order Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ReservationOrderId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Quantity
Quantity.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationId
Reservation Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationResponse

## NOTES

ALIASES

## RELATED LINKS

