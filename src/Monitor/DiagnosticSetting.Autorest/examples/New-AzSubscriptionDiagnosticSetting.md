### Example 1: Create diagnostic setting for current subscription
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
$log = @()
$log += New-AzDiagnosticSettingSubscriptionLogSettingsObject -Category Recommendation -Enabled $true
New-AzSubscriptionDiagnosticSetting -Name test-setting -WorkspaceId /subscriptions/$subscriptionId/resourcegroups/test-rg-name/providers/microsoft.operationalinsights/workspaces/test-workspace -Log $log
```

Create diagnostic setting for current subscription

