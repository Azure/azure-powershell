### Example 1: List all Alert Rules
```powershell
 Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
AlertDisplayName : (Preview) TI map IP entity to SigninLogs
FriendlyName     : (Preview) TI map IP entity to SigninLogs
Description      : Identifies a match in SigninLogs from any IP IOC from TI
Kind             : SecurityAlert
Name             : d1e4d1dd-8d16-1aed-59bd-a256266d7244
ProductName      : Azure Sentinel
Status           : New
ProviderAlertId  : d6c7a42b-c0da-41ef-9629-b3d2d407b181
Tactic           : {Impact}
```

This command lists all Alert Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule
```powershell
 Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "d6c7a42b-c0da-41ef-9629-b3d2d407b181"
```
```output
AlertDisplayName : (Preview) TI map IP entity to SigninLogs
FriendlyName     : (Preview) TI map IP entity to SigninLogs
Description      : Identifies a match in SigninLogs from any IP IOC from TI
Kind             : SecurityAlert
Name             : d1e4d1dd-8d16-1aed-59bd-a256266d7244
ProductName      : Azure Sentinel
Status           : New
ProviderAlertId  : d6c7a42b-c0da-41ef-9629-b3d2d407b181
Tactic           : {Impact}
```

This command gets an Alert Rule.

### Example 3: Get an Alert Rule by object Id
```powershell
 $rules = Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $rules[0] | Get-AzSentinelAlertRule
```
```output
AlertDisplayName : (Preview) TI map IP entity to SigninLogs
FriendlyName     : (Preview) TI map IP entity to SigninLogs
Description      : Identifies a match in SigninLogs from any IP IOC from TI
Kind             : SecurityAlert
Name             : d1e4d1dd-8d16-1aed-59bd-a256266d7244
ProductName      : Azure Sentinel
Status           : New
ProviderAlertId  : d6c7a42b-c0da-41ef-9629-b3d2d407b181
Tactic           : {Impact}
```

This command gets an Alert Rule by object