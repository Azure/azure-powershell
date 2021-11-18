### Example 1: List all Automation Rules
```powershell
PS C:\> Get-AzSentinelAutomationRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Automation Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Automation Rule
```powershell
PS C:\> Get-AzSentinelAutomationRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myAutomationRuleId"

{{ Add output here }}
```

This command gets an Automation Rule.

### Example 3: Get an Automation Rule by object Id
```powershell
PS C:\> $automationrules = Get-AzSentinelAutomationRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $automationrules[0] | Get-AzSentinelAutomationRule

{{ Add output here }}
```

This command gets an Automation Rule by object