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
