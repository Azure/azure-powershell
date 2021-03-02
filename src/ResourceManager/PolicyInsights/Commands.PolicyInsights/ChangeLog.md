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

## Version 1.1.1
* This module is outdated and will go out of support on 29 February 2024.
* The Az.PolicyInsights module has all the capabilities of AzureRM.PolicyInsights and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 1.1.0
* Added policy remediation cmdlets

## Version 1.0.4
* Updated to the latest version of the Azure ClientRuntime.

## Version 1.0.3
* Updated help files to include full parameter types and correct input/output types.

## Version 1.0.2
* Fixed formatting of OutputType in help files

## Version 1.0.1
* Public release of Policy Insights cmdlets
    - Use API version 2018-04-04
    - Add PolicyDefinitionReferenceId to the results of Get-AzureRmPolicyStateSummary

## Version 0.9.1-preview
* Set minimum dependency of module to PowerShell 5.0

## Version 0.9.0-preview
* Public preview release of Policy Insights cmdlets
