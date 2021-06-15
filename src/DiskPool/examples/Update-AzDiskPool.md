### Example 1: Update a Disk Pool
```powershell
PS C:\> Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -DiskId @()

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
```

This command updates a Disk Pool.

### Example 2: Update a Disk Pool by object
```powershell
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Update-AzDiskPool -DiskId @()

Location   Name        Type
--------   ----        ----
westeurope disk-pool-1 Microsoft.StoragePool/diskPools
```

This command updates a Disk Pool by object.

