### Example 1: Create a DNS resolver policy link 
```powershell
New-AzDnsResolverPolicyVirtualNetworkLink  -Name sampleResolverPolicyLink -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -VirtualNetworkId /subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-08b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname16y71mjc -Location westus2
```

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleResolverPolicyLink Microsoft.Network/dnsResolverPolicyLinks "000027d5-0000-0800-0000-6040150e0000"
```

This cmdlet creates a DNS resolver policy link.


### Example 2: Create a DNS resolver policy link with tag 
```powershell
New-AzDnsResolverPolicyVirtualNetworkLink  -Name sampleResolverPolicyLink -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -VirtualNetworkId /subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname16y71mjc -Location westus2 -Tag @{"key0" = "value0"}
```

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleResolverPolicyLink Microsoft.Network/dnsResolverPolicyLinks "00008cd5-0000-0800-0000-604016c90000"
```

This cmdlet creates a DNS resolver policy link with tag.
