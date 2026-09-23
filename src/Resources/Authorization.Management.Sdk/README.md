# Overall
This directory contains management plane service clients of Az.Resources module.

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
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```

###
``` yaml
commit: 31fb4b3e5acb94b16df4a9e6b513057280bd5678
# Updated 2026-03-29: Swagger PR #41104 merged. Commit hash updated to merge commit.
# Path structure changed: specs moved under /Authorization/ subfolder.
# DenyAssignmentGetCalls (2018-07-01-preview, GET-only) replaced with DenyAssignmentCalls (2024-07-01-preview, full CRUD).
# ClassicAdminCalls moved from preview/2015-06-01 to stable/2015-06-01.
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2022-05-01-preview/authorization-RoleDefinitionsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2022-05-01-preview/common-types.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/stable/2015-06-01/authorization-ClassicAdminCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/stable/2015-07-01/authorization-ElevateAccessCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2018-01-01-preview/authorization-ProviderOperationsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2024-07-01-preview/authorization-DenyAssignmentCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2019-08-01-preview/authorization-UsageMetricsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/Authorization/preview/2020-08-01-preview/authorization-RoleAssignmentsCalls.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Authorization
```