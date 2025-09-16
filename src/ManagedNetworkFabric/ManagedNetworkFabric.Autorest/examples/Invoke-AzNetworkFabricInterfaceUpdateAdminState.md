### Example 1: Update the admin state of the Network Interface
```powershell
$state="Enable"
Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName $deviceName -NetworkInterfaceName $name -ResourceGroupName $resourceGroupName -State $state
```

This command update the admin state of the Network Interface


