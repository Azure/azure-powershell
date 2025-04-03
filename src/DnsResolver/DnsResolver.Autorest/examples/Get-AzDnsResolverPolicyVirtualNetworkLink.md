### Example 1: List all DNS Resolver Policy Links under the dns resolver policy 
```powershell
Get-AzDnsResolverPolicyVirtualNetworkLink -ResourceGroupName exampleResourceGroup -DnsResolverPolicyName exampleDnsResolverPolicy
```

```output
Location Name                                  Type                                     Etag
-------- ----                                  ----                                     ----
westus2  dnsresolverpolicylinktestresolver2422 Microsoft.Network/dnsResolverPolicyLinks "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverpolicylinktestresolver2654 Microsoft.Network/dnsResolverPolicyLinks "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverpolicylinktestresolver8416 Microsoft.Network/dnsResolverPolicyLinks "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverpolicylinktestresolver5036 Microsoft.Network/dnsResolverPolicyLinks "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverpolicylinktestresolver3718 Microsoft.Network/dnsResolverPolicyLinks "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverpolicylinktestresolver2758 Microsoft.Network/dnsResolverPolicyLinks "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverpolicylinktestresolver7108 Microsoft.Network/dnsResolverPolicyLinks "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverpolicylinktestresolver7639 Microsoft.Network/dnsResolverPolicyLinks "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverpolicylinktestresolver5912 Microsoft.Network/dnsResolverPolicyLinks "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverpolicylinktestguli01       Microsoft.Network/dnsResolverPolicyLinks "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverpolicylinktestresolver9892 Microsoft.Network/dnsResolverPolicyLinks "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Policy Links under the dns resolver policy.

### Example 2: Get single DNS Resolver Policy Link by name
```powershell
Get-AzDnsResolverPolicyVirtualNetworkLink -ResourceGroupName powershell-test-rg -DnsResolverPolicyName $resolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverpolicylinkname33nmy1fz Microsoft.Network/dnsResolverPolicyLinks "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Policy Link by name.
