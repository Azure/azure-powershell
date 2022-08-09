### Example 1: Update the Anomalies setting
```powershell
 Update-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -SettingsName 'Anomalies' -Enabled
```

This command updates the Anomalies setting, other settings are:
EyesOn, EntityAnalytics and Ueba

