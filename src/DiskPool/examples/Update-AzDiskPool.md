### Example 1: Update a Disk Pool
```powershell
<<<<<<< HEAD
Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -DiskId @()
```

```output
=======
PS C:\> Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -DiskId @()

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command updates a Disk Pool.

### Example 2: Update a Disk Pool by object
```powershell
<<<<<<< HEAD
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Update-AzDiskPool -DiskId @()
```

```output
=======
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Update-AzDiskPool -DiskId @()

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command updates a Disk Pool by object.

