### Example 1: Remove an virtual network link by name.
```powershell
PS C:\> Remove-AzDnsResolverVirtualNetworkLink -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleVnetLink -ResourceGroupName sampleRG
```
This command removes an virtual network link by name.

### Example 2: Remove an virtual network link by identity
```powershell
PS C:\> $inputObject = Get-AzDnsResolverVirtualNetworkLink -DnsResolverName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg
PS C:\> Remove-AzDnsResolverOutboundEndpoint -InputObject $inputObject 
```

This command removes an virtual network link by identity.
