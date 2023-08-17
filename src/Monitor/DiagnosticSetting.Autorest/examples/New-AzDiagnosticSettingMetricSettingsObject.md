### Example 1: Create metric setting object
```powershell
New-AzDiagnosticSettingMetricSettingsObject -Enabled $true -Category AllMetrics -RetentionPolicyDay 7 -RetentionPolicyEnabled $true
```

Create metric setting object, to get supported categories for resource, please see `Get-AzDiagnosticSettingCategory`