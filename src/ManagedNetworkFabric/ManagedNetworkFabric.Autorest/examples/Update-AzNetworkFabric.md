### Example 1: Update the Network Fabric
```powershell
Update-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState FabricAsn FabricVersion Id
---------- ------------------ --------- ------------- --
           Succeeded          65048     1.0           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric
```

This command updates the properties of the given Network Fabric.
