<!-- region Generated -->
# Az.Astro
This directory contains the PowerShell module for the Astro service.

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
For information on how to develop for `Az.Astro`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 01e99457ccf5613a95d5b2960d31a12f84018863
tag: package-2023-08-01
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/liftrastronomer/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/liftrastronomer/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Astro
subject-prefix: $(service-name)
# Disable transform IdentityType as GET+PUT can not replace patch
# 1. Organizations_CreateOrUpdate can not update resources
# 2. the input schemas of PUT and PATCH are different
disable-transform-identity-type: true

directive:
  - from: swagger-document
    where: $.definitions.OrganizationResource
    transform: $['required'] = ['properties']
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|ViaJsonFilePath|ViaJsonString)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      verb: New
    hide: true
  - where:
      verb: Update
    hide: true
```
