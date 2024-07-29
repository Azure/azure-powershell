### Example 1: Get the API portal and its properties.
```powershell
Get-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataCreatedAt          : 2023-12-15 上午 02:47:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.

### Example 2: Get the API portal and its properties.
```powershell
Get-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataCreatedAt          : 2023-12-15 上午 02:47:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.

### Example 3: Get the API portal and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringApiPortal -SpringInputObject $serviceObj -Name default
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataCreatedAt          : 2023-12-15 上午 02:47:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.