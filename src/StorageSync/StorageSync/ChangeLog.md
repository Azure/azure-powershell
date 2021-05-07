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
* Deprecating Invoke-AzStorageSyncFileRecall.
    - Customers should instead use Invoke-StorageSyncFileRecall, a cmdlet that is shipped with the Azure File Sync agent.
* Remove offline data transfer feature.

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
