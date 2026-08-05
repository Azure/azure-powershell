### Example 1: Update an issue in a workspace
```powershell
Update-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001 -Severity "Critical" -Status "Mitigated" -Title "CPU spike on frontend cluster mitigated"
```

```output
Name      Severity Status    ProvisioningState Title
----      -------- ------    ----------------- -----
issue-001 Critical Mitigated Succeeded         CPU spike on frontend cluster mitigated
```

Updates the severity and status of issue-001.
