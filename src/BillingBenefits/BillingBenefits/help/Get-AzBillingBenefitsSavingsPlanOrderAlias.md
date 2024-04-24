---
external help file: Az.BillingBenefits-help.xml
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/get-azbillingbenefitssavingsplanorderalias
schema: 2.0.0
---

# Get-AzBillingBenefitsSavingsPlanOrderAlias

## SYNOPSIS
Get a savings plan.

## SYNTAX

### Get (Default)
```
Get-AzBillingBenefitsSavingsPlanOrderAlias -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBenefitsSavingsPlanOrderAlias -InputObject <IBillingBenefitsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a savings plan.

## EXAMPLES

### Example 1: Get a savings plan order alias.
```powershell
Get-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest2"
```

```output
Name    DisplayName SkuName              CommitmentAmount CommitmentCurrencyCode CommitmentGrain SavingsPlanOrderId
----    ----------- -------              ---------------- ---------------------- --------------- ------------------
PSTest2 PSTest2     Compute_Savings_Plan 0.001            USD                    Hourly          /providers/Microsoft.BillingBenefits/savingsPlanOrders/ae177258-5b5c-4027-b46a-2d79d1…
```

Get a savings plan order alias.

### Example 2: Get a savings plan order alias via identity.
```powershell
$identity = @{
                        SavingsPlanOrderAliasName = "PSTest2"
}

$response = Get-AzBillingBenefitsSavingsPlanOrderAlias -InputObject $identity
```

```output
Name    DisplayName SkuName              CommitmentAmount CommitmentCurrencyCode CommitmentGrain SavingsPlanOrderId
----    ----------- -------              ---------------- ---------------------- --------------- ------------------
PSTest2 PSTest2     Compute_Savings_Plan 0.001            USD                    Hourly          /providers/Microsoft.BillingBenefits/savingsPlanOrders/ae177258-5b5c-4027-b46a-2d79d1…
```

Get a savings plan order alias via identity.

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

### -Name
Name of the savings plan order alias

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SavingsPlanOrderAliasName

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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.ISavingsPlanOrderAliasModel

## NOTES

## RELATED LINKS
