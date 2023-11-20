### Example 1: Delete a Disk Pool
```powershell
PS C:\> Remove-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' 

```

This command deletes a Disk Pool.

### Example 2: Delete a Disk Pool by object
```powershell
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Remove-AzDiskPool

```

This command deletes a Disk Pool by object.
