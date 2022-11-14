---
external help file:
Module Name: Az.BillingBenefitsRp
online version: https://docs.microsoft.com/en-us/powershell/module/az.billingbenefitsrp/test-azbillingbenefitsrpsavingsplanpurchase
schema: 2.0.0
---

# Test-AzBillingBenefitsRpSavingsPlanPurchase

## SYNOPSIS
Validate savings plan purchase.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzBillingBenefitsRpSavingsPlanPurchase [-Benefit <ISavingsPlanOrderAliasModel[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzBillingBenefitsRpSavingsPlanPurchase -Body <ISavingsPlanPurchaseValidateRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate savings plan purchase.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanOrderAliasModel[]
Parameter Sets: ValidateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanPurchaseValidateRequest
Parameter Sets: Validate
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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanPurchaseValidateRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanValidateResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BENEFIT <ISavingsPlanOrderAliasModel[]>`: .
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[AppliedScopePropertyDisplayName <String>]`: Display name
  - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
  - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
  - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
  - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
  - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
  - `[AzureAsyncOperation <String>]`: 
  - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
  - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing SavingsPlan
  - `[CommitmentAmount <Double?>]`: 
  - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
  - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
  - `[DisplayName <String>]`: Display name
  - `[Kind <String>]`: Resource provider kind
  - `[RetryAfter <Int32?>]`: 
  - `[SkuName <String>]`: Name of the SKU to be applied
  - `[Term <SavingsPlanTerm?>]`: Represent SavingsPlan term in ISO 8601 format.

`BODY <ISavingsPlanPurchaseValidateRequest>`: .
  - `[Benefit <ISavingsPlanOrderAliasModel[]>]`: 
    - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
    - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
    - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
    - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
    - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
    - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
    - `[AppliedScopePropertyDisplayName <String>]`: Display name
    - `[AppliedScopePropertyManagementGroupId <String>]`: Fully-qualified identifier of the management group where the benefit must be applied.
    - `[AppliedScopePropertyResourceGroupId <String>]`: Fully-qualified identifier of the resource group.
    - `[AppliedScopePropertySubscriptionId <String>]`: Fully-qualified identifier of the subscription.
    - `[AppliedScopePropertyTenantId <String>]`: Tenant ID where the savings plan should apply benefit.
    - `[AppliedScopeType <AppliedScopeType?>]`: Type of the Applied Scope.
    - `[AzureAsyncOperation <String>]`: 
    - `[BillingPlan <BillingPlan?>]`: Represents the billing plan in ISO 8601 format. Required only for monthly billing plans.
    - `[BillingScopeId <String>]`: Subscription that will be charged for purchasing SavingsPlan
    - `[CommitmentAmount <Double?>]`: 
    - `[CommitmentCurrencyCode <String>]`: The ISO 4217 3-letter currency code for the currency used by this purchase record.
    - `[CommitmentGrain <CommitmentGrain?>]`: Commitment grain.
    - `[DisplayName <String>]`: Display name
    - `[Kind <String>]`: Resource provider kind
    - `[RetryAfter <Int32?>]`: 
    - `[SkuName <String>]`: Name of the SKU to be applied
    - `[Term <SavingsPlanTerm?>]`: Represent SavingsPlan term in ISO 8601 format.

## RELATED LINKS

