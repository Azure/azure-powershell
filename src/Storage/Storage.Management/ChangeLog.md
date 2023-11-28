<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release

## Version 6.0.0
* Supported customer initiated migration
* Supported creationTime filter in Blob Inventory
    - `New-AzStorageBlobInventoryPolicyRule`
* Supported traling dot in Azure file and directory name by default
    - `Close-AzStorageFileHandle`
    - `Get-AzStorageFile`
    - `Get-AzStorageFileCopyState`
    - `Get-AzStorageFileContent`
    - `Get-AzStorageFileHandle`
    - `New-AzStorageDirectory`
    - `Remove-AzStorageDirectory`
    - `Remove-AzStorageFile`
    - `Rename-AzStorageDirectory`
    - `Rename-AzStorageFile`
    - `Set-AzStorageFileContent`
    - `Start-AzStorageFileCopy`
    - `Stop-AzStorageFileCopy`
* Upgraded Azure.Core to 1.35.0.
* [Breaking Change] Removed prefix '?' of the created SAS token
    - `New-AzStorageBlobSasToken`
    - `New-AzStorageContainerSasToken`
    - `New-AzStorageAccountSasToken`
    - `New-AzStorageFileSasToken`
    - `New-AzStorageShareSasToken`
    - `New-AzStorageQueueSasToken`
    - `New-AzStorageTableSasToken`
* Migrated following Azure Queue dataplane cmdlets from 'Microsoft.Azure.Storage.Queue 11.2.2' to 'Azure.Storage.Queues 12.16.0'
    - `New-AzStorageQueue`
    - `Get-AzStorageQueue`
    - `Remove-AzStorageQueue`
    - `New-AzStorageQueueStoredAccessPolicy`
    - `Get-AzStorageQueueStoredAccessPolicy`
    - `Set-AzStorageQueueStoredAccessPolicy`
    - `Remove-AzStorageQueueStoredAccessPolicy`

## Version 5.10.1
* Added warning messages for an upcoming breaking change that the output Permissions will be changed to a string when creating and updating a Queue access policy
    - `Get-AzStorageQueueStoredAccessPolicy`
    - `Set-AzStorageQueueStoredAccessPolicy`

## Version 5.10.0
* Updated Azure.Core to 1.34.0.
* Added support for encryption context 
    - `New-AzDataLakeGen2Item`
* Updated warning messages for an upcoming breaking change when creating a storage account 
    - `New-AzStorageAccount`
* Updated help file of `New-AzStorageQueueSASToken`


## Version 5.9.0
* Supported OAuth authentication on File service cmdlets
    - `New-AzStorageContext`
    - `Get-AzStorageFile`
    - `Get-AzStorageFileContent`
    - `Get-AzStorageFileCopyState`
    - `New-AzStorageDirectory`
    - `Remove-AzStorageDirectory`
    - `Remove-AzStorageFile`
    - `Set-AzStorageFileContent`
    - `Start-AzStorageFileCopy`
    - `Stop-AzStorageFileCopy`
    - `Get-AzStorageFileHandle`
    - `Close-AzStorageFileHandle`
* Supported get a file share object without get share properties. For pipeline to file/directory cmdlets with OAuth authentication.
    - `Get-AzStorageShare`
* Updated Azure.Core to 1.33.0.


## Version 5.8.0
* Supported TierToCold and TierToHot in Storage account management policy
    - `Add-AzStorageAccountManagementPolicyAction`
* Supported Blob Tier Cold
    - `Copy-AzStorageBlob`
    - `Set-AzStorageBlobContent`
    - `Start-AzStorageBlobCopy`
* Migrated the following Azure Queue dataplane cmdlets from 'Microsoft.Azure.Storage.Queue' to 'Azure.Storage.Queue'
    - `New-AzStorageQueueSASToken`
* Added warning messages for an upcoming breaking change when creating SAS token
    - `New-AzStorageBlobSasToken`
    - `New-AzStorageContainerSasToken`
    - `New-AzStorageAccountSasToken`
    - `New-AzStorageContext`
    - `New-AzStorageFileSasToken`
    - `New-AzStorageShareSasToken`
    - `New-AzStorageQueueSasToken`
    - `New-AzStorageTableSasToken`
    - `New-AzDataLakeGen2SasToken`
* Added a warning message for an upcoming breaking change when creating a storage account
    - `New-AzStorageAccount`

## Version 5.7.0
* Fixed issue of getting a single blob with leading slashes
    - `Get-AzStorageBlob`
* Supported setting CORS rules in management plane cmdlets 
    - `Update-AzStorageBlobServiceProperty`
    - `Update-AzStorageFileServiceProperty`
* Fixed an issue of `StorageAccountName` field in context object when the context is invalid 
    - `New-AzStorageContext`
* Fixed an issue when a context does not have Credentials field
* Added `$blobchangefeed` to be a valid container name

## Version 5.6.0
* Supported rename file and directory
    - `Rename-AzStorageFile`
    - `Rename-AzStorageDirectory`
* Added a warning message for an upcoming breaking change when getting a single blob 
    - `Get-AzStorageBlob`
