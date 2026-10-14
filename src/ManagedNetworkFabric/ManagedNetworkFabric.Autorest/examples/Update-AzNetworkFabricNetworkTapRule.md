### Example 1: Update the Network Tap Rule
```powershell
Update-AzNetworkFabricNetworkTapRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkTapRules/example-taprule
```

This command updates the properties of the given Network Tap Rule.
