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
commit: 8933ceed3ed4dbd4d3835ee6e303348e9be7c068
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2024-10-23/openapi.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/preview/2020-01-13-preview/dscCompilationJob.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Automation
directive:
  - where:
      model-name: UserAssignedIdentitiesProperties
    set:
      model-name: IdentityUserAssignedIdentitiesValue
  - from: openapi.json
    where: $
    transform: |
      for (const path of Object.values($.paths ?? {})) {
        for (const operation of Object.values(path)) {
          if (operation?.operationId !== "RunbookDraft_ReplaceContent") continue;

          const acceptedResponse = operation.responses?.["202"];
          if (acceptedResponse) {
            delete acceptedResponse.headers;
          }
        }
      }

      const workerProperties =
        $.definitions?.HybridRunbookWorkerProperties?.properties;
      if (workerProperties?.registeredDateTime) {
        workerProperties.registeredDateTime["x-nullable"] = false;
      }
      if (workerProperties?.lastSeenDateTime) {
        workerProperties.lastSeenDateTime["x-nullable"] = false;
      }
      return $;
```
