### Example 1: Delete a Grafana integration fabric
```powershell
Remove-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

Deletes the specified integration fabric from the Azure Managed Grafana workspace.

### Example 2: Delete a Grafana integration fabric using pipeline input
```powershell
Get-AzGrafanaIntegrationFabric -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Name fabric-integration2 | Remove-AzGrafanaIntegrationFabric
```

Deletes the integration fabric by piping the object from Get-AzGrafanaIntegrationFabric.

