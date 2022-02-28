<!-- region Generated -->
# Az.ConfidentialLedger
This directory contains the PowerShell module for the ConfidentialLedger service.

---
## Status
[![Az.ConfidentialLedger](https://img.shields.io/powershellgallery/v/Az.ConfidentialLedger.svg?style=flat-square&label=Az.ConfidentialLedger "Az.ConfidentialLedger")](https://www.powershellgallery.com/packages/Az.ConfidentialLedger/)

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
For information on how to develop for `Az.ConfidentialLedger`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 429a7ea873cc1bbd4df133f71427162e15e258b1
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/preview/2021-05-13-preview/confidentialledger.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ConfidentialLedger
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where: # Only generate one version of CheckNameAvailability
      verb: Test
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
  - where: # Hide auto-generated Update since we implement a custom one requiring the 'Location' parameter.
      verb: Update
      Subject: Ledger
    hide: true
  - model-cmdlet: # Generate objects for common models.
    - AADBasedSecurityPrincipal
    - CertBasedSecurityPrincipal
```
