### Example 1: Update virtual network link by name (adding metadata)
```powershell
PS C:\> Update-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName sampleDnsForwardingRuleset -Name sampleVnetLink -Metadata @{"value0" = "value1"}

Name         Type                                             Etag
----         ----                                             ----
sampleVnetLink Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "02001eab-0000-0800-0000-60e792500000"
```

This command updates virtual network link by name (adding metadata)

### Example 2: Update virtual network link via identity (adding metadata)
```powershell
PS C:\> $inputObject = Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsResolverName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg
PS C:\> Update-AzDnsForwardingRulesetVirtualNetworkLink -InputObject $inputObject -Metadata @{"value0" = "value1"}

Name         Type                                             Etag
----         ----                                             ----
sampleVnetLink Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "02001eab-0000-0800-0000-60e792500000"
```

This command updates virtual network link via identity (adding metadata)

