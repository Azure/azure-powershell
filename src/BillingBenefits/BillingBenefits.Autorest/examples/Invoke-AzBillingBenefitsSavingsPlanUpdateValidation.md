## EXAMPLES

### Example 1: Validate savings plan patch
```powershell
$model = @{
    AppliedScopeType = "Single"
    AppliedScopePropertiesSubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

$models = @($model)

$response = Invoke-AzBillingBenefitsSavingsPlanUpdateValidation -SavingsPlanId "9fde2a72-776b-49fc-869c-dca8859d7d62" -SavingsPlanOrderId "d7ea1620-2bba-46e2-8434-11f31bfb984d" -Benefit $models
```

```output
Valid ReasonCode Reason
----- ---------- ------
True
```

Validate savings plan patch
