### Example 1: List the subnets of a virtual network that are being used by flexible servers
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName example-location -VirtualNetworkArmResourceId /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.Network/virtualNetworks/example-virtual-network
```

```output
DelegatedSubnetsUsage                            Location         SubscriptionId
---------------------                            --------         --------------
{{…                                              example-location aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e
```

Lists all subnets of a virtual network that are being used by Azure Database for PostgreSQL flexible servers.
