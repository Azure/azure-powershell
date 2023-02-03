# Overall
This directory contains management plane service clients of Az.Resources module.

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
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/71121282e39bccae590462648e77bca283df6d2b/specification/resources/resource-manager/Microsoft.Resources/stable/2022-09-01/resources.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Resources
```