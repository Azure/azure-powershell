<!-- region Generated -->
# Az.Elastic
This directory contains the PowerShell module for the Elastic service.

---
## Status
[![Az.Elastic](https://img.shields.io/powershellgallery/v/Az.Elastic.svg?style=flat-square&label=Az.Elastic "Az.Elastic")](https://www.powershellgallery.com/packages/Az.Elastic/)

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
For information on how to develop for `Az.Elastic`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: eee9cbba738edde2ea48ea0c826f84619e2561df
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/elastic/resource-manager/Microsoft.Elastic/stable/2020-07-01/elastic.json

title: Elastic
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true

directive:
  # Swagger issue that the ProvisioningState should readonly.
  - from: swagger-document
    where: $.definitions.MonitorProperties.properties.provisioningState
    transform: >-
      return {
          "description": "Provisioning state of the monitor resource.",
          "readOnly": true,
          "$ref": "#/definitions/ProvisioningState"
        }
  - from: swagger-document
    where: $.definitions.MonitoringTagRulesProperties.properties.provisioningState
    transform: >-
      return {
          "description": "Provisioning state of the monitoring tag rules.",
          "readOnly": true,
          "$ref": "#/definitions/ProvisioningState"
        }

  - where:
      verb: Set
    remove: true

  # The service not planning to support it in the near future.
  - where:
      verb: Remove
      subject: TagRule
    remove: true

  # Only name allowed for a tag rule is default.
  - where: 
      verb: Get
      subject: TagRule
      variant: List
    remove: true
  - where:
      verb: Get|New
      subject: TagRule
      parameter-name: RuleSetName
    hide: true
    set:
      default:
        script: '"default"'

  - where:
      verb: Get|New|Update|Remove|Invoke
      subject: DeploymentInfo|MonitoredResource|VMHost|DetailVMIngestion|VMCollection
      parameter-name: MonitorName
    set:
      parameter-name: Name

  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: Monitor|VMCollection|TagRule
    remove: true

  - where:
      verb: Invoke
    set:
      verb: Get
  - where:
      model-name: ElasticMonitorResource
    set:
      format-table:
        properties:
          - Name
          - SkuName
          - MonitoringStatus
          - Location
  - where:
      model-name: MonitoringTagRules
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState

  # - model-cmdlet:
  #   - FilteringTag
```
