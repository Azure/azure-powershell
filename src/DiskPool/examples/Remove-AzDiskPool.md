### Example 1: Delete a Disk Pool
```powershell
<<<<<<< HEAD
Remove-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' 
=======
PS C:\> Remove-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' 

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Disk Pool.

### Example 2: Delete a Disk Pool by object
```powershell
<<<<<<< HEAD
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Remove-AzDiskPool
=======
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Remove-AzDiskPool

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a Disk Pool by object.
