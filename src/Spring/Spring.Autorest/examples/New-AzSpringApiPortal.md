### Example 1: Create the default API portal or Create the existing API portal.
```powershell
$gatewayObj = Get-AzSpringCloudGateway -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
New-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -GatewayId $gatewayObj.Id -Public:$true -SkuName "E0" -SkuCapacity 2 -SkuTier "Enterprise"
```

```output
ApiTryOutEnabledState        : Enabled
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-56cd88b4f7-6c4fm",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-56cd88b4f7-v7f64",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestMemory        : 1Gi
SkuCapacity                  : 2
SkuName                      : E0
SkuTier                      : Enterprise
SourceUrl                    :
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyIssuerUri         :
SsoPropertyScope             :
SystemDataCreatedAt          : 2024-04-25 上午 06:52:12
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-25 上午 06:52:12
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Create the default API portal or Create the existing API portal.