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
* Add support for Compute Policy CRUD through the following commands:
    - New-AzureRMDataLakeAnalyticsComputePolicy
    - Get-AzureRMDataLakeAnalyticsComputePolicy
    - Remove-AzureRMDataLakeAnalyticsComputePolicy
    - Update-AzureRMDataLakeAnalyticsComputePolicy
* Add support for job relationship metadata for help with recurring jobs and job pipelines. The following commands were updated or added:
    - Submit-AzureRMDataLakeAnalyticsJob
    - Get-AzureRMDataLakeAnalyticsJob
    - Get-AzureRMDataLakeAnalyticsJobRecurrence
    - Get-AzureRMDataLakeAnalyticsJobPipeline
* Updated the token audience for job and catalog APIs to use the correct Data Lake specific audience instead of the Azure Resource audience.
    
## Version 3.1.0

## Version 3.0.1

## Version 3.0.0
* Add support for catalog package get and list
* Add support for listing the following catalog items from deeper ancestors:
  * Table
  * TVF
  * View
  * Statistics

## Version 2.8.0
* Fix help for some commands to have the proper verbage and examples.

## Version 2.7.0

## Version 2.6.0
* Add Firewall Rule support to Data Lake Analytics:
    - Add-AzureRMDataLakeAnalyticsFirewallRule
    - Get-AzureRMDataLakeAnalyticsFirewallRule
    - Set-AzureRMDataLakeAnalyticsFirewallRule
    - Remove-AzureRMDataLakeAnalyticsFirewallRule
    - Set-AzureRMDataLakeAnalyticsAccount supports enabling/disabling the firewall and allowing/blocking Azure originating IPs through the firewall
    - Warnings will be raised if updating firewall rules when the firewall is disabled
* Fix Get-AzureRMDataLakeAnalyticsJob functionality:
    - Top now correctly returns the number of jobs specified. The default number of jobs to return is 500. The more jobs requested the longer the command will take.
* Remove explicit restrictions on resource locations. If Data Lake Analytics is not supported in a region, we will surface an error from the service.

## Version 2.5.0
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