<!-- region Generated -->
# Az.MarketplaceOrdering
This directory contains the PowerShell module for the MarketplaceOrdering service.

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
For information on how to develop for `Az.MarketplaceOrdering`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: ee9fe9888e8d4e5a583e275c4c35deff6c6f96e0
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/marketplaceordering/resource-manager/Microsoft.MarketplaceOrdering/stable/2021-01-01/Agreements.json

title: MarketplaceOrdering
subject-prefix: Marketplace

identity-correction-for-post: true
nested-object-to-string: true
inlining-threshold: 50

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
      variant: ^CreateExpanded$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # List response not mapp swagger define.
  - where:
      verb: Get
      subject: MarketplaceTerms
      variant: ^List$|^GetViaIdentity1$|^GetViaIdentity$
    remove: true

  # For map old cmdlet
  - where:
      verb: Get|Stop
      subject: MarketplaceTerms
      parameter-name: OfferId
    set:
      parameter-name: Product

  - where:
      verb: Get|Stop
      subject: MarketplaceTerms
      parameter-name: PublisherId
    set:
      parameter-name: Publisher

  - where:
      verb: Get|Stop
      subject: MarketplaceTerms
      parameter-name: PlanId
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: MarketplaceTerms
    hide: true

  - where:
      verb: New
      subject: MarketplaceTerms
    set:
      verb: Set

  - where:
      verb: Set
      subject: MarketplaceTerms
      parameter-name: OfferId
    set:
      parameter-name: Product

  - where:
      verb: Set
      subject: MarketplaceTerms
      parameter-name: PublisherId
    set:
      parameter-name: Publisher

  - where:
      verb: Set
      subject: MarketplaceTerms
      parameter-name: PlanId
    set:
      parameter-name: Name

  - where:
      verb: Set
      subject: MarketplaceTerms
    hide: true

  - where:
      verb: Invoke
      subject: SignTerms
      parameter-name: OfferId
    set:
      parameter-name: Product

  - where:
      verb: Invoke
      subject: SignTerms
      parameter-name: PublisherId
    set:
      parameter-name: Publisher

  - where:
      verb: Invoke
      subject: SignTerms
      parameter-name: PlanId
    set:
      parameter-name: Name

  - where:
      model-name: AgreementTerms
    set:
      format-table:
        properties:
          - Name
          - Product
          - Publisher
          - Accepted
          - Signature
          - PrivacyPolicyLink
```
