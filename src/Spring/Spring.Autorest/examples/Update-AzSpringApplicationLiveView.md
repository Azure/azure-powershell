### Example 1: Update the default Application Live View or Update the existing Application Live View.
```powershell
Update-AzSpringApplicationLiveView -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
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
                                     "name": "application-live-view-connector-6b7c597746-b4hkc",
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
                                     "name": "application-live-view-server-69dbcd544c-nrst2",
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
SystemDataLastModifiedAt     : 2024-05-28 上午 11:50:02
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationLiveViews
```

Update the default Application Live View or Update the existing Application Live View.