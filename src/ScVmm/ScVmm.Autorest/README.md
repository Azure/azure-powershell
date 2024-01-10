<!-- region Generated -->
# Az.ScVmm
This directory contains the PowerShell module for the ScVmm service.

---
## Status
[![Az.ScVmm](https://img.shields.io/powershellgallery/v/Az.ScVmm.svg?style=flat-square&label=Az.ScVmm "Az.ScVmm")](https://www.powershellgallery.com/packages/Az.ScVmm/)

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
For information on how to develop for `Az.ScVmm`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: ee9e300b2bc6e68da09d6c98f321675d33ad6c5d
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/scvmm/resource-manager/Microsoft.ScVmm/stable/2023-10-07/scvmm.json

module-version: 0.3.0
title: ScVmm
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ScVmm/vmmServers/{vmmServerName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ScVmm/clouds/{cloudResourceName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ScVmm/virtualNetworks/{virtualNetworkName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ScVmm/virtualMachineTemplates/{virtualMachineTemplateName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ScVmm/availabilitySets/{availabilitySetResourceName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }

  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/stop"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/start"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/restart"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/createCheckpoint"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/deleteCheckpoint"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.ScVmm/virtualMachineInstances/default/restoreCheckpoint"].post.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ee9e300b2bc6e68da09d6c98f321675d33ad6c5d/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
          }
        }
      }

  - from: swagger-document 
    where: $.definitions.GuestCredential.properties.password
    transform: >-
      return {
        "description": "Gets or sets the password to connect with the guest.",
        "type": "string",
        "format": "password",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "x-ms-secret": true
      }
  - from: swagger-document 
    where: $.definitions.VMMCredential.properties.password
    transform: >-
      return {
        "description": "Password to use to connect to VMMServer.",
        "type": "string",
        "format": "password",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "x-ms-secret": true
      }

  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      verb: Set
    remove: true

  - where:
      subject: VirtualMachineInstance
    set:
      subject: VM
  - where:
      subject: VirtualMachineInstanceHybridIdentityMetadata
    set:
      subject: VMHybridIdentityMetadata
  - where:
      subject: VirtualMachineTemplate
    set:
      subject: VMTemplate
  - where:
      subject: VMInstanceGuestAgent
    set:
      subject: VMGuestAgent
  - where:
      subject: VirtualMachineInstanceCheckpoint
    set:
      subject: VMCheckpoint

  - where:
      verb: Update
      subject: InventoryItem
    remove: true
  - where:
      verb: Update|Remove
      subject: VMGuestAgent
    remove: true

  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - model-cmdlet:
    - model-name: AvailabilitySetListItem
    - model-name: NetworkInterfaceUpdate
    - model-name: NetworkInterface
    - model-name: VirtualDiskUpdate
    - model-name: VirtualDisk
    - model-name: Checkpoint

  - where:
      model-name: AvailabilitySet
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
  - where:
      model-name: Cloud
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Uuid
          - ProvisioningState
  - where:
      model-name: InventoryItem
    set:
      format-table:
        properties:
          - Name
          - InventoryItemName
          - InventoryType
          - ProvisioningState
  - where:
      model-name: VirtualMachineTemplate
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Uuid
          - ProvisioningState
  - where:
      model-name: VirtualNetwork
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Uuid
          - ProvisioningState
  - where:
      model-name: VmmServer
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - ProvisioningState
```
