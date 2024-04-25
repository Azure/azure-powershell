<!-- region Generated -->
# Az.ScheduledQueryRule
This directory contains the PowerShell module for the ScheduledQueryRule service.

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
For information on how to develop for `Az.ScheduledQueryRule`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: 9be728717e3e81bd3d28566016e71d8f49a8e755
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2021-08-01/scheduledQueryRule_API.json

root-module-name: $(prefix).Monitor
title: ScheduledQueryRule
module-version: 0.1.0
subject-prefix: ScheduledQueryRule
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule
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
  - where:
      verb: Set
    remove: true
  # Polish parameter names
  - where:
      subject: ScheduledQueryRule
      parameter-name: RuleName
    set:
      parameter-name: Name
  - where:
      subject: ScheduledQueryRule
      verb: New|Update
      parameter-name: ActionGroup
    set:
      parameter-name: ActionGroupResourceId
  - where:
      subject: (^ScheduledQueryRule$)(.*)
    set:
      subject-prefix: ""
  # enum integer is not supported
  - from: swagger-document
    where: $.definitions.ScheduledQueryRuleProperties.properties.severity
    transform: >-
      return {
        "type": "integer",
        "format": "int64",
        "description": "Severity of the alert. Should be an integer between [0-4]. Value of 0 is severest. Relevant and required only for rules of the kind LogAlert."
      }
  # Rename 'Equals'
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Support.ConditionOperator Equals = @"Equals";', 'public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Support.ConditionOperator Equal = @"Equals";');
  - model-cmdlet:
    - Condition
    - Dimension
```
