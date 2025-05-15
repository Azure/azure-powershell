### Example 1: Update an iSCSI target
```powershell
$lun0 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Compute/disks/disk1" -Name "lun0"
Update-AzDiskPoolIscsiTarget -Name 'target0' -DiskPoolName 'disk-pool-5' -ResourceGroupName 'storagepool-rg-test' -Lun @($lun0)
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command updates an iSCSI target.

### Example 2: Update an iSCSI target by object
```powershell
$lun0 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Compute/disks/disk1" -Name "lun0"
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0' | Update-AzDiskPoolIscsiTarget -Lun @($lun0)
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command updates an iSCSI target by object.

