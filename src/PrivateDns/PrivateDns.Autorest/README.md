<!-- region Generated -->
# Az.PrivateDns
This directory contains the PowerShell module for the PrivateDns service.

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
For information on how to develop for `Az.PrivateDns`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: f4cabaa4f22f7ae7c4b804617d16aeb17d166ba6
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/privatedns/resource-manager/Microsoft.Network/stable/2024-06-01/privatedns.json

# For new RP, the version is 0.1.0
module-version: 1.1.0
# Normally, title is the service name
title: PrivateDns
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where: 
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$ 
      subject: ^(?!.*VirtualNetworkLink).*$
    remove: true
  # Remove zone and record set cmdlets
  - where:
      subject: ^(?!.*VirtualNetworkLink).*$
    remove: true

  - where:
      subject: (^VirtualNetworkLink)
    set:
      preview-announcement:
        preview-message: Private Dns Virtual Network Link new property resolution policy is in preview.

  # Table formatting

  - where:
      model-name: (.*)
    set:
      suppress-format: true

```
