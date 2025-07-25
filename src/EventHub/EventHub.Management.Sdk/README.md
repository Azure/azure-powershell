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
commit: 805e16a53f0a725471e0caa6007b48986c7722d9
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/AvailableClusterRegions-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/Clusters-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/namespaces-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/quotaConfiguration-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/networkrulessets-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/CheckNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/consumergroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/disasterRecoveryConfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/eventhubs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/SchemaRegistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-01-01-preview/ApplicationGroups.json

output-folder: Generated

namespace: Microsoft.Azure.Management.EventHub

directive:
  - suppress: R4007
    reason: DefaultErrorResponseSchema - we will be Implementing in new API version
# Remove "x-ms-client-flatten": true
  - from: swagger-document
    where: $.definitions.Encryption
    transform: >-
      return {
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
                    "modelAsString": false
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
                "type": "string",
                "description": "Type of managed service identity.",
                "enum": [
                    "SystemAssigned",
                    "UserAssigned",
                    "SystemAssigned, UserAssigned",
                    "None"
                ],
                "x-ms-enum": {
                    "name": "ManagedServiceIdentityType",
                    "modelAsString": false
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
        "description": "Properties to configure Identity for Bring your Own Keys"
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
                }
            }
        },
        "description": "The response from the List namespace operation."
      }
  - from: swagger-document
    where: $.definitions.NWRuleSetVirtualNetworkRules
    transform: >-
      return {
        "properties": {
            "subnet": {
                "$ref": "#/definitions/Subnet",
                "description": "Subnet properties"
            },
            "ignoreMissingVnetServiceEndpoint": {
                "type": "boolean",
                "description": "Value that indicates whether to ignore missing Vnet Service Endpoint"
            }
        },
        "description": "The response from the List namespace operation."
      }
```