### Example 1: Update Administrative State of a Network Bootstrap Interface
```powershell
$state = "Enable"
Update-AzNetworkFabricNetworkBootstrapInterfaceAdministrativeState -NetworkBootstrapDeviceName $networkBootstrapDeviceName -NetworkBootstrapInterfaceName $name -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the administrative state of the given Network Bootstrap Interface.
