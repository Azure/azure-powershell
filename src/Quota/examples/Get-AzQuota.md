### Example 1: List the quota limits of a scope
```powershell
<<<<<<< HEAD
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"
```

```output
=======
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                                ResourceGroupName Unit  ETag
----                                                ----------------- ----  ----
VirtualNetworks                                                       Count
StaticPublicIPAddresses                                               Count
NetworkSecurityGroups                                                 Count
PublicIPAddresses                                                     Count
CustomIpPrefixes                                                      Count
PublicIpPrefixes                                                      Count
```

This command lists the quota limits of a scope.

### Example 2: Get the quota limit of a resource
```powershell
<<<<<<< HEAD
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName "MinPublicIpInterNetworkPrefixLength"
```

```output
=======
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName "MinPublicIpInterNetworkPrefixLength"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                NameLocalizedValue        Unit  ETag
----                                ------------------        ----  ----
MinPublicIpInterNetworkPrefixLength Public IPv4 Prefix Length Count
```

This command gets the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.
