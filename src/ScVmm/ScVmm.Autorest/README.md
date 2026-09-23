<!-- region Generated -->
# Az.ScVmm
This directory contains the PowerShell module for the ScVmm service.

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
For information on how to develop for `Az.ScVmm`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 5c9d5f957d76d9fea9c513f494660c6c5d3e809a
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/scvmm/resource-manager/Microsoft.ScVmm/stable/2023-10-07/scvmm.json
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2024-07-10/HybridCompute.json

module-version: 0.1.0
title: ScVmm
subject-prefix: $(service-name)

disable-transform-identity-type-for-operation:
  - Machines_Update

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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5c9d5f957d76d9fea9c513f494660c6c5d3e809a/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
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
  - from: swagger-document 
    where: $.definitions.OsProfileForVMInstance.properties.adminPassword
    transform: >-
      return {
        "description": "Admin password of the virtual machine.",
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

  # In "Microsoft.HybridCompute/stable/2024-07-10/HybridCompute.json" service team just to use "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}" and "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/extensions/{extensionName}", so remove other subjects.
  - where:
      subject: MachinePatch|AssessMachinePatch|Gateway|License|LicenseProfile|MachineRunCommand|AgentVersion|ExtensionMetadata|HybridIdentityMetadata|NetworkProfile|Setting
    remove: true
  - where:
      subject: Machine
    hide: true
  - where:
      subject: MachineExtension
    set:
      subject: VMExtension
  - where:
      subject: VMExtension
    hide: true
  - where:
      subject: Extension
    hide: true

  - where:
      subject: VirtualMachineInstance
    set:
      subject: VM
  - where:
      subject: VM
    hide: true

  - where:
      subject: VMInstanceHybridIdentityMetadata
    set:
      subject: VMHybridIdentityMetadata
  - where:
      subject: VirtualMachineTemplate
    set:
      subject: VMTemplate
  - where:
      subject: GuestAgent
    set:
      subject: VMGuestAgent
  - where:
      subject: VirtualMachineInstanceCheckpoint
    set:
      subject: VMCheckpoint

  - where:
      verb: New|Update|Remove
      subject: InventoryItem
    remove: true
  - where:
      verb: Update|Remove
      subject: VMGuestAgent
    remove: true
  - where:
      verb: Get|New
      subject: VMGuestAgent
    hide: true
  - where:
      subject: VMCheckpoint
    hide: true
  - where:
      verb: New
      subject: VMTemplate|Server|Cloud|VirtualNetwork|AvailabilitySet
    hide: true

  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      parameter-name: ResourceUri
    set:
      parameter-name: MachineId

  - model-cmdlet:
    - model-name: NetworkInterfaceUpdate
    - model-name: NetworkInterface
    - model-name: VirtualDiskUpdate
    - model-name: VirtualDisk

  - where:
      model-name: VirtualDisk
      property-name: StorageQoPolicyName
    set:
      property-name: StorageQoSPolicyName
  - where:
      model-name: VirtualDiskUpdate
      property-name: StorageQoPolicyName
    set:
      property-name: StorageQoSPolicyName
  
  - where:
      model-name: VirtualDisk
      property-name: StorageQoPolicyId
    set:
      property-name: StorageQoSPolicyId

  - where:
      model-name: VirtualDiskUpdate
      property-name: StorageQoPolicyId
    set:
      property-name: StorageQoSPolicyId

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
  - where:
      model-name: MachineExtension
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - ProvisioningState
```
