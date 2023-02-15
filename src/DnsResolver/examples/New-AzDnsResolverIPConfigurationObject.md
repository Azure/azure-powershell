### Example 1: Create an IPConfiguration
```powershell
New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 1.1.2.12 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname44yqt9mb/subnets/pssubnetname44c6v0lr
```

```output
PrivateIPAddress PrivateIPAllocationMethod
---------------- -------------------------
1.1.2.12         Dynamic
```

This command creates an IPConfiguration
