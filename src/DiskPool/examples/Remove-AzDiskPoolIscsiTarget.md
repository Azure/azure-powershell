### Example 1: Remove an iSCSI target
```powershell
<<<<<<< HEAD
Remove-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'
=======
PS C:\> Remove-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes an iSCSI target.

### Example 2: Remove an iSCSI target by object
```powershell
<<<<<<< HEAD
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0' | Remove-AzDiskPoolIscsiTarget
=======
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0' | Remove-AzDiskPoolIscsiTarget

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes an iSCSI target by object.

