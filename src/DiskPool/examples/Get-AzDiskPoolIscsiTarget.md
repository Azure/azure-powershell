### Example 1: List iSCSI targets in a Disk Pool
```powershell
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5'

Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command lists all iSCSI targets in a Disk Pool.

### Example 2: Get an iSCSI target
```powershell
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'

Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target.

### Example 3: Get an iSCSI target by object
```powershell
PS C:\> New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-5' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic' | Get-AzDiskPoolIscsiTarget

Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target by object.
