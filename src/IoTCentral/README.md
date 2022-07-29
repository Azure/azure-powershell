<!-- region Generated -->
# Az.IoTCentral
This directory contains the PowerShell module for the IoTCentral service.

---
## Status
[![Az.IoTCentral](https://img.shields.io/powershellgallery/v/Az.IoTCentral.svg?style=flat-square&label=Az.IoTCentral "Az.IoTCentral")](https://www.powershellgallery.com/packages/Az.IoTCentral/)

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
For information on how to develop for `Az.IoTCentral`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 1809a66a915b28f9fdbefaf93a4dc8fed8bdb8c8
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/iotcentral/resource-manager/Microsoft.IoTCentral/preview/2021-11-01-preview/iotcentral.json

module-version: 0.1.0
title: IoTCentral
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true

directive:
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTCentral/iotApps/{resourceName}"].patch.responses
    transform: >-
      return {
          "200": {
            "description": "OK. The Update has succeeded",
            "headers": {
              "Azure-AsyncOperation": {
                "description": "URL to query for status of the operation. Returns current state, progress, and error metadata for the operation.",
                "type": "string"
              },
              "Retry-After": {
                "description": "How long the user should wait before making a follow-up request.",
                "type": "string"
              }
            },
            "schema": {
              "$ref": "#/definitions/App"
            }
          },
          "202": {
            "description": "Accepted - Patch request accepted; the operation will complete asynchronously.",
            "headers": {
              "Azure-AsyncOperation": {
                "description": "URL to query for status of the operation. Returns current state, progress, and error metadata for the operation.",
                "type": "string"
              },
              "Location": {
                "description": "URL to query for status of the operation. Returns 202 Accepted while the operation is in progress.",
                "type": "string"
              },
              "Retry-After": {
                "description": "How long the user should wait before making a follow-up request.",
                "type": "string"
              }
            }
          },
          "default": {
            "description": "DefaultErrorResponse",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/1809a66a915b28f9fdbefaf93a4dc8fed8bdb8c8/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            },
            "x-ms-error-response": true
          }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTCentral/iotApps/{resourceName}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "OK. The delete has succeeded"
          },
          "202": {
            "description": "Accepted - Delete request accepted; the operation will complete asynchronously.",
            "headers": {
              "Azure-AsyncOperation": {
                "description": "URL to query for status of the operation. Returns current state, progress, and error metadata for the operation.",
                "type": "string"
              },
              "Location": {
                "description": "URL to query for status of the operation. Returns 202 Accepted while the operation is in progress.",
                "type": "string"
              },
              "Retry-After": {
                "description": "How long the user should wait before making a follow-up request.",
                "type": "string"
              }
            }
          },
          "204": {
            "description": "If the resource does not exist, a 204 No Content status code is returned."
          },
          "default": {
            "description": "DefaultErrorResponse",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/1809a66a915b28f9fdbefaf93a4dc8fed8bdb8c8/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            },
            "x-ms-error-response": true
          }
      }
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Test
    remove: true
  - where:
      subject: PrivateEndpointConnection
    remove: true
  - where:
      subject: PrivateLink
    remove: true
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
  - where:
      verb: New
      subject: App
    hide: true
  - where:
      model-name: App
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName
```
