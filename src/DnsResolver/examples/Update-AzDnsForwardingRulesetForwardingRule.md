### Example 1: Update forwarding rule by name (adding metadata)
```powershell
Update-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -Metadata @{"key0" = "value0"}
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  forwardingRule Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
```

This command updates forwarding rule by name (adding metadata)

### Example 2: Updates a forwarding rule by identity
```powershell
$inputObject = Get-AzDnsForwardingRulesetForwardingRule -ResourceGroupName powershell-test-rg -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule
Update-AzDnsForwardingRulesetForwardingRule -InputObject $inputObject  -Metadata @{"value0" = "value1"}
```

```output
Location Name                 Type                                             Etag
-------- ----                 ----                                             ----
westus2  forwardingRule Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
```

This command updates forwarding rule via identity (adding metadata)

