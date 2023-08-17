---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/merge-azreservation
schema: 2.0.0
---

# Merge-AzReservation

## SYNOPSIS
Merge two reservations into one reservation within the same reservation order.

## SYNTAX

```
Merge-AzReservation -OrderId <String> -ReservationId <String[]> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Merge two reservations into one reservation within the same reservation order.

## EXAMPLES

### Example 1: Merge two reservations into one single reservation
```powershell
$arr=@("72bc398d-b201-4a2e-a1fa-60fb48a85b23", "34f2474f-b4d7-41ec-a96d-d4bb7c2f85b6")
Merge-AzReservation -ReservationOrderId "79ebddac-4030-4296-ab93-1ad90f032058" -ReservationId $arr
```

```output
Location   ReservationOrderId/ReservationId                                            Sku           State     BenefitStartTime    ExpiryDate           LastUpdatedDateTime SkuDescription
--------   --------------------------------                                            ---           -----     ----------------    ----------           ------------------- --------------
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/72bc398d-b201-4a2e-a1fa-60fb48a85b23/5 Standard_B1ls Cancelled 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/34f2474f-b4d7-41ec-a96d-d4bb7c2f85b6/4 Standard_B1ls Cancelled 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
westeurope 79ebddac-4030-4296-ab93-1ad90f032058/5a91b7d0-9276-4bc9-adae-2a3f5c2ee076/2 Standard_B1ls Succeeded 7/5/2022 1:24:21 AM 7/5/2025 12:00:00 AM 7/8/2022 1:09:29 AM Reserved VM Instan…
```

Merge two reservations into one single reservation.
The two reservations must have the same reservation order id.
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

### -ReservationId
Reservation Ids.

```yaml
Type: System.String[]
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

