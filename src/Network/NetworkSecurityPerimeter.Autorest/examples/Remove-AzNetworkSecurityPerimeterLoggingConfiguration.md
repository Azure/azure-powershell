### Example 1: Remove the Network security perimeter logging configuration
```powershell
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3
```

Get the Network security perimeter logging configuration

### Example 2: Remove a network security perimeter logging configuration via identity
```powershell
 $configObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_Ex -SecurityPerimeterName ext-nsp11
 Remove-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $configObj
```

Remove a network security perimeter logging configuration via identity