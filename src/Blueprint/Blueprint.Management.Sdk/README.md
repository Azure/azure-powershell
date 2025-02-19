# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
# csharp: true
title: BlueprintManagementClient
reflect-api-versions: true
openapi-type: arm
azure-arm: true
payload-flattening-threshold: 1
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
```



###
``` yaml
commit: 94e82241deb262a5bd60added152f5c9175fdd82
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/blueprint/resource-manager/Microsoft.Blueprint/preview/2018-11-01-preview/blueprintDefinition.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/blueprint/resource-manager/Microsoft.Blueprint/preview/2018-11-01-preview/blueprintAssignment.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/blueprint/resource-manager/Microsoft.Blueprint/preview/2018-11-01-preview/assignmentOperation.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Blueprint

directive:
  - from: blueprintAssignment.json
    suppress: TrackedResourcePatchOperation 
    reason: Assignment is proxy resource.
  - from: blueprintDefinition.json
    suppress: UniqueResourcePaths
    where: $.paths
    reason: Microsoft.Management is a proxy resource provider
  - from: blueprintAssignment.json
    suppress: OperationsAPIImplementation
    where: $.paths
    reason: OperationsAPI for Microsoft.Management is out of scope.
  - from: blueprintDefinition.json
    suppress: OperationsAPIImplementation
    where: $.paths
    reason: OperationsAPI for Microsoft.Management is out of scope.
  - from: assignmentOperation.json
    suppress: OperationsAPIImplementation
    where: $.paths
    reason: OperationsAPI for Microsoft.Management is out of scope.
  - from: blueprintAssignment.json
    where: $.paths["/{resourceScope}/providers/Microsoft.Blueprint/blueprintAssignments/{assignmentName}"].delete.parameters
    transform: >-
      return [
          {
            "$ref": "#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "#/parameters/ScopeParameter"
          },
          {
            "$ref": "#/parameters/AssignmentNameParameter"
          },
          {
            "name": "deleteBehavior",
            "in": "query",
            "required": false,
            "type": "string",
            "enum": [
              "none",
              "all"
            ],
            "x-ms-enum": {
              "name": "AssignmentDeleteBehavior",
              "modelAsString": true
            },
            "description": "When deleteBehavior=all, the resources that were created by the blueprint assignment will be deleted."
          }
        ]
  - from: blueprintAssignment.json
    where: $.definitions.BlueprintResourcePropertiesBase.x-ms-external
    transform: >-
      return false
  - where:
      model-name: Blueprint
    set:
      model-name: BlueprintModel
```