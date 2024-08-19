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
commit: 679e6bd33cc09224a02e73573c8818feb355eff8
require: https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datafactory/resource-manager/readme.md

output-folder: Generated

namespace: Microsoft.Azure.Management.DataFactory
```