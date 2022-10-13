### Example 1: List supported diagnostic setting categories
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
Get-AzDiagnosticSettingCategory -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001
```

List supported diagnostic setting categories for resource