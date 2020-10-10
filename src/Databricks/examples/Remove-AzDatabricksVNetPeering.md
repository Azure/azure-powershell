### Example 1: Remove a vnet peering of databricks by name
```powershell
PS C:\> Remove-AzDatabricksVNetPeering -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -Name vnetpeering-t01

```

This command removes a vnet peering of databricks by name

### Example 2: Remove a vnet peering of databricks by object
```powershell
PS C:\> Get-AzDatabricksVNetPeering -ResourceGroupName lucas-manual-test -WorkspaceName databricks-test01 -PeeringName MyPeering-test01 | Remove-AzDatabricksVNetPeering

```

This command removes a vnet peering of databricks by object

