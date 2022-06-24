<!-- region Generated -->
# Az.Reservations
This directory contains the PowerShell module for the Reservations service.

---
## Status
[![Az.Reservations](https://img.shields.io/powershellgallery/v/Az.Reservations.svg?style=flat-square&label=Az.Reservations "Az.Reservations")](https://www.powershellgallery.com/packages/Az.Reservations/)

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
For information on how to develop for `Az.Reservations`, see [how-to.md](how-to.md).
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
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/reservations/resource-manager/Microsoft.Capacity/stable/2022-03-01/reservations.json
module-version: 0.1.0
title: Reservations
subject-prefix: $(service-name)

resourcegroup-append: true
nested-object-to-string: true
inlining-threshold: 100

directive:
  - where:
      model-name: ReservationOrderResponse
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Term
          - ProvisioningState
          - OriginalQuantity
          - Reservation
        labels:
          Name: ReservationOrderId
          ProvisioningState: State
          OriginalQuantity: Quantity
          Reservation: Reservations
  - where:
      model-name: ReservationResponse
    set:
      format-table:
        properties:
          - Sku
          - Location
          - Name
          - SkuName1
          - ProvisioningState
          - BenefitStartTime
          - ExpiryDate
          - LastUpdatedDateTime
          - SkuDescription
        labels:
          Name: ReservationOrderId/ReservationId
          SkuName1: Sku
          ProvisioningState: State
  - where:
      model-name: AppliedReservations
    set:
      suppress-format: true
  - where:
      model-name: Catalog
    set:
      format-table:
        properties:
          - ResourceType
          - Term
          - Name
          - Location

```
