### Example 1: Update the resources for an issue
```powershell
$resources = @(
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01"
        Relevance = "Relevant"
    },
    @{
        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Network/loadBalancers/lb-app-01"
        Relevance = "Relevant"
    }
)
Update-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001 -Value $resources
```

```output
Id                                                                                                                                     Relevance
--                                                                                                                                     ---------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01   Relevant
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Network/loadBalancers/lb-app-01     Relevant
```

Replaces the related resources for issue-001.
