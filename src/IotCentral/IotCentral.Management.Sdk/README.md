# Overall
This directory contains management plane service clients of Az.IotCentral module.

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
title: IotCentralClient
openapi-type: arm
useDateTimeOffset: true
clear-output-folder: true
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
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