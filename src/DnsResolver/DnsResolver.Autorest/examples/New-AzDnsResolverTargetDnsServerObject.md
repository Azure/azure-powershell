### Example 1: Create an Target DNS server
```powershell
New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
```

```output
PrivateIPAddress PrivateIPAllocationMethod
---------------- -------------------------
1.1.2.12       Dynamic
```

This command creates an target DNS server.

