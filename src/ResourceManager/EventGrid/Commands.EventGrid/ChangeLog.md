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

## Version 0.3.8
* This module is outdated and will go out of support on 29 February 2024.
* The Az.EventGrid module has all the capabilities of AzureRM.EventGrid and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.3.7
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.3.6
* Updated help files to include full parameter types and correct input/output types.

## Version 0.3.5
* Fixed formatting of OutputType in help files

## Version 0.3.4
* Remove ValidateNotNullOrEmpty validation conditions for SubjectBeginsWith/SubjectEndsWith in Update-AzureRmEventGridSubscription cmdlet to allow changing these parameters to empty string if needed.

## Version 0.3.3
* Set minimum dependency of module to PowerShell 5.0

## Version 0.3.2
* Updated to the latest version of the Azure ClientRuntime

## Version 0.3.1
* Updated to use the 2018-01-01 API version.

## Version 0.3.0
* Added the following new cmdlet:
    - Update-AzureRmEventGridSubscription
        - Update the properties of an Event Grid event subscription.
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription


## Version 0.2.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 0.1.1

## Version 0.1.0
* Added cmdlets to manage the resources in Azure Event Grid service.

    - New-AzureRmEventGridTopic
        - Creates a new Azure Event Grid Topic.
    - Get-AzureRmEventGridTopic
        - Gets the details of an Event Grid topic, or gets a list of all Event Grid topics in the current Azure subscription.
    - Set-AzureRmEventGridTopic
        - Set the properties of an Event Grid topic.
    - Remove-AzureRmEventGridTopic
        - Removes an Azure Event Grid Topic.
    - New-AzureRmEventGridTopicKey
        - Regenerates the shared access key for an Azure Event Grid Topic.
    - Get-AzureRmEventGridTopicKey
        - Gets the shared access keys used to publish events to an Event Grid topic.
    - New-AzureRmEventGridSubscription
        - Creates a new Azure Event Grid Event Subscription to a topic, Azure resource, Azure subscription or Resource Group.
    - Get-AzureRmEventGridSubscription
        - Gets the details of an event subscription, or gets a list of all event subscriptions in the current Azure subscription.
    - Remove-AzureRmEventGridSubscription
        - Removes an Azure Event Grid event subscription.
    - Get-AzureRmEventGridTopicType
        - Gets the details about the topic types supported by Azure Event Grid.
