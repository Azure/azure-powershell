### Example 1: Update DNS Forwarding ruleset by name (adding metadata)
```powershell
Update-AzDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName sampleRG -Metadata @{"key0" = "value0"}
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command updates DNS Forwarding ruleset by name (adding metadata)

### Example 2: Updates an existing DNS Forwarding ruleset by identity
```powershell
$inputObject = Get-AzDnsForwardingRuleset -ResourceGroupName powershell-test-rg -Name  dnsForwardingRuleset
Update-AzDnsForwardingRuleset -InputObject $inputObject  -Metadata @{"key0" = "value0"} 
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command updates DNS Forwarding ruleset via identity (adding metadata)

