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

## Version 2.3.0
* Supported sandbox custom image
* Supported database CMK
* Supported cluster migration

## Version 2.2.0
* Added cmdlet `Get-AzKustoSku`
* Added parameter `CallerRole` for cmdlet `AzKustoDatabase` and `Update-AzKustoDatabase`
* Added support for new data connection kind `CosmosDb` for cmdlet `New-AzKustoDataConnection` and `Update-AzKustoDataConnection`
* Added parameters `DatabaseNameOverride` `DatabaseNamePrefix` `TableLevelSharingPropertyFunctionsToInclude` `TableLevelSharingPropertyFunctionsToExclude` for cmdlet `New-AzKustoAttachedDatabaseConfiguration`

## Version 2.1.0
* Supported inline script resource (creation of script with content instead of sas token)
* Added managed identity support to EventGrid
* Added databaseRouting (Single/Multi) to all data connections
* Added PublicIPType to cluster

## Version 2.0.0
* Bumped API version to stable 2021-01-01

## Version 1.0.1
* Updated API version to 2020-09-18.

## Version 1.0.0
* General availability of 'Az.Kusto' module

## Version 0.2.0
* Updated API version to 2020-06-14; added new properties to data connection and cluster

## Version 0.1.4
* Supported new cmdlets

## Version 0.1.3
* Update references in .psd1 to use relative path

## Version 0.1.2
* Fixed miscellaneous typos across module

## Version 0.1.1
* Capacity is a new and optional parameter for Create and Update Cluster.
* ETag of Database is depricated.
* Cluster has new Properties: Uri, DataIngestionUri and Capacity.

## Version 0.1.0
* Initial version of the Kusto PowerShell interface
