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

## Version 6.1.2
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Automation module has all the capabilities of AzureRM.Automation and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 6.1.0
* Swagger based Azure Automation cmdlets
* Added Update Management cmdlets
* Added Source Control cmdlets
* Added Remove-AzureRmAutomationHybridWorkerGroup cmdlet
* Fixed the DSC Register Node command

## Version 6.0.1-preview
* Fixed the DSC Register Node command

## Version 6.0.0-preview
* Swagger based Azure Automation cmdlets
* Added Update Management cmdlets
* Added Source Control cmdlets
* Added Remove-AzureRmAutomationHybridWorkerGroup  cmdlet

## Version 5.1.2
* Renamed cmdlet DLL filename to Microsoft.Azure.Commands.Automation.dll

## Version 5.1.1
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.1.0
* Fixed issue with default resource groups not being set.

## Version 5.0.4
* Updated to the latest version of the Azure ClientRuntime.
* Corrected description of example for Remove-AzureRmAutomationSchedule.

## Version 5.0.3
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.0.2
* Update help and add example for `New-AzureRMAutomationSchedule`

## Version 5.0.1
* Documentation update for New-AzureRmAutomationSchedule

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Remove deprecated `Tags` alias from cmdlets
    - `Set-AzureRmAutomationRunbook`

## Version 4.3.2
* Updated to the latest version of the Azure ClientRuntime

## Version 4.3.1
* Fix issue with Default Resource Group in CloudShell

## Version 4.3.0
* Fixed issue with importing aliases

## Version 4.2.1
* Added alias from New-AzureRmAutomationModule to Import-AzureRmAutomationModule

## Version 4.2.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Set-AzureRmAutomationRunbook

## Version 4.1.1
* Update to Import-AzureRMAutomationRunbook
    - Support is now being provided for Python2 runbooks

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0
* Fixed help documents for cmdlets fixed in the earlier release.
* Added 3 new cmdlets to support staged rollout of DSC node configurations.
	- Start-AzureRmAutomationDscNodeConfigurationDeployment
	- Stop-AzureRmAutomationDscNodeConfigurationDeployment
	- Get-AzureRmAutomationDscNodeConfigurationDeployment
	- Get-AzureRmAutomationDscNodeConfigurationDeploymentSchedule

## Version 3.3.1

## Version 3.3.0
* Made changes to AutomationDSC* cmdlets to pull more than 100 records
* Resolved the issue where the Verbose streams stop working after calling some Automation cmdlets (for example Get-AzureRmAutomationVariable, Get-AzureRmAutomationJob).
* Support for NodeConfiguration Build versioning added in StartAzureAutomationDscCompilationJob and ImportAzureAutomationDscNodeConfiguration.
* Bug fixes for existing issues - Fixes the alias issue is #3775 and the runOn alias and support for HybridWorkers.

## Version 3.2.1

## Version 3.2.0
* Properly setting TimeZone value for Weekly and Monthly schedules for New-AzureRmAutomationSchedule
    - More information can be found in this issue: https://github.com/Azure/azure-powershell/issues/3043

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
