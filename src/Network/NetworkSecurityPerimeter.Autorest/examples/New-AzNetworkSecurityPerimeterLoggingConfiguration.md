### Example 1: Create network security perimeter logging configuration
```powershell
New-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -EnabledLogCategory NspPublicOutboundPerimeterRulesAllowed
```

```output
EnabledLogCategory           Name
------------------           ----
{NspPublicOutboundPerimeterRulesAllowed} instance
```

Create network security perimeter logging configuration
