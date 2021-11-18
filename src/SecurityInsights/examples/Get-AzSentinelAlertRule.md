### Example 1: List all Alert Rules
```powershell
PS C:\> Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

Etag                                   Id
----                                   --
"fa015769-0000-0100-0000-618d3f570000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
"fa015969-0000-0100-0000-618d3f570000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
"fa015b69-0000-0100-0000-618d3f580000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command lists all Alert Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule
```powershell
PS C:\> Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "myRuleId"

Etag                                   Id
----                                   --
"0102eeea-0000-0100-0000-618dd65c0000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command gets an Alert Rule.

### Example 3: Get an Alert Rule by object Id
```powershell
PS C:\> $rules = Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $rules[0] | Get-AzSentinelAlertRule

Etag                                   Id
----                                   --
"fa015769-0000-0100-0000-618d3f570000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command gets an Alert Rule by object