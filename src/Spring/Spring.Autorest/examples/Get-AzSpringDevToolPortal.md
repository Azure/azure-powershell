### Example 1: Get the Application Live  and its properties.
```powershell
Get-AzSpringDevToolPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApplicationAcceleratorRoute  : create
ApplicationAcceleratorState  : Enabled
ApplicationLiveViewRoute     : app-live-view
ApplicationLiveViewState     : Enabled
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "1Gi",
                                   "instanceCount": 2
                                 },
                                 "name": "server",
                                 "instances": [
                                   {
                                     "name": "server-d5bfc75b-9jv75",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "server-d5bfc75b-wdvpk",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/devToolPortals/default
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyMetadataUrl       :
SsoPropertyScope             :
SystemDataCreatedAt          : 2024-05-24 上午 06:17:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 06:17:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/devToolPortals
Url                          : azps-spring-01-devtoolportal-a638a.svc.azuremicroservices.io
```

Get the Application Live  and its properties.

### Example 2: Get the Application Live  and its properties.
```powershell
Get-AzSpringDevToolPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApplicationAcceleratorRoute  : create
ApplicationAcceleratorState  : Enabled
ApplicationLiveViewRoute     : app-live-view
ApplicationLiveViewState     : Enabled
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "1Gi",
                                   "instanceCount": 2
                                 },
                                 "name": "server",
                                 "instances": [
                                   {
                                     "name": "server-d5bfc75b-9jv75",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "server-d5bfc75b-wdvpk",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/devToolPortals/default
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyMetadataUrl       :
SsoPropertyScope             :
SystemDataCreatedAt          : 2024-05-24 上午 06:17:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 06:17:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/devToolPortals
Url                          : azps-spring-01-devtoolportal-a638a.svc.azuremicroservices.io
```

Get the Application Live  and its properties.