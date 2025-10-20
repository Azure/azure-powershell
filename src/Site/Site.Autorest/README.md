<!-- region Generated -->
# Az.Site
This directory contains the PowerShell module for the Site service.

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
For information on how to develop for `Az.Site`, see [how-to.md](how-to.md).
<!-- endregion -->

<!-- region Generated -->
# Az.Site
This directory contains the PowerShell module for the Site service.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/edge/resource-manager/Microsoft.Edge/sites/stable/2025-06-01/sites.json
  
commit: 3d1eea900f369f1a655c9bbb4fff4bf4657a7d75
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Site
inlining-threshold: 50

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update|CreateViaIdentity|CreateViaIdentityExpanded|UpdateViaIdentity)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Hide ALL scope-specific cmdlets to allow custom unified cmdlets
  - where:
      subject: SitesBySubscription
    hide: true
  - where:
      subject: SitesByServiceGroup
    hide: true
  
  # Hide ALL base resource group scope cmdlets (our custom unified cmdlets replace them)
  - where:
      verb: Get
      subject: Site
    hide: true
  - where:
      verb: New
      subject: Site
    hide: true
  - where:
      verb: Remove
      subject: Site
    hide: true
  - where:
      verb: Update
      subject: Site
    hide: true

  # Parameter customizations for better user experience
  - where:
      parameter-name: Label
    set:
      parameter-name: Labels

  # Remove SiteAddress prefix from address-related parameters
  - where:
      parameter-name: SiteAddressCity
    set:
      parameter-name: City
  
  - where:
      parameter-name: SiteAddressCountry
    set:
      parameter-name: Country
  
  - where:
      parameter-name: SiteAddressPostalCode
    set:
      parameter-name: PostalCode
  
  - where:
      parameter-name: SiteAddressStateOrProvince
    set:
      parameter-name: StateOrProvince
  
  - where:
      parameter-name: SiteAddressStreetAddress1
    set:
      parameter-name: StreetAddress1
  
  - where:
      parameter-name: SiteAddressStreetAddress2
    set:
      parameter-name: StreetAddress2

  - where:
      property-name: Label
    set:
      property-name: Labels

  # Remove Address prefix from address-related properties  
  - where:
      property-name: AddressCity
    set:
      property-name: City
  
  - where:
      property-name: AddressCountry
    set:
      property-name: Country
  
  - where:
      property-name: AddressPostalCode
    set:
      property-name: PostalCode
  
  - where:
      property-name: AddressStateOrProvince
    set:
      property-name: StateOrProvince
  
  - where:
      property-name: AddressStreetAddress1
    set:
      property-name: StreetAddress1
  
  - where:
      property-name: AddressStreetAddress2
    set:
      property-name: StreetAddress2

  - where:
      parameter-name: SiteName
    set:
      alias: Name

```
