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
* Introduced various new features by upgrading code generator. Please see details [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).
* Added breaking change announcement for `Get-AzStorageMoverAgent` and `Update-AzStorageMoverAgent` cmdlets from fixed array to list.
* Added unexpanded parameter sets deprecated breaking change announcement for below cmdlets.
  * parameter sets Create for cmdlet `New-AzStorageMover`, `New-AzStorageMoverProject`, `New-AzStorageMoverJobDefinition`
  * parameter sets Update and UpdateViaIdentity for Cmdlet `Update-AzStorageMover`, `Update-AzStorageMoverAgent`, `Update-AzStorageMoverJobDefinition`,  `Update-AzStorageMoverProject`
* Added  support for new api version 2025-07-01
* Included new endpoint types supported in the api version
    * MultiCloudConnector
    * NFSFileShare

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
