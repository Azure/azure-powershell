### Example 1: List Network Bootstrap Devices
```powershell
Get-AzNetworkFabricNetworkBootstrapDevice -ResourceGroupName $resourceGroupName
```

```output
Id Location Name
-- -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device EastUs example-device
```

This command lists all the Network Bootstrap Devices in the given resource group.

### Example 2: Get Network Bootstrap Device
```powershell
Get-AzNetworkFabricNetworkBootstrapDevice -Name $name -ResourceGroupName $resourceGroupName
```

```output
Id Location Name
-- -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device EastUs example-device
```

This command gets details of the given Network Bootstrap Device.

