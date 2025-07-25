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
commit: 526e6049f46d58a5077850731dce19ab9767988f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2022-05-01-preview/authorization-RoleDefinitionsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2022-05-01-preview/common-types.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2015-06-01/authorization-ClassicAdminCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/stable/2015-07-01/authorization-ElevateAccessCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2018-01-01-preview/authorization-ProviderOperationsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2018-07-01-preview/authorization-DenyAssignmentGetCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2019-08-01-preview/authorization-UsageMetricsCalls.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-08-01-preview/authorization-RoleAssignmentsCalls.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Authorization
```