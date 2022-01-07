### Example 1: Redeploy a Disk Pool
```powershell
PS C:\> Invoke-AzDiskPoolRedeployment -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'

```

This command redeploys a Disk Pool.

### Example 2: Redeploy a Disk Pool by object
```powershell
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Invoke-AzDiskPoolRedeployment

```

This command redeploys a Disk Pool by object.
