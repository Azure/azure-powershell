---
external help file:
Module Name: Az.ReservationApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi/invoke-azreservationapipurchasereservationorder
schema: 2.0.0
---

# Invoke-AzReservationApiPurchaseReservationOrder

## SYNOPSIS
Purchase `ReservationOrder` and create resource under the specified URI.

## SYNTAX

### PurchaseExpanded (Default)
```
Invoke-AzReservationApiPurchaseReservationOrder -ReservationOrderId <String> [-AppliedScope <String[]>]
 [-AppliedScopeType <AppliedScopeType>] [-BillingPlan <ReservationBillingPlan>] [-BillingScopeId <String>]
 [-DisplayName <String>] [-Location <String>] [-Quantity <Int32>] [-Renew]
 [-ReservedResourcePropertyInstanceFlexibility <InstanceFlexibility>]
 [-ReservedResourceType <ReservedResourceType>] [-SkuName <String>] [-Term <ReservationTerm>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Purchase
```
Invoke-AzReservationApiPurchaseReservationOrder -ReservationOrderId <String> -Body <IPurchaseRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PurchaseViaIdentity
```
Invoke-AzReservationApiPurchaseReservationOrder -InputObject <IReservationApiIdentity>
 -Body <IPurchaseRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PurchaseViaIdentityExpanded
```
Invoke-AzReservationApiPurchaseReservationOrder -InputObject <IReservationApiIdentity>
 [-AppliedScope <String[]>] [-AppliedScopeType <AppliedScopeType>] [-BillingPlan <ReservationBillingPlan>]
 [-BillingScopeId <String>] [-DisplayName <String>] [-Location <String>] [-Quantity <Int32>] [-Renew]
 [-ReservedResourcePropertyInstanceFlexibility <InstanceFlexibility>]
 [-ReservedResourceType <ReservedResourceType>] [-SkuName <String>] [-Term <ReservationTerm>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Purchase `ReservationOrder` and create resource under the specified URI.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.AppliedScopeType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.ReservationBillingPlan
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IPurchaseRequest
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity
Parameter Sets: PurchaseViaIdentity, PurchaseViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ReservedResourcePropertyInstanceFlexibility
Turning this on will apply the reservation discount to other VMs in the same VM size group.
Only specify for VirtualMachines reserved resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.InstanceFlexibility
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservedResourceType
The type of the resource that is being reserved.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.ReservedResourceType
Parameter Sets: PurchaseExpanded, PurchaseViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Support.ReservationTerm
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

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IPurchaseRequest

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IReservationOrderResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IPurchaseRequest>: .
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

INPUTOBJECT <IReservationApiIdentity>: Identity Parameter
  - `[Id <String>]`: Quota Request ID.
  - `[Id1 <String>]`: Resource identity path
  - `[Location <String>]`: Azure region.
  - `[ProviderId <String>]`: Azure resource provider ID.
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[ResourceName <String>]`: The resource name for a resource provider, such as SKU name for Microsoft.Compute, Sku or TotalLowPriorityCores for Microsoft.MachineLearningServices
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

