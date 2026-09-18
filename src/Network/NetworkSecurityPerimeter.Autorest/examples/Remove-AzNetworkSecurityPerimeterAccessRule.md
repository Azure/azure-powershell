### Example 1: Delete NetworkSecurityPerimeter AccessRule by Name
```powershell
Remove-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-1 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Delete NetworkSecurityPerimeter AccessRule by Name

### Example 2: Delete NetworkSecurityPerimeter AccessRule by Identity (using pipe)
```powershell
$accessRuleObj = Get-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-1 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterAccessRule -InputObject $accessRuleObj
```

Deletes NetworkSecurityPerimeter AccessRule by Identity (using pipe)