<!-- region Generated -->
# Az.IoTCentral
This directory contains the PowerShell module for the IoTCentral service.

---
## Status
[![Az.IoTCentral](https://img.shields.io/powershellgallery/v/Az.IoTCentral.svg?style=flat-square&label=Az.IoTCentral "Az.IoTCentral")](https://www.powershellgallery.com/packages/Az.IoTCentral/)

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
For information on how to develop for `Az.IoTCentral`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 1809a66a915b28f9fdbefaf93a4dc8fed8bdb8c8
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/iotcentral/resource-manager/Microsoft.IoTCentral/preview/2021-11-01-preview/iotcentral.json

module-version: 0.1.0
title: IoTCentral
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Test
    remove: true
  - where:
      subject: PrivateEndpointConnection|PrivateLink
    remove: true
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
```
