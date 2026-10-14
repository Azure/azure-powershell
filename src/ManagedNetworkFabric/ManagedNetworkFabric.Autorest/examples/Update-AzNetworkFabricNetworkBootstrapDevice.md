### Example 1: Update the Network Bootstrap Device
```powershell
Update-AzNetworkFabricNetworkBootstrapDevice -Name $name -ResourceGroupName $resourceGroupName -SerialNumber $serialNumber
```

```output
Id Location Name
-- -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkBootstrapDevices/example-device EastUs example-device
```

This command updates the properties of the given Network Bootstrap Device.
