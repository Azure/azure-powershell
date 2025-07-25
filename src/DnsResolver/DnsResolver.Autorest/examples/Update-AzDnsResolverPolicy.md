### Example 1: Update an existing DNS Resolver Policy by name
```powershell
Update-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name  psdnsresolverpolicyname33nmy1fz -Tag @{"key0" = "value0"} 
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000efd6-0000-0800-0000-60401c7c0000"
```

This command updates an existing DNS Resolver Policy by name ( adding tag ).

### Example 2: Updates an existing DNS Resolver Policy by identity
```powershell
$dnsResolverPolicyObject = Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name  psdnsresolverpolicyname33nmy1fz
Update-AzDnsResolverPolicy -InputObject $dnsResolverPolicyObject  -Tag @{} 
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000efd6-0000-0800-0000-60401c7c0000"
```
This command updates an existing DNS Resolver Policy by identity ( removing tag ).
