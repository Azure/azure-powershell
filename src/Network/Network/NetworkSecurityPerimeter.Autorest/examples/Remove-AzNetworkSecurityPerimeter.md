### Example 1: Deletes a NetworkSecurityPerimeter by Name
```powershell

 Remove-AzNetworkSecurityPerimeter -Name nsp5 -ResourceGroupName ResourceGroup-1

```

```output

```
Deletes a NetworkSecurityPerimeter by Name

### Example 2: Deletes a NetworkSecurityPerimeter by identity (using pipe)
```powershell

 $nspObj = Get-AzNetworkSecurityPerimeter -Name nsp6 -ResourceGroupName ResourceGroup-1 
 Remove-AzNetworkSecurityPerimeter -InputObject $nspObj

```

```output

```
Deletes a NetworkSecurityPerimeter by identity (using pipe)
