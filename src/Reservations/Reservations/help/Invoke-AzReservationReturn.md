---
external help file: Az.Reservations-help.xml
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationreturn
schema: 2.0.0
---

# Invoke-AzReservationReturn

## SYNOPSIS
Return a Reservation.

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationReturn -ReservationOrderId <String> -ReservationToReturnReservationId <String>
 -ReservationToReturnQuantity <Int32> -SessionId <String> -Scope <String> -ReturnReason <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzReservationReturn -InputObject <IReservationsIdentity> -Body <IRefundRequest>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzReservationReturn -InputObject <IReservationsIdentity> -ReservationToReturnReservationId <String>
 -ReservationToReturnQuantity <Int32> -SessionId <String> -Scope <String> -ReturnReason <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationReturn -ReservationOrderId <String> -Body <IRefundRequest>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Return a Reservation.

## EXAMPLES

### Example 1: Return a reservation using the session ID obtained from calculateRefund command.
```powershell
$orderId = "50000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"

Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
```

```output
ReservationOrderId                   DisplayName            Term State     Quantity Reservations
------------------                   -----------            ---- -----     -------- ------------
179ef21b-90ec-4fe4-9423-f794b856dfee VM_RI_08-20-2021_15-47 P3Y  Succeeded 1        {{…
```

Proceed reservations return with session ID obtained from Invoke-AzReservationCalculateRefund.

## PARAMETERS

### -Body
The return request body.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IRefundRequest
Parameter Sets: PostViaIdentity, Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
Parameter Sets: PostViaIdentity, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReservationOrderId
Reservation Order Id.

```yaml
Type: System.String
Parameter Sets: PostExpanded, Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationToReturnQuantity
Quantity to return.

```yaml
Type: System.Int32
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationToReturnReservationId
Reservation Id to return.

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnReason
The reason for this reservation return.

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of this return, e.g.
Reservation.

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionId
The session id obtained from Invoke-AzReservationCalculateRefund..

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationOrderResponse

## NOTES

## RELATED LINKS
