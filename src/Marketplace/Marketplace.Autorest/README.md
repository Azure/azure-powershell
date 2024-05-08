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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

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
commit: a54263176acce91199a19333d6c4717367a3317e
input-file:
  - $(repo)/specification/marketplace/resource-manager/Microsoft.Marketplace/stable/2023-01-01/Marketplace.json

module-version: 1.1.0
title: Marketplace
subject-prefix: $(service-name)
inlining-threshold: 50

use-extension: 
  "@autorest/powershell": "4.x"

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
      subject: ^PrivateStoreCollection$
    remove: true
  - where:
      verb: Invoke
      subject: ^PrivateStoreCollectionOffer$
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

    # Rename POST methods
  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/anyExistingOffersInTheCollections
  - where:
      verb: Invoke
      subject: AnyPrivateStoreExistingOffer
    set:
      verb: Test
      subject: PrivateStoreAnyExistingOffer
  - where:
      verb: Get
      subject: PrivateStoreUserOffer
      variant: Query(?!.*?Expanded)
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/queryUserOffers
  - where:
      verb: Invoke
      subject: QueryPrivateStoreUserOffer
    set:
      verb: Get
      subject: PrivateStoreUserOffer
  - where:
      verb: Get
      subject: PrivateStoreUserOffer
      variant: Query(?!.*?Expanded)
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/queryUserRules
  - where:
      verb: Invoke
      subject: QueryUserRule
    set:
      verb: Get
      subject: PrivateStoreUserRule
  - where:
      verb: Get
      subject: PrivateStoreUserRule
      variant: Query(?!.*?Expanded)
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/approveAllItems
  - where:
      verb: Approve
      subject: PrivateStoreCollectionItem
    set:
      verb: Enable
      subject: PrivateStoreCollectionAllItem
  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/disableApproveAllItems"
  - where:
      verb: Disable
      subject: PrivateStoreCollectionApproveItem
    set:
      subject: PrivateStoreCollectionAllItem 

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/mapOffersToContexts
  - where:
      verb: Get
      subject: PrivateStoreCollectionOffer
      variant: ^List\S+
    set:
      subject: PrivateStoreCollectionMapOffersToContext
  - where:
      verb: Get
      subject: PrivateStoreCollectionMapOffersToContext
      variant: List(?!.*?Expanded)
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/setRules
  # swagger does not match request
  # - where:
  #     verb: Set
  #     subject: CollectionRule
  #   set:
  #     verb: New
  #     subject: PrivateStoreCollectionRule
  # - where:
  #     verb: New
  #     subject: PrivateStoreCollectionRule
  #     variant: Set(?!.*?Expanded)
  #   remove: true
  - where:
      verb: Set
      subject: CollectionRule
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/queryRules
  - where: 
      verb: Invoke
      subject: QueryRule
    set:
      verb: Get
      subject: PrivateStoreCollectionRule
    
  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/offers/{offerId}/upsertOfferWithMultiContext
  - where:
      verb: Invoke
      subject: OfferPrivateStoreCollectionOfferUpsert
    set:
      verb: New
      subject: PrivateStoreCollectionOfferMultiContext
  - where:
      verb: New
      subject: PrivateStoreCollectionOfferMultiContext
      variant: Offer(?!.*?Expanded)
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/fetchAllSubscriptionsInTenant
  - where:
      verb: Invoke
      subject: FetchPrivateStoreSubscription
    set:
      verb: Get
      subject: PrivateStoreAllSubscriptionInTenant

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/listStopSellOffersPlansNotifications
  # - where:
  #     verb: Get
  #     subject: PrivateStoreStopSellOfferPlanNotification
  #     variant: List(?!.*?Expanded)
  #   remove: true
  - where:
      verb: Get
      subject: PrivateStoreStopSellOfferPlanNotification
    remove: true

  # /providers/Microsoft.Marketplace/privateStores/{privateStoreId}/listSubscriptionsContext
  - where:
      verb: Get
      subject: PrivateStoreSubscriptionContext
    set:
      subject: PrivateStoreSubscription
```
