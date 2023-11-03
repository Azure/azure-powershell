### Example 1: List all Settings
```powershell
 Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Kind      : EntityAnalytics
Name      : EntityAnalytics
IsEnabled : True

Kind      : EyesOn
Name      : EyesOn
IsEnabled : True

Kind : IPSyncer
Name : IPSyncer

Kind      : Anomalies
Name      : Anomalies
IsEnabled : True

Kind       : Ueba
Name       : Ueba
DataSource : {AuditLogs, AzureActivity, SecurityEvent, SigninLogs}
```

This command lists all Settings under a Microsoft Sentinel workspace.

### Example 2: Get a Setting
```powershell
 Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -SettingsName "Anomalies"
```
```output
Kind      : Anomalies
Name      : Anomalies
IsEnabled : True
```

This command gets a Setting.

### Example 3: Get a Setting by object Id
```powershell
 $Settings = Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $Settings[0] | Get-AzSentinelSetting
```
```output
Kind      : Anomalies
Name      : Anomalies
IsEnabled : True
```

This command gets a Setting by object