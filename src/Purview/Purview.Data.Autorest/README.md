<!-- region Generated -->
# Az.Purview
This directory contains the PowerShell module for the Purview service.

---
## Status
[![Az.Purview](https://img.shields.io/powershellgallery/v/Az.Purview.svg?style=flat-square&label=Az.Purview "Az.Purview")](https://www.powershellgallery.com/packages/Az.Purview/)

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
For information on how to develop for `Az.Purview`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: ${commit}
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/purview/data-plane/Azure.Analytics.Purview.Scanning/preview/2021-10-01-preview/scanningService.json

module-version: 0.1.0
title: Purview
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true
endpoint-resource-id-key-name: AzurePurviewEndpointResourceId

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$|^Set$|^AddViaIdentity$|^Add$
    remove: true
  - where:
      variant: ^Create$
      subject: ^(?!.*ClassificationRule).*
    remove: true
  - where:
      variant: ^CreateExpanded$
      subject: ^ClassificationRule$
    remove: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScanAuthorizationType TeradataUserPass = @"TeradataTeradataUserPass";', 'public static Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScanAuthorizationType TeradataTeradataUserPass = @"TeradataTeradataUserPass";');
  - from: source-file-csharp
    where: $
    transform: $ = $.split("{Endpoint}").join("{endpoint}");
  - where:
        model-name: ClassificationRule
    set:      
        suppress-format: true
  - model-cmdlet:
    - CustomClassificationRule
    - SystemClassificationRule
```
