### Example 1: List virtual network links under a DNS forwarding ruleset
```powershell
PS C:\> Get-AzDnsResolverVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -ResourceGroupName powershell-test-rg
Name                   Type                                            Etag
----                   ----                                            ----
samplevnetLink1  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
samplevnetLink2  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b0071aa-0000-0800-0000-60406a2d0000"
```

This command gets all virtual network link by name

### Example 2: Get single virtual network link by name
```powershell
PS C:\> Get-AzDnsResolverVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg

Name                  Type                                            Etag
----                  ----                                            ----
samplevnetLink1 Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
```

<<<<<<< HEAD
This command gets single virtual network link by name
=======
This command gets single virtual network link by name
>>>>>>> 2935e5fc9cb77a0d10c6bd977239c21938094193
