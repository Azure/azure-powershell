### Example 1: Create an AzureMonitorWorkspaceIntegration for Grafana.
```powershell
New-AzGrafanaMonitorWorkspaceIntegrationObject -AzureMonitorWorkspaceResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/microsoft.monitor/accounts/myAzureMonitorWorkspace"
```

```output
AzureMonitorWorkspaceResourceId
-------------------------------
/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/microsoft.monitor/accounts/myAzureMonitorWorkspace
```

Create an AzureMonitorWorkspaceIntegration for Grafana.