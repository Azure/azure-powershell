---
Module Name: Az.ResourceMover
Module Guid: 97d87543-8eef-4574-a70d-7317ec4abe54
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.resourcemover
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ResourceMover Module
## Description
Microsoft Azure PowerShell: Az.ResourceMover cmdlets

## Az.ResourceMover Cmdlets
### [Get-AzResourceMoverMoveCollection](Get-AzResourceMoverMoveCollection.md)


### [Get-AzResourceMoverMoveResource](Get-AzResourceMoverMoveResource.md)


### [Get-AzResourceMoverUnresolvedDependency](Get-AzResourceMoverUnresolvedDependency.md)


### [Invoke-AzResourceMoverCommit](Invoke-AzResourceMoverCommit.md)
Commits the set of resources included in the request body.
The commit operation is triggered on the moveResources in the moveState 'CommitPending' or 'CommitFailed', on a successful completion the moveResource moveState do a transition to Committed.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverDiscard](Invoke-AzResourceMoverDiscard.md)
Discards the set of resources included in the request body.
The discard operation is triggered on the moveResources in the moveState 'CommitPending' or 'DiscardFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverInitiateMove](Invoke-AzResourceMoverInitiateMove.md)
Moves the set of resources included in the request body.
The move operation is triggered after the moveResources are in the moveState 'MovePending' or 'MoveFailed', on a successful completion the moveResource moveState do a transition to CommitPending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverPrepare](Invoke-AzResourceMoverPrepare.md)
Initiates prepare for the set of resources included in the request body.
The prepare operation is on the moveResources that are in the moveState 'PreparePending' or 'PrepareFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [New-AzResourceMoverMoveCollection](New-AzResourceMoverMoveCollection.md)


### [New-AzResourceMoverMoveResource](New-AzResourceMoverMoveResource.md)


### [Remove-AzResourceMoverMoveCollection](Remove-AzResourceMoverMoveCollection.md)


### [Remove-AzResourceMoverMoveResource](Remove-AzResourceMoverMoveResource.md)


### [Resolve-AzResourceMoverMoveCollectionDependency](Resolve-AzResourceMoverMoveCollectionDependency.md)
Computes, resolves and validate the dependencies of the moveResources in the move collection.

