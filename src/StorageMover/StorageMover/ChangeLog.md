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

## Version 2.0.0
* Improved user experience and consistency. This may introduce breaking changes. Please refer to [here](https://go.microsoft.com/fwlink/?linkid=2340249).
* Remove parameter sets Create for cmdlet `New-AzStorageMover`, `New-AzStorageMoverProject`, `New-AzStorageMoverJobDefinition`
* Remove parameter sets Update and UpdateViaIdentity for Cmdlet `Update-AzStorageMover`, `Update-AzStorageMoverAgent`, `Update-AzStorageMoverJobDefinition`,  `Update-AzStorageMoverProject`

## Version 1.6.0
* Added  support for new api version 2025-07-01
* Included new endpoint types supported in the api version: `MultiCloudConnector`, `NFSFileShare`
* Enhanced help documentation for New-AzStorageMoverAzStorageContainerEndpoint and New-AzStorageMoverMultiCloudConnectorEndpoint with identity details.
* Corrected online version link for Update-AzStorageMoverAzNfsFileShareEndpoint help documentation.
* Added identity information to the output properties in help documentation for storage container and multi-cloud connector endpoints.

## Version 1.5.1
* Preannounced breaking changes. Please refer to https://go.microsoft.com/fwlink/?linkid=2333229

## Version 1.5.0
* Upgraded nuget package to signed package.

## Version 1.4.0
* Added input parameter validation set for UploadLimitWeeklyRecurrenceObject
* Supported Uploaded Limit Schedule

## Version 1.3.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.3.0
* Renamed SmbFileShare endpoint cmdlets

## Version 1.2.0
*  Supported SmbFileShareEndpoint and SmbEndpoint

## Version 1.0.1
* Fixed the issue of $Host conflicting with system parameter $Host

## Version 1.0.0
* General availability for module Az.StorageMover
* Updated StorageMover API version to 2023-03-01

## Version 0.1.0
* First preview release for module Az.StorageMover
