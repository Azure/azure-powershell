### Example 1: List virtual network links under a DNS forwarding ruleset
```powershell
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -ResourceGroupName powershell-test-rg
```

```output
Name                   Type                                            Etag
----                   ----                                            ----
samplevnetLink1  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
samplevnetLink2  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b0071aa-0000-0800-0000-60406a2d0000"
```

This command gets all virtual network link by name

### Example 2: Get single virtual network link by name
```powershell
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
samplevnetLink1 Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
```

This command gets single virtual network link by name

