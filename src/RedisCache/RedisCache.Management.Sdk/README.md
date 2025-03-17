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
commit: ada2aba3ac674ba632c07571421d64484230289a
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/redis/resource-manager/Microsoft.Cache/stable/2024-11-01/redis.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RedisCache

directive:
  - from: swagger-document 
    where: $.definitions.RedisCacheAccessPolicyAssignmentProperties.properties.accessPolicyName
    transform: >-
      return {
        "type": "string",
        "description": "The name of the access policy that is being assigned",
        "pattern": "^([a-zA-Z0-9][a-zA-Z0-9- ]*[a-zA-Z0-9]|[a-zA-Z0-9])$"
      }

  - from: swagger-document
    where: $.parameters.AccessPolicyNameParameter
    transform: >-
      return {
        "name": "accessPolicyName",
        "in": "path",
        "required": true,
        "type": "string",
        "description": "The name of the access policy that is being added to the Redis cache.",
        "x-ms-parameter-location": "method",
        "pattern": "^([a-zA-Z0-9][a-zA-Z0-9- ]*[a-zA-Z0-9]|[a-zA-Z0-9])$",
        "minLength": 3,
        "maxLength": 63
      }
```
