<!-- region Generated -->
# Az.KubernetesConfiguration
This directory contains the PowerShell module for the KubernetesConfiguration service.

---
## Status
[![Az.KubernetesConfiguration](https://img.shields.io/powershellgallery/v/Az.KubernetesConfiguration.svg?style=flat-square&label=Az.KubernetesConfiguration "Az.KubernetesConfiguration")](https://www.powershellgallery.com/packages/Az.KubernetesConfiguration/)

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
For information on how to develop for `Az.KubernetesConfiguration`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: fa0a95854a551be7fdb04367e2e7b6500ab2e341
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/kubernetesconfiguration/resource-manager/Microsoft.KubernetesConfiguration/stable/2021-03-01/kubernetesconfiguration.json
  - $(repo)/specification/kubernetesconfiguration/resource-manager/Microsoft.KubernetesConfiguration/stable/2021-09-01/extensions.json

title: KubernetesConfiguration
module-version: 0.1.0
subject-prefix: ''

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK",
          "schema": {
            "$ref": "#/definitions/Extension"
          }
        },
        "202": {
          "description": "Request received successfully, and the resource will be updated asynchronously.",
          "schema": {
            "$ref": "#/definitions/Extension"
          }
        },
        "409": {
          "description": "Conflict",
          "x-ms-error-response": true,
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/fa0a95854a551be7fdb04367e2e7b6500ab2e341/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
          }
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/fa0a95854a551be7fdb04367e2e7b6500ab2e341/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document 
    where: $.definitions.Extension.properties.properties.properties.statuses
    transform: >-
      return {
          "description": "Status from this extension.",
          "type": "array",
          "readOnly": true,
          "x-nullable": true,
          "items": {
            "$ref": "#/definitions/ExtensionStatus"
          }
      }
  - from: swagger-document
    where: $.definitions.EnableHelmOperatorDefinition.type
    transform: return "string"
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: SourceControlConfiguration
    set:
      subject: KubernetesConfiguration
  - where:
      parameter-name: ClusterResourceName
    set:
      parameter-name: ClusterType
  - where:
      verb: New
      subject: KubernetesConfiguration
      parameter-name: HelmOperatorPropertyChartValue
    set:
      parameter-name: HelmOperatorChartValue
  - where:
      verb: New
      subject: KubernetesConfiguration
      parameter-name: HelmOperatorPropertyChartVersion
    set:
      parameter-name: HelmOperatorChartVersion
  - where:
      verb: New
      subject: KubernetesConfiguration
      parameter-name: OperatorParameters
    set:
      parameter-name: OperatorParameter
  - where:
      verb: New
      subject: KubernetesConfiguration
      parameter-name: SshKnownHostsContent
    set:
      parameter-name: SshKnownHost
  - where:
      verb: Set
      subject: KubernetesConfiguration
    set:
      verb: Update
  - where:
      subject: KubernetesConfiguration
    hide: true
  - where:
      verb: Update
      subject: KubernetesConfiguration
    remove: true
  - where:
      subject: OperationStatus
    remove: true
  - where:
      subject: ^Extension$
    set:
      subject: KubernetesExtension
  - where:
      subject: KubernetesExtension
    hide: true
  - where:
      verb: Get
      subject: KubernetesExtension
    set:
      alias: Get-AzK8sExtension
  - where:
      verb: New
      subject: KubernetesExtension
    set:
      alias: New-AzK8sExtension
  - where:
      verb: Remove
      subject: KubernetesExtension
    set:
      alias: Remove-AzK8sExtension
  - where:
      verb: Update
      subject: KubernetesExtension
    set:
      alias: Update-AzK8sExtension
  - where:
      verb: Get
      subject: KubernetesConfiguration
    set:
      alias: Get-AzK8sConfiguration
  - where:
      verb: New
      subject: KubernetesConfiguration
    set:
      alias: New-AzK8sConfiguration
  - where:
      verb: Remove
      subject: KubernetesConfiguration
    set:
      alias: Remove-AzK8sConfiguration
  - where:
      model-name: Extension
    set:
      format-table:
        properties:
          - Name
          - ExtensionType
          - Version
          - ProvisioningState
          - AutoUpgradeMinorVersion
          - ReleaseTrain
```
