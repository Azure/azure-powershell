### Example 1: Compute, resolve and validate the dependencies of the Move Resources in the Move collection. (RegionToRegion)
```powershell
Resolve-AzResourceMoverMoveCollectionDependency -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" 
```

```output
AdditionalInfo : 
Code           : MoveCollectionResolveDependenciesOperationFailed
Detail         : {}
EndTime        : 2/9/2021 2:05:04 AM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/operations/c2ad0066-6a69-45fe-aa70-193c240a9bc0
Message        : The resolve dependencies operation of one or more resources has failed. Check the move status of the resource for more details.
Possible Causes: The resolve dependencies operation of one ore more resources has failed.
Recommended Action: Retry the operation after resolving errors if any. If issue persists, contact support.
Name           : c2ad0066-6a69-45fe-aa70-193c240a9bc0
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/9/2021 2:05:00 AM
Status         : Succeeded
```

Compute, resolve and validate the dependencies of the Move Resources in 'RegionToRegion' type Move collection.

### Example 2: Compute, resolve and validate the dependencies of the Move Resources in the Move collection. (RegionToZone)
```powershell
Resolve-AzResourceMoverMoveCollectionDependency -MoveCollectionName "PS-demo-RegionToZone"  -ResourceGroupName "RG-MoveCollection-demoRMS"
```

```output
AdditionalInfo :
Code           :
Detail         :
EndTime        : 9/5/2023 11:45:11 AM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/operations/26077f45-dd8a-406d-bfc9-1b2d59d27e25
Message        :
Name           : 26077f45-dd8a-406d-bfc9-1b2d59d27e25
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 9/5/2023 11:45:10 AM
Status         : Succeeded
```

Compute, resolve and validate the dependencies of the Move Resources in 'RegionToZone' type Move collection.