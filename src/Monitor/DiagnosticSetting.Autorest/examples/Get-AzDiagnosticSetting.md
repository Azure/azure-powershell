### Example 1: List diagnostic settings
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
Get-AzDiagnosticSetting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001
```

List diagnostic settings for resource

### Example 2: Get diagnostic setting by name
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
Get-AzDiagnosticSetting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001 -Name test-setting
```

Get diagnostic settings under resource by name