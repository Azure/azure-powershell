<!-- region Generated -->
# Az.DevCenterdata
This directory contains the PowerShell module for the DevCenterdata service.

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
For information on how to develop for `Az.DevCenterdata`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 82e9c6f9fbfa2d6d47d5e2a6a11c0ad2eb345c43
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2025-04-01-preview/devcenter.json
title: DevCenterdata
subject-prefix: DevCenter
root-module-name: $(prefix).DevCenter
endpoint-resource-id-key-name: https://devcenter.azure.com
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - no-inline:
    - AzureCoreFoundationsInnerError
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:start"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:stop"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:restart"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:repair"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:align"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:approve"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}/addons/{addOnName}:disable"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}/addons/{addOnName}:enable"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}/addons/{addOnName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:restoreSnapshot"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:captureSnapshot"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/environments/{environmentName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Environment"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/environments/{environmentName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}"].get.operationId
    transform: >-
      return "Projects_Get"
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/abilities"].get.operationId
    transform: >-
      return "Projects_GetAbilities"
  - from: swagger-document
    where: $.paths["/projects"].get.operationId
    transform: >-
      return "Projects_List"
  - from: swagger-document
    where: $.paths["/projects/{projectName}/environmentTypes/{environmentTypeName}"].get.operationId
    transform: >-
      return "EnvironmentTypes_Get"
  - from: swagger-document
    where: $.paths["/projects/{projectName}/environmentTypes/{environmentTypeName}/users/{userId}/abilities"].get.operationId
    transform: >-
      return "EnvironmentTypes_GetAbilities"
  - from: swagger-document
    where: $.paths["/projects/{projectName}/environmentTypes"].get.operationId
    transform: >-
      return "EnvironmentTypes_List"
  - where:
      subject: ^(.*)(DevBoxPool)(.*)$
    set:
      subject: Pool
  - where:
      subject: ^(.*)(DevBoxSchedule)(.*)$
    set:
      subject: Schedule
  - where:
      subject: ^(.*)(DevCenterProject)(.*)$
    set:
      subject: Project
  - where:
      subject: ^(.*)(EnvironmentCatalog)(.*)$
    set:
      subject: Catalog
# Matches any subject that is not strictly "DevBox" or "Environment" (eg. still includes DevBoxAction)
  - where:
      subject: ^(?!DevBox$|Environment$).*
      parameter-name: UserId
    set:
      default:
        script: '"me"'
# Matches cmdlets with exact subject DevBox or Environment, but not with verb Get
  - where:
      verb: ^(?!Get$|Approve$)
      subject: ^(DevBox|Environment)$
      parameter-name: UserId
    set:
      default:
        script: '"me"'
  - where:
      verb: Invoke
      subject: Pool
    set:
      subject: AlignPool
  - where:
      parameter-name: Top
    hide: true
  - where:
      parameter-name: Filter
    hide: true
  - where:
      parameter-name: ActionName
    set:
      parameter-name: Name
      alias: ActionName
  - where:
      verb: New|Test
      variant: ^Create$|^CreateViaIdentity$|^Validate$|^ValidateViaIdentity$
    remove: true
  - where:
      subject: ^(.*)
    hide: true
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterUser
```
