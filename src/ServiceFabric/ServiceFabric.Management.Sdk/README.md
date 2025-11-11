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
commit: 33a08abd715bd9d671ade5aaf4e3810e003792f1
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/preview/2023-11-01-preview/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/preview/2023-11-01-preview/application.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabric
```
