### Example 1: Create a savings plan
```powershell
<<<<<<< HEAD
New-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest1" -AppliedScopeType "Shared" -BillingPlan "P1M" 
=======
New-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest1" -AppliedScopeType "Shared" -BillingPlan "P1M" `
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
-BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -CommitmentAmount 0.001 -CommitmentCurrencyCode "USD" -CommitmentGrain "Hourly" -SkuName "Compute_Savings_Plan" -DisplayName "PSTest199" -Term "P3Y"
```

```output
Name    DisplayName SkuName              CommitmentAmount CommitmentCurrencyCode CommitmentGrain SavingsPlanOrderId                                                                          ProvisioningState BillingScopeId
----    ----------- -------              ---------------- ---------------------- --------------- ------------------                                                                          ----------------- --------------
PSTest1 PSTest1     Compute_Savings_Plan 0.001            USD                    Hourly          /providers/Microsoft.BillingBenefits/savingsPlanOrders/955e24a7-6672-4038-9961-619a75c2acf4 Created           /subscriptions/eef82110-c91b-4395-9420…
```

Create a savings plan