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
