### Example 1: List all access connectors under a subscription.
```powershell
Get-AzDatabricksAccessConnector
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command lists all access connectors under a subscription.

### Example 2: List all access connectors under a resource group.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command lists all access connectors under a resource group.

### Example 3: Get a access connectors by name.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command gets a access connectors by name.