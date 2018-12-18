---
Module Name: Azs.Subscriptions.Admin
Module Guid: 60c5ab08-9482-4a99-b973-141ac294c07a
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# Azs.Subscriptions.Admin Module
## Description
Preview release of the AzureStack Subscription operator module.  This module provides functionality for operators to manage plans, offers and subscriptions

## Azs.Subscriptions.Admin Cmdlets
### [Add-AzsPlanToOffer](Add-AzsPlanToOffer.md)
Links a plan to an offer.

### [Get-AzsDelegatedProvider](Get-AzsDelegatedProvider.md)
Get the list of delegatedProviders.

### [Get-AzsDelegatedProviderManagedOffer](Get-AzsDelegatedProviderManagedOffer.md)
Get the list of delegated provider offers.

### [Get-AzsDirectoryTenant](Get-AzsDirectoryTenant.md)
Lists all the directory tenants under the current subscription and given resource group name.

### [Get-AzsLocation](Get-AzsLocation.md)
Get a list of all AzureStack location.

### [Get-AzsManagedOffer](Get-AzsManagedOffer.md)
Get the list of offers as the operator.

### [Get-AzsOfferDelegation](Get-AzsOfferDelegation.md)
Get the list of delegated offers.

### [Get-AzsOfferMetric](Get-AzsOfferMetric.md)
Get the offer metrics.

### [Get-AzsPlan](Get-AzsPlan.md)
List all plans across all subscriptions.

### [Get-AzsPlanMetric](Get-AzsPlanMetric.md)
Get the plan metrics.

### [Get-AzsSubscriptionPlan](Get-AzsSubscriptionPlan.md)
Get a collection of all acquired plans that subscription has access to.

### [Get-AzsSubscriptionsQuota](Get-AzsSubscriptionsQuota.md)
Get the list of subscription resource provider quotas at a location.

### [Get-AzsUserSubscription](Get-AzsUserSubscription.md)
Get the list of user subscriptions as operator.

### [Move-AzsSubscription](Move-AzsSubscription.md)
Move subscriptions between delegated provider offers.
This process will only perform a rebranding,
the underlying offer, plans, quotas for the subscriptions will not be altered.

### [New-AzsAddonPlanDefinitionObject](New-AzsAddonPlanDefinitionObject.md)
Contains the name of the desired plan to be linked or unlinked from an offer.

### [New-AzsOffer](New-AzsOffer.md)
Creates a new offer.

### [New-AzsOfferDelegation](New-AzsOfferDelegation.md)
Create a new offer delegation.

### [New-AzsPlan](New-AzsPlan.md)
Creates a new plan

### [New-AzsSubscriptionPlan](New-AzsSubscriptionPlan.md)
Creates a subscription plan.

### [New-AzsUserSubscription](New-AzsUserSubscription.md)
Create a new subscription.

### [Remove-AzsOffer](Remove-AzsOffer.md)
Delete the specified offer.

### [Remove-AzsOfferDelegation](Remove-AzsOfferDelegation.md)
Removes the offer delegation

### [Remove-AzsPlan](Remove-AzsPlan.md)
Removes the specified plan

### [Remove-AzsPlanFromOffer](Remove-AzsPlanFromOffer.md)
Unlink a plan from an offer.

### [Remove-AzsSubscriptionPlan](Remove-AzsSubscriptionPlan.md)
Deletes a subscription plan.

### [Remove-AzsUserSubscription](Remove-AzsUserSubscription.md)
Removes the specified tenant subscription.

### [Set-AzsOffer](Set-AzsOffer.md)
Update the offer.

### [Set-AzsOfferDelegation](Set-AzsOfferDelegation.md)
Updates the offer delegation.

### [Set-AzsPlan](Set-AzsPlan.md)
Updates the specified plan

### [Set-AzsUserSubscription](Set-AzsUserSubscription.md)
Updates the specified user subscription

### [Test-AzsMoveSubscription](Test-AzsMoveSubscription.md)
Validate that user subscriptions can be moved between delegated provider offers.

### [Test-AzsNameAvailability](Test-AzsNameAvailability.md)
Returns the avaialbility of the specified subscriptions resource type and name

