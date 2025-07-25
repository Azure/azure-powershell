### Example 1: List all DNS Resolver Policies under the subscription 
```powershell
Get-AzDnsResolverPolicy -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                              Type                                  Etag
-------- ----                              ----                                  ----
westus2  dnsresolverpolicytestresolver2422 Microsoft.Network/dnsResolverPolicies "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverpolicytestresolver2654 Microsoft.Network/dnsResolverPolicies "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverpolicytestresolver8416 Microsoft.Network/dnsResolverPolicies "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverpolicytestresolver5036 Microsoft.Network/dnsResolverPolicies "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverpolicytestresolver3718 Microsoft.Network/dnsResolverPolicies "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverpolicytestresolver2758 Microsoft.Network/dnsResolverPolicies "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverpolicytestresolver7108 Microsoft.Network/dnsResolverPolicies "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverpolicytestresolver7639 Microsoft.Network/dnsResolverPolicies "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverpolicytestresolver5912 Microsoft.Network/dnsResolverPolicies "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverpolicytestguli01       Microsoft.Network/dnsResolverPolicies "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverpolicytestresolver9892 Microsoft.Network/dnsResolverPolicies "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Policies under the subscription.

### Example 2: List all DNS Resolver Policies under the resource group 
```powershell
Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg
```

```output
Location Name                      Type                                        Etag
-------- ----                      ----                                        ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolverpolicyname34dp19g6 Microsoft.Network/dnsResolverPolicies "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolverpolicyname35m3jf0n Microsoft.Network/dnsResolverPolicies "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolver Policies under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name psdnsresolverpolicyname33nmy1fz
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Policy by name.
