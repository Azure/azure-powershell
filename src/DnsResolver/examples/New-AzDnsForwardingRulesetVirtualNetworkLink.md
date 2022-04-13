### Example 1: Create a virtual network link
```powershell
New-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleVnetLink -ResourceGroupName sampleRG -VirtualNetworkId "/subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c64/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub"
```

```output
Location Name                   Type                                             Etag
-------- ----                   ----                                             ----
westus2  sampleVnetLink Microsoft.Network/dnsForwardingRulesets/virtualNetworkLinks "0a009902-0000-0800-0000-60e378030000"
```

This cmdlet creates a virtual network link.

### Example 2: Create a virtual network link with metadata
```powershell
New-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleVnetLink -ResourceGroupName sampleRG -VirtualNetworkId "/subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c64/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub" -Metadata @{"key0" = "value0"}
```

```output
Location Name                   Type                                             Etag
-------- ----                   ----                                             ----
westus2  sampleVnetLink Microsoft.Network/dnsForwardingRulesets/virtualNetworkLinks "0a009902-0000-0800-0000-60e378030000"
```

This cmdlet creates a virtual network link with metadata.

