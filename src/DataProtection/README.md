<!-- region Generated -->
# Az.DataProtection
This directory contains the PowerShell module for the DataProtection service.

---
## Status
[![Az.DataProtection](https://img.shields.io/powershellgallery/v/Az.DataProtection.svg?style=flat-square&label=Az.DataProtection "Az.DataProtection")](https://www.powershellgallery.com/packages/Az.DataProtection/)

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
For information on how to develop for `Az.DataProtection`, see [how-to.md](how-to.md).
<!-- endregion -->

# My API 

This file contains the configuration for generating My API from the OpenAPI specification.

> see https://aka.ms/autorest

``` yaml
# it's the same options as command line options, just drop the double-dash!
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: https://github.com/Azure/azure-rest-api-specs/blob/main/specification/dataprotection/resource-manager/Microsoft.DataProtection/stable/2022-04-01/dataprotection.json
title: DataProtection
directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}"].delete
    transform: $["description"] = "Delete a backupInstances"
  - where:      
      parameter-name: AzureMonitorAlertSettingAlertsForAllJobFailure
    set:
      parameter-name: AzureMonitorAlertsForAllJobFailure
      parameter-description: Parameter to Enable or Disable built-in azure monitor alerts for job failures. Security alerts cannot be disabled.
  - where:      
      parameter-name: VaultCriticalOperationExclusionList
    set:
      parameter-name: CriticalOperationExclusionList
    clear-alias: true
  - where:
      verb: Get
      subject: BackupVaultResource.*
    hide: true
  - where:
      verb: Get
      subject: ResourceGuardResource
      variant: Get1
    set:
      subject: ResourceGuard
  - where:
      subject: ResourceGuard
      parameter-name: SName
    set:
      parameter-name: Name
    clear-alias: true
  - where:
      subject: ResourceGuard.+      
    remove: true
  - where:
      verb: Update
      subject: ResourceGuard      
    remove: true
  - where:
      verb: Set
      subject: ResourceGuard.*
    set:
      verb: New
  - where:
      verb: New
      subject: ResourceGuard      
    hide: true
  - where:
      subject: RecoveryPoint
      variant: List
    hide: true
  - where:
      verb: Get
      subject: RecoveryPointList.*
    hide: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: New
      subject: BackupInstance.*
    hide: true
  - where:
      verb: New
      subject: BackupPolicy.*
    hide: true
  - where:
      variant: ^CreateViaIdentity$|^Patch$|^PatchViaIdentity$|^Backup$|^BackupViaIdentity$|^TriggerViaIdentity|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Get
      subject: ExportJobsOperationResult
    remove: true
  - where:
      verb: Resume
      subject: Backup$
    remove: true
  - where:
      subject: Context$|OperationResult$
    remove: true
  - where:
      verb: Sync
      variant: Sync$|SyncViaIdentity$|SyncViaIdentityExpanded$
    remove: true
  - where:
      verb: Get
      subject: OperationResult
    remove: true
  - where:
      verb: Get
      subject: OperationStatus
    remove: true
  - where:
      verb: Start
      subject: BackupInstanceRehydrate
    remove: true
  - where:
      verb: Start
      subject: ExportJob
    remove: true
  - where:
      verb: Get
      subject: OperationResultPatch
    remove: true
  - where:
      verb: Get
      subject: BackupVaultOperationResult
    remove: true
  - where:
      verb: New
      subject: BackupVault
    hide: true
  - where:
      verb: Invoke
      variant: ^Post$|^PostViaIdentity$|^PostViaIdentityExpanded$
    remove: true
  - where:
      verb: Find
      variant: ^Find$|^FindViaIdentity$|^FindViaIdentityExpanded$
    remove: true
  - where:
      verb: Get
      subject: BackupVault
      variant: ^GetViaIdentity2$|^Get$|^GetViaIdentity1$
    remove: true
  - where:
      verb: Invoke
      subject: FindRestorableTimeRange
      parameter-name: BackupInstance
    set:
      parameter-name: BackupInstanceName
  - where:
      verb: Invoke
      subject: FindRestorableTimeRange
    set:
      verb: Find
      subject: RestorableTimeRange
  - where:
      verb: Test
      subject: BackupInstance
      variant: ^Validate1$|^ValidateExpanded1$|^ValidateViaIdentity1$|^ValidateViaIdentityExpanded1$
    remove: true
  - where:
      verb: Test
    hide: true
  - where:
      property-name: AzureMonitorAlertSettingAlertsForAllJobFailure
    set:
      property-name: AzureMonitorAlertsForAllJobFailure
  - where:
      property-name: VaultCriticalOperationExclusionList
    set:
      property-name: CriticalOperationExclusionList
  - where:
      model-name: BackupVaultResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - Type
          - IdentityType
  - no-inline:
    - UserFacingError
    - InnerError
    - BackupInstance
    - RestoreTargetInfo
    - ItemLevelRestoreTargetInfo
    - RestoreFilesTargetInfo
    - RestoreTargetInfoBase
    - PolicyParameters
    - SecretStoreBasedAuthCredentials
    - SecretStoreResource
    - SystemData
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IBaseBackupPolicy Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IBaseBackupPolicy Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.ITriggerContext Trigger', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.ITriggerContext Trigger');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IBackupParameters BackupParameter', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IBackupParameters BackupParameter');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IAzureBackupRecoveryPoint Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IAzureBackupRecoveryPoint Property');
```

## Alternate settings

This section is only activated if the `--make-it-rain` switch is added to the command line

``` yaml $(make-it-rain)
namespace: MyCompany.Special.Rest
```
