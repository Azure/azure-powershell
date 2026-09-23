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
```



###
``` yaml
commit: d8a796d42bbe9456e3de85c37d3e1a38f4026d01
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/devtestlabs/resource-manager/Microsoft.DevTestLab/stable/2016-05-15/DTL.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DevTestLabs

directive:
  - from: swagger-document
    where: $.parameters.resourceGroupName
    transform: >-
      return {
            "name": "resourceGroupName",
            "in": "path",
            "description": "The name of the resource group.",
            "required": true,
            "type": "string"
        }
```