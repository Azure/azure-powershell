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
commit: bce3a8d1141c8c6df26d17c94b0f5437f214141f
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2023-10-01-preview/devbox.json
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2023-10-01-preview/devcenter.json
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2023-10-01-preview/environments.json
title: DevCenterdata
subject-prefix: DevCenter
endpoint-resource-id-key-name: https://devcenter.azure.com
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}"].delete.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:start"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:stop"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:restart"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where: $.paths["/projects/{projectName}/users/{userId}/devboxes/{devBoxName}:repair"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
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
        "schema": {"$ref": "devcenter.json#/definitions/OperationStatus"}
      }
  - from: swagger-document
    where-operation: Environments_PatchEnvironment
    transform: >
      $['parameters'] = [
          {
            "$ref": "devcenter.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "devcenter.json#/parameters/ProjectNameParameter"
          },
          {
            "$ref": "devcenter.json#/parameters/UserIdParameter"
          },
          {
            "$ref": "#/parameters/EnvironmentNameParameter"
          },
          {
            "name": "body",
            "in": "body",
            "description": "Updatable environment properties.",
            "required": true,
            "schema": {
              "$ref": "#/definitions/EnvironmentPatchProperties"
            }
          }
      ]
  - from: swagger-document
    where: $.paths["/devboxes"].get.operationId
    transform: return "DevBoxes_ListAllDevBoxes"
  - from: swagger-document
    where: $.paths["/users/{userId}/devboxes"].get.operationId
    transform: return "DevBoxes_ListAllDevBoxesByUser"
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
      verb: ^(?!Get$)
      subject: ^(DevBox|Environment)$
      parameter-name: UserId
    set:
      default:
        script: '"me"'
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
      verb: New
      variant: ^Create$|^CreateViaIdentity$
    remove: true
  - from: swagger-document
    where: $.definitions.EnvironmentUpdateProperties.properties.parameters
    transform: $["additionalProperties"] = true
  - where:
      subject: ^(.*)
    hide: true
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterUser
```
