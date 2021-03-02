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

## Version 0.6.15
* This module is outdated and will go out of support on 29 February 2024.
* The Az.AnalysisServices module has all the capabilities of AzureRM.AnalysisServices and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.6.14
 * Fixed issue with default resource groups not being set.
 * Updated common runtime assemblies

## Version 0.6.13
* Fixed issue with default resource groups not being set.

## Version 0.6.12
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.6.11
* Updated help files to include full parameter types and correct input/output types.

## Version 0.6.10
* Add required property ResourceGroupName to AS.

## Version 0.6.9
* Fixed formatting of OutputType in help files

## Version 0.6.8
* Enable Gateway assocaite/disassociate operations on AS.

## Version 0.6.7
* Set minimum dependency of module to PowerShell 5.0

## Version 0.6.6
* Updated to the latest version of the Azure ClientRuntime

## Version 0.6.5
* Fix issue with Default Resource Group in CloudShell
* Fixed issue with cleaning up scripts in build

## Version 0.6.4
* Fixed issue with importing aliases
* Add support of firewall and query scaleout feature, as well as support of 2017-08-01 api version.
* Fix unique Id is null or empty bug.

## Version 0.6.3
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

## Version 0.6.2
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.6.1
* Remove validate set of location into dynamic lookup so that all clouds are supported.

## Version 0.5.0
* Fixed Synchronize-AzureAsInstance command to work with new AsAzure REST API for sync
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.4.7

## Version 0.4.6
* Added a new dataplane commandlet to allow synchronization of databases from read-write instance to read-only instances
    - Included help file for the commandlet
    - Added in-memory tests and a scenario test (only live)
* Fixed bugs in Add-AzureAsAccount commandlet

## Version 0.4.4

## Version 0.4.3
* Fixed bug in Set-AzureRmAnalysisServciesServer
    - When admin was not provided, the admin will be removed.
* Added BackupBlobContainerUri in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
    - Enable to set/disable backup blob container for backup/restore Azure Analysis Services Server
* Updated Sku lookup in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
    - Changed hard coded Sku into dynamic lookup.
* Add-AzureAnalysisServicesAccount to support login with Service Principal

## Version 0.4.2

## Version 0.4.1
* Add new dataplane API
    - Introduced API to fetch AS server log, Export-AzureAnalysisServicesInstanceLog

## Version 0.4.0
* New SKUs added: B1, B2, S0
* Scale up/down support added

## Version 0.3.1

## Version 0.3.0

## Version 0.2.0

## Version 0.1.0

## Version 0.0.4
* Added State property in additional to ProvisioningState
    - All the cmdlet returning AnalysisService would have a new property 'State' used outside of provisioing.
    - The 'State' is intended to check status outside of provisioning, while 'ProvisioningState' is intended to check status related to Provisioning.
    - ProvisioningState and State are same in service side at this moment, the service side would differenciate ProvisioningState and State in future

## Version 0.0.3
* Added two new dataplane APIs in a separate module Azure.AnalysisServices.psd1
    - This introduces two new APIs that enable customers to login to Azure Analysis Services servers and issue a restart command.

## Version 0.0.2
* Fixed bug in Get-AzureRMAnalysisServicesServer
    - When this command was run against some resources, it would fail with a null reference exception.
