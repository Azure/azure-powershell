---
external help file:
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
Invoke-AzReservationReturn -ReservationOrderId <String> -ReservationToReturnQuantity <Int32>
 -ReservationToReturnReservationId <String> -ReturnReason <String> -Scope <String> -SessionId <String>
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationReturn -Body <IRefundRequest> -ReservationOrderId <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzReservationReturn -InputObject <IReservationsIdentity> -Body <IRefundRequest> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzReservationReturn -InputObject <IReservationsIdentity> -ReservationToReturnQuantity <Int32>
 -ReservationToReturnReservationId <String> -ReturnReason <String> -Scope <String> -SessionId <String>
 [-Confirm] [-WhatIf] [<CommonParameters>]
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
BillingInformationBillingCurrencyProratedAmount            : {
                                                               "currencyCode": "USD",
                                                               "amount": 12.9        
                                                             }
BillingInformationBillingCurrencyRemainingCommitmentAmount : {
                                                               "currencyCode": "USD",
                                                               "amount": 18.06       
                                                             }
BillingInformationBillingCurrencyTotalPaidAmount           : {
                                                               "currencyCode": "USD",
                                                               "amount": 15.48       
                                                             }
BillingInformationBillingPlan                              : Monthly
BillingInformationCompletedTransaction                     : 5
BillingInformationTotalTransaction                         : 12
BillingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 2.58
                                                             }
ConsumedRefundsTotal                                       : {
                                                               "currencyCode": "USD",
                                                               "amount": 368.23
                                                             }
Id                                                         : /providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003
Location                                                   :
MaxRefundLimit                                             : {
                                                               "currencyCode": "USD",
                                                               "amount": 50000
                                                             }
PolicyError                                                : {}
PricingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 2.58
                                                             }
Quantity                                                   : 1
ResourceGroupName                                          :
SessionId                                                  : 93fe5df2-d888-47c5-b00c-cd0ccb1f29b9
```

Proceed reservations return with session ID obtained from Invoke-AzReservationCalculateRefund.

## PARAMETERS

### -Body
The return request body.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IRefundRequest
Parameter Sets: Post, PostViaIdentity
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
Parameter Sets: Post, PostExpanded
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

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IRefundRequest>`: The return request body.
  - `[ReservationToReturnQuantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
  - `[ReservationToReturnReservationId <String>]`: Fully qualified identifier of the reservation being returned
  - `[ReturnReason <String>]`: The reason of returning the reservation
  - `[Scope <String>]`: The scope of the refund, e.g. Reservation
  - `[SessionId <String>]`: SessionId that was returned by CalculateRefund API.

`INPUTOBJECT <IReservationsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the reservation item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

