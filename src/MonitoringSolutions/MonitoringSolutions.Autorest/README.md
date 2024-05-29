<!-- region Generated -->
# Az.MonitoringSolutions
This directory contains the PowerShell module for the MonitoringSolutions service.

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
For information on how to develop for `Az.MonitoringSolutions`, see [how-to.md](how-to.md).
<!-- endregion -->

## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 740a40ba31720ad514a308054ba517a8ea956a3c
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/operationsmanagement/resource-manager/Microsoft.OperationsManagement/preview/2015-11-01-preview/OperationsManagement.json

module-version: 0.1.0
title: MonitoringSolutions
subject-prefix: MonitorLogAnalytics

inlining-threshold: 40

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Fix error in swagger: PUT, PATCH, DELETE of solutions are not long running
  - from: swagger-document
    where: $
    # ": " is a special term in yaml, indicating a key-value pair. Needs to use ":\ " to prevent grammar error.
    transform: return $.replace(/"x-ms-long-running-operation":\ true/g, "\"x-ms-long-running-operation\":\ false")
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove the cmdlets we don't need for now
  - where:
      subject: Association$|Configuration$
    remove: true
  # Hide New-*Solution for customization
  - where:
      verb: New
      subject: Solution$
    hide: true
  - where:
      model-name: Solution
    set:
      format-table:
        properties:
          - Name
          - Type
          - Location

  # Update the cmdlet description of Update-AzMonitorLogAnalyticsSolution
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.OperationsManagement/solutions/{solutionName}"].patch.description
    transform: return "Update the tags of a solution."
```
