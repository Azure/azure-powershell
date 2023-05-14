### Example 1: Gets the list of endpoints that VNET Injected Workspace calls Azure Databricks Control Plane.
```powershell
Get-AzDatabricksOutboundNetworkDependenciesEndpoint -ResourceGroupName azps_test_gp_db -WorkspaceName azps-databricks-workspace-t2
```

```output
Category
--------
Webapp
Control Plane NAT
Extended infrastructure
Azure Storage
Azure My SQL
Azure Servicebus
```

This command gets the list of endpoints that VNET Injected Workspace calls Azure Databricks Control Plane.
You must configure outbound access with these endpoints.
For more information, see https://learn.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/udr