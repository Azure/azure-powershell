### Example 1: Update diagnostic setting for current subscription
```powershell
$log = New-AzDiagnosticSettingSubscriptionLogSettingsObject -Category Recommendation -Enabled $true
Update-AzSubscriptionDiagnosticSetting -Name settingname -WorkspaceId 'workspaceid' -Log $log
```

These command update diagnostic setting for current subscription.

