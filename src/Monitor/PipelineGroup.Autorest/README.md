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
commit: 928047803788f7377fa003a26ba2bdc2e0fcccc0
require:
  - $(this-folder)/../../../tools/SwaggerCI/readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/monitor/resource-manager/Microsoft.Monitor/preview/2023-10-01-preview/azuremonitor.json

root-module-name: $(prefix).Monitor
title: PipelineGroup
module-version: 0.1.0
subject-prefix: $(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
# use-extension:
#   "@autorest/powershell": "3.x"

directive:
  - where:
      subject: ^AzureMonitorWorkspace(.*)
    remove: true
  - where:
      model-name: ^AzureMonitorWorkspace(.*)
    remove: true
  - where:
      variant: ^Get$|^GetViaIdentity$|^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
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
          - PublicNetworkAccess
          - ResourceGroupName
```
