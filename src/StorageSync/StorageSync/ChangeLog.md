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

## Version 2.1.0
* Fixed minor issues.

## Version 2.0.0
* Deprecated "RegisteredServer" alias for InputObject parameter for Set-AzStorageSyncServerEndpoint

## Version 1.7.0
* Migrated Azure AD features in Az.StorageSync to MSGraph APIs. The cmdlets will call MSGraph API according to input parameters: New-AzStorageSyncCloudEndpoint
* Changed default parameter set of Invoke-AzStorageSyncChangeDetection to use full share detection

## Version 1.6.1
* Fixed a bug where not all properties of PSSyncSessionStatus and PSSyncActivityStatus objects were being populated properly.
* This affected the `Get-AzStorageSyncServerEndpoint` cmdlet when trying to access the following properties of the output:
    - SyncStatus.UploadStatus
    - SyncStatus.DownloadStatus
    - SyncStatus.UploadActivity
    - SyncStatus.DownloadActivity

## Version 1.6.0
* Added parameter sets to `Invoke-AzStorageSyncChangeDetection`
    - Can call the cmdlet without -DirectoryPath and -Path parameters to trigger change detection on an entire file share
* Added support for authoritative upload as part of New-AzStorageSyncServerEndpoint.
* Added cloud change enumeration status information in Cloud Endpoint object.
* Updated Server Endpoint object with various health properties
* Added "ServerName" property in Server Endpoint and Registered Server objects to support showing the current FQDN of a server.

## Version 1.5.0
* Deprecated `Invoke-AzStorageSyncFileRecall`
    - Customers should instead use `Invoke-StorageSyncFileRecall`, a cmdlet that is shipped with the Azure File Sync agent.
* Removed offline data transfer feature in `New-AzStorageSyncServerEndpoint`.

## Version 1.4.0
* Added Sync tiering policy feature with download policy and local cache mode

## Version 1.3.0
* Added a new version StorageSync SDK targeting ApiVersion 2020-03-01
* Added Update Storage Sync Service cmdlet
    - `Set-AzStorageSyncService`
* Added IncomingTrafficPolicy and PrivateEndpointConnections to StorageSyncService cmdlets.

## Version 1.2.3
* Updated supported character sets in `Invoke-AzStorageSyncCompatibilityCheck`.

## Version 1.2.2
* Update references in .psd1 to use relative path

## Version 1.2.1

* Fix Issue 9810 in Reset-AzStorageSyncServerCertificate.

## Version 1.2.0
* Adding Invoke-AzStorageSyncChangeDetection cmdlet.
* Fix Issue 9551 for honoring TierFilesOlderThanDays

## Version 1.1.1
* Fix Assembly Loading bug in PowerShell core

## Version 1.1.0
* Fix bug for not passing OFflineDataTransferProxy to SDK

## Version 1.0.0
* Replace Graph method for ensuring Service Principal in CloudEndpoint provisioning.

## Version 0.8.1
* Support for tracking upload and download sync activity in parallel

## Version 0.8.0
* Update all cmdlets required to manage StorageSync ARM resources.

## Version 0.7.1
* General availability of `Az.StorageSync` module
