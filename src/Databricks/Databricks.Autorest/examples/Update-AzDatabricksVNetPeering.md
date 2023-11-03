### Example 1: Update AllowForwardedTraffic of vnet peering.
```powershell
Update-AzDatabricksVNetPeering -Name vnet-peering-t1 -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -AllowForwardedTraffic $True
```

```output
Name            ResourceGroupName
----            -----------------
vnet-peering-t1 azps_test_gp_db
```

This command updates AllowForwardedTraffic of vnet peering.

### Example 2: Update AllowForwardedTraffic of vnet peering by object.
```powershell
Get-AzDatabricksVNetPeering -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -Name vnet-peering-t1 | Update-AzDatabricksVNetPeering -AllowGatewayTransit $true
```

```output
Name            ResourceGroupName
----            -----------------
vnet-peering-t1 azps_test_gp_db
```

This command updates AllowForwardedTraffic of vnet peering by object.