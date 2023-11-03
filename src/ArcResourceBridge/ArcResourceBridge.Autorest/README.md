<!-- region Generated -->
# Az.ArcResourceBridge
This directory contains the PowerShell module for the ArcResourceBridge service.

---
## Status
[![Az.ArcResourceBridge](https://img.shields.io/powershellgallery/v/Az.ArcResourceBridge.svg?style=flat-square&label=Az.ArcResourceBridge "Az.ArcResourceBridge")](https://www.powershellgallery.com/packages/Az.ArcResourceBridge/)

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
For information on how to develop for `Az.ArcResourceBridge`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7d6c14d986a67dca3451d7d92d8f6b9416d61fbf
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/resourceconnector/resource-manager/Microsoft.ResourceConnector/stable/2022-10-27/appliances.json

title: ArcResourceBridge
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ResourceConnector/appliances/{resourceName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "Succeeded. The resource bridge was deleted."
        },
        "202": {
          "description": "Accepted. The response indicates the delete operation is performed in the background."
        },
        "204": {
          "description": "NoContent. The response indicates the appliance resource is already deleted."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/7d6c14d986a67dca3451d7d92d8f6b9416d61fbf/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
          }
        }
      }

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
  - where:
      subject-prefix: ArcResourceBridge
      subject: Appliance
    set:
      subject-prefix: ArcResource
      subject: Bridge
  - where:
      subject-prefix: ArcResourceBridge
      subject: ApplianceClusterUserCredential
    set:
      subject: ApplianceCredential
  - where:
      subject-prefix: ArcResourceBridge
      subject: ApplianceKey
    set:
      subject: Credential
  - where:
      subject-prefix: ArcResourceBridge
      subject: ApplianceTelemetryConfig
    set:
      subject: TelemetryConfig
  - where:
      subject-prefix: ArcResourceBridge
      subject: ApplianceUpgradeGraph
    set:
      subject: UpgradeGraph
  - where:
      subject-prefix: ArcResourceBridge
      subject: ApplianceOperation
    hide: true
  - where:
      model-name: Appliance
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
```
