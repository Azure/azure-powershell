### Example 1: Update an Internal Network
```powershell
Update-AzNetworkFabricInternalNetwork -Name $name -L3IsolationDomainName $l3IsolationDomainName -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/example-l3domain/internalNetworks/example-network
```

This command updates the properties of the given Internal Network.
