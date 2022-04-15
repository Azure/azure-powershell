<!-- region Generated -->
# Az.ContainerApp
This directory contains the PowerShell module for the ContainerApp service.

---
## Status
[![Az.ContainerApp](https://img.shields.io/powershellgallery/v/Az.ContainerApp.svg?style=flat-square&label=Az.ContainerApp "Az.ContainerApp")](https://www.powershellgallery.com/packages/Az.ContainerApp/)

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
For information on how to develop for `Az.ContainerApp`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: c5c5e1d0c31a0ceccda42505d6e872ff303d1c80
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/AuthConfigs.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/CommonDefinitions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ContainerApps.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ContainerAppsRevisions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/DaprComponents.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/Global.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ManagedEnvironments.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ManagedEnvironmentsStorages.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/SourceControls.json

title: ContainerApp
module-version: 0.1.0
subject-prefix: ''

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
#   - from: swagger-document 
#     where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}"].patch.responses
#     transform: >-
#       return {
#         "200": {
#           "description": "OK",
#           "schema": {
#             "$ref": "#/definitions/Extension"
#           }
#         },
#         "202": {
#           "description": "Request received successfully, and the resource will be updated asynchronously.",
#           "schema": {
#             "$ref": "#/definitions/Extension"
#           }
#         },
#         "409": {
#           "description": "Conflict",
#           "x-ms-error-response": true,
#           "schema": {
#             "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/fa0a95854a551be7fdb04367e2e7b6500ab2e341/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
#           }
#         },
#         "default": {
#           "description": "Error response describing why the operation failed.",
#           "schema": {
#             "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/fa0a95854a551be7fdb04367e2e7b6500ab2e341/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
#           }
#         }
#       }
#   - from: swagger-document 
#     where: $.definitions.Extension.properties.properties.properties.statuses
#     transform: >-
#       return {
#           "description": "Status from this extension.",
#           "type": "array",
#           "readOnly": true,
#           "x-nullable": true,
#           "items": {
#             "$ref": "#/definitions/ExtensionStatus"
#           }
#       }
#   - from: swagger-document
#     where: $.definitions.EnableHelmOperatorDefinition.type
#     transform: return "string"
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Test
    remove: true
  - where:
      subject: CustomHostNameAnalysis
    hide: true
  - where:
      verb: Initialize
      subject: AzContainerAppRevision
    set:
      verb: Enable
  - where:
      verb: Invoke
      subject: AzDeactivateContainerAppRevision
    set:
      verb: Disable
#   - where:
#       parameter-name: ClusterResourceName
#     set:
#       parameter-name: ClusterType
#   - where:
#       verb: New
#       subject: KubernetesConfiguration
#       parameter-name: HelmOperatorPropertyChartValue
#     set:
#       parameter-name: HelmOperatorChartValue
#   - where:
#       verb: New
#       subject: KubernetesConfiguration
#       parameter-name: HelmOperatorPropertyChartVersion
#     set:
#       parameter-name: HelmOperatorChartVersion
#   - where:
#       verb: New
#       subject: KubernetesConfiguration
#       parameter-name: OperatorParameters
#     set:
#       parameter-name: OperatorParameter
#   - where:
#       verb: New
#       subject: KubernetesConfiguration
#       parameter-name: SshKnownHostsContent
#     set:
#       parameter-name: SshKnownHost
#   - where:
#       subject: KubernetesConfiguration
#     hide: true
#   - where:
#       verb: Update
#       subject: KubernetesConfiguration
#     remove: true
#   - where:
#       subject: OperationStatus
#     remove: true
#   - where:
#       subject: KubernetesExtension
#     hide: true
#   - where:
#       verb: Get
#       subject: KubernetesExtension
#     set:
#       alias: Get-AzK8sExtension
#   - where:
#       verb: New
#       subject: KubernetesExtension
#     set:
#       alias: New-AzK8sExtension
#   - where:
#       verb: Remove
#       subject: KubernetesExtension
#     set:
#       alias: Remove-AzK8sExtension
#   - where:
#       verb: Update
#       subject: KubernetesExtension
#     set:
#       alias: Update-AzK8sExtension
#   - where:
#       verb: Get
#       subject: KubernetesConfiguration
#     set:
#       alias: Get-AzK8sConfiguration
#   - where:
#       verb: New
#       subject: KubernetesConfiguration
#     set:
#       alias: New-AzK8sConfiguration
#   - where:
#       verb: Remove
#       subject: KubernetesConfiguration
#     set:
#       alias: Remove-AzK8sConfiguration
#   - where:
#       model-name: Extension
#     set:
#       format-table:
#         properties:
#           - Name
#           - ExtensionType
#           - Version
#           - ProvisioningState
#           - AutoUpgradeMinorVersion
#           - ReleaseTrain
```
