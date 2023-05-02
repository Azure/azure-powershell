### Example 1: Create a vnet peering for databricks
```powershell
New-AzDatabricksVNetPeering -Name vnetpeering-t01 -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -RemoteVirtualNetworkId '/subscriptions/xxxxxx-xxxx-xxx-xxx/resourceGroups/azure-manual-test/providers/Microsoft.Network/virtualNetworks/vnet-test01'
```

```output
Name            Type
----            ----
vnetpeering-t01
```

This command creates a vnet peering for databricks.
