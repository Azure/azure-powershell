---
Module Name: Az.ResourceMoverServiceApi
Module Guid: 6d4d51c3-c57d-4cee-adfa-d95ae09c02db
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.resourcemoverserviceapi
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ResourceMoverServiceApi Module
## Description
Microsoft Azure PowerShell: ResourceMoverServiceApi cmdlets

## Az.ResourceMoverServiceApi Cmdlets
### [Get-AzResourceMoverServiceApiMoveCollection](Get-AzResourceMoverServiceApiMoveCollection.md)
Gets the move collection.

### [Get-AzResourceMoverServiceApiMoveCollectionRequired](Get-AzResourceMoverServiceApiMoveCollectionRequired.md)
List of the move resources for which an arm resource is required for.

### [Get-AzResourceMoverServiceApiMoveResource](Get-AzResourceMoverServiceApiMoveResource.md)
Gets the Move Resource.

### [Get-AzResourceMoverServiceApiOperationsDiscovery](Get-AzResourceMoverServiceApiOperationsDiscovery.md)


### [Get-AzResourceMoverServiceApiUnresolvedDependency](Get-AzResourceMoverServiceApiUnresolvedDependency.md)
Gets a list of unresolved dependencies.

### [Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove](Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove.md)
Removes the set of move resources included in the request body from move collection.
The orchestration is done by service.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverServiceApiCommitMoveCollection](Invoke-AzResourceMoverServiceApiCommitMoveCollection.md)
Commits the set of resources included in the request body.
The commit operation is triggered on the moveResources in the moveState 'CommitPending' or 'CommitFailed', on a successful completion the moveResource moveState do a transition to Committed.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverServiceApiInitiateMoveCollectionMove](Invoke-AzResourceMoverServiceApiInitiateMoveCollectionMove.md)
Moves the set of resources included in the request body.
The move operation is triggered after the moveResources are in the moveState 'MovePending' or 'MoveFailed', on a successful completion the moveResource moveState do a transition to CommitPending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [Invoke-AzResourceMoverServiceApiPrepareMoveCollection](Invoke-AzResourceMoverServiceApiPrepareMoveCollection.md)
Initiates prepare for the set of resources included in the request body.
The prepare operation is on the moveResources that are in the moveState 'PreparePending' or 'PrepareFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

### [New-AzResourceMoverServiceApiMoveCollection](New-AzResourceMoverServiceApiMoveCollection.md)
Creates or updates a move collection.

### [New-AzResourceMoverServiceApiMoveResource](New-AzResourceMoverServiceApiMoveResource.md)
Creates or updates a Move Resource in the move collection.

### [Remove-AzResourceMoverServiceApiMoveCollection](Remove-AzResourceMoverServiceApiMoveCollection.md)
Deletes a move collection.

### [Remove-AzResourceMoverServiceApiMoveResource](Remove-AzResourceMoverServiceApiMoveResource.md)
Deletes a Move Resource from the move collection.

### [Resolve-AzResourceMoverServiceApiMoveCollectionDependency](Resolve-AzResourceMoverServiceApiMoveCollectionDependency.md)
Computes, resolves and validate the dependencies of the moveResources in the move collection.

### [Update-AzResourceMoverServiceApiMoveCollection](Update-AzResourceMoverServiceApiMoveCollection.md)
Updates a move collection.

