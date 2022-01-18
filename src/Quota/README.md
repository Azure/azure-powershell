<!-- region Generated -->
# Az.Quota
This directory contains the PowerShell module for the Quota service.

---
## Status
[![Az.Quota](https://img.shields.io/powershellgallery/v/Az.Quota.svg?style=flat-square&label=Az.Quota "Az.Quota")](https://www.powershellgallery.com/packages/Az.Quota/)

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
For information on how to develop for `Az.Quota`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: 21ffb64fdcbc0da039117af64f13c028c20d1286
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/quota/resource-manager/Microsoft.Quota/preview/2021-03-15-preview/quota.json

title: Quota
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

inlining-threshold: 50

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
    # Remove the set Workspace cmdlet
  - where:
      verb: Set
      subject: ""
    remove: true
  - where:
      werb: New
      subject: ""
      parameter-name: NameValue
    set:
      parameter-name: Name
  - where:
      model-name: CurrentQuotaLimitBase
    set:
      format-table:
        properties:
          - Name
          - LimitObjectType
          - Unit
          - ETag
  - no-inline:
    - LimitJsonObject
    
  - modle-cmdlet:
    - LimitValue
```
