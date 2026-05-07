<!-- region Generated -->
# Az.MonitorWorkspace
This directory contains the PowerShell module for the MonitorWorkspace service.

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
For information on how to develop for `Az.MonitorWorkspace`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 936922b8f9c7e5dbadf806a73a888a8e93e9a1f8
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/monitoringservice/resource-manager/Microsoft.Monitor/Accounts/stable/2025-10-03/azuremonitorworkspace.json

root-module-name: $(prefix).Monitor
title: MonitorWorkspace
module-version: 0.1.0
subject-prefix: $(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace

directive:
  - where:
      subject: ^AzureMonitorWorkspace(.*)
    set:
      subject: $1
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: MonitorOperation
    remove: true
  - where:
      model-name: AzureMonitorWorkspaceResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - PublicNetworkAccess
          - ResourceGroupName
  - where:
      verb: Get|New|Update
    set:
      breaking-change:
        deprecated-output-properties:
          - PrivateEndpointConnection
          - ProvisioningState
        new-output-properties:
          - PrivateEndpointConnection
          - ProvisioningState
        change-description: The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
```
