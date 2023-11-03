### Example 1: Update an scheduled alert rule
```powershell
Update-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -ruleId "4a21e485-75ae-48b3-a7b9-e6a92bcfe434" -Query "SecurityAlert | take 2"
```

This command updates a scheduled alert rule

