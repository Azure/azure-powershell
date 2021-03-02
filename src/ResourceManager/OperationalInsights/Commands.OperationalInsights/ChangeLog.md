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

## Version 5.0.7
* This module is outdated and will go out of support on 29 February 2024.
* The Az.OperationalInsights module has all the capabilities of AzureRM.OperationalInsights and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.0.6
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.0.5
* Fixed issue with default resource groups not being set.

## Version 5.0.4
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.0.3
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.0.2
* Fixed formatting of OutputType in help files

## Version 5.0.1
* Updated PSWorkspace model to allow Network to use type as a parameter

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

## Version 4.3.2
* Updated to the latest version of the Azure ClientRuntime

## Version 4.3.1
* Fix issue with Default Resource Group in CloudShell
* Fixed issue with cleaning up scripts in build

## Version 4.3.0
* Fixed issue with importing aliases

## Version 4.2.0
* Added support for V2 API querying via Invoke-AzureRmOperationalInsightsQuery. See [https://dev.loganalytics.io/](https://dev.loganalytics.io/) for more info on the new API.

## Version 4.1.0
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
