# Overall
This directory contains management plane service clients of Az.Aks module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
clear-output-folder: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
```

###
``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/4522e1d3fb6dcb81bc63e3414d11dd7eaf08264b/specification/containerservice/resource-manager/Microsoft.ContainerService/stable/2021-05-01/managedClusters.json

output-folder: Generated
namespace: Microsoft.Azure.Management.ContainerService
```