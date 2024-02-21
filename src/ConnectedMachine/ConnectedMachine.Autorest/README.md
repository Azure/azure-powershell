<!-- region Generated -->
# Az.ConnectedMachine
This directory contains the PowerShell module for the ConnectedMachine service.

---
## Status
[![Az.ConnectedMachine](https://img.shields.io/powershellgallery/v/Az.ConnectedMachine.svg?style=flat-square&label=Az.ConnectedMachine "Az.ConnectedMachine")](https://www.powershellgallery.com/packages/Az.ConnectedMachine/)

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
For information on how to develop for `Az.ConnectedMachine`, see [how-to.md](how-to.md).
<!-- endregion -->

 
<!-- region Generated -->
# Az.ConnectedMachine
This directory contains the PowerShell module for Hybrid Compute.
 
---
## Run Generation
In this directory, run AutoRest:
> `autorest`
 
---
### AutoRest Configuration
> see https://aka.ms/autorest
 
``` yaml
commit: 2d044b8a317aff46d45080f5a797ac376955f648
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2023-10-03-preview/HybridCompute.json
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2023-10-03-preview/privateLinkScopes.json
 
module-version: 0.5.0
title: ConnectedMachine
subject-prefix: 'Connected'

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}"].get.parameters
    transform: >-
      return [
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "name": "machineName",
            "in": "path",
            "required": true,
            "type": "string",
            "pattern": "^[a-zA-Z0-9-_\\.]{1,54}$",
            "minLength": 1,
            "maxLength": 54,
            "description": "The name of the hybrid machine."
          },
          {
            "name": "$expand",
            "in": "query",
            "required": false,
            "type": "string",
            "description": "The expand expression to apply on the operation.",
          }
        ]
 
  - from: swagger-document
    where: $.definitions.Machine.properties.properties
    transform: >-
      return {
          "x-ms-client-flatten": true,
          "$ref": "#/definitions/MachineProperties",
          "description": "Hybrid Compute Machine properties"
        }
 
  - from: swagger-document
    where: $.definitions.MachineExtensionUpdateProperties.properties
    transform: >-
      return {
        "forceUpdateTag": {
          "type": "string",
          "description": "How the extension handler should be forced to update even if the extension configuration has not changed."
        },
        "publisher": {
          "type": "string",
          "description": "The name of the extension handler publisher."
        },
        "type": {
          "type": "string",
          "description": "Specifies the type of the extension; an example is \"CustomScriptExtension\"."
        },
        "typeHandlerVersion": {
          "type": "string",
          "description": "Specifies the version of the script handler."
        },
        "enableAutomaticUpgrade": {
          "type": "boolean",
          "description": "Indicates whether the extension should be automatically upgraded by the platform if there is a newer version available."
        },
        "autoUpgradeMinorVersion": {
          "type": "boolean",
          "description": "Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true."
        },
        "settings": {
          "type": "object",
          "additionalProperties": true,
          "description": "Json formatted public settings for the extension."
        },
        "protectedSettings": {
          "type": "object",
          "additionalProperties": true,
          "description": "The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all."
        }
      }
  - from: swagger-document
    where: $.definitions.MachineExtensionProperties.properties
    transform: >-
      return {
        "forceUpdateTag": {
          "type": "string",
          "description": "How the extension handler should be forced to update even if the extension configuration has not changed."
        },
        "publisher": {
          "type": "string",
          "description": "The name of the extension handler publisher."
        },
        "type": {
          "type": "string",
          "description": "Specifies the type of the extension; an example is \"CustomScriptExtension\"."
        },
        "typeHandlerVersion": {
          "type": "string",
          "description": "Specifies the version of the script handler."
        },
        "enableAutomaticUpgrade": {
          "type": "boolean",
          "description": "Indicates whether the extension should be automatically upgraded by the platform if there is a newer version available."
        },
        "autoUpgradeMinorVersion": {
          "type": "boolean",
          "description": "Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true."
        },
        "settings": {
          "type": "object",
          "additionalProperties": true,
          "description": "Json formatted public settings for the extension."
        },
        "protectedSettings": {
          "type": "object",
          "additionalProperties": true,
          "description": "The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all."
        },
        "provisioningState": {
          "readOnly": true,
          "type": "string",
          "description": "The provisioning state, which only appears in the response."
        },
        "instanceView": {
          "$ref": "#/definitions/MachineExtensionInstanceView",
          "description": "The machine extension instance view."
        }
      }
  # add 200 response to run-command delete 
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/runCommands/{runCommandName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK"
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "description": "The URL of the resource used to check the status of the asynchronous operation.",
              "type": "string"
            },
            "Retry-After": {
              "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
              "type": "integer",
              "format": "int32"
            },
            "Azure-AsyncOperation": {
              "description": "The URI to poll for completion status.",
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
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/2d044b8a317aff46d45080f5a797ac376955f648/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
          }
        }
      }

  # GetViaIdentity isn't useful until Azure PowerShell supports piping of different subjects
  - where:
      verb: Get
      variant: ^GetViaIdentity.*$
    remove: true

  # Make parameters friendlier for extensions
  - where:
      subject: MachineExtension
      parameter-name: Name
    set:
      parameter-name: MachineName
  - where:
      subject: MachineExtension
      parameter-name: ExtensionName
    set:
      parameter-name: Name
  - where:
      subject: MachineExtension
      parameter-name: PropertiesType
    set:
      parameter-name: ExtensionType
  - where:
      model-name: MachineExtension
      property-name: PropertiesType
    set:
      property-name: MachineExtensionType
  - where:
      subject: MachineExtension
      parameter-name: Setting
    set:
      alias: Settings
  - where:
      subject: MachineExtension
      parameter-name: ProtectedSetting
    set:
      alias: ProtectedSettings
  - where:
      subject: MachineExtension
      parameter-name: ForceUpdateTag
    set:
      parameter-name: ForceRerun
  - where:
      subject: Machine
      parameter-name: AgentUpgradeEnableAutomaticUpgrade
    set:
      parameter-name: AgentUpgradeEnableAutomatic
    
  # Rename Tag to Tags
  - where:
      property-name: Tag
    set:
      property-name: Tags
 
  # Formatting
  - where:
       model-name: Machine
    set:
      format-table:
        properties:
          - ResourceGroupName
          - Name
          - Location
          - OSType
          - Status
          - ProvisioningState
  - where:
       model-name: MachineExtension
    set:
      format-table:
        properties:
          - ResourceGroupName
          - Name
          - Location
          - TypeHandlerVersion
          - ProvisioningState
          - Publisher
  - where:
       model-name: HybridComputePrivateLinkScope
    set:
      format-table:
        properties:
          - ResourceGroupName
          - Name
          - Location
          - PublicNetworkAccess
          - ProvisioningState
 
  # Removing cmlets
  - where:
      subject: PrivateEndpointConnection
    remove: true
  - where:
      subject: PrivateLinkResource
    remove: true
  - where:
      verb: Get
      subject: PrivateLinkScopeValidationDetail
    remove: true
  - where:
      subject: NetworkProfile
    remove: true
  - where:
      subject: AgentVersion
    remove: true
  - where:
      subject: HybridIdentityMetadata
    remove: true
  - where:
      subject: MachineRunCommand
      verb: Set
    remove: true

  # add back when swagger change is checked in
  - where:
      subject: License
    remove: true
  - where:
      subject: LicenseProfile
    remove: true
  - where:
      subject: NetworkConfiguration
    remove: true
  - where:
      subject: NetworkSecurityPerimeterConfiguration$
    remove: true
 
  # Removing non-expand commands
  - where:
      subject: MachinePatch
      variant: ^(Install)(?!.*?Expanded|JsonFilePath|JsonString)
    remove: true
 
  # Completers
  - where:
      parameter-name: Location
    set:
      completer:
        name: Location Completer
        description: Gets the list of locations available for this resource.
        script: Get-AzLocation | Where-Object Providers -Contains "Microsoft.HybridCompute" | Select-Object -ExpandProperty Location
  - where:
      parameter-name: ResourceGroupName
    set:
      completer:
        name: ResourceGroupName Completer
        description: Gets the list of ResourceGroupName's available for this subscription.
        script: Get-AzResourceGroup | Select-Object -ExpandProperty ResourceGroupName
 
  # These APIs are used by the agent so they do not need to be in the cmdlets.
  - remove-operation: Machines_CreateOrUpdate
  - remove-operation: MachineRunCommands_Update
```
