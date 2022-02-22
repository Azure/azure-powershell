### Example 1: Remove a DNS Resolver by name
```powershell
Remove-AzDnsResolver -ResourceGroupName powershell-test-rg -Name psdnsresolvername33nmy1fz
```
This command removes a DNS Resolver by name.

### Example 2: Remove a DNS Resolver by identity
```powershell
$dnsResolverObject = Get-AzDnsResolver -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
Remove-AzDnsResolver -InputObject $dnsResolverObject 
```

This command removes a DNS Resolver by identity.

