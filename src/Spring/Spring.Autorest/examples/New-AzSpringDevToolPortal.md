### Example 1: Create the default Dev Tool Portal or Create the existing Dev Tool Portal.
```powershell
New-AzSpringDevToolPortal -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorState Enabled -ApplicationLiveViewState Enabled -Public:$true
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
                                     "name": "server-74fb8d9d7c-5pwld",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "server-74fb8d9d7c-ffgjt",
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
SystemDataCreatedAt          : 2024-04-25 上午 07:38:47
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-25 上午 07:38:47
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/devToolPortals
Url                          : azps-spring-01-devtoolportal-a638a.svc.azuremicroservices.io
```

Create the default Dev Tool Portal or Create the existing Dev Tool Portal.