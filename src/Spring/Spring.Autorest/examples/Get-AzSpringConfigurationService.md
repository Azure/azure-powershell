### Example 1: Get the Application Configuration Service and its properties.
```powershell
Get-AzSpringConfigurationService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
GitPropertyRepository        : {{
                                 "name": "ghatest",
                                 "patterns": [ "app/dev" ],
                                 "uri": "https://github.com/lijinpei2008/ghatest",
                                 "label": "master"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/configurationServices/default
Instance                     : {{
                                 "name": "application-configuration-service-674f48b866-clsh5",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-674f48b866-g8tgc",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:37:05
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:39:12
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Get the Application Configuration Service and its properties.

### Example 2: Get the Application Configuration Service and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringConfigurationService -SpringInputObject $serviceObj
```

```output
GitPropertyRepository        : {{
                                 "name": "ghatest",
                                 "patterns": [ "app/dev" ],
                                 "uri": "https://github.com/lijinpei2008/ghatest",
                                 "label": "master"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/configurationServices/default
Instance                     : {{
                                 "name": "application-configuration-service-674f48b866-clsh5",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-674f48b866-g8tgc",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:37:05
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:39:12
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Get the Application Configuration Service and its properties.