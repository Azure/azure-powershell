### Example 1: Update diagnostic setting
```powershell
$newlog = New-AzDiagnosticSettingLogSettingsObject -Enabled $false -Category 'VMProtectionAlerts'
$newmetric = New-AzDiagnosticSettingMetricSettingsObject -Enabled $false -Category 'AllMetrics'
Update-AzDiagnosticSetting -Name diagnosticSettingName -ResourceId 'vnetId' -Log $newlog -Metric $newmetric
```

These commands update diagnostic setting for resource with log analytics workspace as destination.

