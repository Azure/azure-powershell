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

## Version 0.1.5
* This module is outdated and will go out of support on 29 February 2024.
* The Az.ManagementPartner module has all the capabilities of AzureRM.ManagementPartner and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.1.4
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.1.3
* Updated all help files to include full parameter types and correct input/output types.

## Version 0.1.2
* Set minimum dependency of module to PowerShell 5.0

## Version 0.1.1
* Add Partner Name in the response for cmdlets: Get-AzureRmManagementPartner, New-AzureRmManagementPartner and Update-AzureRmManagementPartner
* Updated to the latest version of the Azure ClientRuntime

## Version 0.1.0
* First release of Management Partners cmdlets
