<!-- region Generated -->
# Az.DevCenter
This directory contains the PowerShell module for the DevCenter service.

---
## Status
[![Az.DevCenter](https://img.shields.io/powershellgallery/v/Az.DevCenter.svg?style=flat-square&label=Az.DevCenter "Az.DevCenter")](https://www.powershellgallery.com/packages/Az.DevCenter/)

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
For information on how to develop for `Az.DevCenter`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: 1fd32d6d50f5be3dde6d0547f2f3c369998811e1
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/devcenter/resource-manager/readme.md 

directive:
  - where:
      subject: ^(.*)
    set:
      subject-prefix: Admin
```
