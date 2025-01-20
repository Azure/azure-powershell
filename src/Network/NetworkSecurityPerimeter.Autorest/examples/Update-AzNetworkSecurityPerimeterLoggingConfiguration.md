### Example 1: Update network security perimeter logging configuration
```powershell
Update-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6
 -EnabledLogCategory NspPublicOutboundPerimeterRulesAllowed
```

```output
EnabledLogCategory           Name
------------------           ----
{NspPublicOutboundPerimeterRulesAllowed} instance
```

Create network security perimeter logging configuration

