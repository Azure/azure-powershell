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
