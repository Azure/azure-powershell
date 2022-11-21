<!-- region Generated -->
# Az.LoadTesting
This directory contains the PowerShell module for the LoadTesting service.

---
## Status
[![Az.LoadTesting](https://img.shields.io/powershellgallery/v/Az.LoadTesting.svg?style=flat-square&label=Az.LoadTesting "Az.LoadTesting")](https://www.powershellgallery.com/packages/Az.LoadTesting/)

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
For information on how to develop for `Az.LoadTesting`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: abd5d0016f12f6862cae88ef70f1333e84e20c07
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/be6cd9ccfcb6ba08c1c206627026eabfbff31fc1/specification/loadtestservice/resource-manager/Microsoft.LoadTestService/stable/2022-12-01/loadtestservice.json

module-version: 0.1.0
title: LoadTesting
subject-prefix: ""

resourcegroup-append: true

directive:
  - where:
      subject: .*Quota.*
    remove: true
  - where:
      parameter-name: .*Quota.*
    remove: true
  - where:
      model-name: .*Quota.*
    remove: true
  - select: command
    where:
      subject: .*OutboundNetworkDependencyEndpoint.*
    remove: true
  - select: parameter
    where:
      parameter-name: .*OutboundNetworkDependencyEndpoint.*
    remove: true
  - select: model
    where:
      model-name: .*OutboundNetworkDependencyEndpoint.*
    remove: true
  - select: command
    where:
      subject: LoadTest
    set:
      subject: Load  
      suppress-format: true
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: New|Update
      subject: Load
      parameter-name: EncryptionKeyUrl
    set:
      parameter-name: EncryptionKey
  - where:
      verb: New|Update
      subject: Load
      parameter-name: IdentityResourceId
    set:
      parameter-name: EncryptionIdentity
  - where:
      verb: New|Update
      subject: Load
      parameter-name: PropertiesEncryptionIdentityType
    hide: true
  - where:
      verb: New|Update
      subject: Load
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssigned
  - where:
      verb: New
      subject: Load
      parameter-name: ManagedServiceIdentityType
    set:
      parameter-name: IdentityType
  - where:
      verb: Update
      subject: Load
      parameter-name: Type
    set:
      parameter-name: IdentityType
```
