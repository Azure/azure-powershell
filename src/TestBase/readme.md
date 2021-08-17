<!-- region Generated -->
# Az.TestBase
This directory contains the PowerShell module for the TestBase service.

---
## Status
[![Az.TestBase](https://img.shields.io/powershellgallery/v/Az.TestBase.svg?style=flat-square&label=Az.TestBase "Az.TestBase")](https://www.powershellgallery.com/packages/Az.TestBase/)

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
For information on how to develop for `Az.TestBase`, see [how-to.md](how-to.md).
<!-- endregion -->

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/testbase/resource-manager/Microsoft.TestBase/preview/2020-12-16-preview/testbase.json

module-version: 0.1.0
title: TestBase
subject-prefix: $(service-name)

directive:
- where:
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  remove: true
  # Remove the set-* cmdlet
- where:
    verb: Set
  remove: true
```
