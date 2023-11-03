### Example 1: Remove an virtual network link by name.
```powershell
Remove-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleVnetLink -ResourceGroupName sampleRG
```

This command removes an virtual network link by name.

### Example 2: Remove an virtual network link by identity
```powershell
$inputObject = Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg
Remove-AzDnsForwardingRulesetVirtualNetworkLink -InputObject $inputObject
```

This command removes an virtual network link by identity.

