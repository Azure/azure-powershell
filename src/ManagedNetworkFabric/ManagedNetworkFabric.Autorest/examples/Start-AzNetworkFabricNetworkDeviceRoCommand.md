### Example 1: Run a read-only command on a Network Device
```powershell
Start-AzNetworkFabricNetworkDeviceRoCommand -NetworkDeviceName $networkDeviceName -ResourceGroupName $resourceGroupName -Command $command
```

This command runs a read-only CLI command on the given Network Device and returns the output.
