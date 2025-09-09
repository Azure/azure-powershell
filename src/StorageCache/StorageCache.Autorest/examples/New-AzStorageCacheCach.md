### Example 1: Create a new cache
```powershell
New-AzStorageCacheCach -CacheName "myCache" -ResourceGroupName "myResourceGroup" -Location "East US" -CacheSizeGB 3072 -SubnetId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}" -SkuName "Standard_2G"
```

The HPC Cache service is being deprecated.

