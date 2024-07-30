<!-- region Generated -->
# Az.CustomLocation
This directory contains the PowerShell module for the CustomLocation service.

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
For information on how to develop for `Az.CustomLocation`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: f1180941e238bc99ac71f9535ecd126bb8b77d8f
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/extendedlocation/resource-manager/Microsoft.ExtendedLocation/preview/2021-08-31-preview/customlocations.json

module-version: 0.1.0
title: CustomLocation
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ExtendedLocation/customLocations/{resourceName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "Succeeded. The customLocation was deleted."
        },
        "202": {
          "description": "Accepted. The response indicates the delete operation is performed in the background."
        },
        "204": {
          "description": "NoContent. The response indicates the customLocation resource is already deleted."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f1180941e238bc99ac71f9535ecd126bb8b77d8f/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document
    where: $.definitions.customLocationProperties.properties.provisioningState
    transform: >-
      return {
          "description": "Provisioning State for the Custom Location.",
          "type": "string",
          "readOnly": true
      }

  - from: swagger-document
    where: $
    transform: return $.replace(/resourceGroups\//g, "resourcegroups/")

  - from: swagger-document
    where: $
    transform: return $.replace(/providers\/Microsoft.ExtendedLocation\//g, "providers/microsoft.extendedlocation/")

  - from: swagger-document
    where: $
    transform: return $.replace(/customLocations\//g, "customlocations/")

  - from: swagger-document
    where: $
    transform: return $.replace(/\{resourceName\}\/enabledResourceTypes/g, "{resourceName}/enabledresourcetypes")

  - from: swagger-document
    where: $.definitions.customLocation
    transform: $['required'] = ['properties']

  - from: swagger-document
    where: $.definitions.customLocationProperties
    transform: $['required'] = ['clusterExtensionIds', 'hostResourceId', 'namespace']

  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: CustomLocation
      variant: ^CreateViaIdentityExpanded$
    remove: true
  - where:
      variant: ^Find$|^FindViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true

  - where:
      verb: New|Update
      subject: ^CustomLocation$
      parameter-name: HostType
    hide: true
    set:
      default:
        script: '"Kubernetes"'

  - where:
      subject: CustomLocationOperation
    hide: true

  - where:
      subject: ^CustomLocation$|^CustomLocationEnabledResourceType$
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      subject: ^CustomLocationTargetResourceGroup$|^ResourceSyncRule$
      parameter-name: ResourceName
    set:
      parameter-name: CustomLocationName

  - where:
      subject: ^CustomLocationTargetResourceGroup$|^ResourceSyncRule$
      parameter-name: ChildResourceName
    set:
      parameter-name: Name

  - where:
      model-name: CustomLocation
    set:
      format-table:
        properties:
          - Location
          - Name
          - Namespace
          - ResourceGroupName

  - where:
      model-name: EnabledResourceType
    set:
      format-table:
        properties:
          - Name
          - ExtensionType

  - model-cmdlet:
    - model-name: MatchExpressionsProperties
      cmdlet-name: New-AzCustomLocationMatchExpressionsObject
```
