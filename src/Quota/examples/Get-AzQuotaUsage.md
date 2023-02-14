### Example 1: List the currents usage of a resource
```powershell
<<<<<<< HEAD
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" 
```

```output
=======
PS C:\> Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" 

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                                ResourceGroupName UsageUsagesType UsageValue ETag
----                                                ----------------- --------------- ---------- ----
VirtualNetworks                                                                       0
StaticPublicIPAddresses                                                               0
NetworkSecurityGroups                                                                 0
PublicIPAddresses                                                                     0
CustomIpPrefixes                                                                      0
PublicIpPrefixes                                                                      0
NatGateways                                                                           0
NetworkInterfaces                                                                     0
PrivateEndpoints                                                                      0
PrivateEndpointRedirectMaps                                                           0
LoadBalancers                                                                         0
PrivateLinkServices                                                                   0
ApplicationGateways                                                                   0
RouteTables                                                                           0
RouteFilters                                                                          0
```

This command lists the currents usage of a resource

### Example 2: Get the current usage of a resource
```powershell
<<<<<<< HEAD
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -Name "MinPublicIpInterNetworkPrefixLength"
```

```output
=======
PS C:\> Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -Name "MinPublicIpInterNetworkPrefixLength"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                NameLocalizedValue        UsageUsagesType UsageValue ETag
----                                ------------------        --------------- ---------- ----
MinPublicIpInterNetworkPrefixLength Public IPv4 Prefix Length                 0
```

This command lists the currents usage of a resource.

