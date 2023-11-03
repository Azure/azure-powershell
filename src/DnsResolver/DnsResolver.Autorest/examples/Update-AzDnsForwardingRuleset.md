### Example 1: Update DNS Forwarding ruleset by name (adding tag)
```powershell
Update-AzDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName sampleRG -Tag @{"key0" = "value0"}
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command updates DNS Forwarding ruleset by name (adding tag)

### Example 2: Updates an existing DNS Forwarding ruleset by identity
```powershell
$inputObject = Get-AzDnsForwardingRuleset -ResourceGroupName powershell-test-rg -Name  dnsForwardingRuleset
Update-AzDnsForwardingRuleset -InputObject $inputObject -Tag @{"key0" = "value0"}
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command updates DNS Forwarding ruleset via identity (adding tag)

