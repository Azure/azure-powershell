### Example 1: Delete NetworkSecurityPerimeter by Name
```powershell
Remove-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
```

Delete NetworkSecurityPerimeter by Name

### Example 2: Delete NetworkSecurityPerimeter by Identity (using pipe)
```powershell
$nspObj = Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1 
Remove-AzNetworkSecurityPerimeter -InputObject $nspObj
```

Delete NetworkSecurityPerimeter by Identity (using pipe)