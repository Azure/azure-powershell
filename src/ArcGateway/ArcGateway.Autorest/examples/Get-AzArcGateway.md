### Example 1: Get a list of gateway under a subscription
```powershell
Get-AzArcGateway -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Location      Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDat
                                                                                                  aLastModi
                                                                                                  fiedAt
--------      ----                ------------------- ------------------- ----------------------- ---------
eastus2euap   adrielk_gateway
centraluseuap dakirby_gatewayTest
eastus        MyArcgateway2
eastus        myArcGateway
centralus     hcrp_synthetics_gw
```

Get a list of gateway under a subscription

### Example 2: Get a list of gateway under a resource group
```powershell
 Get-AzArcGateway -Name "myArcGateway" -ResourceGroupName "ytongtest"
```

```output
AllowedFeature               : {*}
Endpoint                     : 00000000-0000-0000-0000-000000000000.gw.arc.azure.com
GatewayId                    : 00000000-0000-0000-0000-000000000000
GatewayType                  : Public
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest
                               /providers/Microsoft.HybridCompute/gateways/myArcGateway
Location                     : eastus
Name                         : myArcGateway
ProvisioningState            : Succeeded
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/gateways
```

Get a list of gateway under a resource group

