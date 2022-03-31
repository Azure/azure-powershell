<!-- region Generated -->
# Az.Security
This directory contains the PowerShell module for the Security service.

---
## Status
[![Az.Security](https://img.shields.io/powershellgallery/v/Az.Security.svg?style=flat-square&label=Az.Security "Az.Security")](https://www.powershellgallery.com/packages/Az.Security/)

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
For information on how to develop for `Az.Security`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
branch: 5c137f96ba99facc5224032a0312988575f9fa35
require:
# readme.azure.noprofile.md is the common configuration file
  - https://github.com/Azure/autorest.powershell/blob/b8f4e10805fca9da50e1a515594af7f9d91b29bc/tests-upgrade/readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/ariklin/azure-rest-api-specs/blob/5c137f96ba99facc5224032a0312988575f9fa35/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/SecuritySolutions.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 
#- $(this-folder)/securitySolutionsReferenceData.json
#- $(this-folder)/../../../../azure-rest-api-specs/specification/security/resource-manager/Microsoft.Security/stable/2020-01-01/securitySolutionsReferenceData.json
# For new RP, the version is 0.1.0
module-version: 1.1.2
# Normally, title is the service name
title: Security
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

```
