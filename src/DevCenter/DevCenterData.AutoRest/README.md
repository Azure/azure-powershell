<!-- region Generated -->
# Az.DevCenterdata
This directory contains the PowerShell module for the DevCenterdata service.

---
## Status
[![Az.DevCenterdata](https://img.shields.io/powershellgallery/v/Az.DevCenterdata.svg?style=flat-square&label=Az.DevCenterdata "Az.DevCenterdata")](https://www.powershellgallery.com/packages/Az.DevCenterdata/)

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
branch: 4f6418dca8c15697489bbe6f855558bb79ca5bf5
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/devbox.json
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/devcenter.json
  - $(repo)/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/environments.json
title: DevCenterdata
subject-prefix: DevCenter
endpoint-resource-id-key-name: https://devcenter.azure.com
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
