### Example 1: Start a Disk Pool
```powershell
<<<<<<< HEAD
Start-AzDiskPool -DiskPoolName 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'
=======
PS C:\> Start-AzDiskPool -DiskPoolName 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command starts a Disk Pool.

### Example 2: Start a Disk Pool by object
```powershell
<<<<<<< HEAD
Get-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' | Start-AzDiskPool
=======
PS C:\> Get-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' | Start-AzDiskPool

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command starts a Disk Pool by object.

