### Example 1: Operation to Update an exiting Deployment.
```powershell
Update-AzSpringAppDeployment -AppName tools -Name green -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02
```

```output
Active                       : True
DeploymentSetting            : {
                                 "resourceRequests": {
                                   "cpu": "1",
                                   "memory": "1Gi"
                                 },
                                 "livenessProbe": {
                                   "probeAction": {
                                     "type": "TCPSocketAction"
                                   },
                                   "disableProbe": false,
                                   "initialDelaySeconds": 300,
                                   "periodSeconds": 10,
                                   "timeoutSeconds": 3,
                                   "failureThreshold": 3,
                                   "successThreshold": 1
                                 },
                                 "readinessProbe": {
                                   "probeAction": {
                                     "type": "TCPSocketAction"
                                   },
                                   "disableProbe": false,
                                   "initialDelaySeconds": 0,
                                   "periodSeconds": 5,
                                   "timeoutSeconds": 3,
                                   "failureThreshold": 3,
                                   "successThreshold": 1
                                 },
                                 "startupProbe": {
                                   "disableProbe": false
                                 },
                                 "terminationGracePeriodSeconds": 90
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/apps/tools/deployments/green
Instance                     : {{
                                 "name": "tools-green-5-6776b488f6-xllmz",
                                 "status": "Running",
                                 "discoveryStatus": "UP",
                                 "startTime": "2024-05-28T03:52:58Z"
                               }}
Name                         : green
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  : 1
SkuName                      : S0
SkuTier                      : Standard
Source                       : {
                                 "type": "Jar",
                                 "relativePath": "resources/f9d35d43770d39092a663e665e82ae1d84a9e0da3d0d10c407acada6a40cd281-2024052703-cca56cd9-5602-4ec6-bb23-64df5cdd7e94",
                                 "runtimeVersion": "Java_8"
                               }
Status                       : Running
SystemDataCreatedAt          : 2024-05-27 上午 03:48:15
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 03:52:53
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apps/deployments
```

Operation to Update an exiting Deployment.