<!-- region Generated -->
# Az.MonitorWorkspace
This directory contains the PowerShell module for the MonitorWorkspace service.

---
## Status
[![Az.MonitorWorkspace](https://img.shields.io/powershellgallery/v/Az.MonitorWorkspace.svg?style=flat-square&label=Az.MonitorWorkspace "Az.MonitorWorkspace")](https://www.powershellgallery.com/packages/Az.MonitorWorkspace/)

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
branch: 14268abc2d999d7c0425490f8ecf0c91b46ea44b
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/monitor/resource-manager/Microsoft.Monitor/stable/2023-04-03/monitoringAccounts_API.json
  - $(repo)/specification/monitor/resource-manager/Microsoft.Monitor/stable/2023-04-03/operations_API.json

root-module-name: $(prefix).Monitor
title: MonitorWorkspace
module-version: 0.1.0
subject-prefix: $(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - where:
      subject: ^AzureMonitorWorkspace(.*)
    set:
      subject: $1
  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
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
```
