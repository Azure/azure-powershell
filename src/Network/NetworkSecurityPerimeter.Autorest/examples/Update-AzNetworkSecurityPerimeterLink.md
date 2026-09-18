### Example 1: Update NetworkSecurityPerimeter Link
```powershell
Update-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {*}
LocalOutboundProfile                  : {*}
Name                                  : link-test-1
ProvisioningState                     : Succeeded
RemoteInboundProfile                  : {*}
RemoteOutboundProfile                 : {*}
RemotePerimeterGuid                   : 0000000-b1c5-4473-86d7-7755db0c6970
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

Update NetworkSecurityPerimeter Link

### Example 2: Update NetworkSecurityPerimeter Link via Identity
```powershell
$linkObj = Get-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Update-AzNetworkSecurityPerimeterLink -InputObject $linkObj -LocalInboundProfile @('profile-test-2')
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {profile-test-2}
LocalOutboundProfile                  : {*}
Name                                  : link-test-1
ProvisioningState                     : Succeeded
RemoteInboundProfile                  : {*}
RemoteOutboundProfile                 : {*}
RemotePerimeterGuid                   : 0000000-b1c5-4473-86d7-7755db0c6970
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

Update NetworkSecurityPerimeter Link via Identity