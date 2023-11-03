### Example 1: Create an in-memory object for NginxPrivateIPAddress
```powershell
New-AzNginxPrivateIPAddressObject -PrivateIPAddress 10.0.0.0 -PrivateIPAllocationMethod Static -SubnetId /subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default
```

```output
PrivateIPAddress PrivateIPAllocationMethod SubnetId
---------------- ------------------------- --------
10.0.0.0         Static                    /subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default
```

Create an in-memory object for NginxPrivateIPAddress.
