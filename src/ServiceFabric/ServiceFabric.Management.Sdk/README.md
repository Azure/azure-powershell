# Overall

This directory contains management plane service clients of Az.ServiceFabric module.

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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```

###

``` yaml
commit: 6963bf056ac44c592c385e84d493053bd2d5a5ee
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/application.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabric
```
