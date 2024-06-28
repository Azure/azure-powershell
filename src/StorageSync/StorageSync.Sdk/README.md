# Overall
This directory contains management plane service clients of Az.StorageSync module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
autorest.cmd README.md --version=v2
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
commit: 9ec0fcc278aa2128c4fbb2b8a1aa93432d72cce0
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storagesync/resource-manager/Microsoft.StorageSync/stable/2022-09-01/storagesync.json

output-folder: Generated

namespace: Microsoft.Azure.Management.StorageSync
```