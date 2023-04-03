---
external help file:
Module Name: Az.BillingBenefitsRp
online version: https://learn.microsoft.com/powershell/module/az.billingbenefitsrp/test-azbillingbenefitsrpsavingplanupdate
schema: 2.0.0
---

# Test-AzBillingBenefitsRpSavingPlanUpdate

## SYNOPSIS
Validate savings plan patch.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzBillingBenefitsRpSavingPlanUpdate -SavingsPlanId <String> -SavingsPlanOrderId <String>
 [-Benefit <ISavingsPlanUpdateRequestProperties[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Validate
```
Test-AzBillingBenefitsRpSavingPlanUpdate -SavingsPlanId <String> -SavingsPlanOrderId <String>
 -Body <ISavingsPlanUpdateValidateRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzBillingBenefitsRpSavingPlanUpdate -InputObject <IBillingBenefitsRpIdentity>
 -Body <ISavingsPlanUpdateValidateRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzBillingBenefitsRpSavingPlanUpdate -InputObject <IBillingBenefitsRpIdentity>
 [-Benefit <ISavingsPlanUpdateRequestProperties[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Validate savings plan patch.

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

### -Benefit
.
To construct, see NOTES section for BENEFIT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanUpdateRequestProperties[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanUpdateValidateRequest
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SavingsPlanId
ID of the savings plan

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SavingsPlanOrderId
Order ID of the savings plan

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanUpdateValidateRequest

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanValidateResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BENEFIT <ISavingsPlanUpdateRequestProperties[]>`: .
  - `[AppliedScopePropertiesDisplayName <String>]`: Display name
  - `[AppliedScopePropertiesManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
  - `[AppliedScopePropertiesResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
  - `[AppliedScopePropertiesSubscriptionId <String>]`: Fully-qualified identifier of the subscription.
  - `[AppliedScopePropertiesTenantId <String>]`: Tenant ID where the benefit is applied.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing the benefit
  - `[CommitmentAmount <Double?>]`: 
  - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
  - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
  - `[DisplayName <String>]`: Display name
  - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new benefit on the expiration date time.
  - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesDisplayName <String>]`: Display name
  - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
  - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
  - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesSubscriptionId <String>]`: Fully-qualified identifier of the subscription.
  - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesTenantId <String>]`: Tenant ID where the benefit is applied.
  - `[RenewPropertiesPurchasePropertiesAppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[RenewPropertiesPurchasePropertiesDisplayName <String>]`: Friendly name of the savings plan
  - `[RenewPropertiesPurchasePropertiesRenew <Boolean?>]`: Setting this to true will automatically purchase a new benefit on the expiration date time.
  - `[SkuName <String>]`: Name of the SKU to be applied
  - `[Term <Term?>]`: Represent benefit term in ISO 8601 format.

`BODY <ISavingsPlanUpdateValidateRequest>`: .
  - `[Benefit <ISavingsPlanUpdateRequestProperties[]>]`: 
    - `[AppliedScopePropertiesDisplayName <String>]`: Display name
    - `[AppliedScopePropertiesManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
    - `[AppliedScopePropertiesResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
    - `[AppliedScopePropertiesSubscriptionId <String>]`: Fully-qualified identifier of the subscription.
    - `[AppliedScopePropertiesTenantId <String>]`: Tenant ID where the benefit is applied.
    - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
    - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing the benefit
    - `[CommitmentAmount <Double?>]`: 
    - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
    - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
    - `[DisplayName <String>]`: Display name
    - `[Renew <Boolean?>]`: Setting this to true will automatically purchase a new benefit on the expiration date time.
    - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesDisplayName <String>]`: Display name
    - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
    - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
    - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesSubscriptionId <String>]`: Fully-qualified identifier of the subscription.
    - `[RenewPropertiesPurchasePropertiesAppliedScopePropertiesTenantId <String>]`: Tenant ID where the benefit is applied.
    - `[RenewPropertiesPurchasePropertiesAppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[RenewPropertiesPurchasePropertiesDisplayName <String>]`: Friendly name of the savings plan
    - `[RenewPropertiesPurchasePropertiesRenew <Boolean?>]`: Setting this to true will automatically purchase a new benefit on the expiration date time.
    - `[SkuName <String>]`: Name of the SKU to be applied
    - `[Term <Term?>]`: Represent benefit term in ISO 8601 format.

`INPUTOBJECT <IBillingBenefitsRpIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationOrderAliasName <String>]`: Name of the reservation order alias
  - `[SavingsPlanId <String>]`: ID of the savings plan
  - `[SavingsPlanOrderAliasName <String>]`: Name of the savings plan order alias
  - `[SavingsPlanOrderId <String>]`: Order ID of the savings plan

## RELATED LINKS

