### Example 1: Delete NetworkSecurityPerimeter Association by Name
```powershell
Remove-AzNetworkSecurityPerimeterAssociation -Name association-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Delete NetworkSecurityPerimeter Association by Name

### Example 2: Delete NetworkSecurityPerimeter Association by Identity (using pipe)
```powershell
$associationObj = Get-AzNetworkSecurityPerimeterAssociation -Name association-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterAssociation -InputObject $associationObj
```

Delete NetworkSecurityPerimeter Association by Identity (using pipe)