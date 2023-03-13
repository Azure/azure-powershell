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
branch: 49b2b960e028825de1e3b95568c93ed235354e06
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/reservations/resource-manager/Microsoft.Capacity/stable/2022-11-01/reservations.json
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
  - where:
      verb: Get
      subject: AppliedReservationList
    set:
      verb: Get
      subject-prefix: Reservation
      subject: OrderId
  - where:
      verb: Invoke
      subject: CalculateExchange
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: CalculateExchange
  - where:
      verb: Invoke
      subject: Exchange
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: Exchange
  - where:
      verb: Invoke
      subject: CalculateRefund
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: CalculateRefund
  - where:
      verb: Invoke
      subject: Return
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: Return
  - where:
      verb: Invoke
      subject: ArchiveReservation
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: ArchiveReservation
  - where:
      verb: Invoke
      subject: UnarchiveReservation
    set:
      verb: Invoke
      subject-prefix: Reservation
      subject: UnarchiveReservation
  - where:
      verb: Invoke
      subject: PurchaseReservationOrder
    set:
      verb: New
      subject-prefix: ''
      subject: Reservation
  - where:
      verb: Split
      subject: Reservation
    set:
      verb: Split
      subject-prefix: ''
      subject: Reservation
  - where:
      verb: Merge
      subject: Reservation
    set:
      verb: Merge
      subject-prefix: ''
      subject: Reservation
  - where:
      verb: Update
      subject: Reservation
    set:
      verb: Update
      subject-prefix: ''
      subject: Reservation
  - where:
      verb: Rename
      subject: ReservationOrderDirectory
    set:
      verb: Move
      subject-prefix: Reservation
      subject: Directory
  - where:
      verb: Invoke
      subject: AvailableReservationScope
    set:
      verb: Get
      subject-prefix: Reservation
      subject: AvailableScope

  ### Hide cmdlet
  - where:
      verb: Split
      subject-prefix: ''
      subject: Reservation
    hide: true
  - where:
      verb: Merge
      subject-prefix: ''
      subject: Reservation
    hide: true
  - where: 
      verb: Invoke
      subject-prefix: Reservation
      subject: Return
    hide: true

  ### Rename property name
  - where:
      model-name: ReservationResponse|PurchaseRequest
      property-name: Sku
    set:
      property-name: InternalSkuName
  - where:
      model-name: ReservationResponse
      property-name: SkuName1
    set:
      property-name: Sku
  - where:
      model-name: PurchaseRequest
      property-name: SkuName
    set:
      property-name: Sku
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
  - where:
      model-name: ExchangeOperationResultResponse|ReservationToPurchaseExchange|PurchaseRequest
      property-name: Property
    set:
      property-name: Properties
  - where:
      model-name: ReservationToPurchaseExchange|PurchaseRequest|ReservationResponse
      property-name: AppliedScope
    set:
      property-name: AppliedScopes  
  - where:
      model-name: ReservationToPurchaseExchange|PurchaseRequest
      property-name: ReservedResourceProperty
    set:
      property-name: ReservedResourceProperties
  - where:
      model-name: PurchaseRequest
      property-name: ReservedResourcePropertyInstanceFlexibility
    set:
      property-name: InstanceFlexibility
  - where:
      model-name: ReservationResponse
      property-name: SplitProperty
    set:
      property-name: SplitProperties
  - where:
      model-name: ReservationResponse
      property-name: MergeProperty
    set:
      property-name: MergeProperties
  - where:
      model-name: ReservationSplitProperties
      property-name: SplitDestination
    set:
      property-name: SplitDestinations
  - where:
      model-name: ReservationMergeProperties
      property-name: MergeSource
    set:
      property-name: MergeSources

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
  ## New-AzReservation
  - where:
      verb: New
      subject-prefix: ''
      subject: Reservation
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      verb: New
      subject-prefix: ''
      subject: Reservation
      parameter-name: ReservedResourcePropertyInstanceFlexibility
    set:
      parameter-name: InstanceFlexibility
  ## Merge-AzReservation
  - where:
      verb: Merge
      subject-prefix: ''
      subject: Reservation
      parameter-name: Source
    set:
      parameter-name: ReservationId
  ## Update-AzReservation
  - where:
      verb: Update
      subject-prefix: ''
      subject: Reservation
      parameter-name: Parameter
    set:
      parameter-name: Reservation

  ### Set parameter alias
  - where:
      parameter-name: OrderId
    set:
      alias: ReservationOrderId  
  - where:
      parameter-name: Id
    set:
      alias: ReservationId

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
  - where:
      model-name: ExchangeOperationResultResponse
    set:
      format-table:
        properties:
          - SessionId
          - Status
  - where:
      model-name: SkuRestriction
    set:
      format-table:
        properties:
          - Type
          - Values
          - ReasonCode
  - where:
      model-name: CalculateRefundResponse
    set:
      suppress-format: true
  - where:
      model-name: RefundResponse
    set:
      suppress-format: true
          
  - no-inline:
    - Price
    - ExtendedStatusInfo
    - CalculatePriceResponsePropertiesBillingCurrencyTotal
    - CalculatePriceResponsePropertiesPricingCurrencyTotal
    - ReservationToPurchaseExchange
    - BillingInformation
    - ReservationSplitProperties
    - ReservationMergeProperties
    - PatchPropertiesRenewProperties
```
