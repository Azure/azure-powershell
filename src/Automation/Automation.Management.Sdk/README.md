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
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/preview/2020-01-13-preview/dscNode.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/dscNodeConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/preview/2020-01-13-preview/dscCompilationJob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/certificate.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/credential.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/jobSchedule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/schedule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/module.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/variable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/connection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/connectionType.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/sourceControl.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/sourceControlSyncJob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/sourceControlSyncJobStreams.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/dscConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/job.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2019-06-01/softwareUpdateConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/softwareUpdateConfigurationRun.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/softwareUpdateConfigurationMachineRun.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/account.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2015-10-31/webhook.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/runbook.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/powershell72Module.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/hybridRunbookWorker.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/hybridRunbookWorkerGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/automation/resource-manager/Microsoft.Automation/stable/2023-11-01/python3package.json


output-folder: Generated

namespace: Microsoft.Azure.Management.Automation
directive:
  - where:
      model-name: UserAssignedIdentitiesProperties
    set:
      model-name: IdentityUserAssignedIdentitiesValue
```