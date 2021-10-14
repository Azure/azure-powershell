<!-- region Generated -->
# Az.LabServices
This directory contains the PowerShell module for the LabServices service.

---
## Status
[![Az.LabServices](https://img.shields.io/powershellgallery/v/Az.LabServices.svg?style=flat-square&label=Az.LabServices "Az.LabServices")](https://www.powershellgallery.com/packages/Az.LabServices/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.LabServices`, see [how-to.md](how-to.md).
<!-- endregion -->

---
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
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/Images.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/LabPlans.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/LabServices.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/Labs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/OperationResults.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/Schedules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/Users.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/labservices/resource-manager/Microsoft.LabServices/preview/2021-10-01-preview/VirtualMachines.json

module-version: 1.0.0
title: LabServices
subject-prefix: $(service-name)

inlining-threshold: 50

directive:
  # set default SubscriptionId to the AzContext Subscription
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: "(Get-AzContext).Subscription.Id"
  # change VirtualMachine to VM
  - where:
      subject: ^(.*)(VirtualMachine)(.*)$
    set:
      subject: $1VM$3
  # change Invoke to Send for InviteUser
  - where:
      verb: Invoke
      subject: ^(.*)(InviteUser)(.*)$
    set:
      verb: Send
      subject: $1UserInvite$3
  # change Invoke to Redeploy-AzLabVM
  - where:
      verb: Invoke
      subject: ^(.*)(RedeployVM)(.*)$
    set:
      verb: Redeploy
      subject: $1VM$3
  # Change the sync group to users
  - where:
      verb: Sync
      subject: ^(.*)(Group)(.*)$
    set:
      subject: $1Users$3
  # Change Update-xxxVM to Update-AzLabVMReimage
  - where:
      verb: Update
      subject: ^(.*)(VM)
    set:
      subject: $1VMReimage
  # Remove operation cmdlets
  - where:
      subject: Operation
    remove: true
  # Remove OperationResult to Operation
  - where:
      subject: OperationResult
    remove: true
  # remove the New cmdlets and alias the Set ones - aliasing doesn't work with regex-replacement so we have to explicitly identify all of them
  - where:
      verb: Set
      subject: Lab
    set:
      alias: New-AzLab
  - where:
      verb: Set
      subject: LabImage
    set:
      alias: New-AzLabImage
  - where:
      verb: Set
      subject: LabPlan
    set:
      alias: New-AzLabPlan
  - where:
      verb: Set
      subject: Schedule
    set:
      alias: New-AzLabSchedule
  - where:
      verb: Set
      subject: User
    set:
      alias: New-AzLabUser
  - where:
      verb: Set
    remove: true
  # remove the Identity variants
  - where:
      variant: ^(.*)ViaIdentity(.*)$
    remove: true
  # Change LabImage to LabPlanImage
  - where:
      verb: Get
      subject: ^(.*)(Image)(.*)$
    set:
      subject: $1PlanImage$3
  - where:
      verb: Get
      subject: AzLabImage
    remove: true
  - where:
      verb: New
      subject: ^(.*)(Image)(.*)$
    remove: true  
  - where:
      verb: Update
      subject: ^(.*)(Image)(.*)$
    set:
      subject: $1PlanImage$3
  - where:
      verb: Update
      subject: AzLabImage
    remove: true
  - where:
      verb: Update
      subject: ^(.*)VMRePlanImage
    set:
      verb: Update
      subject: $1VMReimage
```
