### Example 1: Add an alert to an issue
```powershell
$alerts = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-001"
        Relevance = "Relevant"
        AddedAt = (Get-Date "2026-05-07T18:01:00Z")
        OriginAddedBy = "ops@contoso.com"
        OriginAddedByType = "User"
    }
)
Add-AzMonitorWorkspaceIssueAlert -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $alerts
```

```output
Id                                                                                                 Relevance
--                                                                                                 ---------
/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.AlertsManagement/alerts/alert-001 Relevant
```

Adds a related alert to issue-001.
