### Example 1: Create the application accelerator.
```powershell
New-AzSpringApplicationAccelerator -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -SkuName E0 -SkuCapacity 2 -SkuTier Enterprise
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 2
                                 },
                                 "name": "accelerator-server",
                                 "instances": [
                                   {
                                     "name": "acc-server-7d4b6c6bc9-749xf",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "acc-server-7d4b6c6bc9-tqqjt",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1000m",
                                   "memory": "3Gi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-engine",
                                 "instances": [
                                   {
                                     "name": "acc-engine-6478748db4-6b2mt",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-controller",
                                 "instances": [
                                   {
                                     "name": "accelerator-controller-manager-85c98cf5fb-wr6rp",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "source-controller",
                                 "instances": [
                                   {
                                     "name": "source-controller-manager-d69766f6c-gd87t",
                                     "status": "Running"
                                   }
                                 ]
                               }…}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
SystemDataCreatedAt          : 2024-04-26 上午 06:04:21
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-26 上午 06:04:21
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators
```

Create the application accelerator.