<!-- region Generated -->
# Az.Batch
This directory contains the PowerShell module for the Batch service.

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
For information on how to develop for `Az.Batch`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: 4cb330be555a994ed507acf739e3349b7cb76d85
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/batch/data-plane/Azure.Batch/preview/2024-07-01.20.0/BatchService.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
module-version: 0.1.0
# Normally, title is the service name
title: Batch
subject-prefix: ""

disable-transform-identity-type-for-operation:
   - GetAzNodeFile_Get
   - GetAzNodeFile_GetViaIdentity

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      variant: ^GetViaIdentity$|^GetViaIdentityExpanded$
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
