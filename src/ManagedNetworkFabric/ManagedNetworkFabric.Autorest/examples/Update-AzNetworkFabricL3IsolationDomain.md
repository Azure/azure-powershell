### Example 1: Update the L3 Isolation Domain
```powershell
Update-AzNetworkFabricL3IsolationDomain -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/example-l3domain
```

This command updates the properties of the given L3 Isolation Domain.
