### Example 1: Patch the base Settings of the target resource
```powershell
Update-AzArcSetting -ResourceGroupName "ytongtest" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BaseProvider "Microsoft.HybridCompute" -BaseResourceName "testmachine" -BaseResourceType "machines" -GatewayResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/gateways/myArcGateway"
```

```output
GatewayPropertyGatewayResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/p
                                   roviders/Microsoft.HybridCompute/gateways/myArcGateway
Id                               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/p
                                   roviders/Microsoft.HybridCompute/machines/testmachine/providers/Microsoft.Hybr
                                   idCompute/settings/default
Name                             : default
ResourceGroupName                : ytongtest
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
TenantId                         : 00000000-0000-0000-0000-000000000000
Type                             : Microsoft.HybridCompute/settings
```

Patch the base Settings of the target resource