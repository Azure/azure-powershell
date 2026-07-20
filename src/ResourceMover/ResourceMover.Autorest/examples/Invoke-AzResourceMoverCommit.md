### Example 1: Validate the dependencies before commit of the resources.
```powershell
Invoke-AzResourceMoverCommit -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('psdemorm-vnet') -MoveResourceInputType "MoveResourceId" -ValidateOnly
```

```output
AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 12:38:26 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralu
                 s-demoRMS/operations/c194298b-b2eb-4aab-80b4-129d1473b75c
Message        : 
Name           : c194298b-b2eb-4aab-80b4-129d1473b75c
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 12:38:25 PM
Status         : Succeeded

```

Validate the dependencies before commit of the resources. The same command can be used for both 'RegionToRegion' and 'RegionToZone' type move collections.

### Example 2: Commit the set of resources in the Move Collection using "MoveResource Name" as input. (RegionToRegion)
```powershell
Invoke-AzResourceMoverCommit -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('psdemorm-vnet') -MoveResourceInputType "MoveResourceId"
```

```output
AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 12:41:13 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralu
                 s-demoRMS/operations/80c04850-7f3f-4e9c-aa68-b868978b59f3
Message        : 
Name           : 80c04850-7f3f-4e9c-aa68-b868978b59f3
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 12:41:05 PM
Status         : Succeeded


```

Commit the set of resources in 'RegionToRegion' type Move Collection using "MoveResource Name" as input.

### Example 3: Commit the set of resources in the Move Collection using "MoveResource Name" as input. (RegionToZone)
```powershell
Invoke-AzResourceMoverCommit -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -MoveResource $('PSDemoVM-RegionToZone') -MoveResourceInputType "MoveResourceId"
```

```output
AdditionalInfo :
Code           :
Detail         :
EndTime        : 9/5/2023 12:03:41 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/operations/804a7a40-dd8a-4c55-aba1-4a68978b59f9
Message        :
Name           : 804a7a40-dd8a-4c55-aba1-4a68978b59f9
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 9/5/2023 12:02:33 PM
Status         : Succeeded

```

Commit the set of resources in 'RegionToZone' type Move Collection using "MoveResource Name" as input.

### Example 4: Commit the set of resources in the Move Collection using "SourceARMID" as input. (RegionToRegion)
```powershell
Invoke-AzResourceMoverCommit -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Network/networkSecurityGroups/PSDemoVM-nsg') -MoveResourceInputType "MoveResourceSourceId"
```

```output
AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 12:42:46 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralu
                 s-demoRMS/operations/d36ca519-8ced-48c9-a968-cb5e9c4db731
Message        : 
Name           : d36ca519-8ced-48c9-a968-cb5e9c4db731
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 12:42:41 PM
Status         : Succeeded

```

Commit the set of resources in 'RegionToRegion' type Move Collection using "SourceARMID" as input.


### Example 5: Commit the set of resources in the Move Collection using "SourceARMID" as input. (RegionToZone)
```powershell
Invoke-AzResourceMoverCommit -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -MoveResource $('/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-RegionToZone-RG/providers/Microsoft.Compute/virtualMachines/demo-RegionToZone-VM') -MoveResourceInputType "MoveResourceSourceId"
```

```output
AdditionalInfo :
Code           :
Detail         :
EndTime        : 9/5/2023 12:05:38 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/operations/48c9f452-10c6-a519-888b-d46cb5e9c4db
Message        :
Name           : 48c9f452-10c6-a519-888b-d46cb5e9c4db
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 9/5/2023 12:04:28 PM
Status         : Succeeded

```

Commit the set of resources in 'RegionToZone' type Move Collection using "SourceARMID" as input.