### Example 1: Update a metrics container
```powershell
Update-AzMonitorWorkspaceMetricsContainer -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name metrics-container-001 -Version "v3"
```

```output
Name                  ProvisioningState Version
----                  ----------------- -------
metrics-container-001 Succeeded         v3
```

Updates metrics-container-001 in the workspace.
