### Example 1: Remove a vnet peering of databricks by name
```powershell
Remove-AzDatabricksVNetPeering -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -Name vnetpeering-t01
```

This command removes a vnet peering of databricks by name

### Example 2: Remove a vnet peering of databricks by object
```powershell
Get-AzDatabricksVNetPeering -ResourceGroupName lucas-manual-test -WorkspaceName databricks-test01 -Name MyPeering-test01 | Remove-AzDatabricksVNetPeering
```

This command removes a vnet peering of databricks by object

