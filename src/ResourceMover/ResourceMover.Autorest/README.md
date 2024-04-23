<!-- region Generated -->
# Az.ResourceMover
This directory contains the PowerShell module for the ResourceMover service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ResourceMover`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`
 
---
### AutoRest Configuration
> see https://aka.ms/autorest

> Metadata
``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
title: ResourceMover
service-name: ResourceMover
prefix: Az
subject-prefix: $(service-name)
commit: bf2585e9f0696cc8d5f230481612a37eac542f39
repo: https://github.com/Azure/azure-rest-api-specs/tree/$(commit)
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/resourcemover/resource-manager/Microsoft.Migrate/stable/2023-08-01
input-file:
  - $(aks)/resourcemovercollection.json
module-version: 1.0.0

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Initiate$|^InitiateViaIdentity$|^InitiateViaIdentityExpanded$|^Commit$|^CommitViaIdentity$|^CommitViaIdentityExpanded$|^Discard$|^DiscardViaIdentity$|^DiscardViaIdentityExpanded$|^Prepare$|^PrepareViaIdentity$|^PrepareViaIdentityExpanded$|^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentityExpanded$|^UpdateViaIdentity$|^ResolveViaIdentity$|^GetViaIdentity$|^DeleteViaIdentity$|^Bulk$|^BulkViaIdentity$|^BulkViaIdentityExpanded$  
    remove: true
  - where:
      subject: OperationsDiscovery
    remove: true
  - where:      
      variant: DiscardExpanded
      subject: MoveCollection 
      verb: Remove
    set:
      verb: Invoke      
  - where:      
      variant: DiscardExpanded
      subject: MoveCollection 
      verb: Invoke
    set:
      subject: Discard
  - where:      
      variant: CreateExpanded 
      subject: MoveResource
      verb: New
    set:
      verb: Add
  - where:      
      variant: PrepareExpanded            
    set:
      subject: Prepare
  - where:      
      variant: InitiateExpanded            
    set:
      subject: InitiateMove
  - where:      
      variant: CommitExpanded            
    set:
      subject: Commit
  - where:
      variant: BulkExpanded
    set:
      subject: BulkRemove
  - where:
      verb: Add
      subject: MoveResource
    set:
      alias:
        - Update-AzResourceMoverMoveResource
  - where:
      verb: Get
      subject: MoveCollectionRequired
    set:
      subject: RequiredForResources
  - where:
      model-name: MoveResource
    set:
       suppress-format: true
  - where:
      model-name: OperationStatus
    set:
       suppress-format: true  
  - where:
      model-name: UnresolvedDependency
    set:
       suppress-format: true
  - no-inline:
    - ResourceSettings
  - from: ResourceMover.cs
    where: $
    transform: $ = $.replace(/throw new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.UndeclaredResponseException\(_response\);/g,"await onDefault\(_response,_response.Content.ReadAsStringAsync\(\).ContinueWith\( body => Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.CloudError.FromJson\(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse\(body.Result\)\) \)\);");

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}"].put
    transform: $["description"] = "Creates or updates a move collection. The following types of move collections based on the move scenario are supported currently:\<br>\<br>**1. RegionToRegion** (Moving resources across regions)\<br>\<br>**2. RegionToZone** (Moving virtual machines into a zone within the same region)"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}"].get
    transform: $["description"] = "Gets the move collection.\<br>\<br>**The 'Get-AzResourceMoverMoveCollection' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}"].delete
    transform: $["description"] = "Deletes a move collection.\<br>\<br>**The 'Remove-AzResourceMoverMoveCollection' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/prepare"].post
    transform: $["description"] = "Initiates prepare for the set of resources included in the request body. The prepare operation is on the moveResources that are in the moveState 'PreparePending' or 'PrepareFailed', on a successful completion the moveResource moveState do a transition to MovePending. To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.\<br>\<br>**The 'Invoke-AzResourceMoverPrepare' command is not applicable on move collections with moveType 'RegionToZone' since prepare is not a valid operation for region to zone move scenario.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/initiateMove"].post
    transform: $["description"] = "Moves the set of resources included in the request body.The move operation is triggered after the moveResources are in the moveState 'MovePending' or 'MoveFailed', on a successful completion the moveResource moveState do a transition to CommitPending.To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.\<br>\<br>**The 'Invoke-AzResourceMoverInitiateMove' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/commit"].post
    transform: $["description"] = "Commits the set of resources included in the request body. The commit operation is triggered on the moveResources in the moveState 'CommitPending' or 'CommitFailed', on a successful completion the moveResource moveState do a transition to Committed. To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.\<br>\<br>**The 'Invoke-AzResourceMoverCommit' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/discard"].post
    transform: $["description"] = "Discards the set of resources included in the request body. The discard operation is triggered on the moveResources in the moveState 'CommitPending' or 'DiscardFailed', on a successful completion the moveResource moveState do a transition to MovePending. To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.\<br>\<br>**The 'Invoke-AzResourceMoverDiscard' command is not applicable on move collections with moveType 'RegionToZone' since discard is not a valid operation for region to zone move scenario.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/resolveDependencies"].post
    transform: $["description"] = "Computes, resolves and validate the dependencies of the moveResources in the move collection.\<br>\<br>**Please note that for 'RegionToRegion' type move collections the 'Resolve-AzResourceMoverMoveCollectionDependency' command just resolves the move collection, the user is required to identify the list of unresolved dependencies using 'Get-AzResourceMoverUnresolvedDependency' and then manually add them to the move collection using 'Add-AzResourceMoverMoveResource' command.**\<br>\<br>**However, for moveType 'RegionToZone' this command finds the required dependencies and automatically adds them to the move collection in a single step.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/unresolvedDependencies"].get
    transform: $["description"] = "Gets a list of unresolved dependencies.\<br>\<br>**The 'Get-AzResourceMoverUnresolvedDependency' command is applicable for 'RegionToRegion' type move collections.**\<br>\<br>**However, for move collections with moveType 'RegionToZone' dependencies are automatically added to the move collection once 'Resolve-AzResourceMoverMoveCollectionDependency' is executed. Please refer to 'Resolve-AzResourceMoverMoveCollectionDependency' command documentation for additional details.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/bulkRemove"].post
    transform: $["description"] = "Removes the set of move resources included in the request body from move collection. The orchestration is done by service. To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.\<br>\<br>**The 'Invoke-AzResourceMoverBulkRemove ' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/moveResources/{moveResourceName}"].put
    transform: $["description"] = "Creates or updates a Move Resource in the move collection.\<br>\<br>**The 'Add-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/moveResources/{moveResourceName}"].delete
    transform: $["description"] = "Deletes a Move Resource from the move collection.\<br>\<br>**The 'Remove-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/moveResources/{moveResourceName}"].get
    transform: $["description"] = "Gets the Move Resource.\<br>\<br>**The 'Get-AzResourceMoverMoveResource' command remains same for both 'RegionToRegion' and 'RegionToZone' type move collections.**"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/requiredFor"].get
    transform: $["description"] = "List of the move resources for which an arm resource is required for.\<br>\<br>**The 'Get-AzResourceMoverRequiredForResources' command is applicable for 'RegionToRegion' type move collections.\<br>\<br>However, for move collections with moveType 'RegionToZone' dependencies are automatically added to the move collection once 'Resolve-AzResourceMoverMoveCollectionDependency' is executed. Please refer to 'Resolve-AzResourceMoverMoveCollectionDependency' command documentation for additional details.**"
```
