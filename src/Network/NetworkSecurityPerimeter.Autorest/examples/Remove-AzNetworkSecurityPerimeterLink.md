### Example 1: Remove network security perimeter link
```powershell
Remove-AzNetworkSecurityPerimeterLink -Name t-linkD3 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp8
```

```output

```

Remove network security perimeter link

### Example 2: Remove network security perimeter link via identity

```powershell
$linkObj = Get-AzNetworkSecurityPerimeterLink -Name t-linkD4 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp10
Remove-AzNetworkSecurityPerimeterLink -InputObject $linkObj
```

```output

```

Remove network security perimeter link via identity
