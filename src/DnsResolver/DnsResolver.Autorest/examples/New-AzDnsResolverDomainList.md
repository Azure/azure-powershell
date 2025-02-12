### Example 1: Create a DNS resolver domain list 
```powershell
New-AzDnsResolverDomainList -Name sampleResolverDomainList -ResourceGroupName powershell-test-rg -Location westus2 -Domain @("contoso.com.", "example.com.")
```

```output
Location Name                     Type                           Etag
-------- ----                     ----                           ----
westus2  sampleResolverDomainList Microsoft.Network/dnsResolvers "000027d5-0000-0800-0000-6040150e0000"
```

This cmdlet creates a DNS resolver domain list.


### Example 2: Create a DNS resolver domain list with tag
```powershell
New-AzDnsResolverDomainList -Name sampleResolverDomainList -ResourceGroupName powershell-test-rg -Location westus2 -Domain @("contoso.com.", "example.com.") -Tag @{"key0" = "value0"}
```

```output
Location Name                     Type                                  Etag
-------- ----                     ----                                  ----
westus2  sampleResolverDomainList Microsoft.Network/dnsResolverPolicies "00008cd5-0000-0800-0000-604016c90000"
```

This cmdlet creates a DNS resolver domain list with tag.
