### Example 1: Get resources for an issue
```powershell
Get-AzMonitorWorkspaceIssueResource -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -IssueName issue-001
```

```output
Id                                                                                                                                  Relevance
--                                                                                                                                  ---------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azps_test_group/providers/Microsoft.Compute/virtualMachines/vm-app-01 Relevant
```

Gets the related resources for issue-001.
