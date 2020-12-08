<!-- region Generated -->
# Az.ResourceMover
This directory contains the PowerShell module for the ResourceMover service.

---
## Status
[![Az.ResourceMover](https://img.shields.io/powershellgallery/v/Az.ResourceMover.svg?style=flat-square&label=Az.ResourceMover "Az.ResourceMover")](https://www.powershellgallery.com/packages/Az.ResourceMover/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

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
  - $(this-folder)/../readme.azure.noprofile.md
title: ResourceMover
service-name: ResourceMover
prefix: Az
subject-prefix: $(service-name)
branch: master
repo: https://github.com/Azure/azure-rest-api-specs/tree/$(branch)
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/resourcemover/resource-manager/Microsoft.Migrate/preview/2019-10-01-preview
input-file:
	- $(aks)/resourcemovercollection.json
module-version: 0.1.0

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Initiate$|^InitiateViaIdentity$|^InitiateViaIdentityExpanded$|^Commit$|^CommitViaIdentity$|^CommitViaIdentityExpanded$|^Discard$|^DiscardViaIdentity$|^DiscardViaIdentityExpanded$|^Prepare$|^PrepareViaIdentity$|^PrepareViaIdentityExpanded$|^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentityExpanded$|^UpdateViaIdentity$|^ResolveViaIdentity$|^GetViaIdentity$|^DeleteViaIdentity$  
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
```
