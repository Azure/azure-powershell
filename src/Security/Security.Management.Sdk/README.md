# Overall
This directory contains management plane service clients of Az.Security module.

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
payload-flattening-threshold: 2
```



###
``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/security/resource-manager/Microsoft.Security/stable/2022-01-01/alerts.json

directive:
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.alertNotifications.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationState';
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.notificationsByRole.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationByRoleState';
  - from: swagger-document
    where: $.parameters.AscLocation
    transform: >
        $['x-ms-parameter-location'] = 'client';

output-folder: Generated

namespace: Microsoft.Azure.Management.Security
```