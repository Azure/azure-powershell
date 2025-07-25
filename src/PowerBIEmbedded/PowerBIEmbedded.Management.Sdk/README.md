# Overall
This directory contains PowerBI Embedded management plane service clients of Az.PowerBIEmbedded module.

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
title: PowerBIEmbeddedManagementClient
```



###
``` yaml
commit: d2bb2feadd0deb1c7212706aa65cab2f56adccc7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/powerbiembedded/resource-manager/Microsoft.PowerBI/stable/2016-01-29/powerbiembedded.json

output-folder: Generated

namespace: Microsoft.Azure.Management.PowerBIEmbedded
```