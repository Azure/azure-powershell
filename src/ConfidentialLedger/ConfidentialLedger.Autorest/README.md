<!-- region Generated -->
# Az.ConfidentialLedger
This directory contains the PowerShell module for the ConfidentialLedger service.

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
For information on how to develop for `Az.ConfidentialLedger`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: c2d2b523575031790b8672640ea762bdf9ad4964
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/stable/2022-05-13/confidentialledger.json

# For new RP, the version is 0.1.0
module-version: 1.0.0
# Normally, title is the service name
title: ConfidentialLedger
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
