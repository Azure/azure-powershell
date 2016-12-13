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

## Version 1.0.0
* Adds commandlets for the Azure IoT Hub 
    - Add-AzureRmIotHubEventHubConsumerGroup
        - Adds an Event Hub consumer group for an existing Azure IoT hub.
    - Add-AzureRmIotHubKey
        - Adds a new key to an existing Azure IoT hub.
    - Get-AzureRmIotHub
        - Gets the properties of an exisiting Azure IoT hub.
    - Get-AzureRmIotHubConnectionString
        - Gets the connection strings of an existing Azure IoT hub.
    - Get-AzureRmIotHubEventHubConsumerGroup
        - Gets the list of event hub consumer groups for the specified eventhub endpoint.
    - Get-AzureRmIotHubJob
        - Gets the properties of a set of Azure IoT hubs in a subscription or resource group.
    - Get-AzureRmIotHubKey
        - Gets the information related to a list of keys of an Azure IoT hub.
    - Get-AzureRmIotHubQuotaMetric
        - Gets the quota metrics for an Azure IoT hub.
    - Get-AzureRmIotHubRegistryStatistic
        - Gets the registry statistics for an Azure IoT hub.
    - Get-AzureRmIotHubValidSku
        - Gets the list of valid Skus to which an existing Azure IoT hub can transition to.
    - New-AzureRmIotHub
        - Creates a new Azure IoT hub.
    - New-AzureRmIotHubExportDevices
        - Starts a new job for exporting the devices of an Azure IoT hub.
    - New-AzureRmIotHubImportDevices
        - Starts a new job for importing the devices of an Azure IoT hub.
    - Remove-AzureRmIotHub
        - Removes an Azure IoT hub.
    - Remove-AzureRmIotHubEventHubConsumerGroup
        - Removes a consumer group for the specified event hub endpoint of a give Azure IoT hub.
    - Remove-AzureRmIotHubKey
        - Removes a key from an Azure IoT hub.
    - Set-AzureRmIotHub
        - Updates the properties of an Azure IoT hub.