### Example 1: Update the default Spring Cloud Gateway route configs or Update the existing Spring Cloud Gateway route configs.
```powershell
$routeObj = New-AzSpringCloudGatewayApiRouteObject -Title "myApp route config" -SsoEnabled $true -Filter "StripPrefix=2","RateLimit=1,1s" -Predicate "Path=/api5/customer/**"
$appObj = Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tools
Update-AzSpringCloudGatewayRouteConfig -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default -RouteConfigName azps-routeconfig -appResourceId $appObj.Id -OpenApiUri "https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json" -Protocol HTTPS -Route $routeObj
```

```output
AppResourceId                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
Filter                       :
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default/routeConfigs/azp
                               s-routeconfig
Name                         : azps-routeconfig
OpenApiUri                   : https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json
Predicate                    :
Protocol                     : HTTPS
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Route                        : {{
                                 "title": "myApp route config",
                                 "ssoEnabled": true,
                                 "tokenRelay": false,
                                 "predicates": [ "Path=/api5/customer/**" ],
                                 "filters": [ "StripPrefix=2", "RateLimit=1,1s" ]
                               }}
SsoEnabled                   :
SystemDataCreatedAt          : 2024-05-24 上午 07:08:09
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 10:41:02
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/gateways/routeConfigs
```

Update the default Spring Cloud Gateway route configs or Update the existing Spring Cloud Gateway route configs.