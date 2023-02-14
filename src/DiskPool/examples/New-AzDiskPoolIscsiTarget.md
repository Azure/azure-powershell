### Example 1: Create an iSCSI target
```powershell
<<<<<<< HEAD
New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-1' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic'
```

```output
=======
PS C:\> New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-1' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command creates an iSCSI target.

