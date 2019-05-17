<!-- region Generated -->
# Az.Compute
This directory contains the PowerShell module for the Compute service.

---
## Status
[![Az.Compute](https://img.shields.io/powershellgallery/v/Az.Compute.svg?style=flat-square&label=Az.Compute "Az.Compute")](https://www.powershellgallery.com/packages/Az.Compute/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Compute`, see [how-to.md](how-to.md).
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

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/compute/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/compute/resource-manager/readme.md

subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true

directive:
  - where:
      verb: Get
      subject: .*All
    set:
      hide: true
  - where:
      subject: VirtualMachineScaleSet(.*)
    set:
      subject: Vmss$1
  - where:
      subject: VirtualMachine(.*)
    set:
      subject: VM$1
  - where:
      subject: VM
      parameter-name: VmName
    set:
      parameter-name: Name
  - where:
      verb: Convert
      subject: VMToManagedDisk
    set:
      verb: ConvertTo
      subject: VMManagedDisk
  - where:
      verb: Get
      subject: ResourceSku
    set:
      subject-prefix: Compute
  - where:
      verb: Invoke
      subject: ForceVmssRecoveryServiceFabricPlatformUpdateDomainWalk
    set:
      verb: Repair
      subject: VmssServiceFabricUpdateDomain
  - where:
      verb: Invoke
      subject: ForceVmssRecoveryServiceFabricPlatformUpdateDomainWalk
    set:
      verb: Repair
      subject: VmssServiceFabricUpdateDomain
  - where:
      verb: Get
      subject: VMRunCommand
    set:
      subject: VMRunCommandDocument
  - where: 
      verb: Get
      subject: VmssRollingUpgradeLatest
    set:
      subject: VmssRollingUpgrade
  - where: 
      verb: Invoke
      subject: RedeployVM
    set:
      subject: VMReimage
  - where: 
      verb: Start
      subject: .*RunCommand
    set:
      verb: Invoke
  - where:
      verb: Set
      subject: Gallery
    set:
      verb: Update
  - where:
      verb: Set
      subject: GalleryImage.*
    set:
      verb: Update
  - where: 
      subject: GalleryImage
    set:
      subject: GalleryImageDefinition
  - where:
      subject: Usage
    set:
      subject: VMUsage
  - where: 
      verb: Start
      subject: VmssRollingUpgradeOSUpgrade
    set:
      subject: VmssRollingUpgrade
  - where: 
      verb: Export
      subject: VM
    set:
      verb: Save
      subject: VMImage
  - where: 
      verb: Export
      subject: LogAnalyticRequestRate
    set:
      subject: LogAnalyticRequestRateByInterval
  - where: 
      verb: Export
      subject: LogAnalyticThrottledRequest
    set:
      subject: LogAnalyticThrottledRequests
  - where: 
      parameter-name: GalleryImageName
    set:
      parameter-name: GalleryImageDefinitionName
  - where:
      noun: VMExtension
      parameter-name: ExtensionImageName
    set:
      parameter-name: Name
  - where:
      noun: VmssExtension
      parameter-name: ExtensionImageName
    set:
      parameter-name: Name
  - where:
      verb: Get
      subject: VMImage
      parameter-name: Filter
    set:
      parameter-name: FilterExpression
  - where:
      parameter-name: PublishingProfile(.+)
    set:
      parameter-name: $1
  - where:
      parameter-name: StorageProfile(.+)
    set:
      parameter-name: $1
  - where:
      parameter-name: NetworkProfile(.+)
    set:
      parameter-name: $1
```
