<!-- region Generated -->
# Az.ConnectedNetwork
This directory contains the PowerShell module for the ConnectedNetwork service.

---
## Status
[![Az.ConnectedNetwork](https://img.shields.io/powershellgallery/v/Az.ConnectedNetwork.svg?style=flat-square&label=Az.ConnectedNetwork "Az.ConnectedNetwork")](https://www.powershellgallery.com/packages/Az.ConnectedNetwork/)

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
For information on how to develop for `Az.ConnectedNetwork`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: a2d4dc4b1296624eefd4b5c235d56af46f7c39d2
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/common.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunction.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunctionVendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendorNetworkFunction.json

module-version: 0.1.0
title: ConnectedNetwork
subject-prefix: $(service-name)
identity-correction-for-post: true
resourcegroup-append: true

directive:
  - where:
      verb: Set
    remove: true

  - where:
      subject: ^VendorNetworkFunction$
    set:
      subject: VendorFunction

  - where:
      subject: ^RoleInstance$
    set:
      subject: VendorFunctionRoleInstance
```
