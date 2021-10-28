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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

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
require:
  - $(this-folder)/../readme.azure.noprofile.md
module-version: 0.4.0
title: ConnectedMachine
subject-prefix: 'Connected'
input-file:
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2021-05-20/HybridCompute.json
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2021-05-20/privateLinkScopes.json

branch: 3d3c5dda9043e697cbdbb4b3264123b5e39470fd
directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/upgradeExtensions"].post.responses
    transform: >-
      return {
          "200": {
            "description": "OK"
          },
          "202": {
            "description": "HTTP 202 (Accepted) if the operation was successfully started and will complete asynchronously."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/3d3c5dda9043e697cbdbb4b3264123b5e39470fd/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
            }
          }
        }
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019

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
          "description": "Json formatted public settings for the extension."
        },
        "protectedSettings": {
          "type": "object",
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
          "description": "Json formatted public settings for the extension."
        },
        "protectedSettings": {
          "type": "object",
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
      
  # GetViaIdentity isn't useful until Azure PowerShell supports piping of different subjects
  - where:
      verb: Get
      variant: ^GetViaIdentity\d?$
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

  # Formatting
  - where:
       model-name: Machine
    set:
      format-table:
        properties:
          - Name
          - Location
          - OSName
          - Status
          - ProvisioningState
  - where:
       model-name: MachineExtension
    set:
      format-table:
        properties:
          - Name
          - Location
          - PropertiesType
          - ProvisioningState
  - where:
       model-name: HybridComputePrivateLinkScope
    set:
      format-table:
        properties:
          - Name
          - Location
          - PublicNetworkAccess
          - ProvisioningState
          - Tag

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
  - remove-operation:
    - Machines_Reconnect
    - Machines_CreateOrUpdate
    - Machines_Update
```
