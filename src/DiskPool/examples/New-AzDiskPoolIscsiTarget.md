### Example 1: Create an iSCSI target
```powershell
PS C:\> New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-1' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic'

Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command creates an iSCSI target.

