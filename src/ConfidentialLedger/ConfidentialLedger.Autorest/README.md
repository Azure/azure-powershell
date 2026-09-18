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

directive:
  - from: swagger-document
    where: $.definitions.ResourceLocation.properties.location
    transform: >-
      return {
        "description": "The Azure location where the Confidential Ledger is running.",
        "type": "string",
        "x-ms-mutability": [
          "create",
          "read",
          "update"
        ]
      }
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Update|Check)(?!.*?(Expanded))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^CheckViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where: # Hide auto-generated Update since we implement a custom one requiring the 'Location' parameter.
      verb: Update
      Subject: Ledger
    hide: true
  - model-cmdlet:
      - model-name: AADBasedSecurityPrincipal
        cmdlet-name: New-AzConfidentialLedgerAADBasedSecurityPrincipalObject
      - model-name: CertBasedSecurityPrincipal
        cmdlet-name: New-AzConfidentialLedgerCertBasedSecurityPrincipalObject
```
