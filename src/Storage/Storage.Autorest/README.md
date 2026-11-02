<!-- region Generated -->
# Az.Storage
This directory contains the PowerShell module for the Storage service.

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
For information on how to develop for `Az.Storage`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation

```powershell
npx autorest@3.8.0 --version:3.9.7 --use:@autorest/powershell@4.0.754 --use:@autorest/modelerfour@4.26.0
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 548d44095be067632e36c74969cce42472ed1431
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/Storage/stable/2026-09-01/openapi.json

# For new RP, the version is 0.1.0
module-version: 5.9.1
# Normally, title is the service name
title: Storage
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true 

directive:
  # Prevent automatic singularization from truncating the context-cache noun.
  - where:
      subject: ^ContextCach$
    set:
      subject: ContextCache
  # Keep the availability check consistent with the context-cache noun.
  - where:
      subject: ^ContextCachNameAvailability$
    set:
      subject: ContextCacheNameAvailability
  # Avoid the generator's EName abbreviation for the context-cache resource name.
  - where:
      subject: ^ContextCache$
      parameter-name: EName
    set:
      parameter-name: Name
  # The resource is a metrics rule, not an individual metric.
  - where:
      subject: ^AdvancedPlatformMetric$
    set:
      subject: AdvancedPlatformMetricsRule
  # Distinguish testing a stored configuration from testing a proposed connection.
  - where:
      subject: ^BlobAccessPointConfigurationExistingConnection$
    set:
      subject: BlobAccessPointConfigurationConnection
  # Avoid repeating Test and ProposedConnection in the action noun.
  - where:
      subject: ^BlobAccessPointConnectionTestProposedConnection$
    set:
      subject: BlobAccessPointConnection
  # Keep the storage-account identity model distinct from the common ARM identity used by context caches.
  - from: managedidentity.json
    where: $.definitions.UserAssignedIdentity
    transform: $["x-ms-client-name"] = "ContextCacheUserAssignedIdentity";
  # Preserve the public tracked-resource update type name.
  - from: openapi.json
    where: $.definitions.TrackedResourceUpdate
    transform: $["x-ms-client-name"] = "AzureResourceManagerCommonTypesTrackedResourceUpdate";
  # Name the tag dictionary explicitly to preserve existing public model property types.
  - from: openapi.json
    where: $.definitions
    transform: |
      const tags = $.TrackedResourceUpdate.properties.tags;
      $.AzureResourceManagerCommonTypesTrackedResourceUpdateTags = tags;
      $.TrackedResourceUpdate.properties.tags = {
        "$ref": "#/definitions/AzureResourceManagerCommonTypesTrackedResourceUpdateTags",
        description: tags.description
      };
  # AutoRest does not turn the schema's TTL bounds into PowerShell parameter validation.
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public int TimeToLive', '[System.Management.Automation.ValidateRangeAttribute(1,30)]\n        public int TimeToLive');
  # Display Access Point objects without write-only credentials; request serialization still includes them.
  - from: source-file-csharp
    where: $
    transform: if ($.includes('partial class BlobAccessPoint')) { $ = $.replace('return ToJsonString();', 'return ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SerializationMode.IncludeRead)?.ToString();'); }
  # Complex polymorphic Access Point bodies need object and JSON variants as well as expanded inputs.
  - where:
      subject: ^(?!BlobAccessPoint).*
      variant: ^(Create|Update)(?!.*?Expanded|JsonFilePath|JsonString)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - from: swagger-document
    where: $.paths.["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/startAccountMigration"].post.operationId    
    transform: return "StartAccountMigration"
  - from: swagger-document
    where: $.definitions.StorageTaskAssignment  
    transform: $['required'] = ["properties"]
  - remove-operation: StorageAccounts_Update
  - remove-operation: FileShares_Lease
  - where:
      subject: ^StorageAccountCustomerInitiatedMigration$
    set:
      subject: StorageAccountMigration
  - where:
      verb: Start
      subject: AccountMigration
    hide: true
  - where:
      variant: ^Customer$|^CustomerViaIdentity$
    remove: true
  - where:
      parameter-name: StorageAccountMigrationDetailTargetSkuName
    set:
      parameter-name: TargetSku
  - where:
      verb: Get
      subject: ^StorageTaskAssignment$
      parameter-name: Top
    set:
      alias: Maxpagesize
  - where:
      subject: ^FileServiceUsage$
      parameter-name: AccountName
    set:
      parameter-name: StorageAccountName  
  - where:
      property-name: BurstingConstantBurstFloorIop
    set:
      property-name: BurstingConstantBurstFloorIops
  - where:
      property-name: FileShareLimitMaxProvisionedIop 
    set:
      property-name: FileShareLimitMaxProvisionedIops
  - where:
      property-name: FileShareLimitMinProvisionedIop
    set:
      property-name: FileShareLimitMinProvisionedIops
  - where:
      property-name: FileShareRecommendationBaseIop
    set:
      property-name: FileShareRecommendationBaseIops
  - where:
      property-name: LiveShareProvisionedIop
    set:
      property-name: LiveShareProvisionedIops
  - where:
      property-name: SoftDeletedShareProvisionedIop
    set:
      property-name: SoftDeletedShareProvisionedIops
  - where:
      property-name: StorageAccountLimitMaxProvisionedIop
    set:
      property-name: StorageAccountLimitMaxProvisionedIops
  # Generate Blob Access Point commands alongside the handwritten Blob cmdlets.
  - where:
      subject: ^(?!BlobAccessPoint).*Blob.*|.*Table.*|.*Queue.*|^Connector.*|^DataShare$|^StorageAccount$|^StorageAccountKey$|^StorageAccountProperty$|^StorageAccountSas$|^StorageAccountServiceSas$|BlobInventoryPolicy$|^DeletedAccount$|^EncryptionScope$|^LocalUser$|^LocalUserKey$|^ManagementPolicy$|^ObjectReplicationPolicy$|^Usage$|^LocalUserPassword$|^AccountUserDelegationKey$|^AbortStorageAccountHierarchicalNamespaceMigration$|^HierarchicalStorageAccountNamespaceMigration$|^StorageAccountBlobRange$|^StorageAccountUserDelegationKey$|^StorageAccountNameAvailability$|^FileShare$|^FileServiceProperty$|^FileService$
    remove: true  
  # Preserve the existing task-assignment command surface.
  - where:
      verb: Stop
      subject: StorageTaskAssignment
    remove: true 
  - where:
      parameter-name: ParameterEndBy
    set:
      parameter-name: EndBy
  - where:
      parameter-name: ParameterInterval
    set:
      parameter-name: Interval
  - where: 
      parameter-name: ParameterIntervalUnit
    set:
      parameter-name: IntervalUnit
  - where: 
      parameter-name: ParameterStartFrom
    set:
      parameter-name: StartFrom
  - where: 
      parameter-name: ParameterStartOn
    set:
      parameter-name: StartOn
  - where:
      property-name: ParameterEndBy
    set:
      property-name: EndBy
  - where:
      property-name: ParameterInterval
    set:
      property-name: Interval
  - where:
      property-name: ParameterIntervalUnit
    set:
      property-name: IntervalUnit
  - where:
      property-name: ParameterStartFrom
    set:
      property-name: StartFrom
  - where:
      property-name: ParameterStartOn
    set:
      property-name: StartOn
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/reports"].get
    transform: > 
      $["operationId"] = "StorageTaskAssignmentInstancesReport_List"
  # Renaming the operationId to StorageTaskAssignmentInstancesReport_Get, but the operation actually lists all the reports under a specific storage task assignment. 
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/storageTaskAssignments/{storageTaskAssignmentName}/reports"].get
    transform: > 
      $["operationId"] = "StorageTaskAssignmentInstancesReport_Get"
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/storageTaskAssignments/{storageTaskAssignmentName}/reports"].get
    transform: > 
      $["operationId"] = "StorageTaskAssignmentInstancesReport_Get"
  - where: 
      model-name: StorageTaskReportInstance
    set:
      suppress-format: true
  - where:
      model-name: ^SkuInformation$
    set:
      suppress-format: true
```
