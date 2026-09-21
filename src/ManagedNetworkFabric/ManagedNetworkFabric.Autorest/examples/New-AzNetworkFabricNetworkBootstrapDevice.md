### Example 1: Create the Network Bootstrap Device Resource
```powershell
New-AzNetworkFabricNetworkBootstrapDevice -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkDeviceSku $networkDeviceSku -SerialNumber $serialNumber
```

```output
Id Location Name
-- -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device EastUs example-device
```

This command creates the Network Bootstrap Device resource.
