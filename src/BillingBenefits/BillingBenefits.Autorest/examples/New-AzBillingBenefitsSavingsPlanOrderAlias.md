### Example 1: Create a savings plan
```powershell
New-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest1" -AppliedScopeType "Shared" -BillingPlan "P1M" `
-BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -CommitmentAmount 0.001 -CommitmentCurrencyCode "USD" -CommitmentGrain "Hourly" -SkuName "Compute_Savings_Plan" -DisplayName "PSTest199" -Term "P3Y"
```

```output
Name    DisplayName SkuName              CommitmentAmount CommitmentCurrencyCode CommitmentGrain SavingsPlanOrderId                                                                          ProvisioningState BillingScopeId
----    ----------- -------              ---------------- ---------------------- --------------- ------------------                                                                          ----------------- --------------
PSTest1 PSTest1     Compute_Savings_Plan 0.001            USD                    Hourly          /providers/Microsoft.BillingBenefits/savingsPlanOrders/955e24a7-6672-4038-9961-619a75c2acf4 Created           /subscriptions/eef82110-c91b-4395-9420…
```

Create a savings plan