<!-- region Generated -->
# Az.QuotaExtensionApi
This directory contains the PowerShell module for the QuotaExtensionApi service.

---
## Status
[![Az.QuotaExtensionApi](https://img.shields.io/powershellgallery/v/Az.QuotaExtensionApi.svg?style=flat-square&label=Az.QuotaExtensionApi "Az.QuotaExtensionApi")](https://www.powershellgallery.com/packages/Az.QuotaExtensionApi/)

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
For information on how to develop for `Az.QuotaExtensionApi`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: a6302e8490871f3619de9cd7001fd5f9cba887bf
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/quota/resource-manager/Microsoft.Quota/stable/2021-03-15/quota.json

title: Quota
module-version: 0.1.0
subject-prefix: Quota

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

```
