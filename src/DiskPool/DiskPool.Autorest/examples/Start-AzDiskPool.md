### Example 1: Start a Disk Pool
```powershell
PS C:\> Start-AzDiskPool -DiskPoolName 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'

```

This command starts a Disk Pool.

### Example 2: Start a Disk Pool by object
```powershell
PS C:\> Get-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' | Start-AzDiskPool

```

This command starts a Disk Pool by object.

