# Overall
This directory contains management plane service clients of Az.NotificationHubs module.

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
```

###
``` yaml
commit: d2bb2feadd0deb1c7212706aa65cab2f56adccc7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/notificationhubs/resource-manager/Microsoft.NotificationHubs/stable/2017-04-01/notificationhubs.json

output-folder: Generated

namespace: Microsoft.Azure.Management.NotificationHubs
```