### Example 1: List all forwarding rule under the resource
```powershell
PS C:\> Get-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName DnsResolverName -ResourceGroupName sampleRG

Location Name                                                            Type                                                Etag
-------- ----                                                            ----                                                ----
westus2  dnsForwardingRule                                            Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
westus2  pw-dnsForwardingRule                                         Microsoft.Network/dnsForwardingRulesets/forwardingRule "08009ec9-0000-0800-0000-60e383b70000"
```

This command gets all forwarding rule under the resource.

### Example 1: Get forwarding rule by name
```powershell
PS C:\> Get-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName DnsResolverName -ResourceGroupName sampleRG -Name forwardingRule

Location Name                                                            Type                                                Etag
-------- ----                                                            ----                                                ----
westus2  dnsForwardingRule                                            Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
```

This command gets a forwarding rule by name.

