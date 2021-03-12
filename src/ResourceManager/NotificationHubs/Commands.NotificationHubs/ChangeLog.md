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

## Version 5.0.4
Microsoft Azure PowerShell - NotificationHubs service cmdlets.

This module is outdated and will go out of support on 29 February 2024.

The Az.NotificationHubs module has all the capabilities of AzureRM.NotificationHubs and provides the following improvements:
* Az.NotificationHubs takes advantage of greater security with token cache encryption and improved authentication.
* Availability in Azure Cloud Shell and on Linux and macOS.

We encourage you to start using the Az module as soon as possible to take advantage of these improvements.

[Update your scripts](https://aka.ms/azpsmigrate) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024. To automatically update your scripts, follow the [quickstart guide](https://aka.ms/azpsmigratequick).

## Version 5.0.3
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.0.2
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.0.1
* Fixed formatting of OutputType in help files

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

## Version 4.1.1
* Updated to the latest version of the Azure ClientRuntime

## Version 4.1.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmNotificationHubsNamespace and Set-AzureRmNotificationHubsNamespace

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
* Transparent Update to NotificationHubs cmdlets for new API

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0
* Added the skuTier parameter to set the sky for namespace
    - New-AzureRmNotificationHubsNamespace
    - Set-AzureRmNotificationHubsNamespace

## Version 2.3.0
* New cmdlets
    - New-AzureRmNotificationHubKey
    - New-AzureRmNotificationHubsNamespaceKey
