### Example 1: Remove a DNS Resolver Domain List by name
```powershell
Remove-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name psdnsresolvername33nmy1fz
```
This command removes a DNS Resolver Domain List by name.

### Example 2: Remove a DNS Resolver Domain List by identity
```powershell
$dnsResolverDomainListObject = Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
Remove-AzDnsResolverDomainList -InputObject $dnsResolverDomainListObject 
```

This command removes a DNS Resolver Domain List by identity.

