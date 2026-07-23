<!-- region Generated -->
# Az.DataTransfer
This directory contains the PowerShell module for the DataTransfer service.

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
For information on how to develop for `Az.DataTransfer`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: c424d91129a85194f3a0800a6bb5dcd28f8eb6eb
namespace: ADT
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/azuredatatransfer/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/azuredatatransfer/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: DataTransfer
subject-prefix: DataTransfer

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

## Flags to use PATCH method for Update-*
disable-getput: true
disable-transform-identity-type: true
flatten-userassignedidentity: false

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  
  - remove-operation: AzureDataTransfer_validateSchema
  - remove-operation: AzureDataTransfer_listApprovedSchemas
  # - remove-operation: Flows_Get
  # - remove-operation: Flows_CreateOrUpdate
  # - remove-operation: Flows_Delete
  # - remove-operation: Flows_Update
  # - remove-operation: Flows_Enable
  # - remove-operation: Flows_Disable
  # - remove-operation: Flows_Link
  - remove-operation: Flows_SetPassphrase
  - remove-operation: Flows_GeneratePassphrase
  - remove-operation: Flows_GetSourceAddresses
  - remove-operation: Flows_SetSourceAddresses
  - remove-operation: Flows_GetDestinationEndpoints
  - remove-operation: Flows_SetDestinationEndpoints
  - remove-operation: Flows_GetDestinationEndpointPorts
  - remove-operation: Flows_SetDestinationEndpointPorts
  - remove-operation: Flows_GetStreamConnectionString
  # - remove-operation: Flows_ListByConnection
  # - remove-operation: Connections_Get
  # - remove-operation: Connections_CreateOrUpdate
  # - remove-operation: Connections_Delete
  # - remove-operation: Connections_Update
  # - remove-operation: Connections_Link
  # - remove-operation: ListPendingConnections_List
  # - remove-operation: ListPendingFlows_List
  # - remove-operation: Connections_ListByResourceGroup
  # - remove-operation: Connections_ListBySubscription
  # - remove-operation: Pipelines_Get
  - remove-operation: Pipelines_CreateOrUpdate
  - remove-operation: Pipelines_Delete
  - remove-operation: Pipelines_Update
  # - remove-operation: Pipelines_ApproveConnection
  # - remove-operation: Pipelines_RejectConnection
  - remove-operation: ListSchemas_List
  # - remove-operation: Pipelines_ListByResourceGroup
  # - remove-operation: Pipelines_ListBySubscription
  - remove-operation: Operations_List
  - remove-operation: ListFlowsByPipeline_List
  # - remove-operation: Pipelines_ExecuteAction

  - where:
      parameter-name: Pipeline
    set:
      parameter-name: PipelineName

  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
    
  # Rename to avoid codegen errors
  - from: swagger-document
    where: $.definitions.streamSourceAddresses.properties.sourceAddresses
    transform: $['x-ms-client-name'] = 'AddressList'
  - from: swagger-document
    where: $.definitions.flowProperties.properties.connection
    transform: $['x-ms-client-name'] = 'FlowPropertiesConnection'

  # Rename approve/reject ConnectionId param
  - where:
      verb: Invoke
      subject: ^RejectPipelineConnection$
      parameter-name: Id
    set:
      parameter-name: ConnectionId

  - where:
      verb: Approve
      subject: ^PipelineConnection$
      parameter-name: Id
    set:
      parameter-name: ConnectionId

  # Rename approve/reject Connection cmdlets
  - where:
      verb: Invoke
      subject: ^RejectPipelineConnection$
    set:
      verb: Deny
      subject: Connection

  - where:
      verb: Approve
      subject: ^PipelineConnection$
    set:
      subject: Connection

  # Rename Link cmdlets
  - where:
      verb: Invoke
      subject: ^LinkConnection$
      parameter-name: Id
    set:
      parameter-name: PendingConnectionId

  - where:
      verb: Invoke
      subject: ^LinkFlow$
      parameter-name: Id
    set:
      parameter-name: PendingFlowId

  - where:
      verb: Invoke
      subject: ^LinkConnection$
    set:
      subject: LinkPendingConnection

  - where:
      verb: Invoke
      subject: ^LinkFlow$
    set:
      subject: LinkPendingFlow

  # Hide unneeded params
  - where:
      verb: New
      subject: ^Connection$
      parameter-name: Policy
    hide: true

  - where:
      verb: New|Update
      subject: ^Flow$
      parameter-name: Policy
    hide: true

  - where:
      verb: New|Update
      subject: ^Flow$
      parameter-name: KeyVaultUri
    hide: true

  - where:
      verb: New|Update
      subject: ^Flow$
      parameter-name: ^FlowProperty*
    hide: true

  - where:
      verb: Update
      subject: ^Flow$
      parameter-name: DestinationEndpoint|DestinationEndpointPort|Passphrase|SourceAddressList
    hide: true

  # Rename Get Pending Connection/Flow cmdlets
  - where:
      verb: Get
      subject: ^ListPendingConnection
    set:
      subject: PendingConnection

  - where:
      verb: Get
      subject: ^PendingConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName

  - where:
      verb: Get
      subject: ^ListPendingFlow
    set:
      subject: PendingFlow

  ## Hide execute action cmdlet. This is exposed by custom commands
  - where:
      verb: Invoke
      subject: ^ExecutePipelineAction
    hide: true
```
