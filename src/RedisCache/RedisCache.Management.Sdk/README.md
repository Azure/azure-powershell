# Overall
This directory contains management plane service clients of Az.RedisCache module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```



###
``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/ba1184c32a778948ea8836c9143821a874dcfcac/specification/redis/resource-manager/Microsoft.Cache/stable/2023-04-01/redis.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RedisCache
```