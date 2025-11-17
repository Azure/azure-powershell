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

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 04b87408ba3b8afed159b3d3059bd1594c7f2dd3
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/storage.json
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/file.json
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/storageTaskAssignments.json
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2025-01-01/networkSecurityPerimeter.json

# For new RP, the version is 0.1.0
module-version: 5.9.1
# Normally, title is the service name
title: Storage
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true 

directive:
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|JsonFilePath|JsonString)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - from: swagger-document
    where: $.paths.["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/startAccountMigration"].post.operationId    
    transform: return "StartAccountMigration"
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
  - where:
      subject: ^StorageAccount$|^StorageAccountKey$|^StorageAccountProperty$|^StorageAccountSas$|^StorageAccountServiceSas$|BlobInventoryPolicy$|^DeletedAccount$|^EncryptionScope$|^LocalUser$|^LocalUserKey$|^ManagementPolicy$|^ObjectReplicationPolicy$|^Usage$|^LocalUserPassword$|^AccountUserDelegationKey$|^AbortStorageAccountHierarchicalNamespaceMigration$|^HierarchicalStorageAccountNamespaceMigration$|^StorageAccountBlobRange$|^StorageAccountUserDelegationKey$|^StorageAccountNameAvailability$|^FileShare$|^FileServiceProperty$|^FileService$
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
  - from: storageTaskAssignments.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/reports"].get
    transform: > 
      $["operationId"] = "StorageTaskAssignmentInstancesReport_List"
  # Renaming the operationId to StorageTaskAssignmentInstancesReport_Get, but the operation actually lists all the reports under a specific storage task assignment. 
  - from: storageTaskAssignments.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/storageTaskAssignments/{storageTaskAssignmentName}/reports"].get
    transform: > 
      $["operationId"] = "StorageTaskAssignmentInstancesReport_Get"
  - from: storageTaskAssignments.json
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
