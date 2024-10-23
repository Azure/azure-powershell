# Overall
This directory contains management plane service clients of Az.IotCentral module.

## Run Generation
In this directory, run AutoRest:
```
rm -r Generated/*
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
commit: aac5247b6299f15c9d9f5c1dd802c6d4f528953d
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/iotcentral/resource-manager/Microsoft.IoTCentral/stable/2021-06-01/iotcentral.json

output-folder: Generated

namespace: Microsoft.Azure.Management.IotCentral

directive:
  - suppress: R4009
    from: iotcentral.json
    reason: We do not yet support systemdata.
  - suppress: R3018
    from: iotcentral.json
    reason: resource name availability needs to be boolean (available or not)
  - suppress: R4018
    from: iotcentral.json
    reason: We do not yet support isDataAction, display.description and display.resource.
```