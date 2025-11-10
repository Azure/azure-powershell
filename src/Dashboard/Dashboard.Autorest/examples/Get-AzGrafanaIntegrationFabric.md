### Example 1: List all Grafana integration fabrics in a workspace
```powershell
Get-AzGrafanaIntegrationFabric -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
fabric-integration2 eastus   azpstest-gp
```

Lists all integration fabrics for the specified Azure Managed Grafana workspace.

### Example 2: Get a specific Grafana integration fabric
```powershell
Get-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Gets the properties of a specific integration fabric in an Azure Managed Grafana workspace.

