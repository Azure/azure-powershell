<!-- region Generated -->
# Az.ADDomainServices
This directory contains the PowerShell module for the AdDomainServices service.

---
## Status
[![Az.ADDomainServices](https://img.shields.io/powershellgallery/v/Az.ADDomainServices.svg?style=flat-square&label=Az.ADDomainServices "Az.ADDomainServices")](https://www.powershellgallery.com/packages/Az.ADDomainServices/)

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
For information on how to develop for `Az.ADDomainServices`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
Branch: 394ab556cb4aed1196918856a24be9b02609cc93
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/domainservices/resource-manager/Microsoft.AAD/stable/2020-01-01/domainservices.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ADDomainServices
service-name: ADDomainServices
subject-prefix: ADDomainService

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AAD/domainServices/{domainServiceName}"].delete.responses
    transform: >-
        $["200"] = {
          "description": "HTTP 200 (OK) should be returned if the object exists and was deleted successfully."
        }
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject: DomainServiceOperation
    hide: true
  - where:
      verb: New
      subject: (^DomainService)(.*) 
    set: 
      subject-prefix: ADDomainService
      subject: $2
    hide: true
  - where:
      verb: Update
      subject: (^DomainService)(.*) 
    set: 
      subject-prefix: ADDomainService
      subject: $2
    hide: true
  - where:
      verb: Get
      subject: (^DomainService)(.*) 
    set: 
      subject-prefix: ADDomainService
      subject: $2
  - where:
      verb: Remove
      subject: (^DomainService)(.*) 
    set: 
      subject-prefix: ADDomainService
      subject: $2
  - where:
      parameter-name: LdapSettingLdap
    set:
      parameter-name: LdapSettingLdaps
  - where:
      parameter-name: ResourceForestSetting
    set:
      parameter-name: ForestTrust
  - where:
      parameter-name: ResourceForestSettingResourceForest
    set:
      parameter-name: ResourceForest
  - where:
      model-name: DomainService
    set:
      format-table:
        properties:
          - Name
          - DomainName
          - Location
          - Sku
        labels:
          DomainName: Domain Name
```
