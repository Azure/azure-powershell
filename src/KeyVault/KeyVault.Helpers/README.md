# Overall
This directory contains the service clients of other services for Azure PowerShell KeyVault module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Resources
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
payload-flattening-threshold: 2
```


### Tag: Network
``` yaml $(tag) == 'Resources'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/81cd88a080c4bf4bb251afbe62892a6e220cb2b4/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json

output-folder: Resources

namespace: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources
```