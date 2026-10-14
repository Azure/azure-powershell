### Example 1: Add a resource to an issue
```powershell
$resources = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01"
        Relevance = "Relevant"
        AddedAt = (Get-Date "2026-05-07T18:02:00Z")
        OriginAddedBy = "ops@contoso.com"
        OriginAddedByType = "User"
    }
)
Add-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $resources
```

```output
Id                                                                                                                                  Relevance
--                                                                                                                                  ---------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01 Relevant
```

Adds a related resource to issue-001.
