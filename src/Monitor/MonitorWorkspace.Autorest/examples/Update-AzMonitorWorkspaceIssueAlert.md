### Example 1: Update the alerts for an issue
```powershell
$alerts = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-001"
        Relevance = "Relevant"
    },
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-002"
        Relevance = "Relevant"
    }
)
Update-AzMonitorWorkspaceIssueAlert -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $alerts
```

```output
Id                                                                                                 Relevance
--                                                                                                 ---------
/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-001 Relevant
/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-002 Relevant
```

Replaces the related alerts for issue-001.
