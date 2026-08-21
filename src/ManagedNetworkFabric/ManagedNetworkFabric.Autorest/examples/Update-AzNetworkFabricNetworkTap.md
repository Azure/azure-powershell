### Example 1: Update the Network Tap
```powershell
Update-AzNetworkFabricNetworkTap -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkTaps/example-tap
```

This command updates the properties of the given Network Tap.
