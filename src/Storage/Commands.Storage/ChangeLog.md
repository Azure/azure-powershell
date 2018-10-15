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

## Version 4.6.1
* Fix Copy Blob/File won't copy metadata when destination has metadata issue
    - Start-AzureStorageBlobCopy
    - Start-AzureStorageFileCopy
	
## Version 4.6.0
* Upgrade to Azure Storage Client Library 9.3.0 and Azure Storage DataMovement Library 0.8.1
* Support create Storage Context with OAuth. 
	- New-AzureStorageContext

## Version 4.5.0
* Remove the 5TB limitation for Azure File Share quota
- Set-AzureStorageShareQuota

## Version 4.4.0
* Updated all help files to include full parameter types and correct input/output types.
* Updated to the latest version of the Azure ClientRuntime.
* Support get Storage Context from DefaulfProfile
* Add Ps1XmlAttribute to cmdlets output types properties.

## Version 4.3.2
* Support Upload Blob or File with write only Sas token
- Set-AzureStorageBlobContent
- Set-AzureStorageFileContent

## Version 4.3.1
* Added additional information about -Permissions parameter in help files.

## Version 4.3.0
* Set minimum dependency of module to PowerShell 5.0
* Support $web as Storage blob container name
	- New-AzureStorageBlobContainer
	- Remove-AzureStorageBlobContainer
	- Set-AzureStorageBlobContent
	- Get-AzureStorageBlobContent
* Fix the issue that some Storage cmdlets failure output not contain detail failure information

## Version 4.2.1
* Fix the issue that upload Blob and upload File cmdlets fail on FIPS policy enabled machines
	- Set-AzureStorageBlobContent
	- Set-AzureStorageFileContent
* Updated to the latest version of the Azure ClientRuntime

## Version 4.2.0
* Support Soft-Delete feature
	- Enable-AzureStorageDeleteRetentionPolicy
	- Disable-AzureStorageDeleteRetentionPolicy
	- Get-AzureStorageBlob

## Version 4.1.1
* Fix Get Blob Container cmdlet execute fail with Accout SAS credential issue
	- Get-AzureStorageContainer

## Version 4.1.0
* Add cmdlets to get and set Storage service properties
	- Get-AzureStorageServiceProperty
	- Update-AzureStorageServiceProperty

## Version 4.0.2
* Upgrade to Azure Storage Client Library 8.6.0 and Azure Storage DataMovement Library 0.6.5

## Version 4.0.0
* Upgrade to Azure Storage Client Library 8.5.0 and Azure Storage DataMovement Library 0.6.3
* Add File Share Snapshot Support Feature
    - Add 'SnapshotTime' parameter to Get-AzureStorageShare
    - Add 'IncludeAllSnapshot' parameter to Remove-AzureStorageShare
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0
* Upgrade to Azure Storage Client Library 8.4.0 and Azure Storage DataMovement Library 0.6.1
* Add PremiumPageBlobTier Support in Upload and Copy Blob API
    - Set-AzureStorageBlobContent
	- Start-AzureStorageBlobCopy
* Refine the Console Output Format of AzureStorageContainer, AzureStorageBlob, AzureStorageQueue, AzureStorageTable
    - Get-AzureStorageContainer
    - Get-AzureStorageBlob
    - Get-AzureStorageQueue
    - Get-AzureStorageTable

## Version 3.3.1

## Version 3.3.0

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
