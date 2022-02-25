### Example 1: Create a Disk Pool
```powershell
New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'eastus2euap' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1"
```

```output
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command creates a Disk Pool.


