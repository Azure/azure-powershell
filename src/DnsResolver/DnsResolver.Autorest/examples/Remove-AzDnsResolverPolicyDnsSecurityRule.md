### Example 1: Remove a DNS Security Rule by name
```powershell
Remove-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleResolverPolicyName -Name psdnssecurityrulename33nmy1fz
```
This command removes a DNS Security Rule by name.

### Example 2: Remove a DNS Security Rule by identity
```powershell
$dnsSecurityRuleObject = Get-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName exampleResolverPolicyName -Name psdnssecurityrulename33nmy1fz
Remove-AzDnsResolverPolicyDnsSecurityRule  -InputObject $dnsSecurityRuleObject 
```

This command removes a DNS Security Rule by identity.
