---
external help file:
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/get-azbillingbenefitssavingsplan
schema: 2.0.0
---

# Get-AzBillingBenefitsSavingsPlan

## SYNOPSIS
Get savings plan.

## SYNTAX

### List (Default)
```
Get-AzBillingBenefitsSavingsPlan -OrderId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBillingBenefitsSavingsPlan -Id <String> -OrderId <String> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBenefitsSavingsPlan -InputObject <IBillingBenefitsIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get savings plan.

## EXAMPLES

### Example 1: List savings plan under a savings plan order
```powershell
Get-AzBillingBenefitsSavingsPlan -OrderId d7ea1620-2bba-46e2-8434-11f31bfb984d
```

```output
Name    Status    ExpiryDate            PurchaseDate          Term Scope  AppliedScopeDisplayName ProductName          CommitmentAmount CommitmentCurrencyCode
----    ------    ----------            ------------          ---- -----  ----------------------- -----------          ---------------- ------------------
PSTest7 Succeeded 11/29/2025 2:23:51 AM 11/29/2022 2:20:38 AM P3Y  Shared                         Compute_Savings_Plan 0.001            USD
```

List savings plan under a savings plan order

### Example 2: Get a single savings plan
```powershell
Get-AzBillingBenefitsSavingsPlan -OrderId d7ea1620-2bba-46e2-8434-11f31bfb984d -Id 9fde2a72-776b-49fc-869c-dca8859d7d62
```

```output
Name    Status    ExpiryDate            PurchaseDate          Term Scope  AppliedScopeDisplayName ProductName          CommitmentAmount CommitmentCurrencyCode
----    ------    ----------            ------------          ---- -----  ----------------------- -----------          ---------------- ------------------
PSTest7 Succeeded 11/29/2025 2:23:51 AM 11/29/2022 2:20:38 AM P3Y  Shared                         Compute_Savings_Plan 0.001            USD
```

Get a single savings plan

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

### -Expand
May be used to expand the detail information of some properties.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
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
Parameter Sets: Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
Aliases: SavingsPlanOrderId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.ISavingsPlanModel

## NOTES

## RELATED LINKS

