### Example 1: Create NetworkSecurityPerimeter Link
```powershell
$remotePerimeterId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers/Microsoft.Network/networkSecurityPerimeters/test-nsp-2"
New-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName test-nsp-1 -AutoApprovedRemotePerimeterResourceId $remotePerimeterId  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
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

Create NetworkSecurityPerimeter Link