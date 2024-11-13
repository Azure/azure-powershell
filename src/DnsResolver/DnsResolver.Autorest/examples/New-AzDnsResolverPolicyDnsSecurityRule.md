### Example 1: Create a DNS security rule 
```powershell
New-AzDnsResolverPolicyDnsSecurityRule -Name sampleSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -Location westus2 -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100 -DnsResolverDomainList @{id = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/dnsResolverDomainLists/exampleDomainListName";}

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleSecurityRule       Microsoft.Network/dnsSecurityRules       "000027d5-0000-0800-0000-6040150e0000"
```

This cmdlet creates a DNS security rule.

### Example 2: Create a DNS security rule with tag 
```powershell
New-AzDnsResolverPolicyDnsSecurityRule -Name sampleSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -Location westus2 -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100 -DnsResolverDomainList @{id = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/dnsResolverDomainLists/exampleDomainListName";} -Tag @{"key0" = "value0"}
```

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleSecurityRule       Microsoft.Network/dnsSecurityRules       "00008cd5-0000-0800-0000-604016c90000"
```

This cmdlet creates a DNS security rule with tag.
