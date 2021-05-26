### Example 1: Create a Disk Pool
```powershell
PS C:\> New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'westeurope' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/eff9fadd-6918-4253-b667-c39271e7435c/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1"

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
```

This command creates a Disk Pool.


