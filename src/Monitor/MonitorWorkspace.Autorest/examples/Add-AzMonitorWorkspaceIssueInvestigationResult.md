### Example 1: Add an investigation result to an issue
```powershell
Add-AzMonitorWorkspaceIssueInvestigationResult -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Id inv-001 -Result "CPU saturation correlated with deployment ring 2." -CreatedAt (Get-Date "2026-05-07T18:05:00Z") -LastModifiedAt (Get-Date "2026-05-07T18:10:00Z") -OriginAddedBy "ops@contoso.com" -OriginAddedByType "User"
```

```output
Id      CreatedAt             LastModifiedAt        Result
--      ---------             --------------        ------
inv-001 5/7/2026 6:05:00 PM   5/7/2026 6:10:00 PM   CPU saturation correlated with deployment ring 2.
```

Adds an investigation result to issue-001.
