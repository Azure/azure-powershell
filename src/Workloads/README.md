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
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - C:/Users/v-diya/repository/azure-rest-api-specs-pr/specification/workloads/resource-manager/readme.md

try-require: 
  - C:/Users/v-diya/repository/azure-rest-api-specs-pr/specification/workloads/resource-manager/readme.powershell.md

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

- where:
    verb: Update
    subject: ^ProviderInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

# SapApplicationServerInstance
- where:
    verb: New
    subject: ^SapApplicationServerInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
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
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
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
    subject: SapCentralInstance
    parameter-name: CentralInstanceName
  set:
    parameter-name: Name

# SapDatabaseInstance
- where:
    verb: New
    subject: ^SapDatabaseInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
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
    subject: SapLandscapeMonitor
    parameter-name: MonitorName
  set:
    parameter-name: Name

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
    variant: ^Sap$|^SapViaIdentity$
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

- no-inline:  # choose ONE of these models to disable inlining
  - ErrorInnerError
```
