### Example 1: Get alerts for an issue
```powershell
Get-AzMonitorWorkspaceIssueAlert -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001
```

```output
Id                                                                                                 Relevance
--                                                                                                 ---------
/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-001 Relevant
```

Gets the related alerts for issue-001.
