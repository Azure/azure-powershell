<!-- region Generated -->
# Az.DeviceUpdate
This directory contains the PowerShell module for the DeviceUpdate service.

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
For information on how to develop for `Az.DeviceUpdate`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: a7480c1f8b16b7b2be41de94726dca359e93178b
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/deviceupdate/resource-manager/Microsoft.DeviceUpdate/stable/2022-10-01/privatelinks.json
  - $(repo)/specification/deviceupdate/resource-manager/Microsoft.DeviceUpdate/stable/2022-10-01/deviceupdate.json

title: DeviceUpdate
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Invoke
    remove: true
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceUpdate/accounts/{accountName}"].put.responses
    transform: >-
      return {
          "200": {
            "description": "Async operation to create or update Account was created.",
            "schema": {
              "$ref": "#/definitions/Account"
            }
          },
          "201": {
            "description": "Async operation to create or update Account was created.",
            "schema": {
              "$ref": "#/definitions/Account"
            }
          },
          "default": {
            "description": "Error response describing the reason for operation failure.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/a7480c1f8b16b7b2be41de94726dca359e93178b/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceUpdate/accounts/{accountName}/instances/{instanceName}"].put.responses
    transform: >-
      return {
          "200": {
            "description": "Async operation to create or update Instance was created.",
            "schema": {
              "$ref": "#/definitions/Instance"
            }
          },
          "201": {
            "description": "Async operation to create or update Instance was created.",
            "schema": {
              "$ref": "#/definitions/Instance"
            }
          },
          "default": {
            "description": "Error response describing the reason for operation failure.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/a7480c1f8b16b7b2be41de94726dca359e93178b/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceUpdate/accounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}"].put.responses
    transform: >-
      return {
          "200": {
            "description": "The request was successful; the operation will complete asynchronously.",
            "schema": {
              "$ref": "./privatelinks.json#/definitions/PrivateEndpointConnection"
            }
          },
          "201": {
            "description": "The request was successful; the operation will complete asynchronously.",
            "schema": {
              "$ref": "./privatelinks.json#/definitions/PrivateEndpointConnection"
            }
          },
          "default": {
            "description": "Error response describing the reason for operation failure.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/a7480c1f8b16b7b2be41de94726dca359e93178b/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceUpdate/accounts/{accountName}/privateEndpointConnectionProxies/{privateEndpointConnectionProxyId}"].put.responses
    transform: >-
      return {
          "200": {
            "description": "The request was successful; the operation will complete asynchronously.",
            "schema": {
              "$ref": "#/definitions/PrivateEndpointConnectionProxy"
            }
          },
          "201": {
            "description": "The request was successful; the operation will complete asynchronously.",
            "schema": {
              "$ref": "#/definitions/PrivateEndpointConnectionProxy"
            }
          },
          "default": {
            "description": "Error response describing the reason for operation failure.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/a7480c1f8b16b7b2be41de94726dca359e93178b/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
      }
  - where:
      model-name: Account
    set:
      format-table:
        properties:
          - Name
          - Location
          - Sku
          - ResourceGroupName
  - where:
      model-name: Instance
    set:
      format-table:
        properties:
          - AccountName
          - Name
          - Location
          - ResourceGroupName
  - where:
      model-name: PrivateEndpointConnection
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - ResourceGroupName
          - PrivateLinkServiceConnectionStateStatus
  - where:
      model-name: GroupInformation
    set:
      format-table:
        properties:
          - Name
          - GroupId
  - where:
      subject: PrivateEndpointConnectionProxy
    remove: true
  - where:
      subject: PrivateEndpointConnectionProxyPrivateEndpointProperty
    remove: true
  - where:
      subject: PrivateEndpointConnection
    remove: true
  - where:
      subject: PrivateLinkResource
    remove: true
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      verb: New
      subject: Instance
    hide: true
  # The cmdlet's name to long, Re-name it
  # - model-cmdlet:
  #     - IotHubSettings
  #     - PrivateEndpointConnection
  #     - CheckNameAvailabilityRequest
```
