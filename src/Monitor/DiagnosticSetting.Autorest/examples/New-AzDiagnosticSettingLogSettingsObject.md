### Example 1: Create log setting object
```powershell
New-AzDiagnosticSettingLogSettingsObject -Enabled $true -Category ContainerEventLogs -RetentionPolicyDay 7 -RetentionPolicyEnabled $true
```

Create log setting object, to get supported categories for resource, please see `Get-AzDiagnosticSettingCategory`