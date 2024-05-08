<!-- region Generated -->
# Az.Elastic
This directory contains the PowerShell module for the Elastic service.

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
For information on how to develop for `Az.Elastic`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
commit: eee9cbba738edde2ea48ea0c826f84619e2561df
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/elastic/resource-manager/Microsoft.Elastic/stable/2020-07-01/elastic.json

title: Elastic
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
      parameter-name: Sku
    set:
      parameter-description: The SKU depends on the Elasticsearch Plans available for your account and is a combination of PlanID_Term. \<br>For instance, if the plan ID is "planXYZ" and term is "Yearly", the SKU will be "planXYZ_Yearly". \<br>You may find your eligible plans [here](https://portal.azure.com/#view/Microsoft_Azure_Marketplace/GalleryItemDetailsBladeNopdl/id/elastic.ec-azure-pp/selectionMode~/false/resourceGroupId//resourceGroupLocation//dontDiscardJourney~/false/selectedMenuId/home/launchingContext~/%7B%22galleryItemId%22%3A%22elastic.ec-azure-ppess-consumption-2024%22%2C%22source%22%3A%5B%22GalleryFeaturedMenuItemPart%22%2C%22VirtualizedTileDetails%22%5D%2C%22menuItemId%22%3A%22home%22%2C%22subMenuItemId%22%3A%22Search%20results%22%2C%22telemetryId%22%3A%2262f8ce76-e5e4-4983-9d3e-5c608a0b2bff%22%7D/searchTelemetryId/cca0a8d3-f232-4156-948f-701a5d74a729) or in the online documentation [here](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/elastic.ec-azure-pp) for more details or in case of any issues with the SKU.

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
