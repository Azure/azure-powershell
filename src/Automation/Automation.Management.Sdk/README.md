# Overall
This directory contains the service clients of Az.Automation module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
useDateTimeOffset: true
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION

title: AutomationClient
```


### 
``` yaml 
commit: main
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2024-10-23/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Automation
directive:
  - where:
      model-name: UserAssignedIdentitiesProperties
    set:
      model-name: IdentityUserAssignedIdentitiesValue
```