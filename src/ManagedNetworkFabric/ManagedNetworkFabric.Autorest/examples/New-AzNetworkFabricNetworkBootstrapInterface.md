### Example 1: Create the Network Bootstrap Interface Resource
```powershell
New-AzNetworkFabricNetworkBootstrapInterface -Name $name -NetworkBootstrapDeviceName $networkBootstrapDeviceName -ResourceGroupName $resourceGroupName
```

```output
Id Name
-- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device/networkBootstrapInterfaces/example-interface example-interface
```

This command creates the Network Bootstrap Interface resource.
