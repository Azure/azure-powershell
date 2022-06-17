### Example 1: Create an iSCSI target
```powershell
New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-1' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic'
```

```output
Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command creates an iSCSI target.

