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

## Version 4.1.5
* This module is outdated and will go out of support on 29 February 2024.
* The Az.LogicApp module has all the capabilities of AzureRM.LogicApp and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 4.1.4
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 4.1.3
* Fixed issue with default resource groups not being set.

## Version 4.1.2
* Updated to the latest version of the Azure ClientRuntime.

## Version 4.1.1
* Updated all help files to include full parameter types and correct input/output types.

## Version 4.1.0
* Fixed "parameter set could not be resolved" error in New-AzureRmLogicApp

## Version 4.0.5
* Fixed formatting of OutputType in help files

## Version 4.0.4
* Set minimum dependency of module to PowerShell 5.0
* Stop-AzureRmLogicAppRun example documentation fix

## Version 4.0.3
* Updated to the latest version of the Azure ClientRuntime

## Version 4.0.2
* Fix issue with Default Resource Group in CloudShell

## Version 4.0.1
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

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
* New parameters for Interchange Control Number disaster recovery cmdlets:
    - Optional -AgreementType parameter ("X12", or "Edifact") to specify the relevant control numbers

## Version 2.8.0
* Set-AzureRmIntegrationAccountSchema and Set-AzureRmIntegrationAccountMap cmdlets are fixed for the contentlink issue(Both content and contentlink were set resulting in update failure).

## Version 2.7.0
* New cmdlets for X12 Interchange Control Number disaster recovery:
    - Get-AzureRmIntegrationAccountGeneratedIcn
    - Get-AzureRmIntegrationAccountReceivedIcn
    - Remove-AzureRmIntegrationAccountReceivedIcn
    - Set-AzureRmIntegrationAccountGeneratedIcn
    - Set-AzureRmIntegrationAccountReceivedIcn

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
