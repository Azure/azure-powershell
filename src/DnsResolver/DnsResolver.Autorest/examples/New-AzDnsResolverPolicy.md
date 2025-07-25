### Example 1: Create a DNS resolver policy 
```powershell
New-AzDnsResolverPolicy -Name sampleResolverPolicy -ResourceGroupName powershell-test-rg -Location westus2
```

```output
Location Name           Type                           Etag
-------- ----           ----                           ----
westus2  sampleResolverPolicy Microsoft.Network/dnsResolvers "000027d5-0000-0800-0000-6040150e0000"
```

This cmdlet creates a DNS resolver policy.


### Example 2: Create a DNS resolver policy with tag
```powershell
New-AzDnsResolverPolicy -Name sampleResolverPolicy -ResourceGroupName powershell-test-rg -Location westus2 -Tag @{"key0" = "value0"}
```

```output
Location Name                 Type                           Etag
-------- ----                 ----                           ----
westus2  sampleResolverPolicy Microsoft.Network/dnsResolvers "00008cd5-0000-0800-0000-604016c90000"
```

This cmdlet creates a DNS resolver policy with tag.
