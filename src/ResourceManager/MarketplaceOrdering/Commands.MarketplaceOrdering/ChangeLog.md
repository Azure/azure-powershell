﻿<!--
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
* Microsoft Azure PowerShell – MarketplaceOrdering service cmdlets.
* This module is outdated and will go out of support on 29 February 2024.
* The Az.MarketplaceOrdering module has all the capabilities of AzureRM.MarketplaceOrdering and provides the following improvements:
    - Az.MarketplaceOrdering takes advantage of greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://aka.ms/azpsmigrate) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://aka.ms/azpsmigratequick).

## Version 0.2.6
* update the examples description for marketplace cmdlets

## Version 0.2.5
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.2.4
* Updated help files to include full parameter types and correct input/output types.

## Version 0.2.3
* Fixed formatting of OutputType in help files

## Version 0.2.2
* Set minimum dependency of module to PowerShell 5.0

## Version 0.2.1
* Updated to the latest version of the Azure ClientRuntime

## Version 0.2.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.1.0
* New Cmdlet Get-AzureRmMarketplaceTerms
    - Get the agreement terms of a given publisher id, offer id and plan id.
* New Cmdlet Set-AzureRmMarketplaceTerms
	- Accept or reject agreement terms of a give publisher id, offer id and plan id. Please use Get-AzureRmMarketplaceTerms to get the agreement terms.