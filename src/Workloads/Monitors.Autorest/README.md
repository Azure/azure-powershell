<!-- region Generated -->
# Az.Monitors
This directory contains the PowerShell module for the Monitors service.

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
For information on how to develop for `Az.Monitors`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: 2576a40e42832d4b6ff4e1a2d01e6709e7b36c0a
tag: package-preview-2023-10
# tag: package-2023-04

require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/workloads/resource-manager/readme.md

try-require: 
  - $(repo)/specification/workloads/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
root-module-name: $(prefix).Workloads
# Normally, title is the service name
title: Monitors
subject-prefix: Workloads
namespace: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors
resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true
#add-api-version-in-model-namespace: true
inlining-threshold: 100

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
 "@autorest/powershell": "3.x"

directive:
# Monitor
- where:
    verb: New
    subject: ^Monitor$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: Update
    subject: ^Monitor$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    subject: ^Monitor$
    parameter-name: IdentityUserAssignedIdentity
  set:
    parameter-name: UserAssignedIdentity

- where:
    subject: ^Monitor$
    parameter-name: ManagedResourceGroupConfigurationName
  set:
    parameter-name: ManagedResourceGroupName

# ProviderInstance
- where:
    verb: New
    subject: ^ProviderInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

# SapLandscapeMonitor
- where:
    verb: New
    subject: ^SapLandscapeMonitor$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: Get
    subject: ^SapLandscapeMonitor$
    variant: ^List$
  remove: true
- where:
    verb: Update
    subject: ^SapLandscapeMonitor$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

# Module Table Formatting
- where:
    model-name: Monitor
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ManagedResourceGroupConfigurationName
        - Location
        - ProvisioningState

- where:
    model-name: ProviderInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - ProviderSettingProviderType
        - IdentityType

- where:
    model-name: SapLandscapeMonitor
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - GroupingLandscape        
        - GroupingSapApplication

- no-inline:  # choose ONE of these models to disable inlining
  - ProviderSpecificProperties
  - SAPConfiguration
  - ErrorInnerError
- model-cmdlet:
  - SapLandscapeMonitorSidMapping
  - SapLandscapeMonitorMetricThresholds

# remove System Data in module Monitor, ProviderInstance, SapApplicationServerInstance, SapCentralServerInstance, SapDatabaseInstance, SapLandscapeMonitor, SapVirtualInstance
- from: Monitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: ProviderInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapLandscapeMonitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
```
