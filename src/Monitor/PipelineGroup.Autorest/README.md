<!-- region Generated -->
# Az.PipelineGroup
This directory contains the PowerShell module for the PipelineGroup service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.PipelineGroup`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: ba1d416d3bfa258bc55d9b5a892093df29d2efff
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Monitor/PipelineGroups/preview/2024-10-01-preview/pipelineGroups.json

root-module-name: $(prefix).Monitor
title: PipelineGroup
module-version: 0.1.0
subject-prefix: $(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - where:
      subject: ^AzureMonitorWorkspace(.*)
    remove: true
  - where:
      model-name: ^AzureMonitorWorkspace(.*)
    remove: true
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
      subject: PipelineGroup
    remove: true
  - where:
      subject: MonitorOperation
    remove: true
  - where:
      model-name: PipelineGroupResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
```
