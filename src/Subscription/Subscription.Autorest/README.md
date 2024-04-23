<!-- region Generated -->
# Az.Subscription
This directory contains the PowerShell module for the Subscription service.

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
For information on how to develop for `Az.Subscription`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 0f39a2d56070d2bc4251494525cb8af88583a938
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/subscription/resource-manager/Microsoft.Subscription/stable/2021-10-01/subscriptions.json

module-version: 0.3.0
title: Subscription
subject-prefix: $(service-name)

identity-correction-for-post: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document 
    where: $.paths["/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Subscription/policies/default"].get.responses
    transform: >-
      return {
          "200": {
            "description": "Normal response for a successful query.",
            "schema": {
              "$ref": "#/definitions/BillingAccountPoliciesResponse"
            }
          }
      }
  - from: swagger-document 
    where: $.paths["/providers/Microsoft.Subscription/subscriptions/{subscriptionId}/acceptOwnership"].post.responses
    transform: >-
      return {
          "200": {
            "description": "Accept Subscription ownership is OK."
          },
          "202": {
            "description": "Accept Subscription ownership is in progress",
            "headers": {
              "Location": {
                "description": "GET this URL to retrieve the status of the asynchronous operation.",
                "type": "string"
              },
              "Retry-After": {
                "description": "The amount of delay to use while the status of the operation is checked. The value is expressed in seconds.",
                "type": "integer",
                "format": "int32"
              }
            }
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/ErrorResponseBody"
            }
          }
      }

  - where:
      subject: AcceptSubscriptionOwnershipStatus
      variant: Accept
    set:
      variant: AcceptExpanded
  - where:
      subject: AcceptSubscriptionOwnershipStatus
      variant: AcceptViaIdentity
    set:
      variant: AcceptViaIdentityExpanded

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Rename$|^RenameViaIdentity$|^Add$|^Accept$|^AcceptViaIdentity$
    remove: true
  - where:
      subject: BillingAccountPolicy
    remove: true

  - where:
      verb: Stop
    set:
      verb: Disable
  - where:
      verb: Add
    set:
      verb: Update

  - where:
      subject: SubscriptionPolicyUpdatePolicy
    set:
      subject: SubscriptionPolicy
  - where:
      verb: Get
      subject: SubscriptionPolicy
      variant: ^Get$
    remove: true

  # operation cmdlet must be removed
  - where:
      subject: SubscriptionOperation
    hide: true
  # Service feedback: As only global admins to run this, we don't want to have cmdlets for these as 1st class experience
  - where:
      verb: Update
      subject: SubscriptionPolicy
    hide: true

  - where:
      subject: AcceptSubscriptionOwnership
    set:
      subject: AcceptOwnership
  - where:
      verb: Invoke
      subject: AcceptSubscriptionOwnershipStatus
    set:
      subject: AcceptOwnershipStatus
      verb: Get

  - where:
      verb: New
      subject: Alias
      parameter-name: AdditionalPropertyManagementGroupId
    set:
      parameter-name: ManagementGroupId
  - where:
      verb: New
      subject: Alias
      parameter-name: AdditionalPropertySubscriptionOwnerId
    set:
      parameter-name: SubscriptionOwnerId
  - where:
      verb: New
      subject: Alias
      parameter-name: AdditionalPropertySubscriptionTenantId
    set:
      parameter-name: SubscriptionTenantId
  - where:
      verb: New
      subject: Alias
      parameter-name: AdditionalPropertyTag
    set:
      parameter-name: Tag
  # All cmdlets parameter SubscriptionName has the alias DisplayName. ReName-AzSubscription needs to be customized to add an alias.
  - where:
      parameter-name: DisplayName
    set:
      parameter-name: SubscriptionName 
      alias: DisplayName
  - where:
      subject: Alias
      parameter-name: Name
    set:
      parameter-name: AliasName
    clear-alias: true
  - where:
      model-name: SubscriptionAliasResponse
      property-name: Name
    set:
      property-name: AliasName

  # Need to divided the command into two different ones based on the mutual exclusion parameter:
  - where:
      verb: New
      subject: Alias
    hide: true
  # SubscriptionName must be required
  - where:
      verb: Rename
      subject: Subscription
    hide: true

  - from: NewAzSubscriptionAlias_CreateExpanded.cs
    where: $
    transform: $ = $.replace('[Microsoft.Azure.PowerShell.Cmdlets.Subscription.Runtime.DefaultInfo(', '');
  - from: NewAzSubscriptionAlias_CreateExpanded.cs
    where: $
    transform: $ = $.replace('Name = @"",', '');
  - from: NewAzSubscriptionAlias_CreateExpanded.cs
    where: $
    transform: $ = $.replace('Description =@"",', '');
  - from: NewAzSubscriptionAlias_CreateExpanded.cs
    where: $
    transform: $ = $.replace('Script = @"(Get-AzContext).Subscription.Id")]', '');

  - from: GetAzSubscriptionAcceptOwnershipStatus_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('[Microsoft.Azure.PowerShell.Cmdlets.Subscription.Runtime.DefaultInfo(', '');
  - from: GetAzSubscriptionAcceptOwnershipStatus_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Name = @"",', '');
  - from: GetAzSubscriptionAcceptOwnershipStatus_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Description =@"",', '');
  - from: GetAzSubscriptionAcceptOwnershipStatus_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Script = @"(Get-AzContext).Subscription.Id")]', '');
  - where:
      verb: Get
      subject: AcceptOwnershipStatus
      parameter-name: SubscriptionId
    required: true

  - from: InvokeAzSubscriptionAcceptOwnership_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('[Microsoft.Azure.PowerShell.Cmdlets.Subscription.Runtime.DefaultInfo(', '');
  - from: InvokeAzSubscriptionAcceptOwnership_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Name = @"",', '');
  - from: InvokeAzSubscriptionAcceptOwnership_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Description =@"",', '');
  - from: InvokeAzSubscriptionAcceptOwnership_AcceptExpanded.cs
    where: $
    transform: $ = $.replace('Script = @"(Get-AzContext).Subscription.Id")]', '');
  - where:
      verb: Invoke
      subject: AcceptOwnership
      parameter-name: SubscriptionId
    required: true

  # Updated Parameter type of SubscriptionId from string[] to string.
  - where:
      verb: Get
      subject: AcceptOwnershipStatus
    hide: true

  - where:
      model-name: SubscriptionAliasResponse
    set:
      format-table:
        properties:
          - AliasName
          - SubscriptionId
          - ProvisioningState
  - where:
      model-name: GetTenantPolicyResponse
    set:
      format-table:
        properties:
          - Name
          - PolicyId
          - BlockSubscriptionsIntoTenant
          - BlockSubscriptionsLeavingTenant
  - where:
      model-name: AcceptOwnershipStatusResponse
    set:
      format-table:
        properties:
          - AcceptOwnershipState
          - BillingOwner
          - ProvisioningState
          - SubscriptionId
          - SubscriptionTenantId
```
