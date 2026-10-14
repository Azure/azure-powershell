### Example 1: Update the L2 Isolation Domain
```powershell
Update-AzNetworkFabricL2IsolationDomain -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/l2IsolationDomains/example-l2domain
```

This command updates the properties of the given L2 Isolation Domain.
