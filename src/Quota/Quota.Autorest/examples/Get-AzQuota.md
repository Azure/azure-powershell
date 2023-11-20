### Example 1: List the quota limits of a scope
```powershell
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"

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
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName "MinPublicIpInterNetworkPrefixLength"

Name                                NameLocalizedValue        Unit  ETag
----                                ------------------        ----  ----
MinPublicIpInterNetworkPrefixLength Public IPv4 Prefix Length Count
```

This command gets the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.
