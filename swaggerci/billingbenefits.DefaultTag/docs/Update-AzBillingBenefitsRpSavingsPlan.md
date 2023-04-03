---
external help file:
Module Name: Az.BillingBenefitsRp
online version: https://learn.microsoft.com/powershell/module/az.billingbenefitsrp/update-azbillingbenefitsrpsavingsplan
schema: 2.0.0
---

# Update-AzBillingBenefitsRpSavingsPlan

## SYNOPSIS
Update savings plan.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzBillingBenefitsRpSavingsPlan -Id <String> -OrderId <String>
 [-AppliedScopePropertiesDisplayName <String>] [-AppliedScopePropertiesManagementGroupId <String>]
 [-AppliedScopePropertiesResourceGroupId <String>] [-AppliedScopePropertiesSubscriptionId <String>]
 [-AppliedScopePropertiesTenantId <String>] [-AppliedScopeType <AppliedScopeType>]
 [-BillingPlan <BillingPlan>] [-BillingScopeId <String>] [-CommitmentAmount <Double>]
 [-CommitmentCurrencyCode <String>] [-CommitmentGrain <CommitmentGrain>] [-DisplayName <String>] [-Renew]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesDisplayName <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesManagementGroupId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesResourceGroupId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesSubscriptionId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesTenantId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopeType <AppliedScopeType>]
 [-RenewPropertiesPurchasePropertiesDisplayName <String>] [-RenewPropertiesPurchasePropertiesRenew]
 [-SkuName <String>] [-Term <Term>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzBillingBenefitsRpSavingsPlan -InputObject <IBillingBenefitsRpIdentity>
 [-AppliedScopePropertiesDisplayName <String>] [-AppliedScopePropertiesManagementGroupId <String>]
 [-AppliedScopePropertiesResourceGroupId <String>] [-AppliedScopePropertiesSubscriptionId <String>]
 [-AppliedScopePropertiesTenantId <String>] [-AppliedScopeType <AppliedScopeType>]
 [-BillingPlan <BillingPlan>] [-BillingScopeId <String>] [-CommitmentAmount <Double>]
 [-CommitmentCurrencyCode <String>] [-CommitmentGrain <CommitmentGrain>] [-DisplayName <String>] [-Renew]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesDisplayName <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesManagementGroupId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesResourceGroupId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesSubscriptionId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopePropertiesTenantId <String>]
 [-RenewPropertiesPurchasePropertiesAppliedScopeType <AppliedScopeType>]
 [-RenewPropertiesPurchasePropertiesDisplayName <String>] [-RenewPropertiesPurchasePropertiesRenew]
 [-SkuName <String>] [-Term <Term>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update savings plan.

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

### -AppliedScopePropertiesDisplayName
Display name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertiesManagementGroupId
Fully-qualified identifier of the management group where the benefit must be applied.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertiesResourceGroupId
Fully-qualified identifier of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertiesSubscriptionId
Fully-qualified identifier of the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopePropertiesTenantId
Tenant ID where the benefit is applied.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Support.AppliedScopeType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingPlan
Represents the billing plan in ISO 8601 format.
Required only for monthly billing plans.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Support.BillingPlan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingScopeId
Subscription that will be charged for purchasing the benefit

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommitmentAmount
.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommitmentCurrencyCode
The ISO 4217 3-letter currency code for the currency used by this purchase record.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommitmentGrain
Commitment grain.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Support.CommitmentGrain
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -DisplayName
Display name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
ID of the savings plan

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SavingsPlanId

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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrderId
Order ID of the savings plan

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SavingsPlanOrderId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -Renew
Setting this to true will automatically purchase a new benefit on the expiration date time.

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

### -RenewPropertiesPurchasePropertiesAppliedScopePropertiesDisplayName
Display name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesAppliedScopePropertiesManagementGroupId
Fully-qualified identifier of the management group where the benefit must be applied.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesAppliedScopePropertiesResourceGroupId
Fully-qualified identifier of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesAppliedScopePropertiesSubscriptionId
Fully-qualified identifier of the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesAppliedScopePropertiesTenantId
Tenant ID where the benefit is applied.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesAppliedScopeType
Type of the Applied Scope.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Support.AppliedScopeType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesDisplayName
Friendly name of the savings plan

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RenewPropertiesPurchasePropertiesRenew
Setting this to true will automatically purchase a new benefit on the expiration date time.

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

### -SkuName
Name of the SKU to be applied

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Term
Represent benefit term in ISO 8601 format.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Support.Term
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanModel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IBillingBenefitsRpIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationOrderAliasName <String>]`: Name of the reservation order alias
  - `[SavingsPlanId <String>]`: ID of the savings plan
  - `[SavingsPlanOrderAliasName <String>]`: Name of the savings plan order alias
  - `[SavingsPlanOrderId <String>]`: Order ID of the savings plan

## RELATED LINKS

