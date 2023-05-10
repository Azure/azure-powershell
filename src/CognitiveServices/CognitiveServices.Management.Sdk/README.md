# Overall
This directory contains management plane service clients of Az.CognitiveServices module.

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
  - https://github.com/Azure/azure-rest-api-specs/blob/fd296f4cbe90e46098824e020e4a02517d56fc35/specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2022-12-01/cognitiveservices.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CognitiveServices
```