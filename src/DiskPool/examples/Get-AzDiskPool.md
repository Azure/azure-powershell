### Example 1: List all Disk Pools in a resource group
```powershell
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test'

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
westeurope disk-pool-5 Microsoft.StoragePool/diskPools
```

This command lists all Disk Pools in a resource group

### Example 2: Get a Disk Pool
```powershell
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1'

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
```

This command gets a Disk Pool.

### Example 3: List all Disk Pools under a subscription
```powershell
PS C:\> Get-AzDiskPool

Location   Name                 Type
--------   ----                 ----
westeurope disk-pool-1          Microsoft.StoragePool/diskPools
westeurope disk-pool-5          Microsoft.StoragePool/diskPools
WestUS2    disk-pool-01         Microsoft.StoragePool/diskPools
```

This command lists all the Disk Pools in a subscription.

### Example 4: Get a Disk Pool by object
```powershell
PS C:\>  New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'westeurope' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/eff9fadd-6918-4253-b667-c39271e7435c/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1" | Get-AzDiskPool

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
```

This command gets a Disk Pool by object.

