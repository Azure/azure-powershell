### Example 1: Removes a network security perimeter link reference
```powershell
Remove-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3 -Name Ref-from-t-link1-1738a5f3-78f8-4f1b-8f30-ffe0eaa74495
```

```output
```

Removes a network security perimeter link reference

### Example 2: Removes a network security perimeter link reference via identity
```powershell
 $linkRefObj = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName psrg_Ex -SecurityPerimeterName ext-nsp11 -Name Ref-from-t-linkD4-902f9e36-84c2-43d6-983d-677f70568a30
 Remove-AzNetworkSecurityPerimeterLinkReference -InputObject $linkRefObj
```

```output
```

Removes a network security perimeter link reference via identity
