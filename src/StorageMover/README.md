<!-- region Generated -->
# Az.StorageMover
This directory contains the PowerShell module for the StorageMover service.

---
## Status
[![Az.StorageMover](https://img.shields.io/powershellgallery/v/Az.StorageMover.svg?style=flat-square&label=Az.StorageMover "Az.StorageMover")](https://www.powershellgallery.com/packages/Az.StorageMover/)

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
brach: 470c544393281cc986c9b343fa441f54576bc0bc
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storagemover/resource-manager/Microsoft.StorageMover/stable/2023-03-01/storagemover.json

# For new RP, the version is 0.1.0
module-version: 1.0.0
# Normally, title is the service name
title: StorageMover
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true 

directive:
  - where:
      verb: Set
    remove: true
  - where:
      model-name: StorageMover|JobDefinition|Project|Endpoint|Agent|JobRun
    set:
      suppress-format: true
  - no-inline:
      - EndpointBaseProperties
  - no-inline:
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
  # Remove paramater sets Create and CreateViaIdentity
  - where: 
      verb: New 
      subject: Endpoint 
      variant: ^Create$|^CreateViaIdentity$
    remove: true
  # Remove paramater set Update and UpdateViaIdentity
  - where:
      verb: Update
      subject: Endpoint 
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
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
  - where:
      verb: New
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Delete the original ShouldProcess as a ShouldProcess and ShouldContinue are added in the custom cmdlets 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('ShouldProcess($\"Call remote \'StorageMoversDelete\' operation\")', 'true');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('ShouldProcess($\"Call remote \'AgentsDelete\' operation\")', 'true');
```
