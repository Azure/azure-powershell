### Example 1: Get the Application Live  and its properties.
```powershell
Get-AzSpringApplicationLiveView -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "512Mi",
                                   "instanceCount": 1
                                 },
                                 "instances": [
                                   {
                                     "name": "application-live-view-connector-6446fb4795-d28qg",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1",
                                   "memory": "1Gi",
                                   "instanceCount": 1
                                 },
                                 "instances": [
                                   {
                                     "name": "application-live-view-server-77f7f64bc7-qt7rp",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationLiveViews/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-24 上午 07:03:34
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:03:34
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationLiveViews
```

Get the Application Live  and its properties.

### Example 2: Get the Application Live  and its properties.
```powershell
Get-AzSpringApplicationLiveView -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "512Mi",
                                   "instanceCount": 1
                                 },
                                 "instances": [
                                   {
                                     "name": "application-live-view-connector-6446fb4795-d28qg",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1",
                                   "memory": "1Gi",
                                   "instanceCount": 1
                                 },
                                 "instances": [
                                   {
                                     "name": "application-live-view-server-77f7f64bc7-qt7rp",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationLiveViews/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-24 上午 07:03:34
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:03:34
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationLiveViews
```

Get the Application Live  and its properties.