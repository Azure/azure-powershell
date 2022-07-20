---
external help file:
Module Name: Az.Reservations
online version: https://docs.microsoft.com/powershell/module/az.reservations/new-azreservation
schema: 2.0.0
---

# New-AzReservation

## SYNOPSIS
Purchase `ReservationOrder` and create resource under the specified URI.

## SYNTAX

### PurchaseExpanded (Default)
```
New-AzReservation -ReservationOrderId <String> [-AppliedScope <String[]>]
 [-AppliedScopeType <AppliedScopeType>] [-BillingPlan <ReservationBillingPlan>] [-BillingScopeId <String>]
 [-DisplayName <String>] [-InstanceFlexibility <InstanceFlexibility>] [-Location <String>] [-Quantity <Int32>]
 [-Renew] [-ReservedResourceType <ReservedResourceType>] [-Sku <String>] [-Term <ReservationTerm>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Purchase
```
New-AzReservation -ReservationOrderId <String> -Body <IPurchaseRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PurchaseViaIdentity
```
New-AzReservation -InputObject <IReservationsIdentity> -Body <IPurchaseRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PurchaseViaIdentityExpanded
```
New-AzReservation -InputObject <IReservationsIdentity> [-AppliedScope <String[]>]
 [-AppliedScopeType <AppliedScopeType>] [-BillingPlan <ReservationBillingPlan>] [-BillingScopeId <String>]
 [-DisplayName <String>] [-InstanceFlexibility <InstanceFlexibility>] [-Location <String>] [-Quantity <Int32>]
 [-Renew] [-ReservedResourceType <ReservedResourceType>] [-Sku <String>] [-Term <ReservationTerm>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Purchase `ReservationOrder` and create resource under the specified URI.

## EXAMPLES

### Example 1: Create a new reservation
```powershell
New-AzReservation -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'TestVm2222' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y' -ReservationOrderId '846655fa-d9e7-4fb8-9512-3ab7367352f1'
```

```output
ReservationOrderId                   DisplayName Term State     Quantity
------------------                   ----------- ---- -----     --------
846655fa-d9e7-4fb8-9512-3ab7367352f1 TestVm2222  P1Y  Succeeded 1
```

Proceed reservations purchase with reservation order ID obtained from Get-AzReservationQuote.
This is a long running POST operation which can take around 10ish mins.

## PARAMETERS

### -AppliedScope
List of the subscriptions that the benefit will be applied.
Do not specify if AppliedScopeType is Shared.

```yaml
Type: System.String[]
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopeType
Type of the Applied Scope.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.AppliedScopeType
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -BillingPlan
Represent the billing plans.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationBillingPlan
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingScopeId
Subscription that will be charged for purchasing Reservation

```yaml
Type: System.String
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPurchaseRequest
Parameter Sets: Purchase, PurchaseViaIdentity
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

### -DisplayName
Friendly name of the Reservation

```yaml
Type: System.String
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

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
Parameter Sets: PurchaseViaIdentity, PurchaseViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceFlexibility
Turning this on will apply the reservation discount to other VMs in the same VM size group.
Only specify for VirtualMachines reserved resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.InstanceFlexibility
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The Azure Region where the reserved resource lives.

```yaml
Type: System.String
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

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

### -Quantity
Quantity of the SKUs that are part of the Reservation.

```yaml
Type: System.Int32
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Renew
Setting this to true will automatically purchase a new reservation on the expiration date time.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationOrderId
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: Purchase, PurchaseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservedResourceType
The type of the resource that is being reserved.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservedResourceType
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
.

```yaml
Type: System.String
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Represent the term of Reservation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationTerm
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPurchaseRequest

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationOrderResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IPurchaseRequest>`: .
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[AppliedScopes <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared.
  - `[BillingPlan <ReservationBillingPlan?>]`: Represent the billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing Reservation
  - `[DisplayName <String>]`: Friendly name of the Reservation
  - `[InstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
  - `[Location <String>]`: The Azure Region where the reserved resource lives.
  - `[Quantity <Int32?>]`: Quantity of the SKUs that are part of the Reservation.
  - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
  - `[ReservedResourceType <ReservedResourceType?>]`: The type of the resource that is being reserved.
  - `[Sku <String>]`: 
  - `[Term <ReservationTerm?>]`: Represent the term of Reservation.

`INPUTOBJECT <IReservationsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

