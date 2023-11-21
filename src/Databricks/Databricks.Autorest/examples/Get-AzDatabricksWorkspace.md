### Example 1: Get a Databricks workspace with name.
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t3
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

This command gets a Databricks workspace in a resource group.

### Example 2: List all Databricks workspaces in a subscription.
```powershell
Get-AzDatabricksWorkspace
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t1 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t1
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

This command lists all Databricks workspaces in a subscription.

### Example 3: List all Databricks workspaces in a resource group.
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t1 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t1
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

This command lists all Databricks workspaces in a resource group.