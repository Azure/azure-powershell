### Example 1: Update the Access Control List
```powershell
Update-AzNetworkFabricAccessControlList -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState ConfigurationType Id
---------- ------------------ ----------------- --
           Succeeded          File              /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/accessControlLists/example-acl
```

This command updates the properties of the given Access Control List.
