### Example 1: List all vnet peering under a databricks.
```powershell
Get-AzDatabricksVNetPeering -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db
```

```output
Name            ResourceGroupName
----            -----------------
vnet-peering-t1 azps_test_gp_db
```

This command lists all vnet peering under a databricks.

### Example 2: Get a vnet peering.
```powershell
Get-AzDatabricksVNetPeering -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -Name vnet-peering-t1
```

```output
Name            ResourceGroupName
----            -----------------
vnet-peering-t1 azps_test_gp_db
```

This command gets a vnet peering.