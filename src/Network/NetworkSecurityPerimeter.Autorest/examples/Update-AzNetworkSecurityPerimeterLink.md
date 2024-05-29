### Example 1: Update network security perimeter link

```powershell
Update-AzNetworkSecurityPerimeterLink -Name t-link2 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp4  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
Etag Name
---- ----
     t-link2
```

Update network security perimeter link

### Example 2: Update network security perimeter link via identity

```powershell
$getLinkObj = Get-AzNetworkSecurityPerimeterLink -Name t-link2 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp4

Update-AzNetworkSecurityPerimeterLink -InputObject $getLinkObj -LocalInboundProfile @('*')

```

```output
Etag Name
---- ----
     t-link2
```

Update network security perimeter link via identity
