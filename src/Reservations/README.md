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

directive:
  ### Rename Cmdlet names
  - where:
      verb: Invoke
      subject: CalculateReservationOrder
    set:
      verb: Get
      subject-prefix: Reservation
      subject: Quote
  - where:
      verb: Get
      subject: ReservationOrder
    set:
      verb: Get
      subject-prefix: Reservation
      subject: Order
  - where:
      verb: Get
      subject: Reservation
    set:
      verb: Get
      subject-prefix: ''
      subject: Reservation
  - where:
      verb: Get
      subject: Catalog
    set:
      verb: Get
      subject-prefix: Reservation
      subject: Catalog
  - where:
      verb: Get
      subject: ReservationRevision
    set:
      verb: Get
      subject-prefix: Reservation
      subject: History  

  ### Rename property name
  - where:
      model-name: ReservationResponse
      property-name: Sku
    set:
      property-name: InternalSku
  - where:
      model-name: ReservationResponse
      property-name: SkuName1
    set:
      property-name: Sku
  - where:
      model-name: ReservationResponse
      property-name: AppliedScope
    set:
      property-name: AppliedScopes
  - where:
      model-name: ReservationOrderResponse
      property-name: Reservation
    set:
      property-name: Reservations
  - where:
      model-name: Catalog
      property-name: Term
    set:
      property-name: Terms
  - where:
      model-name: Catalog
      property-name: Location
    set:
      property-name: Locations
  - where:
      model-name: Catalog
      property-name: SkuProperty
    set:
      property-name: SkuProperties
  - where:
      model-name: Catalog
      property-name: Restriction
    set:
      property-name: Restrictions
  - where:
      model-name: SkuRestriction
      property-name: Value
    set:
      property-name: Values

  ###Rename parameter name
  ## Get-AzReservationQuote
  - where:
      verb: Get
      subject-prefix: Reservation
      subject: Quote
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      verb: Get
      subject-prefix: Reservation
      subject: Quote
      parameter-name: ReservedResourcePropertyInstanceFlexibility
    set:
      parameter-name: InstanceFlexibility 

  ### Format output table
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
          - Location
          - Name
          - Sku
          - ProvisioningState
          - BenefitStartTime
          - ExpiryDate
          - LastUpdatedDateTime
          - SkuDescription
        labels:
          Name: ReservationOrderId/ReservationId
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
          - Terms
          - Name
          - Locations
  - where:
      model-name: PaymentDetail
    set:
      format-table:
        properties:
          - DueDate
          - PaymentDate
          - Status
  - where:
      model-name: CalculateExchangeOperationResultResponse
    set:
      format-table:
        properties:
          - SessionId
          - Status
          - RefundsTotal
          - PurchasesTotal
          - NetPayable
  - where:
      model-name: SkuRestriction
    set:
      format-table:
        properties:
          - Type
          - Values
          - ReasonCode
          
  - no-inline:
    - Price
    - ExtendedStatusInfo
    - CalculatePriceResponsePropertiesBillingCurrencyTotal
    - CalculatePriceResponsePropertiesPricingCurrencyTotal
```
