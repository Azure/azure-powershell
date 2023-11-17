---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservationquote
schema: 2.0.0
---

# Get-AzReservationQuote

## SYNOPSIS
Calculate price for placing a `ReservationOrder`.

## SYNTAX

### CalculateExpanded (Default)
```
Get-AzReservationQuote [-AppliedScope <String[]>] [-AppliedScopePropertyDisplayName <String>]
 [-AppliedScopePropertyManagementGroupId <String>] [-AppliedScopePropertyResourceGroupId <String>]
 [-AppliedScopePropertySubscriptionId <String>] [-AppliedScopePropertyTenantId <String>]
 [-AppliedScopeType <AppliedScopeType>] [-BillingPlan <ReservationBillingPlan>] [-BillingScopeId <String>]
 [-DisplayName <String>] [-InstanceFlexibility <InstanceFlexibility>] [-Location <String>] [-Quantity <Int32>]
 [-Renew] [-ReservedResourceType <ReservedResourceType>] [-ReviewDateTime <DateTime>] [-Sku <String>]
 [-Term <ReservationTerm>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Calculate
```
Get-AzReservationQuote -Body <IPurchaseRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Calculate price for placing a `ReservationOrder`.

## EXAMPLES

### Example 1: Get reservation price with 'Upfront' billing plan
```powershell
Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'yourRIName' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
```

```output
BillingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
GrandTotal              : 0
IsBillingPartnerManaged : 
IsTaxIncluded           : 
NetTotal                : 0
PaymentSchedule         : 
PricingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
ReservationOrderId      : 846655fa-d9e7-4fb8-9512-3ab7367352f1
SkuDescription          : Standard_b1ls
SkuTitle                : Reserved VM Instance, Standard_B1ls, US West, 1 Year
TaxTotal                : 0
```

Get reservation price with 'Upfront' billing plan

### Example 2: Get reservation price with 'Monthly' billing plan
```powershell
Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Monthly' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'yourRIName' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
```

```output
BillingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
GrandTotal              : 0
IsBillingPartnerManaged : 
IsTaxIncluded           : 
NetTotal                : 0
PaymentSchedule         : {{
                            "dueDate": "2022-07-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "billingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-08-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-09-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-10-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }…}
PricingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
ReservationOrderId      : 23d4106a-8ec0-4709-839f-0e8073459e83
SkuDescription          : Standard_b1ls
SkuTitle                : Reserved VM Instance, Standard_B1ls, US West, 1 Year
TaxTotal                : 0
```

Get reservation price with 'Monthly' billing plan

## PARAMETERS

### -AppliedScope
List of the subscriptions that the benefit will be applied.
Do not specify if AppliedScopeType is Shared.
This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType.

```yaml
Type: System.String[]
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertyDisplayName
Display name

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertyManagementGroupId
Fully-qualified identifier of the management group where the benefit must be applied.

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertyResourceGroupId
Fully-qualified identifier of the resource group.

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertySubscriptionId
Fully-qualified identifier of the subscription.

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertyTenantId
Tenant ID where the savings plan should apply benefit.

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
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
Parameter Sets: CalculateExpanded
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
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingScopeId
Subscription that will be charged for purchasing reservation or savings plan

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
The request for reservation purchase
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IPurchaseRequest
Parameter Sets: Calculate
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
Friendly name of the reservation

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceFlexibility
Turning this on will apply the reservation discount to other VMs in the same VM size group.
Only specify for VirtualMachines reserved resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.InstanceFlexibility
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The Azure region where the reserved resource lives.

```yaml
Type: System.String
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Quantity
Quantity of the skus that are part of the reservation.

```yaml
Type: System.Int32
Parameter Sets: CalculateExpanded
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
Parameter Sets: CalculateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservedResourceType
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReviewDateTime
This is the date-time when the Azure hybrid benefit needs to be reviewed.

```yaml
Type: System.DateTime
Parameter Sets: CalculateExpanded
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
Parameter Sets: CalculateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Represent the term of reservation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationTerm
Parameter Sets: CalculateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IPurchaseRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICalculatePriceResponseProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IPurchaseRequest>`: The request for reservation purchase
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

## RELATED LINKS

