<!-- region Generated -->
# Az.Marketplace
This directory contains the PowerShell module for the Marketplace service.

---
## Status
[![Az.Marketplace](https://img.shields.io/powershellgallery/v/Az.Marketplace.svg?style=flat-square&label=Az.Marketplace "Az.Marketplace")](https://www.powershellgallery.com/packages/Az.Marketplace/)

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
For information on how to develop for `Az.Marketplace`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
branch: 8dc5f1df21caf602944de05e68945c2bbf009c2d
input-file:
  - $(repo)/specification/marketplace/resource-manager/Microsoft.Marketplace/stable/2021-06-01/Marketplace.json

module-version: 1.1.0
title: Marketplace
subject-prefix: $(service-name)

inlining-threshold: 50

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Hide CreateViaIdentity for customization
  - where:
      variant: ^CreateViaIdentity$
    hide: true

    # Remove notification commands
  - where:
      verb: Get
      subject: PrivateStoreRequestApproval
    remove: true
  - where:
      verb: Get
      subject: PrivateStoreApprovalRequestList
    remove: true
  - where:
      verb: Invoke
      subject: WithdrawPrivateStorePlan
    remove: true
  - where:
      verb: Invoke
      subject: QueryPrivateStoreNotificationState
    remove: true
  - where:
      verb: Invoke
      subject: AcknowledgePrivateStoreOfferNotification
    remove: true
  - where:
      verb: Invoke
      subject: QueryPrivateStoreApprovedPlan
    remove: true
  - where:
      verb: Invoke
      subject: QueryPrivateStoreRequestApproval
    remove: true
  - where:
      verb: Set
      subject: PrivateStoreAdminRequestApproval
    remove: true
  - where:
      verb: New
      subject: PrivateStoreApprovalRequest
    remove: true
  - where:
      verb: Request
      subject: PrivateStore
    remove: true
  - where:
      verb: Invoke
      subject: PrivateStoreCollection
    remove: true
  - where:
      verb: Invoke
      subject: PrivateStoreCollectionOffer
    remove: true
  - where:
      verb: Get
      subject: PrivateStoreAdminRequestApproval
    remove: true
  - where:
      verb: Remove
      subject: PrivateStore
    remove: true

    # Change commads names to Get
  - where:
      verb: Invoke
      subject: CollectionPrivateStoreToSubscriptionMapping
    set:
      verb: Get
      subject: CollectionToSubscriptionMapping
  - where:
      verb: Invoke
      subject: QueryPrivateStoreOffer
    set:
      verb: Get
  - where:
      verb: Invoke
      subject: BillingPrivateStoreAccount
    set:
      verb: Get
  - where:
      verb: Move
      subject: PrivateStoreCollectionOffer
      parameter-name: OfferIdsList 
    set:
      parameter-name: OfferIdList 
  - where:
      verb: Invoke
      subject: BulkPrivateStoreCollectionAction
    set:
      verb: Set
  - where:
      verb: Move
      subject: PrivateStoreCollectionOffer
    set:
      verb: Copy
  - where:
      parameter-name: SpecificPlanIdsLimitation 
    set:
      parameter-name: SpecificPlanIdLimitation 
  - where:
      verb: Get
      subject: PrivateStore
    set:
      subject: PrivateStoreV1

   
```
