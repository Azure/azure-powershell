<!-- region Generated -->
# Az.Napster
This directory contains the PowerShell module for the Napster service.

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
For information on how to develop for `Az.Napster`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
# pin the swagger version by using the commit id instead of branch name
commit: 7950f0f1c6372cb09de2961797bdef2d7ceda991
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/napster/resource-manager/readme.md
try-require:
  - $(repo)/specification/napster/resource-manager/readme.powershell.md

module-version: 0.1.0
title: Napster
service-name: Napster
subject-prefix: $(service-name)

directive:
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: Set
    remove: true
```
