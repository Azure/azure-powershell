# Overall
This directory contains the service clients of Az.Automation module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --version=3.10.9 --use:@autorest/powershell@4.0.754
```

The `LegacyGenerated` directory preserves the PowerShell 7.2 module operation group, which is not exposed by the 2024-10-23 specification. AutoRest only clears and regenerates `Generated`.

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
commit: 4e219f2315c4e4ebdd2e5bf1d3c13164db4ec804
input-file:
  - https://github.com/kaarthik2103/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2024-10-23/openapi.json
  - https://github.com/kaarthik2103/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/preview/2020-01-13-preview/dscCompilationJob.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Automation
directive:
  - where:
      model-name: UserAssignedIdentitiesProperties
    set:
      model-name: IdentityUserAssignedIdentitiesValue
```