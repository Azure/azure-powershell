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
commit: 3e6b4ddca225530c27273d0f816466a905c0151b
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storage/resource-manager/Microsoft.Storage/stable/2023-01-01/storage.json

# For new RP, the version is 0.1.0
module-version: 5.9.1
# Normally, title is the service name
title: Storage
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true

directive:
  - from: swagger-document
    where: $.paths.["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/startAccountMigration"].post.operationId    
    transform: return "StartAccountMigration"
  - remove-operation: StorageAccounts_Update
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
      subject: ^StorageAccount$|^StorageAccountKey$|^StorageAccountProperty$|^StorageAccountSas$|^StorageAccountServiceSas$|BlobInventoryPolicy$|^DeletedAccount$|^EncryptionScope$|^LocalUser$|^LocalUserKey$|^ManagementPolicy$|^ObjectReplicationPolicy$|^Sku$|^Usage$|^LocalUserPassword$|^AccountUserDelegationKey$|^AbortStorageAccountHierarchicalNamespaceMigration$|^HierarchicalStorageAccountNamespaceMigration$|^StorageAccountBlobRange$|^StorageAccountUserDelegationKey$|^StorageAccountNameAvailability$
    remove: true
```
