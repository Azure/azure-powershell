<!-- region Generated -->
# Az.ConnectedMachine
This directory contains the PowerShell module for the ConnectedMachine service.

---
## Status
[![Az.ConnectedMachine](https://img.shields.io/powershellgallery/v/Az.ConnectedMachine.svg?style=flat-square&label=Az.ConnectedMachine "Az.ConnectedMachine")](https://www.powershellgallery.com/packages/Az.ConnectedMachine/)

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
For information on how to develop for `Az.ConnectedMachine`, see [how-to.md](how-to.md).
<!-- endregion -->

<!-- region Generated -->
# Az.ConnectedMachine
This directory contains the PowerShell module for Hybrid Compute.

---
## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
module-version: 0.1.0
title: ConnectedMachine
subject-prefix: 'Connected'
input-file:
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2019-12-12/HybridCompute.json

directive:
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019
  - remove-operation:
    - Machines_Reconnect
    - Machines_CreateOrUpdate
    - Machines_Update
    - MachineExtensions_CreateOrUpdate
    - MachineExtensions_Update
    - MachineExtensions_Delete
    - MachineExtensions_Get
    - MachineExtensions_List
```
