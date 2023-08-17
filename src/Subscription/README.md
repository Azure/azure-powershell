<!-- region Generated -->
# Az.Subscription
This directory contains the PowerShell module for the Subscription service.

---
## Status
[![Az.Subscription](https://img.shields.io/powershellgallery/v/Az.Subscription.svg?style=flat-square&label=Az.Subscription "Az.Subscription")](https://www.powershellgallery.com/packages/Az.Subscription/)

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
branch: be90a71f6a482c5b01155b3c9990887529cc6893
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/subscription/resource-manager/Microsoft.Subscription/stable/2021-10-01/subscriptions.json

module-version: 0.3.0
title: Subscription
subject-prefix: $(service-name)

identity-correction-for-post: true
nested-object-to-string: true

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

  - where:
      model-name: SubscriptionAliasResponse
    set:
      format-table:
        properties:
          - AliasName
          - DisplayName
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
```
