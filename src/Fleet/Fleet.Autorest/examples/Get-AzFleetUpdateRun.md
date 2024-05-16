### Example 1: Get a list of fleet update run with specified fleet
```powershell
Get-AzFleetUpdateRun -FleetName testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
Name SystemDataCreatedAt    SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   ResourceGroupN 
                                                                                                                                                                                                ame
---- -------------------    -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   -------------- 
run1 11/21/2023 10:03:56 AM user1@example.com     User                    11/21/2023 10:03:56 AM   user1@example.com        User                         "cb064a93-0000-0100-0000-655c81950000" K8sFleet-Test  
run2 11/21/2023 10:10:18 AM user1@example.com     User                    11/21/2023 10:10:18 AM   user1@example.com        User                         "cb0654a8-0000-0100-0000-655c820b0000" K8sFleet-Test  
```

This command gets a list of fleet update run with specified fleet.

### Example 2: Get specific fleet update run with specified name
```powershell
Get-AzFleetUpdateRun -FleetName testfleet01 -Name run1 -ResourceGroupName K8sFleet-Test
```

```output
AdditionalInfo                             : 
Code                                       : 
Detail                                     : 
ETag                                       : "cb064a93-0000-0100-0000-655c81950000"
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateRuns/run1
Message                                    : 
Name                                       : run1
NodeImageSelectionSelectedNodeImageVersion : 
NodeImageSelectionType                     : Latest
ProvisioningState                          : Succeeded
ResourceGroupName                          : K8sFleet-Test
StatusCompletedTime                        : 
StatusStage                                : {{
                                               "status": {
                                                 "startTime": "2023-11-21T10:07:09.2665585Z",
                                                 "state": "Stopping"
                                               },
                                               "name": "default",
                                               "groups": [
                                                 {
                                                   "status": {
                                                     "startTime": "2023-11-21T10:07:09.2665583Z",
                                                     "state": "Stopping"
                                                   },
                                                   "name": "default",
                                                   "members": [
                                                     {
                                                       "status": {
                                                         "startTime": "2023-11-21T10:07:09.2665580Z",
                                                         "state": "Running"
                                                       },
                                                       "name": "testmember",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01",
                                                       "operationId": "50c4e26b-a391-4f7a-9d04-510bcbeda57d",
                                                       "message": "all agent pools in managed cluster \"TestCluster01\" are already in the latest node image version"
                                                     },
                                                     {
                                                       "status": {
                                                         "state": "NotStarted"
                                                       },
                                                       "name": "testmember2",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/testCluster02"
                                                     }
                                                   ]
                                                 }
                                               ]
                                             }}
StatusStartTime                            : 11/21/2023 10:07:09 AM
StatusState                                : Stopping
StrategyStage                              : 
SystemDataCreatedAt                        : 11/21/2023 10:03:56 AM
SystemDataCreatedBy                        : user1@example.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 11/21/2023 10:03:56 AM
SystemDataLastModifiedBy                   : user1@example.com
SystemDataLastModifiedByType               : User
Target                                     : 
Type                                       : Microsoft.ContainerService/fleets/updateRuns
UpdateStrategyId                           : 
UpgradeKubernetesVersion                   : 1.28.3
UpgradeType                                : Full
```

This command gets specific fleet update run with specified name.

