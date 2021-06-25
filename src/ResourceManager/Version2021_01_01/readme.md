# Overall
This directory contains the service clients of other services for Azure PowerShell Compute module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=package-subscriptions-2021-01
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
``` yaml $(tag) == 'package-subscriptions-2021-01'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/9af192379d5e8d18e9017a85c5977f58e702a866/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json

output-folder: package-subscriptions-2021-01

namespace: Microsoft.Azure.Management.ResourceManager.Version2021_01_01

#directive:
# - remove-operation:
#   - Operations_List
#   - Subscriptions_ListLocations
#   - Subscriptions_Get
#   - Subscriptions_List
#   - Tenants_List
#   - checkResourceName
```
