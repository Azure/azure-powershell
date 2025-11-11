# Overall
This directory contains management plane service clients of Az.DataFactory module.

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
commit: c6e5248223e3bac9293ea4e0ac7c56f16c334e6a
require: https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datafactory/resource-manager/Microsoft.DataFactory/DataFactory/readme.md

output-folder: Generated

namespace: Microsoft.Azure.Management.DataFactory
```