### Example 1: Remove an iSCSI target
```powershell
PS C:\> Remove-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'

```

This command removes an iSCSI target.

### Example 2: Remove an iSCSI target by object
```powershell
PS C:\> Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0' | Remove-AzDiskPoolIscsiTarget

```

This command removes an iSCSI target by object.

