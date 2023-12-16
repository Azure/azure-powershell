### Example 1: Update the Anomalies setting
```powershell
 Update-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -SettingsName "Anomalies" -Enabled $true
```

This command updates the Anomalies setting, other settings are: EyesOn, EntityAnalytics and Ueba

