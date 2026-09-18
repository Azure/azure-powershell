### Example 1: Delete an issue from a workspace
```powershell
Remove-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001
```

Deletes issue-001 from the workspace.

### Example 2: Delete an issue by using pipeline input
```powershell
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001 | Remove-AzMonitorWorkspaceIssue
```

Deletes issue-001 by piping the issue resource to the remove cmdlet.
