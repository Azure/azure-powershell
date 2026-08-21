### Example 1: Update the Network Bootstrap Interface
```powershell
Update-AzNetworkFabricNetworkBootstrapInterface -Name $name -NetworkBootstrapDeviceName $networkBootstrapDeviceName -ResourceGroupName $resourceGroupName
```

```output
Id Name
-- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device/networkBootstrapInterfaces/example-interface example-interface
```

This command updates the properties of the given Network Bootstrap Interface.
