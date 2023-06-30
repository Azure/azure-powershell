<!-- region Generated -->
# Az.Policy
This directory contains the PowerShell module for the Policy service.

---
## Status
[![Az.Policy](https://img.shields.io/powershellgallery/v/Az.Policy.svg?style=flat-square&label=Az.Policy "Az.Policy")](https://www.powershellgallery.com/packages/Az.Policy/)

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
For information on how to develop for `Az.Policy`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
#branch: 314f28163917b9cfc527f7776b5e4a1dea69d295
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Authorization/stable/2021-06-01/policyDefinitions.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Authorization/stable/2021-06-01/policySetDefinitions.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Authorization/stable/2022-06-01/policyAssignments.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Authorization/preview/2022-07-01-preview/policyExemptions.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
root-module-name: $(prefix).Resources
title: Policy
subject-prefix: Policy

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

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
      verb: New|Update
      variant: ^(?!.*?Expanded)
    remove: true
  # Remove spuriously generated unneeded cmdlets
  - where:
      subject: .*Built
    remove: true
  # Alias New-* to Set-*
  - where:
      verb: New
      subject: PolicyAssignment
    set:
      alias:
        Set-AzPolicyAssignment
  - where:
      verb: New
      subject: PolicyDefinition
    set:
      alias:
        Set-AzPolicyDefinition
  - where:
      verb: New
      subject: PolicyExemption
    set:
      alias:
        Set-AzPolicyExemption
  - where:
      verb: New
      subject: PolicySetDefinition
    set:
      alias:
        Set-AzPolicySetDefinition
  # Rename and hide Name and SubscriptionId parameters on Get-AzPolicyDefinition to allow control over parameter binding
  - where:
      verb: Get
      subject: PolicyDefinition
      parameter-name: Name
      variant: Name
    set:
      parameter-name: NameInternal
      default:
        name: DefaultName
        description: Need a placeholder to keep autorest happy
        script: '"PlaceholderName"'
    hide: true
    clear-alias: true
  - where:
      verb: Get
      subject: PolicyDefinition
      parameter-name: SubscriptionId
    set:
      parameter-name: SubscriptionIdInternal
      default:
        name: DefaultSubscriptionId
        description: Need a placeholder to keep autorest happy
        script: '(Get-AzContext).Subscription.Id'
    hide: true
  # Hide generated ManagementGroupId parameter, since we use ManagementGroupName
  - where:
      parameter-name: ManagementGroupId
    set:
      default:
        name: DefaultManagementGroupId
        description: Need a placeholder to keep autorest happy
        script: '{ "" }'
    hide: true
  # Transform empty object definitions (e.g. policyRule, metadata) to hashtable
  - from: swagger-document
    where: $.definitions.PolicyDefinitionProperties.properties.policyRule
    transform: $['additionalProperties'] = true;
  - from: swagger-document
    where: $.definitions.PolicyDefinitionProperties.properties.metadata
    transform: $['additionalProperties'] = true;
  # Rename generated hashtable parameters to support string input (for compatability with current cmdlets)
  - where:
      parameter-name: Metadata
    set:
      parameter-name: MetadataTable
  - where:
      parameter-name: Parameter
    set:
      parameter-name: ParameterTable

metadata:
  nestedModules:
  - ./custom/Helpers

```
