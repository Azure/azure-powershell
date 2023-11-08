<!-- region Generated -->
# Az.ActionGroup
This directory contains the PowerShell module for the ActionGroup service.

---
## Status
[![Az.ActionGroup](https://img.shields.io/powershellgallery/v/Az.ActionGroup.svg?style=flat-square&label=Az.ActionGroup "Az.ActionGroup")](https://www.powershellgallery.com/packages/Az.ActionGroup/)

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
For information on how to develop for `Az.ActionGroup`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
branch: 47d1d82108a0db0395ed4eca106622becee7fbb4

input-file:
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-01-01/actionGroups_API.json

root-module-name: $(prefix).Monitor
title: ActionGroup
module-version: 0.1.0
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup
subject-prefix: ActionGroup
resourcegroup-append: true
nested-object-to-string: true

use-extension:
  "@autorest/powershell": "4.x"

directive:
  - remove-operation: ActionGroups_Update
# #   # Following is two common directive which are normally required in all the RPs
# #   # 1. Remove the unexpanded parameter set
# #   # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Enable|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      verb: Set
      subject: ActionGroup
    hide: true
  - where:
      verb: Get
      subject: ActionGroupTestNotification
    hide: true
  # fix breaking change
  - where:
      subject: ActionGroup
      parameter-name: GroupShortName
    set:
      alias: ShortName
  - model-cmdlet:
    - model-name: ArmRoleReceiver
    - model-name: AutomationRunbookReceiver
    - model-name: AzureAppPushReceiver
    - model-name: AzureFunctionReceiver
    - model-name: EmailReceiver
    - model-name: EventHubReceiver
    - model-name: ItsmReceiver
    - model-name: LogicAppReceiver
    - model-name: SmsReceiver
    - model-name: VoiceReceiver
    - model-name: WebhookReceiver
  # feedback rename
  - where:
      subject: ActionGroupNotification
      verb: New
    set:
      verb: Test
      subject: ActionGroup
  - where:
      subject: ActionGroup
      verb: Test
    hide: true
```
