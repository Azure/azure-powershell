### Example 1: Update Administrative State of a Network Device
```powershell
$state = "Enable"
Update-AzNetworkFabricNetworkDeviceAdministrativeState -NetworkDeviceName $name -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the administrative state of the given Network Device.
