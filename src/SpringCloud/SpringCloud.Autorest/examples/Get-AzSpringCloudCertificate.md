### Example 1: List all the certificate resource under a spring service
```powershell
Get-AzSpringCloudCertificate -ResourceGroupName lucas-rg-test -ServiceName springapp-pwsh01
```

```output
Name   ResourceGroupName
----   -----------------
cert01 lucas-rg-test
```

List all the certificate resource under a spring service.

### Example 2: Get a certificate resource by name
```powershell
Get-AzSpringCloudCertificate -ResourceGroupName lucas-rg-test -ServiceName springapp-pwsh01 -Name cert01  
```

```output
Name   ResourceGroupName
----   -----------------
cert01 lucas-rg-test
```

Get a certificate resource by name.

