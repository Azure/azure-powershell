### Example 1: Delete NetworkSecurityPerimeter Profile by Name
```powershell
Remove-AzNetworkSecurityPerimeterProfile -Name profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Delete NetworkSecurityPerimeter Profile by Name

### Example 2: Delete NetworkSecurityPerimeter Profile by Identity (using pipe)
```powershell
$profileObj = Get-AzNetworkSecurityPerimeterProfile -Name profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterProfile -InputObject $profileObj
```

Delete NetworkSecurityPerimeter Profile by Identity (using pipe)