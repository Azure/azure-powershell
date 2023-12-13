### Example 1: Update a fleet update strategy with a fleet object
```powershell
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600
Update-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3 -StrategyStage $stage
```

```output
ETag                         : "8906612a-0000-0100-0000-655b2c330000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy3
Name                         : strategy3
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
SystemDataCreatedAt          : 11/20/2023 9:51:46 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/20/2023 9:51:46 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

The first command get a fleet. The second command creates a new fleet update stage object. The third command updates stage for specified fleet update strategy with a fleet object.

### Example 2: Update a fleet update strategy
```powershell
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 360
Update-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1 -StrategyStage $stage
```

```output
ETag                         : "c9064db3-0000-0100-0000-655c75350000"
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
                                 "afterStageWaitInSeconds": 360
                               }}
SystemDataCreatedAt          : 11/21/2023 9:15:33 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/21/2023 9:15:33 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

This command updates stage for specified fleet update strategy.

