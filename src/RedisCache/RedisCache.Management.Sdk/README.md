# Overall
This directory contains management plane service clients of Az.RedisCache module.

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
commit: e9029be51f26b9566d03fb8f3f84ea8d66bdc46f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/redis/resource-manager/Microsoft.Cache/stable/2023-04-01/redis.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RedisCache
```
