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

## Version 0.9.13
* This module is outdated and will go out of support on 29 February 2024.
* The Az.CognitiveServices module has all the capabilities of AzureRM.CognitiveServices and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.9.12

* Add Get-AzureRmCognitiveServicesAccountSkus operation.

## Version 0.9.11
* Support Get-AzureRmCognitiveServicesAccountSkus without an existing account.

## Version 0.9.10
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.9.9
* Fixed issue with default resource groups not being set.

## Version 0.9.8
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.9.7
* Updated all help files to include full parameter types and correct input/output types.

## Version 0.9.6
* Update examples for CognitiveServices cmdlets

## Version 0.9.5
* Set minimum dependency of module to PowerShell 5.0

## Version 0.9.4
* Updated to the latest version of the Azure ClientRuntime
* Integrate with Cognitive Services Management SDK version 4.0.0.
* Add Get-AzureRmCognitiveServicesAccountUsage operation.

## Version 0.9.3
* Fix issue with Default Resource Group in CloudShell

## Version 0.9.2
* Update notice.txt and notice message.

## Version 0.9.1
* Integrate with Cognitive Services Management SDK version 3.0.0.

## Version 0.9.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.8.7

## Version 0.8.6
* Integrate with Cognitive Services Management SDK version 2.0.0.
* Get-AzureRmCognitiveServicesAccount now can correctly support paging.

## Version 0.8.4

## Version 0.8.3

## Version 0.8.2

## Version 0.8.1
* Integrate with Cognitive Services Management SDK version 1.0.0.
* Fix an account name length checking bug.

## Version 0.8.0
* Update detailed display of license agreements when creating Cognitive Services resources

## Version 0.7.1

## Version 0.7.0

## Version 0.6.0

## Version 0.5.0

## Version 0.4.4
* Integrate with Cognitive Services Management SDK 0.2.1 to support more Cognitive Services API Types and SKUs.
* Remove the validation against “Type” and “SkuName” of Cognitive Services Account, this will allow the script to support new APIs/SKUs without changes.

## Version 0.4.3

## Version 0.4.2

## Version 0.4.1
