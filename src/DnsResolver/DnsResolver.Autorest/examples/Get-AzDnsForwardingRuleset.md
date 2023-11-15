### Example 1: List all DNS forwarding rulesets in a subscription
```powershell
Get-AzDnsForwardingRuleset -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                                                            Type                                    Etag
-------- ----                                                            ----                                    ----
westus2  dnsForwardingRuleset                                            Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
westus2  pw-dnsForwardingRuleset                                         Microsoft.Network/dnsForwardingRulesets "08009ec9-0000-0800-0000-60e383b70000"
westus2  pw-dnsForwardingRuleset1                                        Microsoft.Network/dnsForwardingRulesets "08007ccc-0000-0800-0000-60e3846a0000"
eastus2  dnsforwardingruleset-test-eastus2-main-syn-outbound-primary-0   Microsoft.Network/dnsForwardingRulesets "4f006bb2-0000-0200-0000-60e7ef240000"
eastus2  dnsforwardingruleset-test-eastus2-main-syn-outbound-secondary-0 Microsoft.Network/dnsForwardingRulesets "4f006db2-0000-0200-0000-60e7ef240000"
```

This command gets all DNS forwarding ruleset under the subscription.

### Example 2: Get single DNS forwarding ruleset by name
```powershell
Get-AzDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName sampleRG
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command gets single DNS forwarding ruleset by name.

### Example 3: List all DNS forwarding ruleset under the resource group
```powershell
Get-AzDnsForwardingRuleset -ResourceGroupName sampleRG
```

```output
Location Name                     Type                                    Etag
-------- ----                     ----                                    ----
westus2  dnsForwardingRuleset     Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
westus2  pw-dnsForwardingRuleset  Microsoft.Network/dnsForwardingRulesets "08009ec9-0000-0800-0000-60e383b70000"
westus2  pw-dnsForwardingRuleset1 Microsoft.Network/dnsForwardingRulesets "08007ccc-0000-0800-0000-60e3846a0000"
```

This command gets all DNS forwarding ruleset under the resource group.

### Example 4: List all DNS forwarding ruleset under the virtual network
```powershell
Get-AzDnsForwardingRuleset -ResourceGroupName sampleRG -VirtualNetworkName virtualnetwork-test
```

```output
Location Name                     Type                                    Etag
-------- ----                     ----                                    ----
westus2  dnsForwardingRuleset     Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command gets all DNS forwarding ruleset under the virtual network.

