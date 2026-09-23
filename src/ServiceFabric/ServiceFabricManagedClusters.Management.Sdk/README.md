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
commit: 769257f30258b59bbc33349646eecfa8ad77a55f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/ServiceFabricManagedClusters/stable/2026-02-01/servicefabricmanagedclusters.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters
```
