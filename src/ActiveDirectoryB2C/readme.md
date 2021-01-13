<!-- region Generated -->
# Az.ActiveDirectoryB2C
This directory contains the PowerShell module for the ActiveDirectoryB2C service.

---
## Status
[![Az.ActiveDirectoryB2C](https://img.shields.io/powershellgallery/v/Az.ActiveDirectoryB2C.svg?style=flat-square&label=Az.ActiveDirectoryB2C "Az.ActiveDirectoryB2C")](https://www.powershellgallery.com/packages/Az.ActiveDirectoryB2C/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ActiveDirectoryB2C`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
Branch: c39f5471c6bffe9edaa63c0f3fe5a2511c907be8
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/cpim/resource-manager/Microsoft.AzureActiveDirectory/preview/2019-01-01-preview/cpimTenant.json

module-version: 0.1.0
title: ActiveDirectoryB2C
subject-prefix: ADB2C

inlining-threshold: 50

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject-prefix: Adb2C
    set:
      subject-prefix: ADB2C
  - where:
      subject: (^B2C)(.*) 
    set: 
      subject: $2
  - where:
      verb: New
      subject: Tenant
    hide: true
  - where:
      verb: Update
      subject: Tenant
    hide: true
  - where:
      verb: Get
      subject: OperationAsyncStatus
    hide: true
  - where:
      verb: Test
      subject: TenantNameAvailability
    hide: true
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name 
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku 
  - where:
      parameter-name: CreateTenantPropertyDisplayName
    set:
      parameter-name: DisplayName
  - where:
      parameter-name: CreateTenantPropertyCountryCode
    set:
      parameter-name: CountryCode
  - where:
      parameter-name: BillingConfigBillingType
    set:
      parameter-name: BillingType
      
```
