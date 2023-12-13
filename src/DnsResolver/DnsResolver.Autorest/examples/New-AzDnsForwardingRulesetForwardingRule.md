### Example 1: Create a forwarding rule.
```powershell
$targetIPConfig = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
New-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -TargetDnsServer $targetIPConfig
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleForwardingRule Microsoft.Network/dnsForwardingRuleset/forwardingRule "0b008451-0000-0800-0000-60402b960000"
```

This cmdlet creates a forwarding rule.

### Example 2: Create a forwarding rule with tag
```powershell
$targetIPConfig = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
New-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -TargetDnsServer $targetIPConfig -Metadata @{"key0" = "value0"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleForwardingRule Microsoft.Network/dnsForwardingRuleset/forwardingRule "0b008451-0000-0800-0000-60402b960000"
```

This cmdlet creates a forwarding rule with tag.

