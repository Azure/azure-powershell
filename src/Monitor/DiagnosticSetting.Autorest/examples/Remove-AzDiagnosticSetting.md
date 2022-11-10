### Example 1: Remove DiagnosticSetting by name
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
Remove-AzDiagnosticSetting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001 -Name test-setting
```

Remove DiagnosticSetting by name