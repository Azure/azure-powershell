### Example 1: Create an iSCSI lun object
```powershell
PS C:\> New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId "/subscriptions/eff9fadd-6918-4253-b667-c39271e7435c/resourceGroups/storagepool-rg-test/providers/Microsoft.Compute/disks/disk-pool-disk-1" -Name 'lun0'

```

This command creates an iSCSI lun object.

