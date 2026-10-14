### Example 1: Set the background visualization for an issue
```powershell
$visualization = '{"type":"AdaptiveCard","version":"1.5","body":[{"type":"TextBlock","text":"CPU spike on frontend cluster"}]}'
Set-AzMonitorWorkspaceIssueBackgroundVisualization -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Visualization $visualization -PassThru
```

```output
True
```

Sets the background visualization for issue-001.
