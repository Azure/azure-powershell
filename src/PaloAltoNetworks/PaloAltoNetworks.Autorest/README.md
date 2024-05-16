<!-- region Generated -->
# Az.PaloAltoNetworks
This directory contains the PowerShell module for the PaloAltoNetworks service.

---
## Status
[![Az.PaloAltoNetworks](https://img.shields.io/powershellgallery/v/Az.PaloAltoNetworks.svg?style=flat-square&label=Az.PaloAltoNetworks "Az.PaloAltoNetworks")](https://www.powershellgallery.com/packages/Az.PaloAltoNetworks/)

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
For information on how to develop for `Az.PaloAltoNetworks`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 1e00aa55113c2a47b26cf588b732758071d6f05f
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/PaloAltoNetworks.Cloudngfw.json

title: PaloAltoNetworks
module-version: 0.2.0
subject-prefix: $(service-name)
disable-transform-identity-type: true
flatten-userassignedidentity: false

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/{localRulestackName}/commit"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "The request has been received but not yet acted upon."
        },
        "default": {
          "description": "Common error response for all Azure Resource Manager APIs to return error details for failed operations.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/1e00aa55113c2a47b26cf588b732758071d6f05f/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
          }
        }
      }

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/{localRulestackName}/revert"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "204": {
          "description": "There is no content to send for this request, but the headers may be useful. "
        },
        "default": {
          "description": "Common error response for all Azure Resource Manager APIs to return error details for failed operations.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/1e00aa55113c2a47b26cf588b732758071d6f05f/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
          }
        }
      }

  - where:
      variant: ^(Create|Update|Save)(?!.*?Expanded)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true

  - where:
      verb: Set
    remove: true
# # Some of the parameters are of type Object and need to be expanded into a command for the convenience of the user
# # The following are commented out and their generated cmdlets may be renamed and custom logic
# # Do not delete this code
#   - model-cmdlet:
#       - IPAddress
#       - FrontendSetting
#       - NetworkProfile
#       - TagInfo

  - where:
      subject: PostRule
    remove: true
  - where:
      subject: PostRuleCounter
    remove: true
  - where:
      subject: PreRule
    remove: true
  - where:
      subject: PreRuleCounter
    remove: true

# We can exclude GlobalRulestack. All GlobalRulestack APIs are not in use.
  - where:
      subject: CertificateObjectGlobalRulestack
    remove: true
  - where:
      subject: FirewallGlobalRulestack
    remove: true
  - where:
      subject: FqdnListGlobalRulestack
    remove: true
  - where:
      subject: GlobalRulestack
    remove: true
  - where:
      subject: GlobalRulestackAdvancedSecurityObject
    remove: true
  - where:
      subject: GlobalRulestackAppId
    remove: true
  - where:
      subject: GlobalRulestackChangeLog
    remove: true
  - where:
      subject: GlobalRulestackCountry
    remove: true
  - where:
      subject: GlobalRulestackFirewall
    remove: true
  - where:
      subject: GlobalRulestackPredefinedUrlCategory
    remove: true
  - where:
      subject: GlobalRulestackSecurityService
    remove: true
  - where:
      subject: PrefixListGlobalRulestack
    remove: true
  - where:
      subject: CommitGlobalRulestack
    remove: true
  - where:
      subject: RevertGlobalRulestack
    remove: true
# Remove update cmdlets generated from get->put, since service team does not need them now.
  - where:
      verb: Update
      subject: ^CertificateObjectLocalRulestack$|^FqdnListLocalRulestack$|^PrefixListLocalRulestack$|^LocalRule$
    remove: true
  - where:
      parameter-name: StackName
    set:
      parameter-name: LocalRulestackName
    clear-alias: true

  - where:
      model-name: LocalRulestackResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: PrefixListResource
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: FqdnListLocalRulestackResource
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: LocalRulesResource
    set:
      format-table:
        properties:
          - RuleName
          - RuleState
          - Priority
          - ResourceGroupName
  - where:
      model-name: FirewallResource
    set:
      format-table:
        properties:
          - Location
          - Name
          - MarketplaceDetailPublisherId
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: FirewallStatusResource
    set:
      format-table:
        properties:
          - IsPanoramaManaged
          - HealthStatus
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: CertificateObjectLocalRulestackResource
    set:
      format-table:
        properties:
          - CertificateSelfSigned
          - Name
          - ProvisioningState
          - ResourceGroupName

  # When service team fixes the bug in swagger related to nextlink, we can generate these commands out.
  - where:
      verb: Get
      subject: FirewallSupportInfo|LocalRuleCounter|LocalRulestackAdvancedSecurityObject|LocalRulestackCountry|LocalRulestackPredefinedUrlCategory|LocalRulestackSecurityService
    remove: true
```
