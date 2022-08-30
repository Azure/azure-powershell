### Example 1: Update an existing DNS Resolver by name
```powershell
Update-AzDnsResolver -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz -Tag @{"key0" = "value0"} 
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000efd6-0000-0800-0000-60401c7c0000"
```

This command updates an existing DNS Resolver by name ( adding tag ).

### Example 2: Updates an existing DNS Resolver by identity
```powershell
$dnsResolverObject = Get-AzDnsResolver -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
Update-AzDnsResolver -InputObject $dnsResolverObject  -Tag @{} 
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000efd6-0000-0800-0000-60401c7c0000"
```
This command updates an existing DNS Resolver by identity ( removing tag ).

