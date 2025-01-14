<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release
* upgraded nuget package to signed package.

## Version 0.5.1
* Removed Microsoft.Azure.Management.Marketplace 1.1.0 dependencies
* Added Microsoft.Azure.PowerShell.Marketplace.Management.Sdk

## Version 0.5.0
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.4.0
* Added new features and capabilities to user and marketplace-admins:
    - Approve offer and plans with subscription granularity.
    - Enable\Disable Approve-All-Products on a collection.
    - Fetch all subscriptions in a tenant.
    - Get new plans notifications for the offers in the privatestore.
    - Get all approved offers and plans for a user.

## Version 0.3.0
* Added new cmdlets:
 - `Copy-AzMarketplacePrivateStoreCollectionOffer`
 - `Get-AzMarketplaceBillingPrivateStoreAccount`
 - `Get-AzMarketplaceCollectionToSubscriptionMapping`
 - `Get-AzMarketplacePrivateStoreCollection`
 - `Get-AzMarketplacePrivateStoreCollectionOffer`
 - `Get-AzMarketplacePrivateStoreV1`
 - `Get-AzMarketplaceQueryPrivateStoreOffer`
 - `New-AzMarketplacePrivateStore`
 - `New-AzMarketplacePrivateStoreCollection`
 - `New-AzMarketplacePrivateStoreCollectionOffer`
 - `Remove-AzMarketplacePrivateStoreCollection`
 - `Remove-AzMarketplacePrivateStoreCollectionOffer`
 - `Set-AzMarketplaceBulkPrivateStoreCollectionAction`
 - `Set-AzMarketplacePrivateStore`
 - `Set-AzMarketplacePrivateStoreCollection`
 - `Set-AzMarketplacePrivateStoreCollectionOffer'`

## Version 0.2.0
* Preview release , support private offers in private store under subscription level

## Version 0.1.0
* the first preview release
