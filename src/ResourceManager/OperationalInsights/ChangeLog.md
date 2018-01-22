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
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmOperationalInsightsSavedSearch, Set-AzureRmOperationalInsightsSavedSearch, New-AzureRmOperationalInsightsWorkspace, and Set-AzureRmOperationalInsightsWorkspace

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 3.4.1

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0
* Get-AzureRmOperationalInsightsSearchResults no longer requires the Top parameter to retrieve results

## Version 2.4.0

## Version 2.3.0
* Add new parameter to cmdlet New-AzureRmOperationalInsightsWindowsPerformanceCounterDataSource
    - UseLegacyCollector (switch parameter) will enable collection of 32-bit legacy performance counters on 64-bit machines
* Rename New-AzureRmOperationalInsightsAzureAuditDataSource to New-AzureRmOperationalInsightsAzureActivityLogDataSource (an alias for the old command was created)
* Get-AzureRmOperationalInsightsDataSource returns null instead of throwing an exception if not found
* New-AzureRmOperationalInsightsComputerGroup now supports defining a group simply by separating computer names with commas