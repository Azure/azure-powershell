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

## Version 0.1.9
* This module is outdated and will go out of support on 29 February 2024.
* The Az.ApplicationInsights module has all the capabilities of AzureRM.ApplicationInsights and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.1.8
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.1.7
* Fixed issue with default resource groups not being set.

## Version 0.1.6
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.1.5
* Updated help files to include full parameter types and correct input/output types.

## Version 0.1.4
* Set minimum dependency of module to PowerShell 5.0

## Version 0.1.3
* Updated to the latest version of the Azure ClientRuntime

## Version 0.1.2
* Fix issue with Default Resource Group in CloudShell

## Version 0.1.1
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.1.0
* Add commands to get/create/remove applicaiton insights resource
    - Get-AzureRmApplicationInsights
    - New-AzureRmApplicationInsights
    - Remove-AzureRmApplicationInsights
* Add commands to get/update pricing/daily cap of applicaiton insights resource
    - Get-AzureRmApplicationInsights -IncludeDailyCap
    - Set-AzureRmApplicationInsightsPricingPlan
    - Set-AzureRmApplicationInsightsDailyCap
* Add commands to get/create/update/remove continuous export of applicaiton insights resource
	- Get-AzureRmApplicationInsightsContinuousExport
	- Set-AzureRmApplicationInsightsContinuousExport
    - New-AzureRmApplicationInsightsContinuousExport
	- Remove-AzureRmApplicationInsightsContinuousExport
* Add commands to get/create/remove api keys of applicaiton insights resoruce
	- Get-AzureRmApplicationInsightsApiKey
	- New-AzureRmApplicationInsightsApiKey
	- Remove-AzureRmApplicationInsightsApiKey
