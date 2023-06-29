<!-- region Generated -->
# Az.RecoveryServices
This directory contains the PowerShell module for the RecoveryServices service.

---
## Status
[![Az.RecoveryServices](https://img.shields.io/powershellgallery/v/Az.RecoveryServices.svg?style=flat-square&label=Az.RecoveryServices "Az.RecoveryServices")](https://www.powershellgallery.com/packages/Az.RecoveryServices/)

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
For information on how to develop for `Az.RecoveryServices`, see [how-to.md](how-to.md).
<!-- endregion -->

# My API

This file contains the configuration for generating My API from the OpenAPI specification.

> see https://aka.ms/autorest

``` yaml
# it's the same options as command line options, just drop the double-dash!
branch: c94569d116a82ee11a94c5dfb190650dd675a1bf
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2023-02-01/bms.json
title: RecoveryServices
directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}"].put
    transform: $["x-ms-long-running-operation"] = true
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{fabricName}/protectionContainers/{containerName}/protectedItems/{protectedItemName}"].delete
    transform: $["x-ms-long-running-operation"] = true
  - where:
      verb: New
      subject: ProtectionPolicy
      variant: ^CreateViaIdentityExpanded$|^CreateExpanded$|^CreateViaIdentity$
    remove: true
  - where:
      verb: New
      subject: ProtectionPolicy
      variant: Create
    hide: true
  - where:
      verb: Remove
      subject: ProtectionPolicy
      variant: DeleteViaIdentity
    remove: true
  - where:
      verb: Get
      subject: ProtectedItem
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: ProtectionPolicy
      variant: GetViaIdentity
    remove: true
  - where:
      subject: ProtectionPolicy
    set:
      subject: BackupPolicy
  - where:      
      verb: Set
      subject: BackupPolicy
    remove: true
  - no-inline:
    - DailyRetentionSchedule
    - DiskExclusionProperty
    - DiskLunList
    - HourlySchedule
    - IsInclusionList
    - MonthlyRetentionSchedule
    - Settings
    - SubProtectionPolicyTieringPolicy
    - TieringPolicy
    - WeeklyRetentionSchedule
    - YearlyRetentionSchedule
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy Property', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRetentionPolicy RetentionPolicy', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRetentionPolicy RetentionPolicy');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ISchedulePolicy SchedulePolicy', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ISchedulePolicy SchedulePolicy'); 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItem Property', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItem Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IExtendedProperties ExtendedProperty', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IExtendedProperties ExtendedProperty');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItem Property', 'public Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItem Property');
```
