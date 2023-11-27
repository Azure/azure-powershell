### Example 1: Create a vnet peering for databricks.
```powershell
New-AzDatabricksVNetPeering -Name vnet-peering-t1 -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -RemoteVirtualNetworkId '/subscriptions/{subId}/resourceGroups/azps_test_gp_db/providers/Microsoft.Network/virtualNetworks/azps-VNnet-t1'
```

```output
Name            ResourceGroupName
----            -----------------
vnet-peering-t1 azps_test_gp_db
```

This command creates a vnet peering for databricks.