### Example 1: List Network Bootstrap Interfaces
```powershell
Get-AzNetworkFabricNetworkBootstrapInterface -NetworkBootstrapDeviceName $networkBootstrapDeviceName -ResourceGroupName $resourceGroupName
```

```output
Id Name
-- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device/networkBootstrapInterfaces/example-interface example-interface
```

This command lists all the Network Bootstrap Interfaces for the given Network Bootstrap Device.

### Example 2: Get Network Bootstrap Interface
```powershell
Get-AzNetworkFabricNetworkBootstrapInterface -Name $name -NetworkBootstrapDeviceName $networkBootstrapDeviceName -ResourceGroupName $resourceGroupName
```

```output
Id Name
-- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device/networkBootstrapInterfaces/example-interface example-interface
```

This command gets details of the given Network Bootstrap Interface.

