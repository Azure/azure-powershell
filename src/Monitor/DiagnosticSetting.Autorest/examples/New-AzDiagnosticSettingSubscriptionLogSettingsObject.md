### Example 1: Create subscription log setting object
```powershell
New-AzDiagnosticSettingSubscriptionLogSettingsObject -Category Recommendation -Enabled $true
```

Create subscription log setting object, to get supported categories for resource, please see `Get-AzEventCategory`