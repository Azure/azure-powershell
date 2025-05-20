### Example 1: Remove NetworkSecurityPerimeter Link
```powershell
Remove-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Remove NetworkSecurityPerimeter Link

### Example 2: Remove NetworkSecurityPerimeter Link via Identity
```powershell
$linkObj = Get-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterLink -InputObject $linkObj
```

Remove NetworkSecurityPerimeter Link via Identity