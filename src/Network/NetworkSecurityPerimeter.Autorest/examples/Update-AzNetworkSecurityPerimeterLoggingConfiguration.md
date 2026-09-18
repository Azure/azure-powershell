### Example 1: Update NetworkSecurityPerimeter LoggingConfiguration
```powershell
Update-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -EnabledLogCategory @('NspPublicOutboundPerimeterRulesAllowed')
```

```output
EnabledLogCategory           : {NspPublicOutboundPerimeterRulesAllowed}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/loggingConfigurations/instance
Name                         : instance
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/loggingConfigurations
Version                      : 2
```

Update NetworkSecurityPerimeter LoggingConfiguration