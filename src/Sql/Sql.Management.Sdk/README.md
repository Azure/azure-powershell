# Overall
This directory contains the service clients of Az.Sql module.

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
title: SqlManagementClient
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: 5142fed9fc2b10464d3d45eb64edd252731974db

input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/sql/resource-manager/Microsoft.Sql/SQL/stable/2025-01-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Sql
```