* Fixed the issue of listing blobs with leading slashes 
    - `Get-AzStorageBlob`
* Added support for sticky bit 
    - `New-AzDataLakeGen2Item`
    - `New-AzDataLakeGen2ACLObject`
    - `Update-AzDataLakeGen2Item`
* Added warning messages for an upcoming cmdlet breaking change 
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Allowed to clear blob tags on a blob 
    - `Set-AzStorageBlobTag`
* Updated Azure.Core to 1.31.0

## Version 5.5.0
* Supported create storage account with DnsEndpointType
    - `New-AzStorageAccount`
* Fixed file cmdlets potential context issue when the current context doesn't match with the credential of input Azure File object
    - `Close-AzStorageFileHandle`
    - `Get-AzStorageFile`
    - `Get-AzStorageFileContent`
    - `Get-AzStorageFileHandle`
    - `New-AzStorageDirectory`
    - `New-AzStorageFileSASToken`
    - `Remove-AzStorageDirectory`
    - `Remove-AzStorageFile`
    - `Remove-AzStorageShare`
    - `Set-AzStorageFileContent`
    - `Set-AzStorageShareQuota`
    - `Start-AzStorageFileCopy`

## Version 5.4.1
* Updated Azure.Core to 1.28.0.

## Version 5.4.0
* Added a warning message for the upcoming breaking change when creating a Storage account
    - `New-AzStorageAccount`
* Removed the ValidateSet of StandardBlobTier parameter
    - `Copy-AzStorageBlob`
    - `Set-AzStorageBlobContent` 
    - `Start-AzStorageBlobCopy`

## Version 5.3.0
* Returned ListBlobProperties in blob list result
    - `Get-AzStorageBlob`
* Returned AllowedCopyScope in get account result
    - `Get-AzStorageAccount`

## Version 5.2.0
* Supported MaxPageSize, Include, and Filter parameters for listing encryption scopes 
    - `Get-AzStorageEncryptionScope`
* Supported excludePrefix, includeDeleted, and many new schema fields in Blob Inventory
    - `New-AzStorageBlobInventoryPolicyRule`

## Version 5.1.0
* Supported generate DataLakeGen2 Sas token with Encryption scope
    -  `New-AzDataLakeGen2SasToken`
* Supported blob type conversions in sync blob copy
    - `Copy-AzStorageBlob`
* Supported create/upgrade storage account with Keyvault from another tenant and access Keyvault with FederatedClientId
  * `New-AzStorageAccount`
  * `Set-AzStorageAccount`
* Supported find blobs in a container with a blob tag filter sql expression
  * `Get-AzStorageBlobByTag`
* Migrated following Azure File dataplane cmdlets from 'Microsoft.Azure.Storage.File' to 'Azure.Storage.Files.Shares'
  * `Get-AzStorageFileHandle`
  * `Close-AzStorageFileHandle`

## Version 5.0.0
* Migrated following Azure File dataplane cmdlets from 'Microsoft.Azure.Storage.File 11.2.2' to 'Azure.Storage.Files.Shares 12.10.0'
  * `Get-AzStorageFile`
  * `Get-AzStorageFileCopyState`
  * `Get-AzStorageShare`
  * `Get-AzStorageShareStoredAccessPolicy`
  * `New-AzStorageDirectory`
  * `New-AzStorageFileSasToken`
  * `New-AzStorageShare`
  * `New-AzStorageShareSasToken`
  * `New-AzStorageShareStoredAccessPolicy`
  * `Remove-AzStorageDirectory`
  * `Remove-AzStorageFile`
  * `Remove-AzStorageShare`
  * `Remove-AzStorageShareStoredAccessPolicy`
  * `Set-AzStorageShareQuota`
  * `Set-AzStorageShareStoredAccessPolicy`
  * `Start-AzStorageFileCopy`
  * `Stop-AzStorageFileCopy`
* Migrated Get/List blob to always use 'Azure.Storage.Blobs'
  * `Get-AzStorageBlob`
* Fix create file sas failure with file object pipeline
  * `New-AzStorageFileSasToken`

## Version 4.9.0
* Supported to create or update Storage account with Azure Files Active Directory Domain Service Kerberos Authentication
    -  `New-AzStorageAccount`
    -  `Set-AzStorageAccount`
* Supported create/upgrade storage account by enable sftp and enable localuser
    -  `New-AzStorageAccount`
    -  `Set-AzStorageAccount`
* Supported manage local user of a storage account
    -  `Set-AzStorageLocalUser`
    -  `Get-AzStorageLocalUser`
    -  `Remove-AzStorageLocalUser`
    -  `New-AzStorageLocalUserSshPassword`
    -  `Get-AzStorageLocalUserKey`
    -  `New-AzStorageLocalUserSshPublicKey`
    -  `New-AzStorageLocalUserPermissionScope`
* Supported soft delete DataLake Gen2 item
    - `Get-AzDataLakeGen2DeletedItem`
    - `Restore-AzDataLakeGen2DeletedItem`

