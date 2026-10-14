### Example 1: Create an issue in a workspace
```powershell
New-AzMonitorWorkspaceIssue -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name issue-001 -Title "CPU spike on frontend cluster" -Severity "High" -Status "Active" -ImpactTime (Get-Date "2026-05-07T18:00:00Z") -BackgroundType "markdown" -BackgroundText "CPU usage exceeded 95% on the frontend cluster."
```

```output
Name      Severity Status ProvisioningState Title
----      -------- ------ ----------------- -----
issue-001 High     Active Succeeded         CPU spike on frontend cluster
```

Creates issue-001 in the workspace.
