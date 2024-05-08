<!-- region Generated -->
# Az.BillingBenefits
This directory contains the PowerShell module for the BillingBenefits service.

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
For information on how to develop for `Az.BillingBenefits`, see [how-to.md](how-to.md).
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
commit: bab95d5636c7d47cc5584ea8dadb21199d229ca7
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/billingbenefits/resource-manager/Microsoft.BillingBenefits/stable/2022-11-01/billingbenefits.json
module-version: 0.1.0
title: BillingBenefits
subject-prefix: $(service-name)

resourcegroup-append: true
nested-object-to-string: true
  
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  ### No inline
  - no-inline:
    - RenewProperties

  ### Rename Cmdlet names
  - where:
      verb: Get
      subject: SavingPlan
    set:
      verb: Get
      subject: SavingsPlanList
  - where:
      verb: Test
      subject: Purchase
    set:
      verb: Invoke
      subject: SavingsPlanPurchaseValidation
  - where:
      verb: Test
      subject: SavingPlanUpdate
    set:
      verb: Invoke
      subject: SavingsPlanUpdateValidation

  ### Rename property name

  ### Rename parameter name  

  ### Format output table
  - where:
      model-name: SavingsPlanModel
    set:
      format-table:
        properties:
          - DisplayName
          - DisplayProvisioningState
          - ExpiryDateTime
          - PurchaseDateTime
          - Term
          - UserFriendlyAppliedScopeType
          - AppliedScopePropertyDisplayName
          - SkuName
          - CommitmentAmount
          - CommitmentCurrencyCode
        labels:
          DisplayName: Name
          DisplayProvisioningState: Status
          ExpiryDateTime: ExpiryDate
          PurchaseDateTime: PurchaseDate
          UserFriendlyAppliedScopeType: Scope
          SkuName: ProductName
          AppliedScopePropertyDisplayName: AppliedScopeDisplayName
  - where:
      model-name: SavingsPlanOrderModel
    set:
      format-table:
        properties:
          - Name
          - SkuName
          - ProvisioningState
          - ExpiryDateTime
          - Term
          - BillingPlan
        labels:
          Name: OrderId
          ProvisioningState: Status
          ExpiryDateTime: ExpiryDate
  - where:
      model-name: SavingsPlanOrderAliasModel
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Id
          - Type
          - SkuName
          - CommitmentAmount
          - CommitmentCurrencyCode
          - CommitmentGrain
          - SavingsPlanOrderId
          - ProvisioningState
          - BillingScopeId
          - Term
          - BillingPlan
          - AppliedScopeType
          - AppliedScopePropertyDisplayName
          - AppliedScopePropertyManagementGroupId
          - AppliedScopePropertyResourceGroupId
          - AppliedScopePropertySubscriptionId
          - AppliedScopePropertyTenantId
  - where:
      model-name: ReservationOrderAliasResponse
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Id
          - Type
          - SkuName
          - Location
          - Term
          - BillingPlan
          - ReservedResourceType
          - ReservationOrderId
          - ProvisioningState
          - BillingScopeId
          - AppliedScopeType
          - AppliedScopePropertyDisplayName
          - AppliedScopePropertyManagementGroupId
          - AppliedScopePropertyResourceGroupId
          - AppliedScopePropertySubscriptionId
          - AppliedScopePropertyTenantId
  - where:
      model-name: RoleAssignmentEntity
    set:
      format-table:
        properties:
          - Id
          - Name
          - PrincipalId
          - RoleDefinitionId
          - Scope
  - where:
      model-name: SavingsPlanValidResponseProperty
    set:
      format-table:
        properties:
          - Valid
          - ReasonCode
          - Reason
```
