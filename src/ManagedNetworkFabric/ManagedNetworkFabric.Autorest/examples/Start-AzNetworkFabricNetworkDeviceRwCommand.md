### Example 1: Run a read-write command on a Network Device
```powershell
Start-AzNetworkFabricNetworkDeviceRwCommand -NetworkDeviceName $networkDeviceName -ResourceGroupName $resourceGroupName -Command $command -CommandUrl $commandUrl
```

This command runs a read-write CLI command on the given Network Device.
