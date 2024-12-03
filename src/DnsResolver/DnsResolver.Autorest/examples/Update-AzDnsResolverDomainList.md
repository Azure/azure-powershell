### Example 1: Update an existing DNS Resolver Domain List by name
```powershell
Update-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name  psdnsresolverdomainlistname33nmy1fz -Tag @{"key0" = "value0"} 
```

```output
Location Name                            Type                                         Etag
-------- ----                            ----                                         ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000efd6-0000-0800-0000-60401c7c0000"
```

This command updates an existing DNS Resolver Domain List by name ( adding tag ).

### Example 2: Updates an existing DNS Resolver Domain List by identity
```powershell
$dnsResolverDomainListObject = Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name  psdnsresolverdomainlistname33nmy1fz
Update-AzDnsResolverDomainList -InputObject $dnsResolverDomainListObject  -Tag @{} 
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000efd6-0000-0800-0000-60401c7c0000"
```
This command updates an existing DNS Resolver Domain List by identity ( removing tag ).
