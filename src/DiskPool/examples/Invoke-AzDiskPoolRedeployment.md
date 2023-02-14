### Example 1: Redeploy a Disk Pool
```powershell
<<<<<<< HEAD
Invoke-AzDiskPoolRedeployment -DiskPoolName 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'
=======
PS C:\> Invoke-AzDiskPoolRedeployment -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command redeploys a Disk Pool.

### Example 2: Redeploy a Disk Pool by object
```powershell
<<<<<<< HEAD
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Invoke-AzDiskPoolRedeployment
=======
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Invoke-AzDiskPoolRedeployment

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command redeploys a Disk Pool by object.
