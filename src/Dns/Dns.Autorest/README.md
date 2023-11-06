<!-- region Generated -->
# Az.Dns
This directory contains the PowerShell module for the Dns service.

---
## Status
[![Az.Dns](https://img.shields.io/powershellgallery/v/Az.Dns.svg?style=flat-square&label=Az.Dns "Az.Dns")](https://www.powershellgallery.com/packages/Az.Dns/)

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
For information on how to develop for `Az.Dns`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: a3126a361b75f952ece050b2cf67c11d4e542ef8
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/dns/resource-manager/Microsoft.Network/preview/2023-07-01-preview/dns.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Dns
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^(?!.*DnssecConfig).*$
    remove: true
  # Remove the set-* cmdlet

  - where:
      verb: Set
    remove: true

  # Remove zone and record set cmdlets
  - where:
      subject: ^(?!.*DnssecConfig).*$
    remove: true

  - where:
      subject: (^DnssecConfig)
    set:
      preview-announcement:
        preview-message: DNSSEC support for Azure DNS Public Zones is in preview.

  # Table formatting

  - where:
      model-name: (.*)
    set:
      suppress-format: true

```
