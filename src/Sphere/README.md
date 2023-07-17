<!-- region Generated -->
# Az.Sphere
This directory contains the PowerShell module for the Sphere service.

---
## Status
[![Az.Sphere](https://img.shields.io/powershellgallery/v/Az.Sphere.svg?style=flat-square&label=Az.Sphere "Az.Sphere")](https://www.powershellgallery.com/packages/Az.Sphere/)

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
For information on how to develop for `Az.Sphere`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: 753f386a4ff062f7cd696d21ef7428f23e2a32a9
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/sphere/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/sphere/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Sphere
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

use-extension:
  "@autorest/powershell": "4.x"

directive:
  - where:
      variant: ^(Create|Update|Generate|Claim)(?!.*?Expanded)
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    hide: true
```
