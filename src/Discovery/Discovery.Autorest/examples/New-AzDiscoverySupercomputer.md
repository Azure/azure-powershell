### Example 1: Create a new supercomputer
```powershell
New-AzDiscoverySupercomputer -ResourceGroupName "my-rg" -Name "my-supercomputer" -Location "eastus" -SubnetId "/subscriptions/{subId}/resourceGroups/my-rg/providers/Microsoft.Network/virtualNetworks/my-vnet/subnets/my-subnet" -ManagementSubnetId "/subscriptions/{subId}/resourceGroups/my-rg/providers/Microsoft.Network/virtualNetworks/my-vnet/subnets/mgmt-subnet"
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-supercomputer    my-rg                Succeeded
```

Creates a new Discovery supercomputer with required networking configuration.
