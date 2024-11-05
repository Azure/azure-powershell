### Example 1: Get the Network security perimeter logging configuration
```powershell
Get-AzNetworkSecurityPerimeterLoggingConfiguration -Name instance -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp3
```

```output
EnabledLogCategory           Name
------------------           ----
{NspPublicInboundPerimeterRulesAllowed} instance
```

Get the Network security perimeter logging configuration