## Version 4.8.0
* Added check for storage account sas token is secured with the storage account key.
    -  `New-AzStorageAccountSASToken`
* Supported Management Policy rule filter BlobIndexMatch
    -  Added a new cmdlet `New-AzStorageAccountManagementPolicyBlobIndexMatchObject`
    -  Added a new parameter `BlobIndexMatch` in `New-AzStorageAccountManagementPolicyFilter`

## Version 4.7.0
* Supported BaseBlob DaysAfterCreationGreaterThan in Management Policy
    -  `Add-AzStorageAccountManagementPolicyAction`

## Version 4.6.0
* Supported generate Sas token for DataLakeGen2
    -  `New-AzDataLakeGen2SasToken`
* Showed OAuth token in debug log in debug build only
    -  `New-AzStorageContext`
* Supported return more file properties when list Azure file
    -  `Get-AzStorageFile`

## Version 4.5.0
* Supported DaysAfterLastTierChangeGreaterThan in Management Policy
    -  `Add-AzStorageAccountManagementPolicyAction`
* Fixed the issue that upload blob might fail on Linux [#17743]
    -  `Set-AzStorageBlobContent`
* Supported AllowPermanentDelete when enable blob soft delete
    - `Enable-AzStorageBlobDeleteRetentionPolicy`
* Added breaking change warning message for upcoming cmdlet breaking change
    - `Get-AzStorageFile`

## Version 4.4.1
* Fixed get blob by tag failure on Powershell 7.2.2
    -  `Get-AzStorageBlobByTag`

## Version 4.4.0
* Updated examples in reference documentation for `Close-AzStorageFileHandle`
* Supported create storage context with customized blob, queue, file, table service endpoint
    - `New-AzStorageContext`
* Fixed copy blob failure on Premium Storage account, or account enabled hierarchical namespace
    -  `Copy-AzStorageBlob` 
* Supported create account SAS token, container SAS token, blob  SAS token with EncryptionScope
    -  `New-AzStorageAccountSASToken` 
    -  `New-AzStorageContainerSASToken` 
    -  `New-AzStorageBlobSASToken` 
* Supported asynchronous blob copy run on new API version
    -  `Start-AzStorageBlobCopy`
* Fixed IpRule examples in help
    -  `Add-AzStorageAccountNetworkRule`
    -  `Remove-AzStorageAccountNetworkRule`
    -  `Update-AzStorageAccountNetworkRuleSet`

## Version 4.3.0
* Supported download blob from managed disk account with Sas Uri and bearer token
    -  `Get-AzStorageBlobContent` 
* Supported create/upgrade storage account with ActiveDirectorySamAccountName and ActiveDirectoryAccountType
    -  `New-AzStorageAccount`
    -  `Set-AzStorageAccount`

## Version 4.2.0
* Fixed the issue that output number in console when update/copy blob sometimes [#16783]
    -  `Set-AzStorageBlobContent` 
    -  `Copy-AzStorageBlob` 
* Updated help file, added more description for the asynchronous blob copy.
    -  `Start-AzStorageBlobCopy`

## Version 4.1.1
* Fixed the failure of sync copy blob with long destination blob name [#16628]
    -  `Copy-AzStorageBlob` 
* Supported AAD oauth storage context in storage table cmdlets.
    - `Get-AzStorageCORSRule`
    - `Get-AzStorageServiceLoggingProperty`
    - `Get-AzStorageServiceMetricsProperty`
    - `Get-AzStorageServiceProperty`
    - `Get-AzStorageTable`
    - `Get-AzStorageTableStoredAccessPolicy`
    - `New-AzStorageTable`
    - `New-AzStorageTableSASToken`
    - `New-AzStorageTableStoredAccessPolicy`
    - `Remove-AzStorageCORSRule`
    - `Remove-AzStorageTableStoredAccessPolicy`
    - `Set-AzStorageCORSRule`
    - `Set-AzStorageServiceLoggingProperty`
    - `Set-AzStorageServiceMetricsProperty`
    - `Set-AzStorageServiceProperty`
    - `Set-AzStorageTable`
    - `Set-AzStorageTableStoredAccessPolicy`

## Version 4.1.0
* Fixed the failure of `Get-AzStorageContainerStoredAccessPolicy` when permission is null [#15644]
* Supported create blob service Sas token or account Sas token with permission i
    -  `New-AzStorageBlobSASToken` 
    -  `New-AzStorageContainerSASToken` 
    -  `New-AzStorageAccountSASToken`
* Fixed creating container SAS token failed from an access policy without expire time, and set SAS token expire time [#16266]
    -  `New-AzStorageContainerSASToken` 
* Removed parameter -Name from Get-AzRmStorageShare ShareResourceIdParameterSet
    - `Get-AzRmStorageShare`
* Supported create or migrate container to enable immutable Storage with versioning.
    -  `New-AzRmStorageContainer`
    -  `Invoke-AzRmStorageContainerImmutableStorageWithVersioningMigration`
* Supported set/remove immutability policy on a Storage blob.
    -  `Set-AzStorageBlobImmutabilityPolicy`
    -  `Remove-AzStorageBlobImmutabilityPolicy`
* Supported enable/disable legal hold on a Storage blob.
    -  `Set-AzStorageBlobLegalHold`
* Supported create storage account with enable account level immutability with versioning, and create/update storage account with account level immutability policy.
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`

## Version 3.12.0
* Upgraded Azure.Storage.Blobs to 12.10.0
* Upgraded Azure.Storage.Files.Shares to 12.8.0
* Upgraded Azure.Storage.Files.DataLake to 12.8.0
* Upgraded Azure.Storage.Queues to 12.8.0
* Supported upgrade storage account to enable HierarchicalNamespace
    -  `Invoke-AzStorageAccountHierarchicalNamespaceUpgrade`
    -  `Stop-AzStorageAccountHierarchicalNamespaceUpgrade`
* Supported AccessTierInferred, Tags in blob inventory policy schema
    - `New-AzStorageBlobInventoryPolicyRule`
* Supported create/update storage account with PublicNetworkAccess enabled/disabled 
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported create/update storage blob container with RootSquash
    - `New-AzRmStorageContainer`
    - `Update-AzRmStorageContainer`
* Supported AllowProtectedAppendWriteAll in set container Immutability Policy, and add container LegalHold
    - `Set-AzRmStorageContainerImmutabilityPolicy`
    - `Add-AzRmStorageContainerLegalHold`

## Version 3.11.0
* Supported get/set blob tags on a specific blob
    -  `Get-AzStorageBlobTag`
    -  `Set-AzStorageBlobTag`
* Supported create destination blob with specific blob tags while upload/copy Blob
    -  `Set-AzStorageBlobContent`
    -  `Start-AzStorageBlobCopy`
* Supported list blobs across containers with a blob tag filter sql expression
    -  `Get-AzStorageBlobByTag`
* Supported list blobs inside a container and include Blob Tags
    -  `Get-AzStorageBlob`
* Supported run blob operation with blob tag condition, and fail the cmdlet when blob tag condition not match
    -  `Get-AzStorageBlob`
    -  `Get-AzStorageBlobContent`
    -  `Get-AzStorageBlobTag`
    -  `Remove-AzStorageBlob`
    -  `Set-AzStorageBlobContent`
    -  `Set-AzStorageBlobTag`
    -  `Start-AzStorageBlobCopy`
    -  `Stop-AzStorageBlobCopy`
* Generate blob sas token with new API version
    -  `New-AzStorageBlobSASToken` 
    -  `New-AzStorageContainerSASToken` 
    -  `New-AzStorageAccountSASToken`
* Fixed blob copy failure with OAuth credential when client and server has time difference [#15644]
    -  `Copy-AzStorageBlob` 
* Fixed remove Data Lake Gen2 item fail with readonly SAS token
    -  `Remove-AzDataLakeGen2Item` 
* Revised destination existing check in move Data Lake Gen2 item
    -  `Move-AzDataLakeGen2Item` 

## Version 3.10.0
* Supported Blob Last Access Time
    -  `Enable-AzStorageBlobLastAccessTimeTracking`
    -  `Disable-AzStorageBlobLastAccessTimeTracking`
    -  `Add-AzStorageAccountManagementPolicyAction`
* Made `Get-AzDataLakeGen2ChildItem` list all datalake gen2 items by default, instead of needing user to list chunk by chunk.
* Fixed BlobProperties is empty issue when using sas without prefix '?' [#15460]
* Fixed synchronously copy small blob failure [#15548]
    - `Copy-AzStorageBlob`

## Version 3.9.0
* Supported enable/disable Blob container soft delete
    -  `Enable-AzStorageContainerDeleteRetentionPolicy`
    -  `Disable-AzStorageContainerDeleteRetentionPolicy`
* Supported list deleted Blob containers
    -  `Get-AzRmStorageContainer`
    -  `Get-AzStorageContainer`
* Supported restore deleted Blob container
    -  `Restore-AzStorageContainer`
* Supported secure SMB setting in File service properties
    - `Update-AzStorageFileServiceProperty`
* Supported create account with EnableNfsV3
    - `New-AzStorageAccount`
* Supported input more copy blob parameters from pipeline [#15301]
    -  `Start-AzStorageBlobCopy`

## Version 3.8.0
* Supported create file share with NFS/SMB enabledEnabledProtocol and RootSquash, and update share with RootSquash
    - `New-AzRmStorageShare`
    - `Update-AzRmStorageShare`
* Supported enable Smb Multichannel on File service
    -  `Update-AzStorageFileServiceProperty`
* Fixed copy inside same account issue by access source with anonymous credential, when copy Blob inside same account with Oauth credential
* Removed StorageFileDataSmbShareOwner from value set of parameter DefaultSharePermission in create/update storage account
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`

## Version 3.7.0
* Supported file share snapshot
    - `New-AzRmStorageShare`
    - `Get-AzRmStorageShare`
    - `Remove-AzRmStorageShare`
* Supported remove file share with it's snapshot (leased and not leased), by default remove file share will fail when share has snapshot
    - `Remove-AzRmStorageShare`
* Supported Set/Get/Remove blob inventory policy
    - `New-AzStorageBlobInventoryPolicyRule`
    - `Set-AzStorageBlobInventoryPolicy`
    - `Get-AzStorageBlobInventoryPolicy`
    - `Remove-AzStorageBlobInventoryPolicy`
* Supported DefaultSharePermission in create/update storage account
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported AllowCrossTenantReplication in create/update storage account
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported Set Object Replication Policy with SourceAccount/DestinationAccount as Storage account resource Id
    - `Set-AzStorageObjectReplicationPolicy`
* Supported set SasExpirationPeriod as TimeSpan.Zero
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount
* Make sure the correct account name is used when create account credential
    - `New-AzStorageContext`

## Version 3.6.0
* Supported create/update storage account with KeyExpirationPeriod and SasExpirationPeriod
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported create/update storage account with keyvault encryption and access keyvault with user assigned identity
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported EdgeZone in create storage account
    - `New-AzStorageAccount`
* Fixed an issue that delete immutable blob will prompt incorrect message.
    - `Remove-AzStorageAccount`
* Allowed update Storage Account KeyVault properties by cleanup Keyversion to enable key auto rotation [#14769]
    - `Set-AzStorageAccount`
* Added breaking change warning message for upcoming cmdlet breaking change
    - `Remove-AzRmStorageShare`

## Version 3.5.1
* Fixed copy blob fail with source context as Oauth [#14662]
    -  `Start-AzStorageBlobCopy`

## Version 3.5.0
* Fixed an issue that list account from resource group won't use nextlink
    - `Get-AzStorageAccount`
* Supported ChangeFeedRetentionInDays when Enable ChangeFeed on Blob service
    - `Update-AzStorageBlobServiceProperty`

## Version 3.4.0
* Upgraded to Microsoft.Azure.Management.Storage 19.0.0, to support new API version 2021-01-01.
* Supported resource access rule in NetworkRuleSet
    - `Update-AzStorageAccountNetworkRuleSet`
    - `Add-AzStorageAccountNetworkRule`
    - `Remove-AzStorageAccountNetworkRule`
* Supported Blob version and Append Blob type in Management Policy
    - `Add-AzStorageAccountManagementPolicyAction`
    - `New-AzStorageAccountManagementPolicyFilter`
    - `Set-AzStorageAccountManagementPolicy`
* Supported create/update account with AllowSharedKeyAccess
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported create Encryption Scope with RequireInfrastructureEncryption
    - `New-AzStorageEncryptionScope`
* Supported copy block blob synchronously, with encryption scope
    - `Copy-AzStorageBlob`
* Fixed issue that Get-AzStorageBlobContent use wrong directory separator char on Linux and MacOS [#14234]

## Version 3.3.0
* Supported RoutingPreference settings in create/update Storage account
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Upgraded Azure.Storage.Blobs to 12.8.0
* Upgraded Azure.Storage.Files.Shares to 12.6.0
* Upgraded Azure.Storage.Files.DataLake to 12.6.0

## Version 3.2.1
* Fix ContinuationToken never null when list blob with -IncludeVersion
    - `Get-AzStorageBlob`

## Version 3.2.0
* Supported create/update/get/list EncryptionScope of a Storage account
    - `New-AzStorageEncryptionScope`
    - `Update-AzStorageEncryptionScope`
    - `Get-AzStorageEncryptionScope`
* Supported create container and upload blob with Encryption Scope setting
    - `New-AzRmStorageContainer`
    - `New-AzStorageContainer`
    - `Set-AzStorageBlobContent`

## Version 3.1.0
* Supported upload Azure File size up to 4 TiB
    - `Set-AzStorageFileContent`
* Upgraded Azure.Storage.Blobs to 12.7.0
* Upgraded Azure.Storage.Files.Shares to 12.5.0
* Upgraded Azure.Storage.Files.DataLake to 12.5.0
* Upgraded Azure.Storage.Queues to 12.5.0

## Version 3.0.0
* Removed obsolete property RestorePolicy.LastEnabledTime
    - `Enable-AzStorageBlobRestorePolicy`
    - `Disable-AzStorageBlobRestorePolicy`
    - `Get-AzStorageBlobServiceProperty`
    - `Update-AzStorageBlobServiceProperty`
* Change Type of DaysAfterModificationGreaterThan from int to int?
    - `Set-AzStorageAccountManagementPolicy`
    - `Get-AzStorageAccountManagementPolicy`
    - `Add-AzStorageAccountManagementPolicyAction`
    - `New-AzStorageAccountManagementPolicyRule`
* Supported create/update file share with access tier
    - `New-AzRmStorageShare`
    - `Update-AzRmStorageShare`
* Supported set/update/remove Acl recursively on Datalake Gen2 item 
    -  `Set-AzDataLakeGen2AclRecursive` 
    -  `Update-AzDataLakeGen2AclRecursive` 
    -  `Remove-AzDataLakeGen2AclRecursive`
* Supported Container access policy with new permission x,t
    -  `New-AzStorageContainerStoredAccessPolicy`
    -  `Set-AzStorageContainerStoredAccessPolicy`
* Changed the output of get/set Container access policy cmdlet, by change the child property Permission type from enum to String
    -  `Get-AzStorageContainerStoredAccessPolicy`
    -  `Set-AzStorageContainerStoredAccessPolicy`
* Fixed a sample script issue of set management policy with json
    -  `Set-AzStorageAccountManagementPolicy`

## Version 2.7.0
* Supported enable/disable/get share soft delete properties on file Service of a Storage account
    - `Update-AzStorageFileServiceProperty`
    - `Get-AzStorageFileServiceProperty`
* Supported list file shares include the deleted ones of a Storage account, and Get single file share usage
    - `Get-AzRmStorageShare`
* Supported restore a deleted file share
    - `Restore-AzRmStorageShare`
* Changed the cmdlets for modify blob service properties, won't get the original properties from server, but only set the modified properties to server.
    - `Enable-AzStorageBlobDeleteRetentionPolicy`
    - `Disable-AzStorageBlobDeleteRetentionPolicy`  
    - `Enable-AzStorageBlobRestorePolicy`
    - `Disable-AzStorageBlobRestorePolicy`
    - `Update-AzStorageBlobServiceProperty`
* Fixed help issue for New-AzStorageAccount parameter -Kind default value [#12189]
* Fixed issue by add example to show how to set correct ContentType in blob upload [#12989]

## Version 2.6.0
* Fixed upload blob fail by upgrade to Microsoft.Azure.Storage.DataMovement 2.0.0 [#12220]
* Supported Point In Time Restore
    - `Enable-AzStorageBlobRestorePolicy`
    - `Disable-AzStorageBlobRestorePolicy`
    - `New-AzStorageBlobRangeToRestore`
    - `Restore-AzStorageBlobRange`
* Supported get blob restore status of Storage account by run get-AzureRMStorageAccount with parameter -IncludeBlobRestoreStatus 
    - `Get-AzureRMStorageAccount`
* Added breaking change warning message for upcoming cmdlet output change
    - `Get-AzStorageContainerStoredAccessPolicy`
    - `Set-AzStorageContainerStoredAccessPolicy`
    - `Set-AzStorageAccountManagementPolicy`
    - `Get-AzStorageAccountManagementPolicy`
    - `Add-AzStorageAccountManagementPolicyAction`
    - `New-AzStorageAccountManagementPolicyRule`
* Upgraded Microsoft.Azure.Cosmos.Table SDK to 1.0.8

    
## Version 2.5.0
* Supported blob query acceleration
    -  `Get-AzStorageBlobQueryResult`
    -  `New-AzStorageBlobQueryConfig`
* Updated help file, added more description, and fixed typo
    -  `Start-AzStorageBlobCopy`
    -  `Get-AzDataLakeGen2Item`
* Fixed download blob fail when related sub directory not exist [#12592]
    -  `Get-AzStorageBlobContent`
* Supported Set/Get/Remove Object Replication Policy on Storage accounts
    - `New-AzStorageObjectReplicationPolicyRule`
    - `Set-AzStorageObjectReplicationPolicy`
    - `Get-AzStorageObjectReplicationPolicy`
    - `Remove-AzStorageObjectReplicationPolicy`
* Supported enable/disable ChangeFeed on Blob Service of a Storage account
    - `Update-AzStorageBlobServiceProperty`

## Version 2.4.0
* Supported create container/blob Sas token with new permission x,t
    -  `New-AzStorageBlobSASToken`
    -  `New-AzStorageContainerSASToken`
* Supported create account Sas token with new permission x,t,f
    -  `New-AzStorageAccountSASToken`
* Supported get single file share usage
    - `Get-AzRmStorageShare`
        
## Version 2.3.0
* Fixed the issue that UserAgent is not added for some data plane cmdlets.
* Supported create/update Storage account with MinimumTlsVersion and AllowBlobPublicAccess
    -  `New-AzStorageAccount`
    -  `Set-AzStorageAccount`
* Support enable/disable versioning on Blob Service of a Storage account
    - `Update-AzStorageBlobServiceProperty`
* Support list blobs with blob versions
    - `Get-AzStorageBlob`
* Support get/remove single blob snapshot or blob version
    - `Get-AzStorageBlob`
    - `Remove-AzStorageBlob`
* Support pipeline from blob object generated from Azure.Storage.Blobs V12
    - `Get-AzStorageBlobContent`
    - `New-AzStorageBlobSASToken`
    - `Remove-AzStorageBlob`
    - `Set-AzStorageBlobContent`
    - `Start-AzStorageBlobCopy`

## Version 2.2.0
* Supported create Storage account with RequireInfrastructureEncryption
    -  `New-AzStorageAccount`
* Moved the logic of loading Azure.Core to Az.Accounts

## Version 2.1.0
* Updated assembly version of data plane cmdlets

## Version 2.0.0
* Added `-AsJob` to get/list account cmdlet `Get-AzStorageAccount`
* Make KeyVersion to optional when update Storage account with KeyvaultEncryption, to support key auto-rotation
    - `Set-AzStorageAccount`
* Fixed remove Azure File Directory fail with pipeline
    - `Remove-AzStorageDirectory`
* Fixed [#9880]: Change NetWorkRule DefaultAction value defination to align with swagger.
	- `Update-AzStorageAccountNetworkRuleSet`
	- `Get-AzStorageAccountNetworkRuleSet`
* Fixed [#11624]: Skip duplicated rules when add NetworkRules, to avoid server failure
    - `Add-AzStorageAccountNetworkRule`
* Upgraded Microsoft.Azure.Cosmos.Table SDK to 1.0.7
* Added a warning message to remind user to list again with ContinuationToken when only part items are returned in list DataLake Gen2 Items,
    - `Get-AzDataLakeGen2ChildItem`
* Supported to create or update Storage account with Azure Files Active Directory Domain Service Authentication
    -  `New-AzStorageAccount`
    -  `Set-AzStorageAccount`
* Supported to new or list Kerberos keys of Storage account
    -  `New-AzStorageAccountKey`
    -  `Get-AzStorageAccountKey`
* Supported failover Storage account
    - `Invoke-AzStorageAccountFailover`
* Updated help of `Get-AzStorageBlobCopyState`
* Updated help of `Get-AzStorageFileCopyState` and `Start-AzStorageBlobCopy`
* Integrated Storage client library v12 to Queue and File cmdlets
* Changed output type from CloudFile to AzureStorageFile, the original output will become a child property of the new output
    - `Get-AzStorageFile`
    - `Remove-AzStorageFile`
    - `Get-AzStorageFileContent`
    - `Set-AzStorageFileContent`
    - `Start-AzStorageFileCopy`
* Changed output type from CloudFileDirectory to AzureStorageFileDirectory, the original output will become a child property of the new output
    - `New-AzStorageDirectory`
    - `Remove-AzStorageDirectory`
* Changed output type from CloudFileShare to AzureStorageFileShare, the original output will become a child property of the new output
    - `Get-AzStorageShare`
    - `New-AzStorageShare`
    - `Remove-AzStorageShare`
* Changed output type from FileShareProperties to AzureStorageFileShare, the original output will become a sub child property of the new output
    - `Set-AzStorageShareQuota`

## Version 1.14.0
* Added breaking change notice for Azure File cmdlets output change in a future release
* Supported new SkuName StandardGZRS, StandardRAGZRS when create/update Storage account
    - `New-AzStorageAccount`
    - `Set-AzStorageAccount`
* Supported DataLake Gen2 
    - `New-AzDataLakeGen2Item`
    - `Get-AzDataLakeGen2Item`
    - `Get-AzDataLakeGen2ChildItem`
    - `Move-AzDataLakeGen2Item`
    - `Set-AzDataLakeGen2ItemAclObject`
    - `Update-AzDataLakeGen2Item`
    - `Get-AzDataLakeGen2ItemContent`
    - `Remove-AzDataLakeGen2Item`

## Version 1.13.0
* Supported AllowProtectedAppendWrite in ImmutabilityPolicy
    - `Set-AzRmStorageContainerImmutabilityPolicy`
* Added breaking change warning message for AzureStorageTable type change in a future release
    - `New-AzStorageTable`
    - `Get-AzStorageTable`

## Version 1.12.0
* Support set Table/Queue Encryption Keytype in Create Storage Account
    - New-AzRmStorageAccount
* Show RequestId when StorageException don't have ExtendedErrorInformation
* Fix the Example 6 of cmdlet Start-AzStorageBlobCopy

## Version 1.11.0
* Add breaking change warning message for DefaultAction Value change in a future release
    - Update-AzStorageAccountNetworkRuleSet
* Support Get last sync time of Storage account by run get-AzureRMStorageAccount with parameter -IncludeGeoReplicationStats 
    - Get-AzureRMStorageAccount

## Version 1.10.0
* Update references in .psd1 to use relative path
* Support generate Blob/Constainer Idenity based SAS token with Storage Context based on Oauth authentication
    - New-AzStorageContainerSASToken
    - New-AzStorageBlobSASToken
* Support revoke Storage Account User Delegation Keys, so all Idenity SAS tokens are revoked
    - Revoke-AzStorageAccountUserDelegationKeys
* Upgrade to Microsoft.Azure.Management.Storage 14.2.0, to support new API version 2019-06-01.
* Support Share QuotaGiB more than 5120 in Management plane File Share cmdlets, and add parameter alias "Quota" to parameter "QuotaGiB" 
	- New-AzRmStorageShare
	- Update-AzRmStorageShare
* Add parameter alias "QuotaGiB" to parameter "Quota"
	- Set-AzStorageShareQuota
* Fix the issue that Set-AzStorageContainerAcl can clean up the stored Access Policy
	- Set-AzStorageContainerAcl

## Version 1.9.0
* Support enable Large File share when create or update Storage account
    -  New-AzStorageAccount
    -  Set-AzStorageAccount
* When close/get File handle, skip check the input path is File directory or File, to avoid failure with object in DeletePending status
    -  Get-AzStorageFileHandle
    -  Close-AzStorageFileHandle

## Version 1.8.0
* Upgrade Storage Client Library to 11.1.0
* List containers with Management plane API, will list with NextPageLink
    -  Get-AzRmStorageContainer
* List Storage accounts from subscription, will list with NextPageLink
    -  Get-AzStorageAccount

## Version 1.7.0
* Updated example in reference documentation for `Get-AzStorageAccountKey`
* In upload/Downalod Azure File,support perserve the source File SMB properties (File Attributtes, File Creation Time, File Last Write Time) in the destination file
    -  Set-AzStorageFileContent
    -  Get-AzStorageFileContent
* Fix Upload block blob with properties/metadate fail on container enabled ImmutabilityPolicy.
    -  Set-AzStorageBlobContent
* Support manage Azure File shares with Management plane API
    -  New-AzRmStorageShare
    -  Get-AzRmStorageShare
    -  Update-AzRmStorageShare
    -  Remove-AzRmStorageShare

## Version 1.6.0
* Fixed miscellaneous typos across module
* Update help for Get/Close-AzStorageFileHandle, by add more scenarios to cmdlet examples and update parameter descriptions
* Support StandardBlobTier in upload blob and copy blob
    -  Set-AzStorageBlobContent
    -  Start-AzStorageBlobCopy
* Support Rehydrate Priority in copy blob
    -  Start-AzStorageBlobCopy

## Version 1.5.1
* Update example in reference documentation for `Get-AzStorageAccount` to use correct parameter name

## Version 1.5.0
* Change 2 parameters "-IndexDocument" and "-ErrorDocument404Path" from required to optional  in cmdlet:
    -  Enable-AzStorageStaticWebsite
* Update help of Get-AzStorageBlobContent by add an example
* Show more error information when cmdlet failed with StorageException 
* Support create or update Storage account with Azure Files AAD DS Authentication
    -  New-AzStorageAccount
    -  Set-AzStorageAccount
* Support list or close file handles of a file share, file directory or a file
    - Get-AzStorageFileHandle
    - Close-AzStorageFileHandle

## Version 1.4.0
* Support Kind FileStorage and SkuName Premium_ZRS when create Storage account
    - New-AzStorageAccount
* Clarified description of blob immutability cmdlet
    -  Remove-AzRmStorageContainerImmutabilityPolicy

## Version 1.3.0
* Upgrade to Storage Client Library 10.0.1 (the namespace of all objects from this SDK change from "Microsoft.WindowsAzure.Storage.*" to "Microsoft.Azure.Storage.*")
* Upgrade to Microsoft.Azure.Management.Storage 11.0.0, to support new API version 2019-04-01.
* The default Storage account Kind in Create Storage account change from 'Storage' to 'StorageV2'
    - New-AzStorageAccount
* Change the Storage account cmdlet output Sku.Name to be aligned with input SkuName by add '-', like "StandardLRS" change to "Standard_LRS"
    - New-AzStorageAccount
    - Get-AzStorageAccount
    - Set-AzStorageAccount

## Version 1.2.0
* Report detail error when create Storage context with parameter -UseConnectedAccount, but without login Azure account
    - New-AzStorageContext
* Support Manage Blob Service Properties of a specified Storage account with Management plane API
    - Update-AzStorageBlobServiceProperty
    - Get-AzStorageBlobServiceProperty
    - Enable-AzStorageBlobDeleteRetentionPolicy
    - Disable-AzStorageBlobDeleteRetentionPolicy
* -AsJob support for Blob and file upload and download cmdlets
    - Get-AzStorageBlobContent
    - Set-AzStorageBlobContent
    - Get-AzStorageFileContent
    - Set-AzStorageFileContent

## Version 1.1.0
* Support Get/Set/Remove Management Policy on a Storage account
    - Set-AzStorageAccountManagementPolicy
    - Get-AzStorageAccountManagementPolicy
    - Remove-AzStorageAccountManagementPolicy
    - Add-AzStorageAccountManagementPolicyAction
    - New-AzStorageAccountManagementPolicyFilter
    - New-AzStorageAccountManagementPolicyRule

## Version 1.0.4
* Upgrade to Storage Client Library 9.4.2 and Microsoft.Azure.Cosmos.Table 0.10.1-preview

## Version 1.0.3
* Support Kind BlockBlobStorage when create Storage account
       - New-AzStorageAccount

## Version 1.0.2
* Update incorrect online help URLs
* Give detail error message when get/set classic Logging/Metric on Premium Storage Account, since Premium Storage Account not supoort classic Logging/Metric.
    - Get/Set-AzStorageServiceLoggingProperty
    - Get/Set-AzStorageServiceMetricsProperty

## Version 1.0.1
* Set the StorageAccountName of Storage context as the real Storage Account Name, when it's created with Sas Token, OAuth or Anonymous
    - New-AzStorageContext
* Create Sas Token of Blob Snapshot Object with '-FullUri' parameter, fix the returned Uri to be the sanpshot Uri
    - New-AzStorageBlobSASToken

## Version 1.0.0
* General availability of `Az.Storage` module
