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
branch: 679887ace44697c726aba8d2814ee415a5d25e6f
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/quota/resource-manager/Microsoft.Quota/preview/2021-03-15-preview/quota.json

title: Quota
module-version: 0.1.0

identity-correction-for-post: true
# resouces usage id does not contain resource group name.
# resourcegroup-append: true
nested-object-to-string: true

inlining-threshold: 50

directive:
  # The regex(^/(?<scope>[^/]+)/) mathch failed because the scope inlcude '/' character.
  # Replace regex to fixed it. 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/global::System.Text.RegularExpressions.Regex\(\"\^\/\(\?\<scope\>\[\^\/\]\+\)/g, 'global::System.Text.RegularExpressions.Regex("^/(?<scope>.+)');

  # Remove the set Workspace cmdlet
  - where:
      verb: Set
      subject: ""
    remove: true
    
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Get
      subject: RequestStatus|Usage
      variant: ^GetViaIdentity$
    remove: true

  # Rename parameter
  - where:
      werb: New
      subject: ""
      parameter-name: NameValue
    set:
      parameter-name: Name
  # Hide parameter
  # future extendibility. It’s not used currently
  - where:
      verb: New|Update
      subject: ""
      parameter-name: AnyProperty
    hide: true

  - where:
      werb: Get
      subject: Usage
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      model-name: CurrentQuotaLimitBase
    set:
      format-table:
        properties:
          - Name
          - NameLocalizedValue
          - LimitObjectType
          - Unit
          - ETag
  - where:
      model-name: CurrentUsagesBase
    set:
      format-table:
        properties:
          - Name
          - NameLocalizedValue
          - UsageUsagesType
          - UsageValue
          - ETag
  - where:
      model-name: QuotaRequestDetails
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - ErrorMessage
          - Code
  
  - no-inline:
    - LimitJsonObject
    
  # - model-cmdlet:
  #   - LimitObject  # Successfull generated then hide it to custom(Rename cmdlet and parameter).
```
