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

## Version 1.0.11
* This module is outdated and will go out of support on 29 February 2024.
* The Az.ContainerRegistry module has all the capabilities of AzureRM.ContainerRegistry and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 1.0.10
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 1.0.9
* Fixed issue with default resource groups not being set.

## Version 1.0.8
* Updated to the latest version of the Azure ClientRuntime.

## Version 1.0.7
* Updated help files to include full parameter types and correct input/output types.

## Version 1.0.6
* Fixed formatting of OutputType in help files

## Version 1.0.5
* Set minimum dependency of module to PowerShell 5.0

## Version 1.0.4
* Decouple reliance on Commands.Resources.Rest and ARM/Storage SDKs.
* Updated to the latest version of the Azure ClientRuntime

## Version 1.0.3
* Fix issue with Default Resource Group in CloudShell

## Version 1.0.2
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 1.0.1
* New cmdlets for geo-replication and webhooks
    - Get/New/Remove-AzureRmContainerRegistryReplication
    - Get/New/Remove/Test/Update-AzureRmContainerRegistryWebhook

## Version 0.3.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.2.7

## Version 0.2.6

## Version 0.2.4

## Version 0.2.3

## Version 0.2.2

## Version 0.2.1

## Version 0.2.0

## Version 0.1.1

## Version 0.1.0
* Add PowerShell cmdlets for Azure Container Registry
    - New-AzureRmContainerRegistry
    - Get-AzureRmContainerRegistry
    - Update-AzureRmContainerRegistry
    - Remove-AzureRmContainerRegistry
    - Get-AzureRmContainerRegistryCredential
    - Update-AzureRmContainerRegistryCredential
    - Test-AzureRmContainerRegistryNameAvailability
