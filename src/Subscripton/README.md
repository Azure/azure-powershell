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

module-version: 0.1.0
title: Subscription
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - model-cmdlet:
      - SubscriptionName
      - AcceptOwnershipRequest
      - PutTenantPolicyRequestProperties
```
