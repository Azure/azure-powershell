<!-- region Generated -->
# Az.confluent
This directory contains the PowerShell module for the Confluent service.

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
For information on how to develop for `Az.confluent`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 74cc90c49189a079b3cc93fde9c9ad76742f0184
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/confluent/resource-manager/Microsoft.Confluent/preview/2025-08-18-preview/confluent.json

module-version: 0.2.0
title: Confluent
service-name: confluent
subject-prefix: $(service-name)

directive:
  # New-AzConfluentMarketplaceAgreeemt has  be removed, because it cand be replace by Set-AzMarketplaceTerms (Az.MarketplaceOrdering).
  - where:
      verb: New
      subject: MarketplaceAgreement$
    remove: true

  - where:
      subject: OrganizationOperation
    hide: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Hide the Remove-AzConfluentOrganization for ask user confirmation before Remove-AzConfluentOrganization been invoken
  - where:
      verb: Remove
      subject: Organization$
    hide: true

  # Rename plural parameter to singular to comply with naming convention
  - where:
      parameter-name: PropertiesOfferDetailPrivateOfferIds
    set:
      parameter-name: PropertiesOfferDetailPrivateOfferId

  # Rename ConnectorBasicInfoConnectorClass as it ends with 's' which triggers the plural noun check (8410)
  - where:
      parameter-name: ConnectorBasicInfoConnectorClass
    set:
      parameter-name: ConnectorBasicInfoConnectorClassName
```
