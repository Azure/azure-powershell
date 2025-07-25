### Example 1: Get a list of fleet update strategy with specified fleet
```powershell
Get-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
Name       SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   ResourceG 
                                                                                                                                                                                                     roupName  
----       -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   --------- 
strategy1  11/17/2023 9:08:49 AM user1@example.com     User                    11/17/2023 9:08:49 AM    user1@example.com        User                         "fd057996-0000-0100-0000-65572da20000" K8sFleet… 
strategy2  11/20/2023 9:36:32 AM user1@example.com     User                    11/20/2023 9:36:32 AM    user1@example.com        User                         "88066ba5-0000-0100-0000-655b28a00000" K8sFleet… 
strategy3  11/20/2023 9:40:21 AM user1@example.com     User                    11/20/2023 9:40:21 AM    user1@example.com        User                         "88067ac6-0000-0100-0000-655b29860000" K8sFleet… 
```

This command get a list of fleet update strategy.

### Example 2: Get a fleet update strategy with specified name
```powershell
Get-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1
```

```output
ETag                         : "fd057996-0000-0100-0000-65572da20000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy1
Name                         : strategy1
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
StrategyStage                : {{
                                 "name": "stag1",
                                 "groups": [
                                   {
                                     "name": "group-a"
                                   }
                                 ],
                                 "afterStageWaitInSeconds": 3600
                               }}
SystemDataCreatedAt          : 11/17/2023 9:08:49 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/17/2023 9:08:49 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

This command gets specific a fleet update strategy with specified update strategy name.

