### Example 1: Remove a vnet peering of databricks by name.
```powershell
Remove-AzDatabricksVNetPeering -Name vnet-peering-t1 -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db 
```

This command removes a vnet peering of databricks by name.

### Example 2: Remove a vnet peering of databricks by object.
```powershell
Get-AzDatabricksVNetPeering -Name vnet-peering-t1 -WorkspaceName azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db  | Remove-AzDatabricksVNetPeering
```

This command removes a vnet peering of databricks by object.