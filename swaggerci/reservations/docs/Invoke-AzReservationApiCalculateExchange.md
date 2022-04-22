---
external help file:
Module Name: Az.ReservationApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi/invoke-azreservationapicalculateexchange
schema: 2.0.0
---

# Invoke-AzReservationApiCalculateExchange

## SYNOPSIS
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationApiCalculateExchange [-ReservationsToExchange <IReservationToReturn[]>]
 [-ReservationsToPurchase <IPurchaseRequest[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationApiCalculateExchange -Body <ICalculateExchangeRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Calculate exchange request
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.ICalculateExchangeRequest
Parameter Sets: Post
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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationsToExchange
List of reservations that are being returned in this exchange.
To construct, see NOTES section for RESERVATIONSTOEXCHANGE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IReservationToReturn[]
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationsToPurchase
List of reservations that are being purchased in this exchange.
To construct, see NOTES section for RESERVATIONSTOPURCHASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IPurchaseRequest[]
Parameter Sets: PostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.ICalculateExchangeRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.ICalculateExchangeOperationResultResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <ICalculateExchangeRequest>: Calculate exchange request
  - `[ReservationsToExchange <IReservationToReturn[]>]`: List of reservations that are being returned in this exchange.
    - `[Quantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
    - `[ReservationId <String>]`: Fully qualified identifier of the Reservation being returned
  - `[ReservationsToPurchase <IPurchaseRequest[]>]`: List of reservations that are being purchased in this exchange.
    - `[AppliedScope <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared.
    - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[BillingPlan <ReservationBillingPlan?>]`: Represent the billing plans.
    - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing Reservation
    - `[DisplayName <String>]`: Friendly name of the Reservation
    - `[Location <String>]`: The Azure Region where the reserved resource lives.
    - `[Quantity <Int32?>]`: Quantity of the SKUs that are part of the Reservation.
    - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
    - `[ReservedResourcePropertyInstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
    - `[ReservedResourceType <ReservedResourceType?>]`: The type of the resource that is being reserved.
    - `[SkuName <String>]`: 
    - `[Term <ReservationTerm?>]`: Represent the term of Reservation.

RESERVATIONSTOEXCHANGE <IReservationToReturn[]>: List of reservations that are being returned in this exchange.
  - `[Quantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
  - `[ReservationId <String>]`: Fully qualified identifier of the Reservation being returned

RESERVATIONSTOPURCHASE <IPurchaseRequest[]>: List of reservations that are being purchased in this exchange.
  - `[AppliedScope <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[BillingPlan <ReservationBillingPlan?>]`: Represent the billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing Reservation
  - `[DisplayName <String>]`: Friendly name of the Reservation
  - `[Location <String>]`: The Azure Region where the reserved resource lives.
  - `[Quantity <Int32?>]`: Quantity of the SKUs that are part of the Reservation.
  - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
  - `[ReservedResourcePropertyInstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
  - `[ReservedResourceType <ReservedResourceType?>]`: The type of the resource that is being reserved.
  - `[SkuName <String>]`: 
  - `[Term <ReservationTerm?>]`: Represent the term of Reservation.

## RELATED LINKS

