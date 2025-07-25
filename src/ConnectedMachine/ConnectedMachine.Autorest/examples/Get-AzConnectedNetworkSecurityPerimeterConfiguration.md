### Example 1: Get network security perimeter of a private link scope
```powershell
Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.ResourceGroupNameNSP -ScopeName $env.PrivateLinkScopeNameNSP
```

```output
Id                               : /subscriptions/********-****-****-****-**********/resourceGroups/adrie
                                   lk_test/providers/Microsoft.HybridCompute/privateLinkScopes/adrielScope/
                                   networkSecurityPerimeterConfigurations/********-****-****-****-**********
                                   .adrielScope-********-****-****-****-**********
Name                             : ********-****-****-****-**********
                                   .adrielScope-********-****-****-****-**********
NetworkSecurityPerimeterGuid     : ********-****-****-****-**********
NetworkSecurityPerimeterId       : /subscriptions********-****-****-****-**********/resourceGroups/adrie
                                   lk_test/providers/Microsoft.Network/networkSecurityPerimeters/adrielNsp
NetworkSecurityPerimeterLocation : centraluseuap
ProfileAccessRule                : {}
ProfileAccessRulesVersion        : 0
ProfileDiagnosticSettingsVersion : 0
ProfileEnabledLogCategory        : {NspPublicInboundPerimeterRulesAllowed,
                                   NspPublicInboundPerimeterRulesDenied,
                                   NspPublicOutboundPerimeterRulesAllowed,
                                   NspPublicOutboundPerimeterRulesDenied…}
ProfileName                      : defaultProfile
ProvisioningIssue                : {}
ProvisioningState                : Succeeded
ResourceAssociationAccessMode    : Learning
ResourceAssociationName          : adrielScope-********-****-****-****-**********
ResourceGroupName                : adrielk_test
Type                             : Microsoft.HybridCompute/privateLinkScopes/networkSecurityPerimeterConfig
                                   urations
```

Get network security perimeter of a private link scope
