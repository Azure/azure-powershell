<!-- region Generated -->
# Az.MarketplaceOrdering
This directory contains the PowerShell module for the MarketplaceOrdering service.

---
## Status
[![Az.MarketplaceOrdering](https://img.shields.io/powershellgallery/v/Az.MarketplaceOrdering.svg?style=flat-square&label=Az.MarketplaceOrdering "Az.MarketplaceOrdering")](https://www.powershellgallery.com/packages/Az.MarketplaceOrdering/)

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
For information on how to develop for `Az.MarketplaceOrdering`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: ee9fe9888e8d4e5a583e275c4c35deff6c6f96e0
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/marketplaceordering/resource-manager/Microsoft.MarketplaceOrdering/stable/2021-01-01/Agreements.json

title: MarketplaceOrdering
subject-prefix: Marketplace

identity-correction-for-post: true
nested-object-to-string: true
inlining-threshold: 50

directive:
  - where:
      subject: MarketplaceAgreement
    set:
      subject: MarketplaceTerms

  - where:
      subject: SignMarketplaceAgreement
    set:
      subject: SignTerms

  - where: 
      subject: ^MarketplaceTerms$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where:
      verb: Get
      subject: MarketplaceTerms
      variant: ^GetViaIdentity1$
    remove: true

  - where:
      verb: Get
      subject: MarketplaceTerms
    hide: true

  - where:
      subject: MarketplaceTerms
      parameter-name: MarketplaceTermsLink
    set:
      parameter-name: TermsLink
```
