<!-- region Generated -->
# Az.DiagnosticSetting
This directory contains the PowerShell module for the DiagnosticSetting service.

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
For information on how to develop for `Az.DiagnosticSetting`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-05-01-preview/diagnosticsSettings_API.json
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-05-01-preview/diagnosticsSettingsCategories_API.json
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/preview/2021-05-01-preview/subscriptionDiagnosticsSettings_API.json
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/eventCategories_API.json

root-module-name: $(prefix).Monitor
title: DiagnosticSetting
module-version: 0.1.0
subject-prefix: DiagnosticSetting
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting
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
  # Rename parameter name for New-AzDiagnosticSetting
  - where:
      subject: ^DiagnosticSetting$|^DiagnosticSettingsCategory$
      parameter-name: ResourceUri
    set:
      parameter-name: ResourceId
  - where:
      subject: DiagnosticSettingsCategory
    set:
      subject: DiagnosticSettingCategory
  - where:
      subject: (DiagnosticSetting|EventCategory)(.*)
    set:
      subject-prefix: ""

  - model-cmdlet:
    - MetricSettings
    - LogSettings
    - SubscriptionLogSettings
```
