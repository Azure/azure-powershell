### Example 1: Fetch available Grafana plugins for a workspace
```powershell
Invoke-AzGrafanaFetchGrafanaAvailablePlugin -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                     Version   Description
----                     -------   -----------
grafana-azure-monitor    1.0.0     Azure Monitor data source
grafana-image-renderer   3.0.0     Image rendering plugin
...
```

Fetches the list of available Grafana plugins that can be installed in the specified Azure Managed Grafana workspace.

### Example 2: Fetch available plugins using pipeline input
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -Name azpstest-grafana | Invoke-AzGrafanaFetchGrafanaAvailablePlugin
```

```output
Name                     Version   Description
----                     -------   -----------
grafana-azure-monitor    1.0.0     Azure Monitor data source
grafana-image-renderer   3.0.0     Image rendering plugin
...
```

Fetches available Grafana plugins by piping a Grafana workspace object from Get-AzGrafana.

