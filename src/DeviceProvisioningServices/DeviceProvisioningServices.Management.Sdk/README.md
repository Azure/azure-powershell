# Overall
This directory contains management plane service clients of Az.DeviceProvisioningServices module.

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
commit: 679887ace44697c726aba8d2814ee415a5d25e6f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/deviceprovisioningservices/resource-manager/Microsoft.Devices/stable/2017-11-15/iotdps.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DeviceProvisioningServices
```