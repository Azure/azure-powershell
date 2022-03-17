<!-- region Generated -->
# Az.Cdn
This directory contains the PowerShell module for the Cdn service.

---
## Status
[![Az.Cdn](https://img.shields.io/powershellgallery/v/Az.Cdn.svg?style=flat-square&label=Az.Cdn "Az.Cdn")](https://www.powershellgallery.com/packages/Az.Cdn/)

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
For information on how to develop for `Az.Cdn`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2021-06-01/afdx.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2021-06-01/cdn.json
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2021-06-01/cdnwebapplicationfirewall.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Cdn
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^(?!RuleSet).+$
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^RuleSet$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Hide Cdn profile
  - where:
      subject: Profile
    hide: true

  - where:
      subject: Afd(.*)
    set:
      subject-prefix: FrontDoorCdn
      subject: $1

  - where:
      subject: Rule
    set:
      subject-prefix: FrontDoorCdn  
  - where:
      subject: RuleSet
    set:
      subject-prefix: FrontDoorCdn
  - where:
      subject: RuleSetResourceUsage
    set:
      subject-prefix: FrontDoorCdn
    
  - where:
      subject: Route
    set:
      subject-prefix: FrontDoorCdn
      subject: Route
  - where:
      subject: Secret
    set:
      subject-prefix: FrontDoorCdn
      subject: Secret   
  - where:
      subject: SecurityPolicy
    set:
      subject-prefix: FrontDoorCdn
      subject: SecurityPolicy   

  # https://github.com/Azure/autorest.powershell/issues/906
  - where:
      model-name: AfdDomainUpdatePropertiesParameters
      property-name: PreValidatedCustomDomainResourceId
    set:
      property-name: AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId
  - where:
      model-name: AfdDomainUpdatePropertiesParameters
      property-name: PreValidatedCustomDomainResourceIdId
    set:
      property-name: PreValidatedCustomDomainResourceId

  # Delete 404
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}"].delete
    transform: >-
      $["x-ms-long-running-operation-options"] = {"final-state-via": "azure-async-operation"}
```
