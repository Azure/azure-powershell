# Overall
This directory contains management plane service clients of Az.CognitiveServices module.

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
commit: 399cbac2de1bc0acbed4c9a0a864a9c84da3692e
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2024-10-01/cognitiveservices.json

output-folder: Generated

namespace: Microsoft.Azure.Management.CognitiveServices
```