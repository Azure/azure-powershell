### Example 1: Update tags for a Grafana integration fabric
```powershell
Update-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Tag @{"Environment"="Production"; "Team"="DataEngineering"}
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Updates the tags of an existing integration fabric in the Azure Managed Grafana workspace.

### Example 2: Update scenarios for a Grafana integration fabric
```powershell
Update-AzGrafanaIntegrationFabric -Name fabric-integration2 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Scenario @("DataExploration", "Monitoring")
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration2 eastus   azpstest-gp
```

Updates the scenarios for an existing integration fabric to enable additional functionality.

