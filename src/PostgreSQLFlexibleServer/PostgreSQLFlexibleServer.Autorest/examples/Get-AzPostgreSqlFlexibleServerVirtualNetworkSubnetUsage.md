### Example 1: Get subnet usage for a virtual network
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -Location "East US" -VirtualNetworkArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVNet"
```

```output
SubnetName        : database-subnet
UsedIPAddresses   : 5
TotalIPAddresses  : 254
AvailableIPAddresses : 249
Description       : Subnet usage for PostgreSQL Flexible Servers

SubnetName        : application-subnet
UsedIPAddresses   : 12
TotalIPAddresses  : 254
AvailableIPAddresses : 242
Description       : Subnet usage for PostgreSQL Flexible Servers
```

Retrieves subnet usage information for PostgreSQL Flexible Servers in the specified virtual network.

### Example 2: Get usage for a specific subnet
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -Location "West Europe" -VirtualNetworkArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/production-rg/providers/Microsoft.Network/virtualNetworks/prod-vnet" -SubnetArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/production-rg/providers/Microsoft.Network/virtualNetworks/prod-vnet/subnets/database-subnet"
```

```output
SubnetName        : database-subnet
UsedIPAddresses   : 8
TotalIPAddresses  : 62
AvailableIPAddresses : 54
Description       : Subnet usage for PostgreSQL Flexible Servers in production
```

Retrieves usage information for a specific subnet used by PostgreSQL Flexible Servers.

