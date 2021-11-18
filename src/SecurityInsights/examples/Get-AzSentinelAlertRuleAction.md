### Example 1: List all Actions for a given Alert Rule
```powershell
PS C:\> Get-AzSentinelAlertRuleAction -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "myRuleId"

Etag                                   Id
----                                   --
"0400363c-0000-0300-0000-618daa370000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command lists all Actions for a given Alert Rule.

### Example 2: Get an Action for a given Alert Rule
```powershell
PS C:\> Get-AzSentinelAlertRuleAction -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "myRuleId" -Id "myActionId"

Etag                                   Id
----                                   --
"0400363c-0000-0300-0000-618daa370000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command gets an Action for a given Alert Rule.

### Example 3: Get an Action by object Id
```powershell
PS C:\> $actions = Get-AzSentinelAlertRuleAction -ResourceGroupName "myResourceGroupb5" -workspaceName "asptestk9wyb8" -RuleId "myRuleId" 
PS C:\> $actions[0] | Get-AzSentinelAlertRuleAction

Etag                                   Id
----                                   --
"0400363c-0000-0300-0000-618daa370000" /subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup…
```

This command gets an Action by object

