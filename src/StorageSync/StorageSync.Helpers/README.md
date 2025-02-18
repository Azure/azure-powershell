# Overall
This directory contains the service clients of other services for Azure PowerShell StorageSync module.

## Run Generation
In this directory, run AutoRest:
```
autorest --use:@autorest/powershell@4.x --tag=authorization
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

### Tag: authorization
``` yaml $(tag) == 'authorization'
commit: 61e7148e9592c5efc95e5c16a5bb4f2dc26d6de0
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2018-01-01-preview/authorization-RoleDefinitionsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-08-01-preview/authorization-RoleAssignmentsCalls.json

output-folder: Authorization

namespace: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Helper.Authorization

directive:
  - remove-operation:
    - Permissions_ListForResourceGroup
    - Permissions_ListForResource
    - RoleDefinitions_Delete
    - RoleDefinitions_CreateOrUpdate
    - RoleDefinitions_List
    - RoleAssignments_ListForSubscription
    - RoleAssignments_ListForResourceGroup
    - RoleAssignments_Get
    - RoleAssignments_Validate
    - RoleAssignments_ListForScope
    - RoleAssignments_GetById
    - RoleAssignments_CreateById
    - RoleAssignments_DeleteById
    - RoleAssignments_ValidateById
  - remove-model:
    - PermissionGetResult
    - ValidationResponseErrorInfo
    - ValidationResponse
    - RoleDefinitionListResult
```
