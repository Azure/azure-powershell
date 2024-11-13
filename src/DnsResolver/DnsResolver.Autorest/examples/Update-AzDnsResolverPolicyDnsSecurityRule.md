### Example 1: Update an existing DNS Security Rule by name
```powershell
Update-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleDnsResolverPolicyName -Name psdnssecurityrulename33nmy1fz -Tag @{"key0" = "value0"} 
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnssecurityrulename33nmy1fz       Microsoft.Network/dnsSecurityRules       "0000efd6-0000-0800-0000-60401c7c0000"
```

This command updates an existing DNS Security Rules by name ( adding tag ).

### Example 2: Updates an existing DNS Resolver by identity
```powershell
$dnsSecurityRuleObject = Get-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleDnsResolverPolicyName -Name psdnssecurityrulename33nmy1fz
Update-AzDnsResolverPolicyDnsSecurityRule -InputObject $dnsSecurityRuleObject  -Tag @{} 
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnssecurityrulename33nmy1fz       Microsoft.Network/dnsSecurityRules       "0000efd6-0000-0800-0000-60401c7c0000"
```
This command updates an existing DNS Security Rules by identity ( removing tag ).
