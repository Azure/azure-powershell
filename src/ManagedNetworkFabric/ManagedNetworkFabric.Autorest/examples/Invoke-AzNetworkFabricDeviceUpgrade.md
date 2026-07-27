### Example 1: Upgrade a Network Device
```powershell
Invoke-AzNetworkFabricDeviceUpgrade -Name $name -ResourceGroupName $resourceGroupName -Version $version -RwDeviceConfigUrl $rwDeviceConfigUrl
```

This command upgrades the given Network Device to the specified version.
