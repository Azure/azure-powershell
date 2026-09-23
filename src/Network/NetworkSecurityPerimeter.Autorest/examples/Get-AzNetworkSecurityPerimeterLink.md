### Example 1: List NetworkSecurityPerimeter Links
```powershell
Get-AzNetworkSecurityPerimeterLink -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
Name            ResourceGroupName
----            -----------------
link-test-1     rg-test-1
link-test-2     rg-test-1
```

List NetworkSecurityPerimeter Links

### Example 2: Get NetworkSecurityPerimeter Link by Name
```powershell
Get-AzNetworkSecurityPerimeterLink -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -Name link-test-1
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {profile-test-1}
LocalOutboundProfile                  : {*}
Name                                  : link-test-1
ProvisioningState                     : Succeeded
RemoteInboundProfile                  : {*}
RemoteOutboundProfile                 : {*}
RemotePerimeterGuid                   : 00000000-0000-0000-0000-000000000000
RemotePerimeterLocation               : eastuseuap
ResourceGroupName                     : rg-test-1
Status                                : Approved
SystemDataCreatedAt                   :
SystemDataCreatedBy                   :
SystemDataCreatedByType               :
SystemDataLastModifiedAt              :
SystemDataLastModifiedBy              :
SystemDataLastModifiedByType          :
Type                                  : Microsoft.Network/networkSecurityPerimeters/links
```

Get NetworkSecurityPerimeter Link by Name