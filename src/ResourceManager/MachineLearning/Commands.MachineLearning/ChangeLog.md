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

## Version 0.18.6
* This module is outdated and will go out of support on 29 February 2024.
* The Az.MachineLearning module has all the capabilities of AzureRM.MachineLearning and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.18.5
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.18.4
* Fixed issue with default resource groups not being set.

## Version 0.18.3
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.18.2
* Updated help files to include full parameter types and correct input/output types.

## Version 0.18.1
* Fixed formatting of OutputType in help files

## Version 0.18.0
* Set minimum dependency of module to PowerShell 5.0
* Remove deprecated `Tags` alias from cmdlets
    - Update-AzureRmMlCommitmentPlan

## Version 0.17.2
* Updated to the latest version of the Azure ClientRuntime

## Version 0.17.1
* Fix issue with Default Resource Group in CloudShell

## Version 0.17.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Update-AzureRmMlCommitmentPlan

## Version 0.16.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.15.7

## Version 0.15.6

## Version 0.15.4

## Version 0.15.3

## Version 0.15.2

## Version 0.15.1

## Version 0.15.0

## Version 0.14.1

## Version 0.14.0
* Consume new version of Azure Machine Learning .Net SDK and add a new cmdlet
    - Add-AzureRmMlWebServiceRegionalProperty
* Minor wording fixes in help text.

## Version 0.13.0

## Version 0.12.0

## Version 0.11.4

## Version 0.11.3

## Version 0.11.2
* Serialization and deserialization improvements for all cmdlets

## Version 0.11.1
* Add support for Azure Machine Learning Committment Plans
    - Get-AzureRmMLCommitmentAssociation
    - Get-AzureRmMLCommitmentPlan
    - Get-AzureRmMLCommitmentPlanUsageHistory
    - Move-AzureRmMLCommitmentAssociation
    - New-AzureRmMLCommitmentPlan
    - Remove-AzureRmMLCommitmentPlan
    - Update-AzureRmMLCommitmentPlan
