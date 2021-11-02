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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Compute`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/compute/resource-manager/Microsoft.Compute/stable/2021-07-01/runCommands.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Compute
subject-prefix: ""
# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Run$|^RunViaIdentity$
    remove: true
  - where:
      subject: VirtualMachineRunCommand
    set:
      subject: VMRunCommand
  - where:
      subject: VirtualMachineScaleSetVMRunCommand
    set:
      subject: VmssVMRunCommand
  - where:
      verb: Start
      subject: VirtualMachineCommand
    remove: true
  - where:
      verb: Start
      subject: VirtualMachineScaleSetVMCommand
    remove: true
  - where:
      verb: New
      subject: VmssVMRunCommand|VMRunCommand
    remove: true
  - where:
      verb: Update
      subject: VmssVMRunCommand|VMRunCommand
    remove: true
```
