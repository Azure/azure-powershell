<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 3.2.1

## Version 3.2.0

## Version 3.1.0

* Update help for parameters that accept wildcard characters and update StorageContext type

## Version 3.0.2

## Version 3.0.1
* Fix issue with New-AzureStorageContext in offline scenarios: https://github.com/Azure/azure-powershell/issues/3939

## Version 3.0.0
* Upgrade to Azure Storage Client Library 8.1.1 and Azure Storage DataMovement Library 0.5.1
* Add a new cmdlet to support blob Incremental Copy feature
    - Start-AzureStorageBlobIncrementalCopy
## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0
* Fix Start-AzureStorageBlobCopy output might has wrong BlobType issue
    - Start-AzureStorageBlobCopy
* Fix hang issue when running cmdlets from WPF/Winform context  
    - Get-AzureStorageBlob
    - Get-AzureStorageBlobContent
    - Get-AzureStorageBlobCopyState
    - Get-AzureStorageContainer
    - Get-AzureStorageContainerStoredAccessPolicy
    - New-AzureStorageContainer
    - Remove-AzureStorageBlob
    - Remove-AzureStorageContainer
    - Set-AzureStorageBlobContent
    - Set-AzureStorageContainerAcl
    - Start-AzureStorageBlobCopy
    - Stop-AzureStorageBlobCopy
    - Get-AzureStorageFile
    - Get-AzureStorageFileContent
    - Get-AzureStorageFileCopyState
    - Get-AzureStorageShare
    - Get-AzureStorageShareStoredAccessPolicy
    - New-AzureStorageDirectory
    - New-AzureStorageShare
    - Remove-AzureStorageDirectory
    - Remove-AzureStorageFile
    - Remove-AzureStorageShare
    - Set-AzureStorageFileContent
    - Start-AzureStorageFileCopy
    - Stop-AzureStorageFileCopy
    - Get-AzureStorageQueueStoredAccessPolicy
    - Get-AzureStorageTableStoredAccessPolicy

## Version 2.3.0

## Version 2.2.0