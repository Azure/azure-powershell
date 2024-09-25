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
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```



###
``` yaml
commit: 09c187c9589a143a477ed02c6639e914a4818179
input-file:
  - D:\code\swagger\specification\storage\resource-manager\Microsoft.Storage\stable\2024-01-01\file.json
  - D:\code\swagger\specification\storage\resource-manager\Microsoft.Storage\stable\2024-01-01\storage.json
  - D:\code\swagger\specification\storage\resource-manager\Microsoft.Storage\stable\2024-01-01\blob.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage
```