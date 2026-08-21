### Example 1: Update the Internet Gateway Rule
```powershell
Update-AzNetworkFabricInternetGatewayRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/internetGatewayRules/example-rule
```

This command updates the properties of the given Internet Gateway Rule.
