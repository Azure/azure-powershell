# Overall
This directory contains management plane service clients of Az.StorageSync module.

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
title : StorageSyncManagementClient
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
```



###
``` yaml
commit: 4a8dd2ded232e5b3e16f0428a0a23532688f522c
input-file:
  - https://github.com/ankushbindlish2/azure-rest-api-specs/blob/$(commit)/specification/storagesync/resource-manager/Microsoft.StorageSync/StorageSync/stable/2025-12-01/storagesync.json
  
output-folder: Generated

namespace: Microsoft.Azure.Management.StorageSync
```