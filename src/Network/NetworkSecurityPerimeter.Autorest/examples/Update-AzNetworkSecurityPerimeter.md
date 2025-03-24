### Example 1: Updates a NetworkSecurityPerimeter
```powershell

Update-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1

```

```output
Location Name
-------- ----
         nsp3
```

Updates a NetworkSecurityPerimeter

### Example 2: Updates a NetworkSecurityPerimeter by identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1
 Update-AzNetworkSecurityPerimeter -InputObject $GETObj
```

```output
Location Name
-------- ----
         nsp3
```

Updates a NetworkSecurityPerimeter by identity (using pipe)