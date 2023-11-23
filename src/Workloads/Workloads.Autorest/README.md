<!-- region Generated -->
# Az.Workloads
This directory contains the PowerShell module for the Workloads service.

---
## Status
[![Az.Workloads](https://img.shields.io/powershellgallery/v/Az.Workloads.svg?style=flat-square&label=Az.Workloads "Az.Workloads")](https://www.powershellgallery.com/packages/Az.Workloads/)

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
For information on how to develop for `Az.Workloads`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
branch: c7c06e7e311df89b6851aa7e12142c8f0d129cd8 
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/workloads/resource-manager/readme.md

try-require: 
  - $(repo)/specification/workloads/resource-manager/readme.powershell.md

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true
inlining-threshold: 100

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

# SapApplicationServerInstance
- where:
    verb: New
    subject: ^SapApplicationServerInstance$
  remove: true

- where:
    verb: Stop
    subject: ^SapApplicationServerInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapApplicationServerInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapApplicationServerInstance$
  remove: true

- where:
    subject: SapApplicationServerInstance
  set:
    subject: SapApplicationInstance

- where:
    subject: SapApplicationInstance
    parameter-name: ApplicationInstanceName
  set:
    parameter-name: Name

# SapCentralInstance
- where:
    verb: New
    subject: ^SapCentralInstance$
  remove: true
- where:
    verb: Stop
    subject: ^SapCentralInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapCentralInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapCentralInstance$
  remove: true

- where:
    subject: SapCentralInstance
    parameter-name: CentralInstanceName
  set:
    parameter-name: Name

# SapDatabaseInstance
- where:
    verb: New
    subject: ^SapDatabaseInstance$
  remove: true

- where:
    verb: Stop
    subject: ^SapDatabaseInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapDatabaseInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapDatabaseInstance$
  remove: true

- where:
    subject: SapDatabaseInstance
    parameter-name: DatabaseInstanceName
  set:
    parameter-name: Name

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

# SapVirtualInstance
- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^CreateExpanded$
  hide: true

- where:
    verb: Stop
    subject: ^SapVirtualInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapVirtualInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    subject: ^SapVirtualInstance$
    parameter-name: IdentityUserAssignedIdentity
  set:
    parameter-name: UserAssignedIdentity

- where:
    subject: ^SapVirtualInstance$
    parameter-name: ManagedResourceGroupConfigurationName
  set:
    parameter-name: ManagedResourceGroupName

# SapAvailabilityZoneDetail
- where:
    verb: Invoke
    subject: ^SapAvailabilityZoneDetail$
  remove: true

# SapDiskConfiguration
- where:
    verb: Invoke
    subject: ^SapDiskConfiguration$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

# SapSizingRecommendation
- where:
    verb: Invoke
    subject: ^SapSizingRecommendation$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

# SapSupportedSku
- where:
    verb: Invoke
    subject: ^SapSupportedSku$
    variant: ^Sap$|^SapViaIdentity$
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
    model-name: SapVirtualInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - Environment
        - ProvisioningState
        - SapProduct
        - State
        - Status
        - Location

- where:
    model-name: SapCentralServerInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - EnqueueServerPropertyHostname
        - ProvisioningState
        - Status
        - Location

- where:
    model-name: SapApplicationServerInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - ProvisioningState
        - Status
        - Hostname
        - Location

- where:
    model-name: SapDatabaseInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - Location        
        - Status
        - IPAddress        
        - DatabaseSid

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
## Need custom below cmdlets.
#   - HanaDbProviderInstanceProperties
#   - SapNetWeaverProviderInstanceProperties
#   - PrometheusOSProviderInstanceProperties
#   - DB2ProviderInstanceProperties
#   - PrometheusHaClusterProviderInstanceProperties
#   - MsSqlServerProviderInstanceProperties

# Result shoule be in SingleServerRecommendationResult and ThreeTierRecommendationResult
- from: source-file-csharp
  where: $
  transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapSizingRecommendationResult Property', 'public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapSizingRecommendationResult Property');

# remove System Data in module Monitor, ProviderInstance, SapApplicationServerInstance, SapCentralServerInstance, SapDatabaseInstance, SapLandscapeMonitor, SapVirtualInstance
- from: Monitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: ProviderInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapApplicationServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapCentralServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapDatabaseInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapLandscapeMonitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapVirtualInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
```
