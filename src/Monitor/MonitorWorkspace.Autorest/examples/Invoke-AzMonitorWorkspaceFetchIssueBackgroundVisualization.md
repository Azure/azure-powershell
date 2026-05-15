### Example 1: Fetch the background visualization for an issue
```powershell
Invoke-AzMonitorWorkspaceFetchIssueBackgroundVisualization -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001
```

```output
Visualization
-------------
{"type":"AdaptiveCard","version":"1.5","body":[{"type":"TextBlock","text":"CPU spike on frontend cluster"}]}
```

Fetches the background visualization for issue-001.
