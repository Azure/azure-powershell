### Example 1: create a gateway for arc machine
```powershell
New-AzArcGateway -Name "myArcGateway" -ResourceGroupName "ytongtest" -Location "eastus" -SubscriptionId "00000000-0000-0000-0000-000000000000"
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

create a gateway for arc machine
