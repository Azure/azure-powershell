# Overall
This directory contains management plane service clients of Az.DeviceProvisioningServices module.

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
title: IotDpsClient
openapi-type: arm
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
useDateTimeOffset: true
```

###
``` yaml
commit: d390062ed96aa6478741b5f5196039540cb90d65
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/deviceprovisioningservices/resource-manager/Microsoft.Devices/stable/2017-11-15/iotdps.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DeviceProvisioningServices

directive:
  - from: swagger-document
    where: $
    transform: return $.replace(/SharedAccessSignatureAuthorizationRule\[AccessRightsDescription\]/g, 'SharedAccessSignatureAuthorizationRuleAccessRightsDescription')
```