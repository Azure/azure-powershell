<!-- region Generated -->
# Az.Advisor
This directory contains the PowerShell module for the Advisor service.

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
For information on how to develop for `Az.Advisor`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# pin the swagger version by using the commit id instead of branch name
commit: 2a07629a9919989375ab04490fb24051f78d1a7c
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/advisor.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Advisor
subject-prefix: $(service-name)
resourcegroup-append: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      parameter-name: ResourceGroup
    set:
      parameter-name: ResourceGroupName
  - where:
      verb: Get|New
      subject: Recommendation
    hide: true
  - where:
      subject: Suppression
    hide: true
  - where:
      verb: New
      subject: Configuration
    hide: true
  - where:
      subject: RecommendationGenerateStatus
    hide: true
  - where:
      subject: RecommendationMetadata
    hide: true
  - where:
      model-name: ResourceRecommendationBase
    set:
      format-table:
        properties:
          - Name
          - Category
          - ResourceGroupName
          - Impact
          - ImpactedValue
          - ImpactedField
        labels:
          ResourceGroupName: Resource Group
  - where:
      model-name: ConfigData
    set:
      format-table:
        properties:
          - Name
          - Exclude
          - LowCpuThreshold
  - where:
      model-name: SuppressionContract
    set:
      format-table:
        properties:
          - SuppressionId
          - Name
          - ResourceGroupName
          - Ttl
        labels:
          ResourceGroupName: Resource Group
