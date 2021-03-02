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

## Version 0.3.13
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Relay module has all the capabilities of AzureRM.Relay and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.3.11
* Added optional Parameter -KeyValue to New-AzureRmRelayKey cmdlet, which enables user to provide KeyValue.

## Version 0.3.10
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.3.9
* Fixed issue with default resource groups not being set.

## Version 0.3.8
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.3.7
* Updated help files to include full parameter types and correct input/output types.

## Version 0.3.6
* Updated markdown files, fix for the parameter name issue in example

## Version 0.3.5
* Fixed formatting of OutputType in help files

## Version 0.3.4
* Set minimum dependency of module to PowerShell 5.0

## Version 0.3.3
* Updated to the latest version of the Azure ClientRuntime

## Version 0.3.2
* Fix issue with Default Resource Group in CloudShell

## Version 0.3.1
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

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
* Adds cmdlets for the Azure Relay which allows users to create and manage all Azure Relay resources.
    - `New-AzureRmRelayNamespace`
    - `Get-AzureRmRelayNamespace`
    - `Set-AzureRmRelayNamespace`
    - `Remove-AzureRmRelayNamespace`
    - `New-AzureRmWcfRelay`
    - `Get-AzureRmWcfRelay`
    - `Set-AzureRmWcfRelay`
    - `Remove-AzureRmWcfRelay`
    - `New-AzureRmRelayHybridConnection`
    - `Get-AzureRmRelayHybridConnection`
    - `Set-AzureRmRelayHybridConnection`
    - `Remove-AzureRmRelayHybridConnection`
    - `Test-AzureRmRelayName`
    - `Get-AzureRmRelayOperation`
    - `New-AzureRmRelayKey`
    - `Get-AzureRmRelayKey`
    - `New-AzureRmRelayAuthorizationRule`
    - `Get-AzureRmRelayAuthorizationRule`
    - `Set-AzureRmRelayAuthorizationRule`
    - `Remove-AzureRmRelayAuthorizationRule`
