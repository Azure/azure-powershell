---
external help file:
Module Name: Az.Reservations
online version: https://docs.microsoft.com/powershell/module/az.reservations/update-azreservation
schema: 2.0.0
---

# Update-AzReservation

## SYNOPSIS
Updates the applied scopes of the `Reservation`.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzReservation -Id <String> -OrderId <String> [-AppliedScope <String[]>]
 [-AppliedScopeType <AppliedScopeType>] [-InstanceFlexibility <InstanceFlexibility>] [-Name <String>] [-Renew]
 [-RenewProperty <IPatchPropertiesRenewProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzReservation -Id <String> -OrderId <String> -Reservation <IPatch> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzReservation -InputObject <IReservationsIdentity> -Reservation <IPatch> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzReservation -InputObject <IReservationsIdentity> [-AppliedScope <String[]>]
 [-AppliedScopeType <AppliedScopeType>] [-InstanceFlexibility <InstanceFlexibility>] [-Name <String>] [-Renew]
 [-RenewProperty <IPatchPropertiesRenewProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the applied scopes of the `Reservation`.

## EXAMPLES

### Example 1: Update Reservation's properties
```powershell
Update-AzReservation -ReservationOrderId "fe784288-6510-4b2b-8a56-3d4e38295a18" -ReservationId "271d8e0b-da88-44d8-b276-2620b8f1c7d1" -Name "testName"
```

```output
Location   ReservationOrderId/ReservationId                                             Sku           State     BenefitStartTime     ExpiryDate            LastUpdatedDateTime  SkuDescription
--------   --------------------------------                                             ---           -----     ----------------     ----------            -------------------  --------------
westeurope fe784288-6510-4b2b-8a56-3d4e38295a18/271d8e0b-da88-44d8-b276-2620b8f1c7d1/16 Standard_B4ms Succeeded 6/14/2022 9:41:17 PM 6/14/2025 12:00:00 AM 7/7/2022 11:37:58 PM Reserved VM In…
```

Update Reservation's properties including name, renew, appliedScopeType, appliedScope

## PARAMETERS

### -AppliedScope
List of the subscriptions that the benefit will be applied.
Do not specify if AppliedScopeType is Shared.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Id of the Reservation Item

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ReservationId

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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Reservation

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -OrderId
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ReservationOrderId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Renew
Setting this to true will automatically purchase a new reservation on the expiration date time.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewProperty
.
To construct, see NOTES section for RENEWPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPatchPropertiesRenewProperties
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reservation
.
To construct, see NOTES section for RESERVATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPatch
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPatch

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IReservationsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

RENEWPROPERTY <IPatchPropertiesRenewProperties>: .
  - `[PurchaseProperty <IPurchaseRequest>]`: 
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

RESERVATION <IPatch>: .
  - `[AppliedScope <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[InstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
  - `[Name <String>]`: Name of the Reservation
  - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
  - `[RenewProperty <IPatchPropertiesRenewProperties>]`: 
    - `[PurchaseProperty <IPurchaseRequest>]`: 
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

## RELATED LINKS

