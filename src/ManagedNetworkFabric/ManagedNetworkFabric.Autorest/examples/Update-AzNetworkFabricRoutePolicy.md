### Example 1: Update the Route Policy
```powershell
$statement = @(@{
    Action = @{ LocalPreference = 20; ActionType = "Permit" }
    SequenceNumber = 1
})
Update-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Statement $statement
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/routePolicies/example-policy
```

This command updates the properties of the given Route Policy.
