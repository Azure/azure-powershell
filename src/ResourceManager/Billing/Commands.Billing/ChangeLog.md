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

## Version 0.14.7
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Billing module has all the capabilities of AzureRM.Billing and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.14.6
* Updated common runtime assemblies

## Version 0.14.5
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.14.4
* Updated help files to include full parameter types and correct input/output types.

## Version 0.14.3
* Fixed formatting of OutputType in help files

## Version 0.14.2
* Set minimum dependency of module to PowerShell 5.0

## Version 0.14.1
* New Cmdlet Get-AzureRmEnrollmentAccount
  - cmdlet to retrieve enrollment accounts
* Updated to the latest version of the Azure ClientRuntime

## Version 0.14.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.13.7

## Version 0.13.6

## Version 0.13.4

## Version 0.13.3

## Version 0.13.2

## Version 0.13.1

## Version 0.13.0

## Version 0.12.1

## Version 0.12.0
* New Cmdlet Get-AzureRmBillingPeriod
    - cmdlet to retrieve azure billing periods of the subscription.
* Update Cmdlet Get-AzureRmBillingInvoice
    - new property BillingPeriodNames
    - output in list view

## Version 0.11.0

## Version 0.10.0
* New Cmdlet Get-AzureRmBillingInvoice
    - cmdlet to retrieve azure billing invoices of the subscription.
