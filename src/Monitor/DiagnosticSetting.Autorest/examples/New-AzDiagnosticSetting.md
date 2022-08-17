### Example 1: Create diagnostic setting
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
$metric = @()
$log = @()
$metric += New-AzDiagnosticSettingMetricSettingsObject -Enabled $true -Category AllMetrics -RetentionPolicyDay 7 -RetentionPolicyEnabled $true
$log += New-AzDiagnosticSettingLogSettingsObject -Enabled $true -Category ContainerEventLogs -RetentionPolicyDay 7 -RetentionPolicyEnabled $true
New-AzDiagnosticSetting -Name test-setting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001 -WorkspaceId /subscriptions/$subscriptionId/resourcegroups/test-rg-name/providers/microsoft.operationalinsights/workspaces/test-workspace -Log $log -Metric $metric
```

Create diagnostic setting for resource with log analytics workspace as destination

### Example 2: Create diagnostic setting for all supported categories
```powershell
$subscriptionId = (Get-AzContext).SubscriptionId
$metric = @()
$log = @()
$categories = Get-AzDiagnosticSettingCategory -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001
$categories | ForEach-Object {if($_.CategoryType -eq "Metrics"){$metrics+=New-AzDiagnosticSettingMetricSettingsObject -Enabled $true -Category $_.Name -RetentionPolicyDay 7 -RetentionPolicyEnabled $true} else{$logs+=New-AzDiagnosticSettingLogSettingsObject -Enabled $true -Category $_.Name -RetentionPolicyDay 7 -RetentionPolicyEnabled $true}}
New-AzDiagnosticSetting -Name test-setting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001 -WorkspaceId /subscriptions/$subscriptionId/resourcegroups/test-rg-name/providers/microsoft.operationalinsights/workspaces/test-workspace -Log $log -Metric $metric
```

Create diagnostic setting for all supported categories
