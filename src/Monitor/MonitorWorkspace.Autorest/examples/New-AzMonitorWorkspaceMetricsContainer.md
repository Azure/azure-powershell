### Example 1: Create a metrics container in a workspace
```powershell
New-AzMonitorWorkspaceMetricsContainer -AzureMonitorWorkspaceName azps-monitor-workspace -ResourceGroupName azps_test_group -Name metrics-container-001 -Version "v2"
```

```output
Name                  ProvisioningState Version
----                  ----------------- -------
metrics-container-001 Succeeded         v2
```

Creates metrics-container-001 in the workspace.
