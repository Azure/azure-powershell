---
Module Name: Az.ResourceMover
Module Guid: 97d87543-8eef-4574-a70d-7317ec4abe54
Download Help Link: https://learn.microsoft.com/powershell/module/az.resourcemover
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ResourceMover Module
## Description
Microsoft Azure PowerShell: ResourceMover cmdlets

## Az.ResourceMover Cmdlets
### [Add-AzResourceMoverMoveResource](Add-AzResourceMoverMoveResource.md)
Creates or updates a Move Resource in the move collection.

**The 'Add-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Get-AzResourceMoverMoveCollection](Get-AzResourceMoverMoveCollection.md)
Gets the move collection.

**The 'Get-AzResourceMoverMoveCollection' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Get-AzResourceMoverMoveResource](Get-AzResourceMoverMoveResource.md)
Gets the Move Resource.

**The 'Get-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Get-AzResourceMoverRequiredForResources](Get-AzResourceMoverRequiredForResources.md)
List of the move resources for which an arm resource is required for.

**The 'Get-AzResourceMoverRequiredForResources' command is applicable for 'RegionToRegion' type move collections.

However, for move collections with moveType 'RegionToZone' dependencies are automatically added to the move collection once 'Resolve-AzResourceMoverMoveCollectionDependency' is executed.
Please refer to 'Resolve-AzResourceMoverMoveCollectionDependency' command documentation for additional details.**

### [Get-AzResourceMoverUnresolvedDependency](Get-AzResourceMoverUnresolvedDependency.md)
Gets a list of unresolved dependencies.

**The 'Get-AzResourceMoverUnresolvedDependency' command is applicable for 'RegionToRegion' type move collections.**

**However, for move collections with moveType 'RegionToZone' dependencies are automatically added to the move collection once 'Resolve-AzResourceMoverMoveCollectionDependency' is executed.
Please refer to 'Resolve-AzResourceMoverMoveCollectionDependency' command documentation for additional details.**

### [Invoke-AzResourceMoverBulkRemove](Invoke-AzResourceMoverBulkRemove.md)
Removes the set of move resources included in the request body from move collection.
The orchestration is done by service.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

**The 'Invoke-AzResourceMoverBulkRemove ' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Invoke-AzResourceMoverCommit](Invoke-AzResourceMoverCommit.md)
Commits the set of resources included in the request body.
The commit operation is triggered on the moveResources in the moveState 'CommitPending' or 'CommitFailed', on a successful completion the moveResource moveState do a transition to Committed.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

**The 'Invoke-AzResourceMoverCommit' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Invoke-AzResourceMoverDiscard](Invoke-AzResourceMoverDiscard.md)
Discards the set of resources included in the request body.
The discard operation is triggered on the moveResources in the moveState 'CommitPending' or 'DiscardFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

**The 'Invoke-AzResourceMoverDiscard' command is not applicable on move collections with moveType 'RegionToZone' since discard is not a valid operation for region to zone move scenario.**

### [Invoke-AzResourceMoverInitiateMove](Invoke-AzResourceMoverInitiateMove.md)
Moves the set of resources included in the request body.The move operation is triggered after the moveResources are in the moveState 'MovePending' or 'MoveFailed', on a successful completion the moveResource moveState do a transition to CommitPending.To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

**The 'Invoke-AzResourceMoverInitiateMove' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Invoke-AzResourceMoverPrepare](Invoke-AzResourceMoverPrepare.md)
Initiates prepare for the set of resources included in the request body.
The prepare operation is on the moveResources that are in the moveState 'PreparePending' or 'PrepareFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

**The 'Invoke-AzResourceMoverPrepare' command is not applicable on move collections with moveType 'RegionToZone' since prepare is not a valid operation for region to zone move scenario.**

### [New-AzResourceMoverMoveCollection](New-AzResourceMoverMoveCollection.md)
Creates or updates a move collection.
The following types of move collections based on the move scenario are supported currently:

**1.
RegionToRegion** (Moving resources across regions)

**2.
RegionToZone** (Moving virtual machines into a zone within the same region)

### [Remove-AzResourceMoverMoveCollection](Remove-AzResourceMoverMoveCollection.md)
Deletes a move collection.

**The 'Remove-AzResourceMoverMoveCollection' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Remove-AzResourceMoverMoveResource](Remove-AzResourceMoverMoveResource.md)
Deletes a Move Resource from the move collection.

**The 'Remove-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**

### [Resolve-AzResourceMoverMoveCollectionDependency](Resolve-AzResourceMoverMoveCollectionDependency.md)
Computes, resolves and validate the dependencies of the moveResources in the move collection.

**Please note that for 'RegionToRegion' type move collections the 'Resolve-AzResourceMoverMoveCollectionDependency' command just resolves the move collection, the user is required to identify the list of unresolved dependencies using 'Get-AzResourceMoverUnresolvedDependency' and then manually add them to the move collection using 'Add-AzResourceMoverMoveResource' command.**

**However, for moveType 'RegionToZone' this command finds the required dependencies and automatically adds them to the move collection in a single step.**

