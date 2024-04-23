---
external help file: Az.BillingBenefits-help.xml
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/get-azbillingbenefitssavingsplanlist
schema: 2.0.0
---

# Get-AzBillingBenefitsSavingsPlanList

## SYNOPSIS
List savings plans.

## SYNTAX

```
Get-AzBillingBenefitsSavingsPlanList [-Filter <String>] [-Orderby <String>] [-RefreshSummary <String>]
 [-SelectedState <String>] [-Skiptoken <Single>] [-Take <Single>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List savings plans.

## EXAMPLES

### Example 1: List savings plans.
```powershell
Get-AzBillingBenefitsSavingsPlanList
```

```output
Name                                 Status    ExpiryDate             PurchaseDate           Term Scope           AppliedScopeDisplayName  ProductName          CommitmentAmount CommitmentCurrencyCode
----                                 ------    ----------             ------------           ---- -----           -----------------------  -----------          ---------------- ------------------
Compute_SavingsPlan_11-30-2022_15-19 Succeeded 11/30/2023 11:22:53 PM 11/30/2022 11:19:31 PM P1Y  Shared                                   Compute_Savings_Plan 0.001            USD
PSTesth1234                          Succeeded 11/30/2025 12:36:25 AM 11/30/2022 12:34:31 AM P3Y  Shared                                   Compute_Savings_Plan 0.001            USD
PSTesth123                           Succeeded 11/29/2025 2:51:18 AM  11/29/2022 2:49:24 AM  P3Y  Shared                                   Compute_Savings_Plan 0.001            USD
PSTesth12                            Succeeded 11/29/2025 2:48:30 AM  11/29/2022 2:46:45 AM  P3Y  Shared                                   Compute_Savings_Plan 0.001            USD
PSTesth1                             Succeeded 11/29/2025 2:45:28 AM  11/29/2022 2:43:36 AM  P3Y  Shared                                   Compute_Savings_Plan 0.001            USD
PSTesth                              Succeeded 11/29/2025 2:42:49 AM  11/29/2022 2:41:03 AM  P3Y  Shared                                   Compute_Savings_Plan 0.001            USD
```

List savings plans.

### Example 2: List savings plans with filtering condition.
```powershell
Get-AzBillingBenefitsSavingsPlanList -Filter "properties/userFriendlyAppliedScopeType eq 'Shared'"
```

```output
Name                                 Status    ExpiryDate             PurchaseDate           Term Scope  AppliedScopeDisplayName ProductName          CommitmentAmount CommitmentCurrencyCode
----                                 ------    ----------             ------------           ---- -----  ----------------------- -----------          ---------------- ------------------
Compute_SavingsPlan_11-30-2022_15-19 Succeeded 11/30/2023 11:22:53 PM 11/30/2022 11:19:31 PM P1Y  Shared                         Compute_Savings_Plan 0.001            USD
PSTesth1234                          Succeeded 11/30/2025 12:36:25 AM 11/30/2022 12:34:31 AM P3Y  Shared                         Compute_Savings_Plan 0.001            USD
PSTesth123                           Succeeded 11/29/2025 2:51:18 AM  11/29/2022 2:49:24 AM  P3Y  Shared                         Compute_Savings_Plan 0.001            USD
PSTesth12                            Succeeded 11/29/2025 2:48:30 AM  11/29/2022 2:46:45 AM  P3Y  Shared                         Compute_Savings_Plan 0.001            USD
PSTesth1                             Succeeded 11/29/2025 2:45:28 AM  11/29/2022 2:43:36 AM  P3Y  Shared                         Compute_Savings_Plan 0.001            USD
```

List savings plans with filtering condition.

## PARAMETERS

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

### -Filter
May be used to filter by reservation properties.
The filter supports 'eq', 'or', and 'and'.
It does not currently support 'ne', 'gt', 'le', 'ge', or 'not'.
Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}

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

### -Orderby
May be used to sort order by reservation properties.

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

### -RefreshSummary
To indicate whether to refresh the roll up counts of the savings plans group by provisioning states

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

### -SelectedState
The selected provisioning state

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

### -Skiptoken
The number of savings plans to skip from the list before returning results

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Take
To number of savings plans to return

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.ISavingsPlanModel

## NOTES

## RELATED LINKS
