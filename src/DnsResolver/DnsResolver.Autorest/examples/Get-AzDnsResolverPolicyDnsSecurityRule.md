### Example 1: List all DNS Security Rule under the dns resolver policy 
```powershell
Get-AzDnsResolverPolicyDnsSecurityRule  -ResourceGroupName exampleResourceGroup -DnsResolverPolicyName exampleDnsResolverPolicy
```

```output
Location Name                            Type                               Etag
-------- ----                            ----                               ----
westus2  dnssecurityruletestresolver2422 Microsoft.Network/dnsSecurityRules "8b002671-0000-0800-0000-60386dc10000"
westus2  dnssecurityruletestresolver2654 Microsoft.Network/dnsSecurityRules "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnssecurityruletestresolver8416 Microsoft.Network/dnsSecurityRules "94008a5e-0000-0800-0000-603972f20000"
westus2  dnssecurityruletestresolver5036 Microsoft.Network/dnsSecurityRules "8b002f71-0000-0800-0000-60386df80000"
westus2  dnssecurityruletestresolver3718 Microsoft.Network/dnsSecurityRules "00009b95-0000-0800-0000-603e8b210000"
westus2  dnssecurityruletestresolver2758 Microsoft.Network/dnsSecurityRules "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnssecurityruletestresolver7108 Microsoft.Network/dnsSecurityRules "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnssecurityruletestresolver7639 Microsoft.Network/dnsSecurityRules "8b00b670-0000-0800-0000-60386b010000"
westus2  dnssecurityruletestresolver5912 Microsoft.Network/dnsSecurityRules "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnssecurityruletestguli01       Microsoft.Network/dnsSecurityRules "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnssecurityruletestresolver9892 Microsoft.Network/dnsSecurityRules "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Security Rule under the dns resolver policy.

### Example 2: Get single DNS Security Rule by name
```powershell
Get-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName $resolverPolicyName -Name psdnssecurityrulename33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnssecurityrulename33nmy1fz       Microsoft.Network/dnsSecurityRules       "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Security Rule by name.
