### Example 1: List all Disk Pools in a resource group
```powershell
<<<<<<< HEAD
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test'
```

```output
=======
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test'
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
disk-pool-5      eastus2euap Running   Succeeded         {3}
```

This command lists all Disk Pools in a resource group

### Example 2: Get a Disk Pool
```powershell
<<<<<<< HEAD
Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1'
```

```output
=======
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command gets a Disk Pool.

### Example 3: List all Disk Pools under a subscription
```powershell
<<<<<<< HEAD
Get-AzDiskPool
```

```output
=======
PS C:\> Get-AzDiskPool

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
disk-pool-5      eastus2euap Running   Succeeded         {3}
```

This command lists all the Disk Pools in a subscription.

### Example 4: Get a Disk Pool by object
```powershell
<<<<<<< HEAD
New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'westeurope' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1" | Get-AzDiskPool
```

```output
=======
PS C:\>  New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'westeurope' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1" | Get-AzDiskPool

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
```

This command gets a Disk Pool by object.

