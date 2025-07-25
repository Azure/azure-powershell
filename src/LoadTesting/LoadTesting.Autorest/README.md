<!-- region Generated -->
# Az.LoadTesting
This directory contains the PowerShell module for the LoadTesting service.

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
For information on how to develop for `Az.LoadTesting`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 7d98899a9e242ef529368c9ba6d1686725a8b23b
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/loadtestservice/resource-manager/Microsoft.LoadTestService/stable/2022-12-01/loadtestservice.json

title: LoadTesting
module-version: 0.1.0
subject-prefix: ""

resourcegroup-append: true
nested-object-to-string: true
inlining-threshold: 200

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # https://stackoverflow.microsoft.com/questions/333196
  - where:
      subject: .*Quota.*
    remove: true
  - where:
      subject: .*OutboundNetworkDependencyEndpoint.*
    remove: true

  # Changing the command name from LoadTest to Load (New-AzLoad)
  - select: command
    where:
      subject: LoadTest
    set:
      subject: Load

  - where:
      variant: ^Create$|^Update$|.*ViaIdentity$|.*ViaIdentityExpanded$
    remove: true

  # Removing Set command
  - where:
      verb: Set
    remove: true
  
  # Renaming managed identity type parameter
  - where:
      parameter-name: ManagedServiceIdentityType
    set:
      parameter-name: IdentityType
  
  # Renaming user assigned identity parameter
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: IdentityUserAssigned

  # Renaming encryption key parameter
  - where:
      parameter-name: EncryptionKeyUrl
    set:
      parameter-name: EncryptionKey

  # Renaming encryption identity type parameter
  - where:
      parameter-name: PropertiesEncryptionIdentityType
    set:
      parameter-name: EncryptionIdentityType

  # Renaming encryption identity resource id parameter
  - where:
      parameter-name: IdentityResourceId
    set:
      parameter-name: EncryptionIdentityResourceId
  - where:
      parameter-name: Type
    set:
      parameter-name: IdentityType

  # Renaming output variables
  - where:
      property-name: EncryptionKeyUrl
    set:
      property-name: EncryptionKey
  
  - where:
      property-name: IdentityResourceId
    set:
      property-name: EncryptionIdentityResourceId

  - where:
      property-name: PropertiesEncryptionIdentityType
    set:
      property-name: EncryptionIdentityType

  - where:
      property-name: ManagedServiceIdentityType
    set:
      property-name: IdentityType

  # formatting the output
  - where:
      model-name: LoadTestResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - DataPlaneUri
        labels:
          ResourceGroupName: Resource group
          DataPlaneUri: DataPlane URL
  
  # Hiding redundant SystemData property 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.Api30.ISystemData SystemData', 'private Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.Api30.ISystemData SystemData');

  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/null != property.Key && null != property.Value/g, 'null != property.Key');
  
  # Hiding description property
  - where:
      parameter-name: Description
    hide: true

  - from: swagger-document 
    where: $.definitions.LoadTestProperties
    transform: >-
      return {
        "description": "LoadTest resource properties.",
        "type": "object",
        "properties": {
          "provisioningState": {
            "description": "Resource provisioning state.",
            "$ref": "#/definitions/ResourceState",
            "readOnly": true
          },
          "dataPlaneURI": {
            "description": "Resource data plane URI.",
            "maxLength": 2083,
            "type": "string",
            "readOnly": true
          },
          "encryption": {
            "description": "CMK Encryption property.",
            "type": "object",
            "$ref": "#/definitions/EncryptionProperties"
          }
        }
      }

  # Remove Azure-Async Operation from header
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LoadTestService/loadTests/{loadTestName}"].put
    transform: >-
      return {
        "tags": [
          "LoadTests"
        ],
        "description": "Create or update LoadTest resource.",
        "operationId": "LoadTests_CreateOrUpdate",
        "x-ms-long-running-operation": true,
        "x-ms-long-running-operation-options": {
          "final-state-via": "azure-async-operation"
        },
        "consumes": [
          "application/json"
        ],
        "produces": [
          "application/json"
        ],
        "parameters": [
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "#/parameters/LoadTestNameParameter"
          },
          {
            "in": "body",
            "name": "LoadTestResource",
            "description": "LoadTest resource data",
            "required": true,
            "schema": {
              "$ref": "#/definitions/LoadTestResource"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "schema": {
              "$ref": "#/definitions/LoadTestResource"
            }
          },
          "201": {
            "description": "Created -- LoadTest resource created",
            "schema": {
              "$ref": "#/definitions/LoadTestResource"
            }
          },
          "default": {
            "description": "Resource provider error response about the failure.",
            "schema": {
              "$ref": "../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
        },
        "x-ms-examples": {
          "LoadTests_CreateOrUpdate": {
            "$ref": "./examples/LoadTests_CreateOrUpdate.json"
          }
        }
      }

  - where:
      verb: New
      subject: Load
    hide: true

  - where:
      verb: Update
      subject: Load
    hide: true

  - where:
      verb: Get
      subject: Load
    hide: true

  - where:
      verb: Remove
      subject: Load
    hide: true
```
