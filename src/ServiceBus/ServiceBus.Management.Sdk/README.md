# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```



###
``` yaml
commit: 226c70f75acef9073d7634dd1506605a9b1db6c7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/namespace-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/DisasterRecoveryConfig.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/migrationconfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/networksets.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Queue.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/topics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Rules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/subscriptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/CheckNameAvailability.json


output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceBus

directive:
# Remove "x-ms-client-flatten": true
  - from: swagger-document
    where: $.definitions.Encryption
    transform: >-
      return {
        "type": "object",
        "properties": {
          "keyVaultProperties": {
            "type": "array",
            "items": {
              "$ref": "#/definitions/KeyVaultProperties"
            },
            "x-ms-client-name": "KeyVaultProperties",
            "description": "Properties of KeyVault"
          },
          "keySource": {
            "type": "string",
            "description": "Enumerates the possible value of keySource for Encryption",
            "default": "Microsoft.KeyVault",
            "enum": [
              "Microsoft.KeyVault"
            ],
            "x-ms-enum": {
              "name": "keySource",
              "modelAsString": true
            }
          },
          "requireInfrastructureEncryption": {
            "type": "boolean",
            "description": "Enable Infrastructure Encryption (Double Encryption)"
          }
        },
        "description": "Properties to configure Encryption"
      }
  - from: swagger-document
    where: $.definitions.Identity
    transform: >-
      return {
        "type": "object",
        "properties": {
          "principalId": {
            "type": "string",
            "description": "ObjectId from the KeyVault",
            "readOnly": true
          },
          "tenantId": {
            "type": "string",
            "description": "TenantId from the KeyVault",
            "readOnly": true
          },
          "type": {
            "description": "Type of managed service identity.",
            "enum": [
              "SystemAssigned",
              "UserAssigned",
              "SystemAssigned, UserAssigned",
              "None"
            ],
            "type": "string",
            "x-ms-enum": {
              "name": "ManagedServiceIdentityType",
              "modelAsString": true
            }
          },
        "userAssignedIdentities": {
          "type": "object",
          "additionalProperties": {
            "$ref": "#/definitions/UserAssignedIdentity"
          },
          "description": "Properties for User Assigned Identities"
        }
      },
      "description": "Properties to configure User Assigned Identities for Bring your Own Keys"
      }
  - from: swagger-document
    where: $.definitions.userAssignedIdentityProperties
    transform: >-
      return {
        "type": "object",
        "properties": {
          "userAssignedIdentity": {
            "type": "string",
            "description": "ARM ID of user Identity selected for encryption"
          }
        }
      }
  - from: swagger-document
    where: $.definitions.NWRuleSetIpRules
    transform: >-
      return {
        "type": "object",
        "properties": {
          "ipMask": {
            "type": "string",
            "description": "IP Mask"
          },
          "action": {
            "type": "string",
            "description": "The IP Filter Action",
            "enum": [
              "Allow"
            ],
            "x-ms-enum": {
              "name": "NetworkRuleIPAction",
              "modelAsString": true
            },
            "default": "Allow"
          }
        },
        "description": "Description of NetWorkRuleSet - IpRules resource."
      }
  - from: swagger-document
    where: $.definitions.NWRuleSetVirtualNetworkRules
    transform: >-
      return {
        "type": "object",
        "properties": {
          "subnet": {
            "$ref": "#/definitions/Subnet",
            "description": "Subnet properties"
          },
          "ignoreMissingVnetServiceEndpoint": {
            "type": "boolean",
            "description": "Value that indicates whether to ignore missing VNet Service Endpoint"
          }
        },
        "description": "Description of VirtualNetworkRules - NetworkRules resource."
      }
```