### Example 1: List all DNS Resolver Domain Lists under the subscription 
```powershell
Get-AzDnsResolverDomainList -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                                  Type                                     Etag
-------- ----                                  ----                                     ----
westus2  dnsresolverdomainlisttestresolver2422 Microsoft.Network/dnsResolverDomainLists "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverdomainlisttestresolver2654 Microsoft.Network/dnsResolverDomainLists "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverdomainlisttestresolver8416 Microsoft.Network/dnsResolverDomainLists "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverdomainlisttestresolver5036 Microsoft.Network/dnsResolverDomainLists "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverdomainlisttestresolver3718 Microsoft.Network/dnsResolverDomainLists "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverdomainlisttestresolver2758 Microsoft.Network/dnsResolverDomainLists "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverdomainlisttestresolver7108 Microsoft.Network/dnsResolverDomainLists "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverdomainlisttestresolver7639 Microsoft.Network/dnsResolverDomainLists "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverdomainlisttestresolver5912 Microsoft.Network/dnsResolverDomainLists "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverdomainlisttestguli01       Microsoft.Network/dnsResolverDomainLists "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverdomainlisttestresolver9892 Microsoft.Network/dnsResolverDomainLists "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Domain Lists under the subscription.

### Example 2: List all DNS Resolver Domain Lists under the resource group 
```powershell
Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolverdomainlistname34dp19g6 Microsoft.Network/dnsResolverDomainLists "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolverdomainlistname35m3jf0n Microsoft.Network/dnsResolverDomainLists "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolver Domain Lists under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name psdnsresolverdomainlistname33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Domain List by name.
