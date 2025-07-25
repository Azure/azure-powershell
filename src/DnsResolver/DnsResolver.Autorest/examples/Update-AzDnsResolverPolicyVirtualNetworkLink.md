### Example 1: Update an existing DNS Resolver Policy Link by name
```powershell
Update-AzDnsResolverPolicyVirtualNetworkLink  -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleDnsResolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz -Tag @{"key0" = "value0"} 
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverpolicylinkname33nmy1fz Microsoft.Network/dnsResolverPolicyLinks "0000efd6-0000-0800-0000-60401c7c0000"
```

This command updates an existing DNS Resolver Policy Links by name ( adding tag ).

### Example 2: Updates an existing DNS Resolver by identity
```powershell
$dnsResolverPolicyLinkObject = Get-AzDnsResolverPolicyVirtualNetworkLink  -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleDnsResolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz
Update-AzDnsResolverPolicyVirtualNetworkLink  -InputObject $dnsResolverPolicyLinkObject  -Tag @{} 
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverpolicylinkname33nmy1fz Microsoft.Network/dnsResolverPolicyLinks "0000efd6-0000-0800-0000-60401c7c0000"
```
This command updates an existing DNS Resolver Policy Links by identity ( removing tag ).
