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

## Version 5.2.1
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Websites module has all the capabilities of AzureRM.Websites and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.2.0
* New Cmdlet Get-AzureRMWebAppContainerContinuousDeploymentUrl - Gets the Container Continuous Deployment Webhook URL
* New Cmdlets New-AzureRMWebAppContainerPSSession and Enter-WebAppContainerPSSession  - Initiates a PowerShell remote session into a windows container app

## Version 5.1.0
* Updating to use the latest .NET SDK version (2.0.0)
* Added two new cmdlets: Get-AzureRmDeletedWebApp and Restore-AzureRmDeletedWebApp
* New-AzureRmAppServicePlan -HyperV switch is added for create app service plan with windows container
* New-AzureRmWebApp/ New-AzureRmWebAppSlot/ Set-AzureRmWebApp/ Set-AzureRmWebAppSlot - New parameters (–ContainerRegistryUser string -ContainerRegistryPassword secureString -EnableContainerContinuousDeployment) added for creating and managing windows container app

## Version 5.0.9
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.0.8
* Fixed issue with default resource group being set incorrectly.

## Version 5.0.7
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.0.6
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.0.5
* `Set-AzureRmWebApp -AssignIdentity` and  `Set-AzureRmWebAppSlot -AssignIdentity` when set to false will now remove the Identity property from the site object.Removing preview tag as well.
* `Get-AzureRmWebAppMetrics`,`Get-AzureRmAppServicePlanMetrics` example updated
* `Set-AzureRmWebApp -PhpVersion` supports off as a valid php version

## Version 5.0.4
* Fixed formatting of OutputType in help files

## Version 5.0.3
* `Set-AzureRmWebApp` is updated to not overwrite the AppSettings when using -AssignIdentity
* `New-AzureRmWebAppSlot` is updated to honor AppServicePlan as an optional parameter

## Version 5.0.2
* `New-AzureRMWebApp` is updated to use common algorithms from the Strategy library.

## Version 5.0.1
* Set minimum dependency of module to PowerShell 5.0
* Upgrade to latest version of the Websites SDK
* Added -AssignIdentity & -Httpsonly properties for Set-AzureRmWebApp and Set-AzureRmWebAppSlot
- Added two new cmdlets: Get-AzureRmWebAppSnapshots and Restore-AzureRmWebAppSnapshot

## Version 5.0.0-preview
* Upgrade to latest version of the Websites SDK
* Added -AssignIdentity & -Httpsonly properties for SetAzureWebApp

## Version 4.2.2
* Updated to the latest version of the Azure ClientRuntime

## Version 4.2.1
* Fixed the help for Remove-AzureRmWebAppSlot
* Fix issue with Default Resource Group in CloudShell
* Fixed issue with cleaning up scripts in build

## Version 4.2.0
* Fixed issue with importing aliases
* New-AzureRMWebApp - added parameter set for simplified WebApp creation, with local git repository support.

## Version 4.1.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running Websites cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
     - Affected cmdlets are New-, Remove-, Add-, and Set- for WebApps, AppServicePlan and Slots

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0
* Add PremiumV2 Tier for App Service Plans

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0
* Update help documentation for AppServicePlan cmdlets

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0
* Add: PerSiteScaling option on cmdlets New-AzureRmAppservicePlan and Set-AzureRmAppServicePlan
* Add: NumberOfWorkers option on cmdlets Set-AzureRmWebApp and Set-AzureRmWebAppSlot
* Add: Help documentation using platyPS

## Version 2.3.0
