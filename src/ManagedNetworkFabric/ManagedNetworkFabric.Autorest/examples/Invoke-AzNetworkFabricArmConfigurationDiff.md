### Example 1: Get ARM configuration diff for Network Fabric
```powershell
Invoke-AzNetworkFabricArmConfigurationDiff -NetworkFabricName $name -ResourceGroupName $resourceGroupName
```

This command returns the diff between the current ARM configuration and the running configuration for the given Network Fabric.
