### Example 1: Create a fleet update strategy
```powershell
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600
New-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1 -StrategyStage $stage
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

The first command creates a fleet update stage object. The second command creates a fleet update strategy.

### Example 2: Create a fleet update strategy with a fleet object
```powershell
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
$stage2 = New-AzFleetUpdateStageObject -Name stag2 -Group @{name='group-b'} -AfterStageWaitInSecond 3600
New-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3 -StrategyStage $stage2
```

```output
ETag                         : "88067ac6-0000-0100-0000-655b29860000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy3
Name                         : strategy3
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
StrategyStage                : {{
                                 "name": "stag2",
                                 "groups": [
                                   {
                                     "name": "group-b"
                                   }
                                 ],
                                 "afterStageWaitInSeconds": 3600
                               }}
SystemDataCreatedAt          : 11/20/2023 9:40:21 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/20/2023 9:40:21 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

The first command get a fleet. The second command creates a fleet update stage object. The third command uses fleet resource to create a fleet update strategy.

