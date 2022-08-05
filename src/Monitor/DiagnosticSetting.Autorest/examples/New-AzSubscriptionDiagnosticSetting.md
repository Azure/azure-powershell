### Example 1: Create diagnostic setting for current subscription
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
$log = @()
$log += New-AzSubscriptionLogSettingsObject -Category Recommendation $Enabled $true
New-AzsubscriptionDiagnosticSetting -Name test-setting -WorkspaceId /subscriptions/$subscriptionId/resourcegroups/test-rg-name/providers/microsoft.operationalinsights/workspaces/test-workspace -Log $log
```

Create diagnostic setting for current subscription

