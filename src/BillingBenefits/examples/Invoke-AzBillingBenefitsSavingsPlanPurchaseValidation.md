## EXAMPLES

### Example 1: Validate savings plan purchase(expended).
```powershell
$model = @{
    SkuName = "Compute_Savings_Plan"
    DisplayName = "MockName"
    Term = "P1Y"
    AppliedScopeType = "Shared"
    BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
    CommitmentGrain = "Hourly"
    CommitmentAmount = 0.01
    CommitmentCurrencyCode = "USD"
}

$models = @($model)

Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation -Benefit $models
```

```output
Valid ReasonCode Reason
----- ---------- ------
True
```

Validate savings plan purchase(expended).

### Example 2: Validate savings plan purchase.
```powershell
Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation -Body $body
```

```output
Valid ReasonCode Reason
----- ---------- ------
True
```

Validate savings plan purchase.
