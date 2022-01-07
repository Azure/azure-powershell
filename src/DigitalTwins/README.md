<!-- region Generated -->
# Az.DigitalTwins
This directory contains the PowerShell module for the DigitalTwins service.

---
## Status
[![Az.DigitalTwins](https://img.shields.io/powershellgallery/v/Az.DigitalTwins.svg?style=flat-square&label=Az.DigitalTwins "Az.DigitalTwins")](https://www.powershellgallery.com/packages/Az.DigitalTwins/)

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
For information on how to develop for `Az.DigitalTwins`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/digitaltwins/resource-manager/Microsoft.DigitalTwins/stable/2020-10-31/digitaltwins.json

module-version: 0.2.0
title: DigitalTwins
subject-prefix: $(service-name)
identity-correction-for-post: true
directive:
  - select: command
    where:
      verb: Get
      parameter-name: VirtualMachine
    set:
      alias: Get-VM
  - select: command
    where:
      verb: New
      subject: DigitalTwin
    set:
      subject: Instance
  - select: command
    where:
      verb: Remove
      subject: DigitalTwin
    set:
      subject: Instance
  - select: command
    where:
      verb: Update
      subject: DigitalTwin
    set:
      subject: Instance
  - select: command      
    where:
      verb: Get
      subject: DigitalTwin
    set:
      subject: Instance
  - select: command
    where:
      verb: New
      subject: DigitalTwinEndpoint
    set:
      subject: Endpoint
  - select: command
    where:
      verb: Test
      subject: DigitalTwinNameAvailability
    set:
      subject: InstanceNameAvailability
  - where:
      verb: Set
      subject: DigitalTwin
    hide: true
  - where:
      verb: Set
      subject: DigitalTwinEndpoint
    hide: true
  - where:
      verb: New
      subject: Instance
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    hide: true
  - where:
      verb: New
      subject: Endpoint
      variant: ^CreateExpanded$|^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    hide: true
  - where:
      verb: Test
      subject: InstanceNameAvailability
    hide: true
  - where:
      verb: New
      subject: CheckNameRequestObject
    hide: true
  - where:
      verb: New
      subject: DigitalTwinsIdentityObject
    hide: true
  
  # Correct some generated code
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties Property');

```
