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