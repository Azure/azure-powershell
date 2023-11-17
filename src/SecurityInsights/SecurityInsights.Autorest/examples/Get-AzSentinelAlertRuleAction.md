### Example 1: List all Actions for a given Alert Rule
```powershell
 Get-AzSentinelAlertRuleAction -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "myRuleId"
```
```output
LogicAppResourceId : /subscriptions/174b1a81-c53c-4092-8d4a-7210f6a44a0c/resourceGroups/myResourceGroup/providers/Microsoft.Logic/workflows/A-Demo-1
Name               : f32239c5-cb9c-48da-a3f6-bd5bd3d924a4
WorkflowId         : 3c73d72560fa4cb6a72a0f10d3a80940

LogicAppResourceId : /subscriptions/274b1a41-c53c-4092-8d4a-7210f6a44a0c/resourceGroups/myResourceGroup/providers/Microsoft.Logic/workflows/EmptyPlaybook
Name               : cf815c77-bc65-4c02-946f-d81e15e9a100
WorkflowId         : 1ac8ccb8bd134253b4baf0c75fe3ecc6
```

This command lists all Actions for a given Alert Rule.
