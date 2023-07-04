### Example 1: Check that subnets will be valid for AML file system create calls.
```powershell
Test-AzStorageCacheAmlFileSystemSubnet -Location eastus -Name "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/azps-vnetwork-sub-kv" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -PassThru
```

```output
True
```

Check that subnets will be valid for AML file system create calls.