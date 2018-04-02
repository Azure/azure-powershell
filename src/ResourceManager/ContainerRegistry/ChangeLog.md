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
