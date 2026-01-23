<!-- region Generated -->
# Az.DataProtection
This directory contains the PowerShell module for the DataProtection service.

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
For information on how to develop for `Az.DataProtection`, see [how-to.md](how-to.md).
<!-- endregion -->

# My API 

This file contains the configuration for generating My API from the OpenAPI specification.

> see https://aka.ms/autorest

``` yaml
# it's the same options as command line options, just drop the double-dash!
commit: 18609d68cf243ee3ce35d7c005ff3c7dd2cd9477
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/dataprotection/resource-manager/Microsoft.DataProtection/DataProtection/stable/2025-09-01/dataprotection.json
title: DataProtection
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths..parameters[?(@.name=='backupInstanceName')]
    transform: $["description"] = "The name of the backup instance."
  - from: swagger-document
    where: $.paths..parameters[?(@.name=='vaultName')]
    transform: $["description"] = "The name of the backup vault."
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}"].put
    transform: delete $["x-ms-long-running-operation-options"];
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}"].put
    transform: delete $["x-ms-long-running-operation-options"];
  - from: swagger-document
    where: $.definitions.ResourceDeletionInfo.properties
    transform: >
      $["deleteActivityID"] = $["deleteActivityId"];
      delete $["deleteActivityId"];
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}"].delete
    transform: $["description"] = "Delete a backupInstances"
  - from: swagger-document
    where: $.definitions.BackupVault
    transform: >
      delete $.required;
  # Fix breaking change: Rename Operation to ClientDiscoveryValueForSingleApi to maintain backward compatibility
  - from: swagger-document
    where: $.definitions
    transform: >
      if ($["Operation"]) {
        $["ClientDiscoveryValueForSingleApi"] = $["Operation"];
        delete $["Operation"];
      }
  # Fix breaking change: Update OperationListResult to use ClientDiscoveryValueForSingleApi
  - from: swagger-document
    where: $.definitions.OperationListResult.properties.value.items
    transform: >
      $["$ref"] = "#/definitions/ClientDiscoveryValueForSingleApi";
  # Fix breaking change: Add DppProxyResource definition (removed in new swagger)
  - from: swagger-document
    where: $.definitions
    transform: >
      $["DppProxyResource"] = {
        "type": "object",
        "x-ms-azure-resource": true,
        "properties": {
          "id": {
            "description": "Proxy Resource Id represents the complete path to the resource.",
            "readOnly": true,
            "type": "string"
          },
          "name": {
            "description": "Proxy Resource name associated with the resource.",
            "readOnly": true,
            "type": "string"
          },
          "type": {
            "description": "Proxy Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...",
            "readOnly": true,
            "type": "string"
          },
          "tags": {
            "$ref": "#/definitions/DppProxyResourceTags"
          },
          "systemData": {
            "$ref": "#/definitions/DppSystemData"
          }
        }
      };
      $["DppProxyResourceTags"] = {
        "type": "object",
        "description": "Proxy Resource tags.",
        "additionalProperties": {
          "type": "string"
        }
      };
      $["DppSystemData"] = {
        "description": "Metadata pertaining to creation and last modification of the resource.",
        "type": "object",
        "readOnly": true,
        "properties": {
          "createdBy": {
            "type": "string",
            "description": "The identity that created the resource."
          },
          "createdByType": {
            "type": "string",
            "description": "The type of identity that created the resource.",
            "enum": ["User", "Application", "ManagedIdentity", "Key"],
            "x-ms-enum": {
              "name": "createdByType",
              "modelAsString": true
            }
          },
          "createdAt": {
            "type": "string",
            "format": "date-time",
            "description": "The timestamp of resource creation (UTC)."
          },
          "lastModifiedBy": {
            "type": "string",
            "description": "The identity that last modified the resource."
          },
          "lastModifiedByType": {
            "type": "string",
            "description": "The type of identity that last modified the resource.",
            "enum": ["User", "Application", "ManagedIdentity", "Key"],
            "x-ms-enum": {
              "name": "createdByType",
              "modelAsString": true
            }
          },
          "lastModifiedAt": {
            "type": "string",
            "format": "date-time",
            "description": "The timestamp of resource last modification (UTC)"
          }
        }
      };
  # Fix breaking change: Revert BackupInstanceResource to old definition (inherit from DppProxyResource, remove explicit tags)
  - from: swagger-document
    where: $.definitions.BackupInstanceResource
    transform: >
      delete $.properties.tags;
      delete $.type;
      $.allOf = [{ "$ref": "#/definitions/DppProxyResource" }];
  - from: swagger-document
    where: $.definitions
    transform: >
      delete $["BackupInstanceResourceTags"];
  - where:
      parameter-name: XmsAuthorizationAuxiliary
    set:
      parameter-name: Token
      parameter-description: Parameter deprecate. Please use SecureToken instead.
  - where:
      parameter-name: AzureMonitorAlertSettingAlertsForAllJobFailure
    set:
      parameter-name: AzureMonitorAlertsForAllJobFailure
      parameter-description: Parameter to Enable or Disable built-in azure monitor alerts for job failures. Security alerts cannot be disabled.
  - where:
      parameter-name: ResourceGuardResourceId
    set:
      parameter-name: ResourceGuardId      
      parameter-description: Resource Guard ARM Id to enable MUA protection for Backup Vault.
  - where:      
      parameter-name: VaultCriticalOperationExclusionList
    set:
      parameter-name: CriticalOperationExclusionList
    clear-alias: true
  - where:      
      parameter-name: ImmutabilitySettingState
    set:
      parameter-name: ImmutabilityState
      parameter-description: Immutability state of the vault. Allowed values are Disabled, Unlocked, Locked.
    clear-alias: true
  - where:      
      parameter-name: CrossSubscriptionRestoreSettingState
    set:
      parameter-name: CrossSubscriptionRestoreState
      parameter-description: Cross subscription restore state of the vault. Allowed values are Disabled, Enabled, PermanentlyDisabled.
    clear-alias: true
  - where:      
      parameter-name: CrossRegionRestoreSettingState
    set:
      parameter-name: CrossRegionRestoreState
      parameter-description: Cross region restore state of the vault. Allowed values are Disabled, Enabled.
    clear-alias: true
  - where:      
      parameter-name: SoftDeleteSettingRetentionDurationInDay
    set:
      parameter-name: SoftDeleteRetentionDurationInDay
      parameter-description: Soft delete retention duration in days.
    clear-alias: true
  - where:      
      parameter-name: SoftDeleteSettingState
    set:
      parameter-name: SoftDeleteState
      parameter-description: Soft delete state of the vault. Allowed values are Off, On, AlwaysOn.
    clear-alias: true
  - where:      
      parameter-name: SecuritySettingSoftDeleteSetting
    set:
      parameter-name: SoftDeleteSetting
    clear-alias: true
  - where:      
      parameter-name: SecuritySettingEncryptionSetting
    set:
      parameter-name: EncryptionSetting
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
      subject: ResourceGuard.+RequestObject
    remove: true
  - where:
      verb: Update
      subject: ResourceGuard      
    remove: true
  - where:
      verb: Get
      subject: ResourceGuardResource
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
      verb: Unlock
      variant: ^UnlockViaIdentityExpanded$|^UnlockViaIdentity$|^Unlock$
    remove: true
  - where:
      verb: Unlock
      variant: ^UnlockExpanded$
    hide: true
  - where:
      verb: New
      subject: ResourceGuardProxy$
      variant: ^Create$|^UpdateExpanded$|^UpdateViaIdentityExpanded$
    remove: true
  - where:
      subject: DppResourceGuardProxy$
    set: 
      subject: ResourceGuardMapping
  - where:
      parameter-name: ResourceGuardProxyName
    hide: true 
    set:
      default:
        script: '"DppResourceGuardProxy"'
  - where:
      verb: New
      subject: ResourceGuardMapping
      parameter-name: LastUpdatedTime|Description|ResourceGuardOperationDetail
    hide: true
  - where:
      verb: Get
      subject: DeletedBackupVault
      variant: ^GetViaIdentity$
    hide: true
  - where:
      verb: Get
      subject: DeletedBackupVault
    set:
      subject: SoftDeletedBackupVault
  - where:
      verb: Get
      subject: DeletedBackupInstance
    set:
      verb: Get
      subject: SoftDeletedBackupInstance
  - where:
      verb: Restore
      subject: DeletedBackupInstance
    set:
      verb: Undo
      subject: BackupInstanceDeletion
  - where:
      subject: RecoveryPoint
      variant: List
    hide: true
  - where:
      verb: Get
      subject: RecoveryPointList.*
    hide: true
  - where:
      verb: Test
      subject: BackupVaultNameAvailability
    remove: true
  - where:
      verb: Test
      subject: FeatureSupport.*
    remove: true
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
      verb: Start
      subject: BackupInstanceRehydrate
    remove: true
  - where:
      verb: Start
      subject: ExportJob
    remove: true
  - where:
      verb: Start
      subject: .*Restore$
    hide: true
  - where:
      verb: Stop
      subject: ^BackupInstanceProtection$
      variant: Stop$|StopViaIdentityExpanded$
    remove: true
  - where:
      verb: Stop
      subject: ^BackupInstanceProtection$
      variant: StopExpanded$|StopViaIdentity$
    hide: true  
  - where:
      verb: Suspend
      subject: ^BackupInstanceBackup$
      variant: Suspend$|SuspendViaIdentityExpanded$
    remove: true
  - where:
      verb: Suspend
      subject: ^BackupInstanceBackup$
      variant: SuspendExpanded$|SuspendViaIdentity$
    hide: true
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
      verb: New
      subject: BackupVault
      parameter-name: Parameter
    set:
      parameter-name: Parameter
    clear-alias: true
  - where:
      verb: New
      subject: BackupVault
      variant: ^Create$
      parameter-name: Parameter
    required: false
  - where:
      verb: New
      subject: BackupVault
      variant: ^CreateExpanded$
      parameter-name: StorageSetting
    required: false
  - where:
      verb: Update
      subject: BackupVault
      variant: ^UpdateExpanded$
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
      variant: ^GetViaIdentity2$|^GetViaIdentity1$
    hide: true
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
      verb: New
      subject: ResourceGuardMapping$
    set:
      verb: Set
  - where:
      verb: Get
      subject: SoftDeletedBackupInstance
      parameter-name: BackupInstanceName
    set:
      parameter-description: The name of the deleted backup instance
  - where:
      verb: Undo
      subject: BackupInstanceDeletion
      parameter-name: BackupInstanceName
    set:
      parameter-description: The name of the deleted backup instance
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}/findRestorableTimeRanges"].post
    transform: $["description"] = "Finds the valid recovery point in time ranges for the restore."
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/deletedBackupInstances/{backupInstanceName}/undelete"].post
    transform: $["description"] = "Undeletes a soft deleted backup instance"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupInstances/{backupInstanceName}/validateForModifyBackup"].post
    transform: >
      $.responses["200"] = {
        "description": "Contains additional information like job Id",
        "schema": {
          "$ref": "#/definitions/OperationJobExtendedInfo"
        }
      }
  - where:
      verb: Test
      subject: BackupInstance
      variant: ^Validate1$|^ValidateExpanded1$|^ValidateViaIdentity1$|^ValidateViaIdentityExpanded1$
    set:
      subject: BackupInstanceRestore
  - where:
      verb: Test
      subject: BackupInstance
      variant: ^Validate2$|^ValidateExpanded2$|^ValidateViaIdentity2$|^ValidateViaIdentityExpanded2$
    set:
      subject: BackupInstanceReadiness
  - where:
      verb: Test
      subject: BackupInstance
      variant: ^Validate$|^ValidateExpanded$|^ValidateViaIdentity$|^ValidateViaIdentityExpanded$
    set:
      subject: BackupInstanceUpdate
  - where:
      verb: Test
      subject: BackupInstanceUpdate
      variant: ^Validate$|^ValidateViaIdentity$|^ValidateViaIdentityExpanded$
    hide: true
  - where:
      verb: Test
      subject: BackupInstanceReadiness
      variant: ^Validate2$|^ValidateViaIdentity2$|^ValidateViaIdentityExpanded2$
    hide: true
  - where:
      verb: Test
      subject: BackupInstanceRestore
      variant: ^Validate1$|^ValidateExpanded1$|^ValidateViaIdentity1$|^ValidateViaIdentityExpanded1$
    hide: true
  - where:
      verb: Test
      subject: BackupInstanceCrossRegionRestore
    hide: true
  - where:
      verb: Test
      subject: BackupInstanceUpdate
      parameter-name: Name
    set: 
      alias: 
        - BackupInstanceName
  - where:
      subject: FetchCrossRegionRestoreJob      
    set:
      subject: CrossRegionRestoreJob
  - where:      
      subject: CrossRegionRestoreJob
      variant: ^Get.*
    set:
      subject: CrossRegionRestoreJobDetail
  - where:
      verb: Get
      subject: ^Job$|^CrossRegionRestoreJob.*|FetchSecondaryRecoveryPoint
    hide: true
  - where:
      property-name: AzureMonitorAlertSettingAlertsForAllJobFailure
    set:
      property-name: AzureMonitorAlertsForAllJobFailure  
  - where:
      property-name: ResourceGuardResourceId
    set:
      property-name: ResourceGuardId  
  - where:
      property-name: VaultCriticalOperationExclusionList
    set:
      property-name: CriticalOperationExclusionList
  - where:
      property-name: ImmutabilitySettingState
    set:
      property-name: ImmutabilityState
  - where:
      property-name: SecuritySettingSoftDeleteSetting
    set:
      property-name: SoftDeleteSetting
  - where:
      property-name: CrossSubscriptionRestoreSettingState
    set:
      property-name: CrossSubscriptionRestoreState
  - where:
      property-name: CrossRegionRestoreSettingState
    set:
      property-name: CrossRegionRestoreState
  - where:
      property-name: SoftDeleteSettingRetentionDurationInDay
    set:
      property-name: SoftDeleteRetentionDurationInDay
  - where:
      property-name: SoftDeleteSettingState
    set:
      property-name: SoftDeleteState
  - where:
      property-name: SecuritySettingEncryptionSetting
    set:
      property-name: EncryptionSetting
  - where:
      property-name: InfrastructureEncryption
    set:
      property-name: CmkInfrastructureEncryption
  - where:
      property-name: KekIdentity
    set:
      property-name: CmkIdentity
  - where:
      property-name: KeyVaultProperty
    set:
      property-name: CmkKeyVaultProperty
  - where:
      subject: OperationStatus
      parameter-name: Location
    set:      
      parameter-description: Azure region where the operation is triggered.
  - where:
      subject: OperationStatus
      parameter-name: OperationId
    set:      
      parameter-description: Operation Id to track the operation status.
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
    - BackupInstance
    - CrossRegionRestoreDetails
    - CrossRegionRestoreRequestObject
    - DeletionInfo
    - EncryptionSettings
    - InnerError
    - ItemLevelRestoreTargetInfo
    - PolicyParameters
    - ResourceDeletionInfo
    - RestoreFilesTargetInfo
    - RestoreTargetInfo
    - RestoreTargetInfoBase
    - SecretStoreBasedAuthCredentials
    - SecretStoreResource    
    - SystemData
    - UserFacingError    
    - ValidateRestoreRequestObject
    - ValidateCrossRegionRestoreRequestObject
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBaseBackupPolicy Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBaseBackupPolicy Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.ITriggerContext Trigger', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.ITriggerContext Trigger');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBackupParameters BackupParameter', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBackupParameters BackupParameter');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IAzureBackupRecoveryPoint Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IAzureBackupRecoveryPoint Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.INamespacedNameResource ResourceModifierReference', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.INamespacedNameResource ResourceModifierReference');
```

## Alternate settings

This section is only activated if the `--make-it-rain` switch is added to the command line

``` yaml $(make-it-rain)
namespace: MyCompany.Special.Rest
```
