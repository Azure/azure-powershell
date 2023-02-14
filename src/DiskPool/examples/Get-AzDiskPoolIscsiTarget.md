### Example 1: List iSCSI targets in a Disk Pool
```powershell
<<<<<<< HEAD
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5'
```

```output
=======
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command lists all iSCSI targets in a Disk Pool.

### Example 2: Get an iSCSI target
```powershell
<<<<<<< HEAD
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'
```

```output
=======
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target.

### Example 3: Get an iSCSI target by object
```powershell
<<<<<<< HEAD
New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-5' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic' | Get-AzDiskPoolIscsiTarget
```

```output
=======
PS C:\> New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-5' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic' | Get-AzDiskPoolIscsiTarget

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target by object.
