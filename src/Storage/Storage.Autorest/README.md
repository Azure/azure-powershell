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
commit: ae38b76a7e681922a05b0b1e4d44cc725eb94802
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2024-01-01/storage.json
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2024-01-01/file.json

# For new RP, the version is 0.1.0
module-version: 5.9.1
# Normally, title is the service name
title: Storage
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true

# Pin to an old version to workaround a regression issue of generator. link to the issue - blabla
use-extension:
  "@autorest/powershell": "4.0.734"
 

directive:
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
      subject: ^StorageAccount$|^StorageAccountKey$|^StorageAccountProperty$|^StorageAccountSas$|^StorageAccountServiceSas$|BlobInventoryPolicy$|^DeletedAccount$|^EncryptionScope$|^LocalUser$|^LocalUserKey$|^ManagementPolicy$|^ObjectReplicationPolicy$|^Sku$|^Usage$|^LocalUserPassword$|^AccountUserDelegationKey$|^AbortStorageAccountHierarchicalNamespaceMigration$|^HierarchicalStorageAccountNamespaceMigration$|^StorageAccountBlobRange$|^StorageAccountUserDelegationKey$|^StorageAccountNameAvailability$|^FileShare$|^FileServiceProperty$|^FileService$
    remove: true
```
