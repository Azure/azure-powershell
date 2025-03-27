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

### Example 3: List savings plans.
```powershell
Get-AzBillingBenefitsSavingsPlan
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

### Example 4: List savings plans with filtering condition.
```powershell
Get-AzBillingBenefitsSavingsPlan -Filter "properties/userFriendlyAppliedScopeType eq 'Shared'"
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