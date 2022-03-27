### Example 1: List all DNS Resolvers under the subscription 
```powershell
Get-AzDnsResolver -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                        Type                           Etag
-------- ----                        ----                           ----
westus2  dnsresolvertestresolver2422 Microsoft.Network/dnsResolvers "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolvertestresolver2654 Microsoft.Network/dnsResolvers "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolvertestresolver8416 Microsoft.Network/dnsResolvers "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolvertestresolver5036 Microsoft.Network/dnsResolvers "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolvertestresolver3718 Microsoft.Network/dnsResolvers "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolvertestresolver2758 Microsoft.Network/dnsResolvers "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolvertestresolver7108 Microsoft.Network/dnsResolvers "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolvertestresolver7639 Microsoft.Network/dnsResolvers "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolvertestresolver5912 Microsoft.Network/dnsResolvers "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolvertestguli01       Microsoft.Network/dnsResolvers "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolvertestresolver9892 Microsoft.Network/dnsResolvers "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolvers under the subscription.

### Example 2: List all DNS Resolvers under the resource group 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolvername34dp19g6 Microsoft.Network/dnsResolvers "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolvername35m3jf0n Microsoft.Network/dnsResolvers "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolvers under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
```

This command gets  single DNS Resolver by name.

### Example 4: List all DNS Resolvers under the virtual network 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg -VirtualNetworkName virtualnetwork-test
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
```

This command gets  single DNS Resolver by virtual network.