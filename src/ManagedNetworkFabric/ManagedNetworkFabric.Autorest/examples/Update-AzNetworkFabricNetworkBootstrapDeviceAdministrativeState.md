### Example 1: Update Administrative State of a Network Bootstrap Device
```powershell
$state = "Enable"
Update-AzNetworkFabricNetworkBootstrapDeviceAdministrativeState -NetworkBootstrapDeviceName $name -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the administrative state of the given Network Bootstrap Device.
