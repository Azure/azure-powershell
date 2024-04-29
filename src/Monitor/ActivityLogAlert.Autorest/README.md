<!-- region Generated -->
# Az.ActivityLogAlert
This directory contains the PowerShell module for the ActivityLogAlert service.

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
For information on how to develop for `Az.ActivityLogAlert`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: e94b0da0c7f80e2986af90c1dd7e9c8f4c336c61
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2020-10-01/activityLogAlerts_API.json

root-module-name: $(prefix).Monitor
title: ActivityLogAlert
module-version: 0.1.0
subject-prefix: ActivityLogAlert
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert
resourcegroup-append: true
nested-object-to-string: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove Set cmdlet
  - where:
      verb: Set
    remove: true
  # Hide New/Update for ActivityLogAlert
  - where:
      subject: ActivityLogAlert
      verb: New|Update
    hide: true
  # Rename parameter name for New-AzActivityLogAlert
  - where:
      subject: ActivityLogAlert
      verb: New
      parameter-name: ConditionAllOf
    set:
      parameter-name: Condition
  - where:
      subject: ActivityLogAlert
      verb: New
      parameter-name: ActionGroup
    set:
      parameter-name: Action
  - where:
      subject: (ActivityLogAlert)(.*)
    set:
      subject-prefix: ""

  - model-cmdlet:
    - AlertRuleAnyOfOrLeafCondition
    - AlertRuleLeafCondition
    - ActionGroup
```
