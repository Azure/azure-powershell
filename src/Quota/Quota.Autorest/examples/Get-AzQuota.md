### Example 1: List the quota limits of a scope
```powershell
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"
```

```output
Name              NameLocalizedValue  Unit  ETag
----              ------------------  ----  ----
VirtualNetworks   Virtual Networks    Count
CustomIpPrefixes  Custom Ip Prefixes  Count
PublicIpPrefixes  Public Ip Prefixes  Count
PublicIPAddresses Public IP Addresses Count
......
```

This command lists the quota limits of a scope.

### Example 2: Get the quota limit of a resource
```powershell
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName VirtualNetworks
```

```output
Name            NameLocalizedValue Unit  ETag
----            ------------------ ----  ----
VirtualNetworks Virtual Networks   Count
```

This command gets the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.