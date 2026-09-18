### Example 1: Remove a DNS Resolver Policy Link by name
```powershell
Remove-AzDnsResolverPolicyVirtualNetworkLink  -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleResolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz
```
This command removes a DNS Resolver Policy Link by name.

### Example 2: Remove a DNS Resolver Policy Link by identity
```powershell
$dnsResolverPolicyLinkObject = Get-AzDnsResolverPolicyVirtualNetworkLink  -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleResolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz
Remove-AzDnsResolverPolicyVirtualNetworkLink  -InputObject $dnsResolverPolicyLinkObject 
```

This command removes a DNS Resolver Policy Link by identity.

