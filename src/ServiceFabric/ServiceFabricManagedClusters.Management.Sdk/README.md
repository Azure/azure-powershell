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
commit: 517eaf1cca58813605768f4ddc9a59ca75173493
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/517eaf1cca58813605768f4ddc9a59ca75173493/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2025-03-01-preview/servicefabricmanagedclusters.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters
```
