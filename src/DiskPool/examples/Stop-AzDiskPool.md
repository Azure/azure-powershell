### Example 1: Stop a Disk Pool
```powershell
PS C:\> Stop-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'

```

This command deallocates a Disk Pool.

### Example 2: Stop a Disk Pool by object
```powershell
PS C:\> Get-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' | Stop-AzDiskPool

```

This command deallocates a Disk Pool by object.
