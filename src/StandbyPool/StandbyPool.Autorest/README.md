<!-- region Generated -->
# Az.StandbyPool
This directory contains the PowerShell module for the StandbyPool service.

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
For information on how to develop for `Az.StandbyPool`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 1866fc3609f55fad6a5e74a9b206ae4ca144c03a
tag: package-2024-03
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/standbypool/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/standbypool/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: StandbyPool
subject-prefix: Standby

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

  # Rename StandbyVirtualMachinePool to StandbyVMPool
  - where:
      verb: Get|New|Update|Remove
      subject: StandbyVirtualMachinePool
    set:
      subject: StandbyVMPool

  # Rename Get-AzStandbyVirtualMachinePoolRuntimeView to Get-AzStandbyVMPoolStatus
  - where:
      verb: Get
      subject: StandbyVirtualMachinePoolRuntimeView
    set:
      subject: StandbyVMPoolStatus

  # Rename Get-AzStandbyContainerGroupPoolRuntimeView to Get-AzStandbyContainerGroupPoolStatus
  - where:
      verb: Get
      subject: StandbyContainerGroupPoolRuntimeView
    set:
      subject: StandbyContainerGroupPoolStatus
  
  # Rename standby container group pool parameters
  - where:
      verb: New|Update
      subject: StandbyContainerGroupPool
      parameter-name: ContainerGroupProfileId
    set:
      parameter-name: ContainerProfileId

  - where:
      verb: New|Update
      subject: StandbyContainerGroupPool
      parameter-name: ContainerGroupProfileRevision
    set:
      parameter-name: ProfileRevision

  - where:
      verb: New|Update
      subject: StandbyContainerGroupPool
      parameter-name: ElasticityProfileMaxReadyCapacity
    set:
      parameter-name: MaxReadyCapacity

  - where:
      verb: New|Update
      subject: StandbyContainerGroupPool
      parameter-name: ElasticityProfileRefillPolicy
    set:
      parameter-name: RefillPolicy

  - where:
      verb: New|Update
      subject: StandbyContainerGroupPool
      parameter-name: ContainerGroupPropertySubnetId
    set:
      parameter-name: SubnetId
  
  - where:
      verb: Get
      subject: StandbyContainerGroupPoolStatus
      parameter-name: StandbyContainerGroupPoolName
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: StandbyContainerGroupPoolStatus
      parameter-name: RuntimeView
    set:
      parameter-name: Version

  # Rename standby virtual machine pool parameters
  - where:
      verb: New|Update
      subject: StandbyVMPool
      parameter-name: AttachedVirtualMachineScaleSetId
    set:
      parameter-name: VMSSId

  - where:
      verb: New|Update
      subject: StandbyVMPool
      parameter-name: ElasticityProfileMaxReadyCapacity
    set:
      parameter-name: MaxReadyCapacity

  - where:
      verb: New|Update
      subject: StandbyVMPool
      parameter-name: ElasticityProfileMinReadyCapacity
    set:
      parameter-name: MinReadyCapacity

  - where:
      verb: New|Update
      subject: StandbyVMPool
      parameter-name: VirtualMachineState
    set:
      parameter-name: VMState

  - where:
      verb: Get
      subject: StandbyVMPoolVM
      parameter-name: Name
    set:
      parameter-name: VMName

  - where:
      verb: Get
      subject: StandbyVMPoolVM
      parameter-name: PoolName
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: StandbyVMPoolStatus
      parameter-name: StandbyVirtualMachinePoolName
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: StandbyVMPoolStatus
      parameter-name: RuntimeView
    set:
      parameter-name: Version

  # Hide parameters from cmdlets
  - where:
      verb: Get
      subject: StandbyVMPoolStatus
      parameter-name: Version
    hide: true
    set:
      default:
        script: "'latest'"

  - where:
      verb: Get
      subject: StandbyContainerGroupPoolStatus
      parameter-name: Version
    hide: true
    set:
      default:
        script: "'latest'"

  # Remove Get-StandbyVirtualMachine
  - where:
      verb: Get
      subject: StandbyVirtualMachine
    remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
