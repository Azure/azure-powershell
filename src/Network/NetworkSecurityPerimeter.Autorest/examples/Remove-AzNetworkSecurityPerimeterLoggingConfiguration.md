### Example 1: Remove the Network security perimeter logging configuration
```powershell
Remove-AzNetworkSecurityPerimeterLoggingConfiguration -Name instance -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3
```

Get the Network security perimeter logging configuration

### Example 2: Remove a network security perimeter logging configuration via identity
```powershell
 $linkRefObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_Ex -SecurityPerimeterName ext-nsp11 -Name instance
 Remove-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $linkRefObj
```

Remove a network security perimeter logging configuration via identity