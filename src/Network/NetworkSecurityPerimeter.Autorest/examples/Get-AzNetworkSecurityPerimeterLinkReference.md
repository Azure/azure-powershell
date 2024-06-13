### Example 1: Lists network security link references

```powershell
Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3
```

```output
Etag Name
---- ----
     Ref-from-t-link1-1738a5f3-78f8-4f1b-8f30-ffe0eaa74495
```

Lists network security link references

### Example 2: Gets a network security link reference by name

```powershell
 Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3 -Name Ref-from-t-link1-1738a5f3-78f8-4f1b-8f30-ffe0eaa74495
```

```output
Etag Name
---- ----
     Ref-from-t-link1-1738a5f3-78f8-4f1b-8f30-ffe0eaa74495
```

Gets a network security link reference by name
