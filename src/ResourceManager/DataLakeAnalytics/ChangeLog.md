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