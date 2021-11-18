### Example 1: List all Alert Rule Templates
```powershell
PS C:\> Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule Template
```powershell
PS C:\> Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myRuleTemplateId"

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command gets an Alert Rule Template.

### Example 3: Get an Alert Rule Template by object Id
```powershell
PS C:\> $template = Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $template[0] | Get-AzSentinelAlertRuleTemplate

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command gets an Alert Rule Template by object