### Example 1: Remove NetworkSecurityPerimeter LinkReference
```powershell
Remove-AzNetworkSecurityPerimeterLinkReference -Name Ref-from-link-test-1-00000000-78f8-4f1b-8f30-ffe0eaa74495 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Remove NetworkSecurityPerimeter LinkReference

### Example 2: Remove NetworkSecurityPerimeter LinkReference via Identity
```powershell
$linkRefObj = Get-AzNetworkSecurityPerimeterLinkReference -Name Ref-from-link-test-1-00000000-78f8-4f1b-8f30-ffe0eaa74495 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterLinkReference -InputObject $linkRefObj
```

Remove NetworkSecurityPerimeter LinkReference via Identity