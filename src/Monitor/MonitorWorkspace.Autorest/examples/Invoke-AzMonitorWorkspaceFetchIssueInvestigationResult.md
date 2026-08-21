### Example 1: Fetch an investigation result for an issue
```powershell
Invoke-AzMonitorWorkspaceFetchIssueInvestigationResult -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -InvestigationId inv-001
```

```output
Id      CreatedAt             LastModifiedAt        Result
--      ---------             --------------        ------
inv-001 5/7/2026 6:05:00 PM   5/7/2026 6:10:00 PM   CPU saturation correlated with deployment ring 2.
```

Fetches investigation result inv-001 for issue-001.
