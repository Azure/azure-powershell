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
title: IotHubClient
openapi-type: arm
useDateTimeOffset: true
clear-output-folder: true
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
commit: 9c0c34231a47458101c2867111b61e183dfba84f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/iothub/resource-manager/Microsoft.Devices/stable/2021-07-02/iothub.json

output-folder: Generated

namespace: Microsoft.Azure.Management.IotHub

```