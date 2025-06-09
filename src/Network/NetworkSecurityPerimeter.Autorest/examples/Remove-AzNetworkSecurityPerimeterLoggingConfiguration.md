### Example 1: Remove NetworkSecurityPerimeter LoggingConfiguration
```powershell
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

Remove NetworkSecurityPerimeter LoggingConfiguration

### Example 2: Remove NetworkSecurityPerimeter LoggingConfiguration via Identity
```powershell
$configObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $configObj
```

Remove NetworkSecurityPerimeter LoggingConfiguration via Identity