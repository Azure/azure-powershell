### Example 1: Get the Service Registry and its properties.
```powershell
Get-AzSpringServiceRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/serviceRegistries/default
Instance                     : {{
                                 "name": "eureka-azps-spring-01-default-727d1-0",
                                 "status": "Running"
                               }, {
                                 "name": "eureka-azps-spring-01-default-727d1-1",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:42:49
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:42:49
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/serviceRegistries
```

Get the Service Registry and its properties.

### Example 2: Get the Service Registry and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringServiceRegistry -SpringInputObject $serviceObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/serviceRegistries/default
Instance                     : {{
                                 "name": "eureka-azps-spring-01-default-727d1-0",
                                 "status": "Running"
                               }, {
                                 "name": "eureka-azps-spring-01-default-727d1-1",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:42:49
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:42:49
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/serviceRegistries
```

Get the Service Registry and its properties.