### Example 1: List all Settings
```powershell
PS C:\> Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Settings under a Microsoft Sentinel workspace.

### Example 2: Get a Setting
```powershell
PS C:\> Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -SettingsName "Anomalies"

{{ Add output here }}
```

This command gets a Setting.

### Example 3: Get a Setting by object Id
```powershell
PS C:\> $Settings = Get-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $Settings[0] | Get-AzSentinelSetting

{{ Add output here }}
```

This command gets a Setting by object