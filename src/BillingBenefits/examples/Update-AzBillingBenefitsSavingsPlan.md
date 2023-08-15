### Example 1: Update savings plan property value
```powershell
Update-AzBillingBenefitsSavingsPlan -Id "f82fd820-f829-4022-8ba5-e3bf4ffc329b" -OrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11" -DisplayName "NewName"
```

```output
Name        Status    ExpiryDate            PurchaseDate          Term Scope  AppliedScopeDisplayName ProductName          CommitmentAmount CommitmentCurrency
----        ------    ----------            ------------          ---- -----  ----------------------- -----------          ---------------- ------------------
NewName Succeeded 10/25/2025 7:01:05 PM 10/25/2022 6:59:06 PM P3Y  Shared                         Compute_Savings_Plan 0.001            USD
```

Update savings plan property value
