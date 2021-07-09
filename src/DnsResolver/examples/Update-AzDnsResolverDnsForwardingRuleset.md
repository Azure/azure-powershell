### Example 1: Update DNS Forwarding ruleset by name (adding metadata)
```powershell
PS C:\> Update-AzDnsResolverDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName sampleRG -Tag @{"key0" = "value0"}

Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

{{ Add description here }}

### Example 2: Updates an existing DNS Forwarding ruleset by identity
```powershell
PS C:\> {{ Add code here }}

Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

{{ Add description here }}

