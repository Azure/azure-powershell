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
commit: ba1884683c35d1ea63d229a7106f207e507c3861
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2023-05-01/cognitiveservices.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CognitiveServices
```