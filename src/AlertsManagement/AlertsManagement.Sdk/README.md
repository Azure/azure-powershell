# Overall
This directory contains management plane service clients of Az.AlertsManagement module.

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
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
title: AlertsManagementClient

```


###
``` yaml
commit: 9366804c62e024801daf8a578924099ff644ccf6
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/alertsmanagement/resource-manager/Microsoft.AlertsManagement/stable/2021-08-08/AlertProcessingRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/alertsmanagement/resource-manager/Microsoft.AlertsManagement/preview/2019-05-05-preview/SmartGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/alertsmanagement/resource-manager/Microsoft.AlertsManagement/preview/2019-05-05-preview/AlertsManagement.json

output-folder: Generated

namespace: Microsoft.Azure.Management.AlertsManagement
```