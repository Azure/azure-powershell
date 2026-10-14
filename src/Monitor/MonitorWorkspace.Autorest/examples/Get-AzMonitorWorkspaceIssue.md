### Example 1: List issues in a workspace
```powershell
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Lists issues in the workspace.

### Example 2: Get a specific issue from a workspace
```powershell
Get-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Gets issue-001 from the workspace.
