### Example 1: Create a new Grafana integration fabric
```powershell
New-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Location eastus -Tag @{"Environment"="Production"}
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Creates a new integration fabric for an Azure Managed Grafana workspace.

### Example 2: Create a Grafana integration fabric with scenarios
```powershell
New-AzGrafanaIntegrationFabric -Name fabric-integration2 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana -Location eastus -Scenario @("DataExploration")
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration2 eastus   azpstest-gp
```

Creates a new integration fabric for the Grafana workspace with specified scenarios.

