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

## Version 0.4.9
* This module is outdated and will go out of support on 29 February 2024.
* The Az.MachineLearningCompute module has all the capabilities of AzureRM.MachineLearningCompute and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.4.8
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.4.7
* Fixed issue with default resource groups not being set.

## Version 0.4.6
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.4.5
* Updated help files to include full parameter types and correct input/output types.

## Version 0.4.4
* Fixed formatting of OutputType in help files

## Version 0.4.3
* Set minimum dependency of module to PowerShell 5.0

## Version 0.4.2
* Updated to the latest version of the Azure ClientRuntime

## Version 0.4.1
* Fix issue with Default Resource Group in CloudShell

## Version 0.4.0
* Add IncludeAllResources parameter to Remove-AzureRmMlOpCluster cmdlet
    - Using this switch parameter will remove all resources that were created with the cluster originally
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.3.1
* Add Set-AzureRmMlOpCluster
    - Update a cluster's agent count or SSL configuration
* Orchestrator properties are optional
    - The service will create a service principal if not provided, so the orchestrator
    properties are now optional

## Version 0.2.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.1.0
- Added initial set of cmdlets for MachineLearningCompute
    - Get-AzureRmMlOpCluster
    - Get-AzureRmMlOpClusterKey
    - New-AzureRmMlOpCluster
    - Remove-AzureRmMlOpCluster
    - Test-AzureRmMlOpClusterSystemServicesUpdateAvailability
    - Update-AzureRmMlOpClusterSystemService
