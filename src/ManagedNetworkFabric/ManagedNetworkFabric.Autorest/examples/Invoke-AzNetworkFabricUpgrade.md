### Example 1: Upgrade a Network Fabric
```powershell
Invoke-AzNetworkFabricUpgrade -Name $name -ResourceGroupName $resourceGroupName -Version $version -Action "Start"
```

This command upgrades the given Network Fabric to the specified version.
