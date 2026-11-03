<!-- region Generated -->
# Az.StorageMover
This directory contains the PowerShell module for the StorageMover service.

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
For information on how to develop for `Az.StorageMover`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: f89d3d95044e14c679785fa9e0d28c7c97af870a
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storagemover/resource-manager/Microsoft.StorageMover/StorageMover/stable/2026-05-01/storagemover.json

# For new RP, the version is 0.1.0
module-version: 2.0.0
# Normally, title is the service name
title: StorageMover
subject-prefix: $(service-name)
# flatten-userassignedidentity: false
disable-transform-identity-type: true

directive:
  - from: swagger-document 
    where: $.definitions.Time.properties.minute
    transform: >-
      return {
          "description": "The minute element of the time. Allowed values are 0 and 30. If not specified, its value defaults to 0.",
          "type": "integer",
          "format": "int32",
          "enum": [
            0,
            30
          ],
          "default": 0
        }
  - from: swagger-document
    where: $.definitions.EndpointBaseUpdateProperties.properties.endpointType
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.Credentials.properties.type
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      model-name: StorageMover|JobDefinition|Project|Endpoint|Agent|JobRun
    set:
      suppress-format: true
  - no-inline:
      - EndpointBaseProperties
      - EndpointBaseUpdateProperties
  # Rename Start-AzDataMoverJobDefinitionJob -> Start-AzDataMoverJobDefinition
  - where:
      verb: Start
      subject: JobDefinitionJob
    set:
      verb: Start
      subject: JobDefinition
  # Rename Stop-AzDataMoverJobDefinitionJob -> Stop-AzDataMoverJobDefinition
  - where:
      verb: Stop
      subject: JobDefinitionJob
    set:
      verb: Stop
      subject: JobDefinition
  # Rename Invoke-AzStorageMoverReconcileJobDefinitionJob -> Invoke-AzStorageMoverReconcileJobDefinition
  # to match the Start/Stop job definition cmdlets, which also act on the job definition's running job
  - where:
      verb: Invoke
      subject: ReconcileJobDefinitionJob
    set:
      subject: ReconcileJobDefinition
  # Remove New-AzStorageMoverAgent
  - where:
      verb: New 
      subject: Agent
    remove: true
  # Hide Remove-AzStorageMover
  - where:
      verb: Remove
      subject: StorageMover
    hide: true
  # Hide Remove-AzStorageMoverAgent
  - where:
      verb: Remove
      subject: Agent
    hide: true
  # Hide New-AzStorageMoverEndpoint
  - where:
      verb: New
      subject: Endpoint 
    hide: true
  # Hide Update-AzStorageMoverEndpoint
  - where:
      verb: Update
      subject: Endpoint
    hide: true
  # Hide Update-AzStorageMoverConnection (no PATCH operation in API; New- already covers PUT)
  - where:
      verb: Update
      subject: Connection
    hide: true
  # The Connections_Delete description contains an embedded newline that the generator emits as a literal "\n" in help;
  # use a single-line description so the generated help renders correctly
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageMover/storageMovers/{storageMoverName}/connections/{connectionName}"].delete
    transform: $['description'] = "Deletes a Connection resource. Returns 409 if there are active jobs using this connection."
  - where:
      model-name: Agent
      property-name: NumberOfCore
    set:
      property-name: NumberOfCores
  - where:
      model-name: Agent
      property-name: UptimeInSecond
    set:
      property-name: UptimeInSeconds
  - where:
      model-name: Agent
      property-name: Status
    set:
      property-name: AgentStatus
  # Rename property Code to ErrorCode in JobRun model 
  - where:
      model-name: JobRun
      property-name: Code
    set:
      property-name: ErrorCode
  # Rename property Message to ErrorMessage in JobRun model
  - where:
      model-name: JobRun
      property-name: Message 
    set:
      property-name: ErrorMessage
  # Delete the original ShouldProcess as a ShouldProcess and ShouldContinue are added in the custom cmdlets 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('ShouldProcess($\"Call remote \'StorageMoversDelete\' operation\")', 'true');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('ShouldProcess($\"Call remote \'AgentsDelete\' operation\")', 'true');
  # Customize add validate
  # - model-cmdlet:
  #     - model-name: UploadLimitWeeklyRecurrence
```
