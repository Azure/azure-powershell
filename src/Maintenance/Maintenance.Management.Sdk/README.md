# Overall
This directory contains management plane service clients of Az.Maintenance module.

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
commit: 741b0c8c71d90525a92bc4f2e45cb189c3affccd
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/maintenance/resource-manager/Microsoft.Maintenance/preview/2023-10-01-preview/Maintenance.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Maintenance

directive:
  - from: IMaintenanceManagementClient.cs
    where: $
    transform: return $.replace(/System.Guid SubscriptionId/g, 'string SubscriptionId')
 
  - from: MaintenanceManagementClient.cs
    where: $
    transform: return $.replace(/System.Guid SubscriptionId/g, 'string SubscriptionId')
```