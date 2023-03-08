---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationcalculateexchange
schema: 2.0.0
---

# Invoke-AzReservationCalculateExchange

## SYNOPSIS
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationCalculateExchange [-ReservationsToExchange <IReservationToReturn[]>]
 [-ReservationsToPurchase <IPurchaseRequest[]>] [-SavingsPlansToPurchase <ISavingsPlanPurchaseRequest[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationCalculateExchange -Body <ICalculateExchangeRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Calculates price for exchanging `Reservations` if there are no policy errors.\n

## EXAMPLES

### Example 1: Calculate reservations exchange
```powershell
$reservationToReturn1 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/85a61229-7b4b-4565-8dee-632280b27370/reservations/4b0a0a3f-83db-429f-9ef3-015b6935f300"
}
$reservationToReturn2 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/9f9d7d79-907e-4405-8764-d54a75f3d887/reservations/4c2008fe-b8cc-4291-b98a-d29792b73b9f"
}
$reservationsToReturn = @($reservationToReturn1, $reservationToReturn2)
$reservationToPurchase1Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/3f0487fd-27ca-4f9c-8a23-000770724b1b"
    DisplayName = "PSExchange"
    Term = "P3Y"
    Quantity = 1
    ReservedResourceType = "VirtualMachines"
}
$reservationToPurchase2Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/3f0487fd-27ca-4f9c-8a23-000770724b1b"
    DisplayName = "PSExchange2"
    Quantity = 2
    ReservedResourceType = "VirtualMachines"
    Term = "P3Y"
}
$reservationToPurchase1 = @{
    Location = "westeurope"
    Sku = "Standard_B20ms"
    Properties = $reservationToPurchase1Properties
}
$reservationToPurchase2 = @{
    Location = "westeurope"
    Sku = "Standard_B8ms"
    Properties = $reservationToPurchase2Properties
}
$reservationsToPurchase = @($reservationToPurchase1, $reservationToPurchase2)

Invoke-AzReservationCalculateExchange -ReservationsToExchange $reservationsToReturn -ReservationsToPurchase $reservationsToPurchase
```

```output
SessionId                            Status   
---------                            ------   
8982593c-679e-4d4e-b971-c48b6d824cba Succeeded
```

Calculate reservations exchange.
The SessionId in the response is a required input parameter for cmdlet Invoke-AzReservationExchange

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeRequest
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationToReturn[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IPurchaseRequest[]
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SavingsPlansToPurchase
List of savings plans that are being purchased in this exchange.
To construct, see NOTES section for SAVINGSPLANSTOPURCHASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ISavingsPlanPurchaseRequest[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculateExchangeOperationResultResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <ICalculateExchangeRequest>`: Calculate exchange request
  - `[ReservationsToExchange <IReservationToReturn[]>]`: List of reservations that are being returned in this exchange.
    - `[Quantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
    - `[ReservationId <String>]`: Fully qualified identifier of the reservation being returned
  - `[ReservationsToPurchase <IPurchaseRequest[]>]`: List of reservations that are being purchased in this exchange.
    - `[AppliedScopePropertyDisplayName <String>]`: Display name
    - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
    - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
    - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
    - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
    - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[AppliedScopes <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared. This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType.
    - `[BillingPlan <ReservationBillingPlan?>]`: Represent the billing plans.
    - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing reservation or savings plan
    - `[DisplayName <String>]`: Friendly name of the reservation
    - `[InstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
    - `[Location <String>]`: The Azure region where the reserved resource lives.
    - `[Quantity <Int32?>]`: Quantity of the skus that are part of the reservation.
    - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
    - `[ReservedResourceType <ReservedResourceType?>]`: The type of the resource that is being reserved.
    - `[ReviewDateTime <DateTime?>]`: This is the date-time when the Azure hybrid benefit needs to be reviewed.
    - `[Sku <String>]`: 
    - `[Term <ReservationTerm?>]`: Represent the term of reservation.
  - `[SavingsPlansToPurchase <ISavingsPlanPurchaseRequest[]>]`: List of savings plans that are being purchased in this exchange.
    - `[AppliedScopePropertyDisplayName <String>]`: Display name
    - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
    - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
    - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
    - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
    - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
    - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing reservation or savings plan
    - `[CommitmentAmount <Double?>]`: 
    - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
    - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
    - `[DisplayName <String>]`: Friendly name of the savings plan
    - `[SkuName <String>]`: 
    - `[Term <SavingsPlanTerm?>]`: Represent savings plan term in ISO 8601 format.

`RESERVATIONSTOEXCHANGE <IReservationToReturn[]>`: List of reservations that are being returned in this exchange.
  - `[Quantity <Int32?>]`: Quantity to be returned. Must be greater than zero.
  - `[ReservationId <String>]`: Fully qualified identifier of the reservation being returned

`RESERVATIONSTOPURCHASE <IPurchaseRequest[]>`: List of reservations that are being purchased in this exchange.
  - `[AppliedScopePropertyDisplayName <String>]`: Display name
  - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
  - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
  - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
  - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[AppliedScopes <String[]>]`: List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared. This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType.
  - `[BillingPlan <ReservationBillingPlan?>]`: Represent the billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing reservation or savings plan
  - `[DisplayName <String>]`: Friendly name of the reservation
  - `[InstanceFlexibility <InstanceFlexibility?>]`: Turning this on will apply the reservation discount to other VMs in the same VM size group. Only specify for VirtualMachines reserved resource type.
  - `[Location <String>]`: The Azure region where the reserved resource lives.
  - `[Quantity <Int32?>]`: Quantity of the skus that are part of the reservation.
  - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new reservation on the expiration date time.
  - `[ReservedResourceType <ReservedResourceType?>]`: The type of the resource that is being reserved.
  - `[ReviewDateTime <DateTime?>]`: This is the date-time when the Azure hybrid benefit needs to be reviewed.
  - `[Sku <String>]`: 
  - `[Term <ReservationTerm?>]`: Represent the term of reservation.

`SAVINGSPLANSTOPURCHASE <ISavingsPlanPurchaseRequest[]>`: List of savings plans that are being purchased in this exchange.
  - `[AppliedScopePropertyDisplayName <String>]`: Display name
  - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
  - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
  - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
  - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing reservation or savings plan
  - `[CommitmentAmount <Double?>]`: 
  - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
  - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
  - `[DisplayName <String>]`: Friendly name of the savings plan
  - `[SkuName <String>]`: 
  - `[Term <SavingsPlanTerm?>]`: Represent savings plan term in ISO 8601 format.

## RELATED LINKS

