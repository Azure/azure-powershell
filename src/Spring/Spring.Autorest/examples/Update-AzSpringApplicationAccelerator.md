### Example 1: Update the application accelerator.
```powershell
Update-AzSpringApplicationAccelerator -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -SkuName E0 -SkuCapacity 2 -SkuTier Enterprise
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
                                     "name": "acc-server-744d7b79b5-s4b8x",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "acc-server-744d7b79b5-xpnzr",
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
                                     "name": "acc-engine-799bc59df8-wr2p2",
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
                                     "name": "accelerator-controller-manager-565b9c888b-qldlg",
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
                                     "name": "source-controller-manager-5c9cd87f5-bwr9x",
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
SystemDataCreatedAt          : 2024-05-24 上午 07:01:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 11:55:35
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators
```

Update the application accelerator.