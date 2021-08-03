<!-- region Generated -->
# Az.HybridNetwork
This directory contains the PowerShell module for the HybridNetwork service.

---
## Status
[![Az.HybridNetwork](https://img.shields.io/powershellgallery/v/Az.HybridNetwork.svg?style=flat-square&label=Az.HybridNetwork "Az.HybridNetwork")](https://www.powershellgallery.com/packages/Az.HybridNetwork/)

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
For information on how to develop for `Az.HybridNetwork`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: a2d4dc4b1296624eefd4b5c235d56af46f7c39d2
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunction.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunctionVendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendorNetworkFunction.json

module-version: 0.1.0
title: HybridNetwork
subject-prefix: $(service-name)

identity-correction-for-post: true

# directive:
#   # Following is two common directive which are normally required in all the RPs
#   # 1. Remove the unexpanded parameter set
#   # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
#   - where:
#       variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
#     remove: true
#   # Remove the set-* cmdlet
#   - where:
#       verb: Set
#     remove: true
#   # Hide cmdlets.
#   - where:
#       verb: New|Remove
#       subject: PrivateCloud
#     hide: true
#   - where:
#       verb: New|Get|Remove
#       subject: HcxEnterpriseSite
#     remove: true
# ```
