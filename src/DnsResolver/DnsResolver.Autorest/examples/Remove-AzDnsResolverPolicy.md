### Example 1: Remove a Dns Resolver Policy by name
```powershell
Remove-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name psdnsresolvername33nmy1fz
```
This command removes a Dns Resolver Policy by name.

### Example 2: Remove a Dns Resolver Policy by identity
```powershell
$dnsResolverPolicyObject = Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
Remove-AzDnsResolverPolicy -InputObject $dnsResolverPolicyObject 
```

This command removes a Dns Resolver Policy by identity.

