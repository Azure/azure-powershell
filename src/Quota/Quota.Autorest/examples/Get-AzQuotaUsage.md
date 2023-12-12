### Example 1: List the currents usage of a resource
```powershell
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"
```

```output
Name              NameLocalizedValue  UsageUsagesType UsageValue ETag
----              ------------------  --------------- ---------- ----
VirtualNetworks   Virtual Networks    Individual      2
CustomIpPrefixes  Custom Ip Prefixes  Individual      0
PublicIpPrefixes  Public Ip Prefixes  Individual      0
PublicIPAddresses Public IP Addresses Individual      4
......
```

This command lists the currents usage of a resource

### Example 2: Get the current usage of a resource
```powershell
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -Name "MinPublicIpInterNetworkPrefixLength"
```

```output
Name                                NameLocalizedValue        UsageUsagesType UsageValue ETag
----                                ------------------        --------------- ---------- ----
MinPublicIpInterNetworkPrefixLength Public IPv4 Prefix Length Individual      0
```

This command lists the currents usage of a resource.