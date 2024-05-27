### Example 1: Stop a Disk Pool
```powershell
Stop-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'
```

This command deallocates a Disk Pool.

### Example 2: Stop a Disk Pool by object
```powershell
Get-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' | Stop-AzDiskPool
```

This command deallocates a Disk Pool by object.
