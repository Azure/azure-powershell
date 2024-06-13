### Example 1: Lists Network security perimeter links

```powershell
 Get-AzNetworkSecurityPerimeterLink -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp2
```

```output
Etag Name
---- ----
     t-link1
```

Lists Network security perimeter links

### Example 2: Get a Network security perimeter link

```powershell
 Get-AzNetworkSecurityPerimeterLink -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp2 -Name t-link1
```

```output
Etag Name
---- ----
     t-link1
```

Get a Network security perimeter link
