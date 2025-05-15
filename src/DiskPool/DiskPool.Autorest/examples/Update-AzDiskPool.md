### Example 1: Update a Disk Pool
```powershell
Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -DiskId @()
```

```output
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command updates a Disk Pool.

### Example 2: Update a Disk Pool by object
```powershell
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1' | Update-AzDiskPool -DiskId @()
```

```output
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command updates a Disk Pool by object.

