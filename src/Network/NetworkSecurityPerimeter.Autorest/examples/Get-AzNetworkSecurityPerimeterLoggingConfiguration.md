### Example 1: Get NetworkSsecurityPerimeter LoggingConfiguration
```powershell
Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
EnabledLogCategory           : {NspPublicInboundPerimeterRulesAllowed}
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
Version                      : 4
```

Get NetworkSsecurityPerimeter LoggingConfiguration