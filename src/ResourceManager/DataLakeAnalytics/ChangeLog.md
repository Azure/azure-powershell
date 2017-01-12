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
* Update Get-AdlJob to support Top parameter
* Update Get-AdlJob to return the list of jobs in order by most recently submitted
* Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
* Update New-AdlAnalyticsAccount and Set-AdlAnalyticsAccount to support commitment tier options for the service.
* Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.

## Version 2.4.0
* Removal of unsupported parameters in Add and Set-AzureRMDataLakeAnalyticsDataSource (default for data lake store)
* Removed unsupported parameter in Set-AzureRMDataLakeAnalyticsAccount (default data lake store)
* Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
* Added the ability to set MaxDegreeOfParallelism, MaxJobCount and QueryStoreRetention in New and Set-AzureRMDataLakeAnalyticsAccount
* Removed invalid return value from New-AzureRMDataLakeAnalyticsCatalogSecret

## Version 2.3.0
* Addition of Catalog CRUD cmdlets:
    - The following cmdlets are replacing Secret CRUD cmdlets. In the next release Secret CRUD cmdlets will be removed.
    - New-AzureRMDataLakeAnalyticsCatalogCredential
    - Set-AzureRMDataLakeAnalyticsCatalogCredential
    - Remove-AzureRMDataLakeAnalyticsCatalogCredential
* Fixes for Get-AzureRMDataLakeAnalyticsCatalogItem
    - Better error messaging and support for invalid input
* General help improvements
    - Clearer help for job operations
    - Fixed typos and incorrect examples