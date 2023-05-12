---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationcalculaterefund
schema: 2.0.0
---

# Invoke-AzReservationCalculateRefund

## SYNOPSIS
Calculate price for returning `Reservations` if there are no policy errors.\n

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationCalculateRefund -ReservationOrderId <String> [-Id <String>]
 [-ReservationToReturnQuantity <Int32>] [-ReservationToReturnReservationId <String>] [-Scope <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationCalculateRefund -ReservationOrderId <String> -Body <ICalculateRefundRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentity
```
Invoke-AzReservationCalculateRefund -InputObject <IReservationsIdentity> -Body <ICalculateRefundRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaIdentityExpanded
```
Invoke-AzReservationCalculateRefund -InputObject <IReservationsIdentity> [-Id <String>]
 [-ReservationToReturnQuantity <Int32>] [-ReservationToReturnReservationId <String>] [-Scope <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Calculate price for returning `Reservations` if there are no policy errors.\n

## EXAMPLES

### Example 1: Calculate price for returning reservations
```powershell
$orderId = "50000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"

Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
```

```output
BillingInformationBillingCurrencyProratedAmount            : {
                                                               "currencyCode": "USD",
                                                               "amount": 25.05       
                                                             }
BillingInformationBillingCurrencyRemainingCommitmentAmount : {
                                                               "currencyCode": "USD",
                                                               "amount": 18.06       
                                                             }
BillingInformationBillingCurrencyTotalPaidAmount           : {
                                                               "currencyCode": "USD",
                                                               "amount": 25.8        
                                                             }
BillingInformationBillingPlan                              : Monthly
BillingInformationCompletedTransaction                     : 5
BillingInformationTotalTransaction                         : 12
BillingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 0.75
                                                             }
ConsumedRefundsTotal                                       : {
                                                               "currencyCode": "USD",
                                                               "amount": 365.43
                                                             }
Id                                                         : /providers/Microsoft.Capacity/reservationOrders/4336d060-da34-4228-91b0-feab5b2a1e1d/reservations/5e012942-5692-41c0-bc71-86303e11104d
MaxRefundLimit                                             : {
                                                               "currencyCode": "USD",
                                                               "amount": 50000
                                                             }
PolicyError                                                : {}
PricingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 0.75
                                                             }
Quantity                                                   : 1
ResourceGroupName                                          :
SessionId                                                  : b0a96155-5f75-4138-b01f-443130f5516e
```

Calculate reservations refund amount.
The SessionId in the response is a required input parameter for cmdlet Invoke-AzReservationReturn

## PARAMETERS

### -Body
Request containing information needed for calculating refund.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateRefundRequest
Parameter Sets: Post, PostViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -Id
Fully qualified identifier of the reservation order being returned

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases: ReservationId

Required: False
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
Order Id of the reservation

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
Quantity to be returned.
Must be greater than zero.

```yaml
Type: System.Int32
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationToReturnReservationId
Fully qualified identifier of the reservation being returned

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the refund, e.g.
Reservation

```yaml
Type: System.String
Parameter Sets: PostExpanded, PostViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateRefundRequest

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateRefundResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <ICalculateRefundRequest>`: Request containing information needed for calculating refund.
  - `[Id <String>]`: Fully qualified identifier of the reservation order being returned
  - `[ReservationToReturnQuantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
  - `[ReservationToReturnReservationId <String>]`: Fully qualified identifier of the reservation being returned
  - `[Scope <String>]`: The scope of the refund, e.g. Reservation

`INPUTOBJECT <IReservationsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the reservation item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

