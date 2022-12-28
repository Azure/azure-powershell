# Overall
This directory contains the service clients of Az.ContainerRegistry module.

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
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
skip-simplifier-on-namespace:
  - System.Threading.Tasks
payload-flattening-threshold: 2
title: ContainerRegistryManagementClient
```


### 
``` yaml 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/5035a36bcd5b0543a9a65ee21f03bd12e301ea72/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/stable/2019-05-01/containerregistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5035a36bcd5b0543a9a65ee21f03bd12e301ea72/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/stable/2019-04-01/containerregistry_build.json
output-folder: Generated

namespace: Microsoft.Azure.Management.ContainerRegistry
```