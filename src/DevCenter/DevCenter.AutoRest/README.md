<!-- region Generated -->
# Az.DevCenter
This directory contains the PowerShell module for the DevCenter service.

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
For information on how to develop for `Az.DevCenter`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 490e7fec728b018ff3ab103a6e1cb09644452ccf
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2024-05-01-preview/commonDefinitions.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2024-05-01-preview/devcenter.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2024-05-01-preview/vdi.json
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/sync"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. Successfully initiated sync."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/sync"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. Successfully initiated sync."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/connect"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/connect"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/galleries/{galleryName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Gallery"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks/{attachedNetworkConnectionName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/AttachedNetworkConnection"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Catalog"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Catalog"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/environmentDefinitions/{environmentDefinitionName}"].get.operationId
    transform: >-
      return "ProjectEnvironmentDefinitions_Get"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/environmentDefinitions"].get.operationId
    transform: >-
      return "ProjectEnvironmentDefinitions_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/environmentDefinitions/{environmentDefinitionName}/getErrorDetails"].post.operationId
    transform: >-
      return "ProjectEnvironmentDefinitions_GetErrorDetails"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks/{attachedNetworkConnectionName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/galleries/{galleryName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/networkConnections/{networkConnectionName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}/schedules/{scheduleName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/plans/{planName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/plans/{planName}/members/{memberName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/networkConnections/{networkConnectionName}/runHealthChecks"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}/runHealthChecks"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded."
      }
  #Use v3 for OperationStatus, remove this for breaking change version
  - from: swagger-document
    where: $.definitions
    transform: >
      $['OperationStatus'] = {
        "description": "The current status of an async operation",
        "type": "object",
        "allOf": [
          {
          "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/490e7fec728b018ff3ab103a6e1cb09644452ccf/specification/common-types/resource-management/v3/types.json#/definitions/OperationStatusResult"
          }
        ],
        "properties": {
          "resourceId": {
            "description": "The id of the resource.",
            "type": "string",
            "readOnly": true
          },
          "properties": {
            "description": "Custom operation properties, populated only for a successful operation.",
            "type": "object",
            "readOnly": true
          }
        }
      }
  - where:
      verb: Get
      subject: OperationStatus
    set:
      breaking-change:
        deprecated-cmdlet-output-type: OperationStatus
        replacement-cmdlet-output-type: OperationStatus
        deprecated-output-properties:
          - ResourceId
        change-description: The element type for property 'ResourceId' has been removed.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.0.0
        change-effective-date: 2024/11/19
  - where:
      parameter-name: Top
    hide: true
  - where:
      parameter-name: Filter
    hide: true
  - where:
      subject: Schedule
      parameter-name: Frequency
    hide: true
    set:
      default:
        script: '"Daily"'
  - where:
      subject: Schedule
      parameter-name: PropertiesType
    hide: true
    set:
      default:
        script: '"StopDevBox"'
  - where:
      subject: Schedule
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'
  - where:
      subject: Schedule
    hide: true
  - where:
      subject: Pool
      parameter-name: LicenseType
    hide: true
    set:
      default:
        script: '"Windows_Client"'
  - where:
      verb: New
      subject: Pool
      parameter-name: LicenseType
    hide: true
    set:
      default:
        script: '"Windows_Client"'
  - where:
      subject: DevCenter
      parameter-name: CustomerManagedKeyEncryptionKeyUrl
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityDelegatedIdentityClientId
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityType
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityUserAssignedIdentityResourceId
    hide: true
# Remove Set per design review
  - where:
      verb: Set
    remove: true
# Remove extra input object variant 
  - where:
      verb: Get 
      subject:  ^(AttachedNetwork|DevBoxDefinition|NetworkConnectionHealthDetail)$
      variant: GetViaIdentity1
    remove: true
  - where:
      verb: Get 
      subject:  NetworkConnectionHealthDetail
      variant: Get
    remove: true
# Matches any verb that is set
  - where:
      verb: Set
    hide: true
# Hide schedule commands
  - where:
      subject: Schedule
    hide: true
# Remove body variant
  - where:
      verb: Update
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$
    remove: true
  - where:
      verb: Invoke
      subject: ExecuteCheckNameAvailability
      variant: ^Execute$|^ExecuteViaIdentity$
    remove: true
  - where:
      verb: Invoke
      subject: ExecuteCheckScopedNameAvailability
      variant: ^Execute$|^ExecuteViaIdentity$
    remove: true
# Set required parameters    
  - where:
      verb: New
      subject:  AttachedNetwork
      parameter-name: NetworkConnectionId
    required: true
# Remove parameter
  - where:
      verb: Update
      parameter-name: Location
    hide: true
  - where:
      verb: Update
      subject: Project
      parameter-name: DevCenterId
    hide: true
  - where:
      verb: New
      subject: ^AttachedNetwork$|^Catalog$|^DevBoxDefinition$|^Gallery$|^NetworkConnection$|^Pool$|^Project$|^ProjectEnvironmentType$|^ProjectCatalog$|^Plan$|^PlanMember$
    hide: true
  - where:
      subject: ^CatalogDevBoxDefinition$|^CatalogDevBoxDefinitionErrorDetail$|^EncryptionSet$
    hide: true
  - where:
      subject: OperationStatuses
    set:
      subject: OperationStatus
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterAdmin
```
