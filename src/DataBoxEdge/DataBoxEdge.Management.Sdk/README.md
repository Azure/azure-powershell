# Overall
This directory contains management plane service clients of Az.Storage module.

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
payload-flattening-threshold: 0
```



###
``` yaml
commit: ef354ec8d6580227707ed935684e533b898beabe
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/databoxedge/resource-manager/Microsoft.DataBoxEdge/stable/2019-08-01/databoxedge.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DataBoxEdge
```